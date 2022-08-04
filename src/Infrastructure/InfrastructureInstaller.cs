using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureInstaller
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<FlashyLearnContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("FlashyConnection"),
                b => b.MigrationsAssembly(typeof(FlashyLearnContext).Assembly.FullName)));

        services.AddDbContext<FlashyLearnContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("FlashyConnection"),
                b => b.MigrationsAssembly(typeof(FlashyLearnContext).Assembly.FullName)));


        //services.AddScoped<IFluent>(provider => provider.GetRequiredService<FlashyLearnContext>());

        services.AddScoped<FlashyLearnContext>(
            sp => sp.GetRequiredService<IDbContextFactory<FlashyLearnContext>>()
                .CreateDbContext());

        return services;
    }
}