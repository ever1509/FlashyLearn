using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IFlashCardRepository
{
    Task<FlashCard?> Get(Expression<Func<FlashCard?, bool>> predicate, CancellationToken cancellationToken);
    Task CreateAsync(FlashCard flashCard);
    Task DeleteAsync(FlashCard flashCard);
    Task UpdateAsync(int id, FlashCard flashCard);
}