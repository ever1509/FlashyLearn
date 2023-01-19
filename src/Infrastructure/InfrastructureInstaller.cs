using Application.Common.Interfaces;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Data.PostgresSQL.Factories;
using Infrastructure.Data.Repositories;
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
                configuration.GetConnectionString("FlashyConnPostgresSQL"),
                b => b.MigrationsAssembly(typeof(FlashyLearnContext).Assembly.FullName)));

        services.AddDbContext<FlashyLearnContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("FlashyConnPostgresSQL"),
                b => b.MigrationsAssembly(typeof(FlashyLearnContext).Assembly.FullName)));
        services.AddScoped<IUnitOfWork>(
            sp => sp.GetRequiredService<IDbContextFactory<FlashyLearnContext>>()
                .CreateDbContext());

        services.AddScoped<IConnectionFactory, ConnectionFactory>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IFlashCardRepository, FlashCardRepository>();
        return services;
    }
}