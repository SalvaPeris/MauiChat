using MauiChat.Application.Contracts;
using MauiChat.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MauiChat.Infrastructure.Persistence.Services
{
	public class SecurityService : ISecurityService
	{
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<Role> _roleManager;
		private readonly IConfiguration _configuration;
		
		public SecurityService(
			UserManager<User> userManager,
			RoleManager<Role> roleManager,
			IConfiguration configuration
			)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_configuration = configuration;
		}

		public async Task<string> LoginUserWithEmail(string email, string password)
		{
			var user = await _userManager.FindByEmailAsync(email);

			if (user is null || !user.IsActive || !await _userManager.CheckPasswordAsync(user, password))
				throw new UnauthorizedAccessException();

			var roles = await _userManager.GetRolesAsync(user);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Sid, user.Id.ToString()),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
				new Claim(ClaimTypes.Role, roles.Single())
			};

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
			var tokenDescriptor = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(720),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
		}

		public async Task<User?> GetUserAsync(string id)
		{
			return await _userManager.Users
				.Include(u => u.Roles)
				.SingleOrDefaultAsync(u => u.Id.ToString() == id);
		}

		public async Task<User?> GetUserAsync(Guid id) => await GetUserAsync(id.ToString());
	}
}
