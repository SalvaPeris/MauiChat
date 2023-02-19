namespace MauiChat.Application.Contracts
{
	public interface ISecurityService
	{
		Task<string> LoginUserWithEmail(string email, string password);
	}
}
