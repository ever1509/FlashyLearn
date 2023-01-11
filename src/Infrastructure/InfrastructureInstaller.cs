using Application.Common.Interfaces;
using Domain.Enums;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureInstaller
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, DatabaseEnum databaseToUse)
    {
        switch (databaseToUse)
        {
            case DatabaseEnum.SQLServer:
                // services.AddDbContext<FlashyLearnContext>(options =>
                //                  options.UseSqlServer(configuration.GetConnectionString("FlashyConnSQLServer"),
                //                      builder => builder.MigrationsAssembly(typeof(FlashyLearnContext).Assembly.FullName)));
                // services.AddScoped<IFlashyLearnContext>(provider => provider.GetRequiredService<FlashyLearnContext>());
                break;
            case DatabaseEnum.PostgresSQL:
                services.AddDbContextFactory<FlashyLearnContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("FlashyConnPostgresSQL"),
                b => b.MigrationsAssembly(typeof(FlashyLearnContext).Assembly.FullName)));

                services.AddDbContext<FlashyLearnContext>(options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString("FlashyConnPostgresSQL"),
                        b => b.MigrationsAssembly(typeof(FlashyLearnContext).Assembly.FullName)));
                services.AddScoped<IFlashyLearnContext>(
                    sp => sp.GetRequiredService<IDbContextFactory<FlashyLearnContext>>()
                        .CreateDbContext());
                break;
        }



        return services;
    }
}