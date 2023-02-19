using Microsoft.EntityFrameworkCore;

namespace MauiChat.Infrastructure.Persistence
{
	public class ChatDbContext : IdentityDbContext<User>
	{
		public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
		{
		}
	}
}
