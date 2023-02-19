using MauiChat.Application.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MauiChat.Application.DTOs.Requests.Users
{
	public class UserLoginRequest
	{
		[Required]
		[EmailAddress]
		public string? Email { get; set; }

		[Required]
		[Password]
		public string? Password { get; set; }
	}
}
