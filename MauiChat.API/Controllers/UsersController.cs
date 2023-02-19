using MauiChat.Application.Contracts;
using MauiChat.Application.DTOs.Requests.Users;
using MauiChat.Application.Extensions;
using MauiChat.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MauiChat.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class UsersController : ControllerBase
	{
		private readonly ISecurityService _securityService;
		public UsersController(ISecurityService securityService)
		{
			_securityService = securityService;
		}

		/// <summary>
		/// Endpoint used to log into the app
		/// </summary>
		/// <param name="request"></param>
		/// <returns>JWT Token</returns>
		[HttpPost("Login")]
		[AllowAnonymous]
		[ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public async Task<IActionResult> Login(UserLoginRequest request)
		{
			try
			{
				return Ok(new
				{
					AccessToken = await _securityService.LoginUserWithEmail(request.Email!, request.Password!)
				});
			}
			catch (UnauthorizedAccessException)
			{
				return Forbid();
			}
		}

		/// <summary>
		/// Endpoint to get current user profile
		/// </summary>
		/// <returns></returns>
		[HttpGet("Me")]
		[ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
		public IActionResult GetMe()
		{
			//var user = await _securityService.GetUserAsync(User.GetUserId());
			return Ok("Hello, you are authenticated!");
		}
	}
}
