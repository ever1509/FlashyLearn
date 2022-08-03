using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class FlashyLearnContext: DbContext, IFlashyLearnContext
{
    public DbSet<FlashCard> FlashCards { get; }
    public DbSet<Category> Category { get; }
    public DbSet<Frequency> Frequencies { get; }
    public DbSet<Tag> Tag { get; }
    public DbSet<FlashCardTag> FlashCardTags { get; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}