using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IFlashyLearnContext
{
    DbSet<FlashCard> FlashCards { get;}
    DbSet<Category> Category { get;}
    DbSet<Frequency> Frequencies { get;}
    DbSet<Tag> Tag { get;}
    DbSet<FlashCardTag> FlashCardTags { get;}
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}