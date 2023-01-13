using System.Linq.Expressions;
using Application.FlashCards.Dtos;
using Application.FlashCards.Queries.RunFlashCards;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IFlashCardRepository
{
    Task<FlashCard?> Get(Expression<Func<FlashCard?, bool>> predicate, CancellationToken cancellationToken);
    Task CreateAsync(FlashCard flashCard);
    Task DeleteAsync(FlashCard flashCard);
    Task UpdateAsync(int id, FlashCard flashCard);
    Task<List<FlashCardDto>> RunFlashCards(RunFlashCards request, CancellationToken cancellationToken);
}