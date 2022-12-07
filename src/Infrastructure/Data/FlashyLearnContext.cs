using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class FlashyLearnContext: DbContext, IFlashyLearnContext
{
    public FlashyLearnContext(DbContextOptions<FlashyLearnContext> options) : base(options)
    {

    }

    public DbSet<FlashCard> FlashCards { get; }
    public DbSet<Category> Category { get; }
    public DbSet<Tag> Tag { get; }
    public DbSet<FlashCardTag> FlashCardTags { get; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(FlashyLearnContext).Assembly);
        base.OnModelCreating(builder);
    }
}