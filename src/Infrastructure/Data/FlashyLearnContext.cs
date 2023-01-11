using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;

public class FlashyLearnContext: DbContext, IUnitOfWork
{
    public FlashyLearnContext(DbContextOptions<FlashyLearnContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder) =>
        builder.ApplyConfigurationsFromAssembly(typeof(FlashyLearnContext).Assembly);
}