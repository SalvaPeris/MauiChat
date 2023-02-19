using MauiChat.Domain.Entities;

namespace MauiChat.Application.Contracts
{
	public interface ISecurityService
	{
		Task<string> LoginUserWithEmail(string email, string password);
		Task<User?> GetUserAsync(string id);
		Task<User?> GetUserAsync(Guid id);
	}
}
