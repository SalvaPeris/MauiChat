using MauiChat.Infrastructure.Persistence.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MauiChat.Infrastructure
{
    public static IServiceCollection AddInfrastructureServicesRegistration(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ChatDbContext>(options =>
					options.UseMySQL(configuration.GetConnectionString("Connection")!)
				);

		return services;
	}
}
