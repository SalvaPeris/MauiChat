using Microsoft.AspNetCore.Identity;

namespace MauiChat.Domain.Entities
{
	public class Role : IdentityRole<Guid>
	{
		public string? Description { get; set; }

		public bool IsActive { get; set; } = true;

		public ICollection<User> Users { get; set; }
	}
}
