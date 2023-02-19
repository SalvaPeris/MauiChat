using MauiChat.Infrastructure.Persistence.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MauiChat.Application.Contracts;
using MauiChat.Infrastructure.Persistence.Services;
using MySql.EntityFrameworkCore.Extensions;
using MauiChat.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MauiChat.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
		public static IServiceCollection AddInfrastructureServicesRegistration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMySQLServer<ChatDbContext>(configuration.GetConnectionString("Connection")!)
					.AddIdentityCore<User>()
					.AddRoles<Role>()
					.AddEntityFrameworkStores<ChatDbContext>()
					.AddDefaultTokenProviders();
			services.AddScoped<ISecurityService, SecurityService>();

			return services;
		}
	}
}
