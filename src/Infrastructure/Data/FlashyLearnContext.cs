using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;

public class FlashyLearnContext: DbContext, IFlashyLearnContext
{
    public FlashyLearnContext(DbContextOptions<FlashyLearnContext> options) : base(options)
    {

    }

    public DbSet<FlashCard> FlashCards => Set<FlashCard>();
    public DbSet<Category> Category => Set<Category>();
    public DbSet<Tag> Tag => Set<Tag>();
    public DbSet<FlashCardTag> FlashCardTags => Set<FlashCardTag>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}