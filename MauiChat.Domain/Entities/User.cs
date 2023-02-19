using MauiChat.Domain.Base;
using Microsoft.AspNetCore.Identity;

namespace MauiChat.Domain.Entities
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; } = default!;
		public string LastName { get; set; } = default!;
		public string Username { get; set; } = default!;
	}
}
