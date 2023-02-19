using MauiChat.Domain.Base;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MauiChat.Domain.Entities
{
	public class User : IdentityUser<Guid>
	{
		public string FirstName { get; set; } = default!;

		public string LastName { get; set; } = default!;

		public string Username { get; set; } = default!;

		public DateTime? EntryDate { get; set; }

		public DateTime? LeavingDate { get; set; }
		public bool IsActive { get; set; }

		[StringLength(10)]
		public string? Pin { get; set; }

		public Role? Role => this.Roles?.SingleOrDefault();

		public ICollection<Role>? Roles { get; set; }
	}
}
