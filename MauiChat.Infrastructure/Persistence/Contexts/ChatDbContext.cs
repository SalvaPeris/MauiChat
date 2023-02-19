using MauiChat.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MauiChat.Infrastructure.Persistence.Contexts
{
    public class ChatDbContext : IdentityDbContext<User, Role, Guid>
    {
		public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
			if (options is null) throw new ArgumentNullException(nameof(options));
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<User>()
				.HasMany(u => u.Roles)
				.WithMany(r => r.Users)
				.UsingEntity<IdentityUserRole<Guid>>(
				j => j
						.HasOne<User>()
						.WithMany()
						.HasForeignKey("UserId")
						.HasConstraintName("FK_UserRoles_AspNetUsers_UserId")
						.OnDelete(DeleteBehavior.Cascade)
				);

			var roles = SeedRoles(builder);
			var users = SeedUsers(builder);
			SeedUserRoles(builder);
		}

		private ICollection<Role> SeedRoles(ModelBuilder builder)
		{
			var roles = new List<Role>()
			{
				new Role
				{
					Id = Guid.Parse(Domain.Constants.Roles.AdminProGuid),
					ConcurrencyStamp = Domain.Constants.Roles.AdminProGuid,
					Name = Domain.Constants.Roles.AdminPro,
					NormalizedName = Domain.Constants.Roles.AdminPro.ToUpper(),
					Description = Domain.Constants.Roles.AdminProDescription
				},
				new Role
				{
					Id = Guid.Parse(Domain.Constants.Roles.AdminGuid),
					ConcurrencyStamp = Domain.Constants.Roles.AdminGuid,
					Name = Domain.Constants.Roles.Admin,
					NormalizedName = Domain.Constants.Roles.Admin.ToUpper(),
					Description = Domain.Constants.Roles.AdminDescription
				},
				new Role
				{
					Id = Guid.Parse(Domain.Constants.Roles.UserGuid),
					ConcurrencyStamp = Domain.Constants.Roles.UserGuid,
					Name = Domain.Constants.Roles.User,
					NormalizedName = Domain.Constants.Roles.User.ToUpper(),
					Description = Domain.Constants.Roles.UserDescription
				}
			};

			builder.Entity<Role>().HasData(roles);

			return roles;
		}

		private ICollection<User> SeedUsers(ModelBuilder builder)
		{
			var hasher = new PasswordHasher<User>();

			var users = new List<User>()
			{
				new User
				{
					Id = Guid.Parse("840411eb-2f77-4444-8f29-76c094834b56"),
					SecurityStamp = "840411eb-2f77-4444-8f29-76c094834b56",
					ConcurrencyStamp = "840411eb-2f77-4444-8f29-76c094834b56",
					UserName = "admin",
					FirstName = "Test",
					LastName = "Admin",
					Email = "test@admin.com",
					NormalizedEmail = "TEST@ADMIN.COM",
					EmailConfirmed = true,
					IsActive = true,
					NormalizedUserName = "TESTADMIN",
					PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd")
				},
				new User
				{
					Id = Guid.Parse("004286d4-a835-45c7-8f36-1f9359d7d955"),
					SecurityStamp = "004286d4-a835-45c7-8f36-1f9359d7d955",
					ConcurrencyStamp = "004286d4-a835-45c7-8f36-1f9359d7d955",
					UserName = "user",
					FirstName = "Test",
					LastName = "User",
					Email = "test@user.com",
					NormalizedEmail = "TEST@USER.COM",
					EmailConfirmed = true,
					IsActive = true,
					NormalizedUserName = "TESTUSER",
					PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd")
				}
			};

			builder.Entity<User>().HasData(users);

			return users;
		}

		private void SeedUserRoles(ModelBuilder builder)
		{
			builder.Entity<IdentityUserRole<Guid>>().HasData(
				new IdentityUserRole<Guid>
				{
					RoleId = Guid.Parse("caddad05-120f-48a8-b659-ff4528e5df97"),
					UserId = Guid.Parse("840411eb-2f77-4444-8f29-76c094834b56")
				},
				new IdentityUserRole<Guid>
				{
					RoleId = Guid.Parse("33dde250-ddde-42db-a4b9-5a2355082391"),
					UserId = Guid.Parse("004286d4-a835-45c7-8f36-1f9359d7d955")
				}
			);
		}
	}
}
