using Application.Common.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureInstaller
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FlashyLearnContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                     builder => builder.MigrationsAssembly(typeof(FlashyLearnContext).Assembly.FullName)));

        services.AddScoped<IFlashyLearnContext>(provider => provider.GetRequiredService<FlashyLearnContext>());

        return services;
    }
}