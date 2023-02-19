using System.Security.Claims;
namespace MauiChat.Application.Extensions
{
	public static class HttpExtensions
	{
		public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
		{
			return Guid.Parse(claimsPrincipal.Claims.Single(c => c.Type == ClaimTypes.Sid).Value);
		}
	}
}
