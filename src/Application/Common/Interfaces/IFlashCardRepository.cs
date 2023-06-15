using System.Linq.Expressions;
using Application.FlashCards.Commands.CreateFlashCard;
using Application.FlashCards.Dtos;
using Application.FlashCards.Queries.RunFlashCards;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IFlashCardRepository
{
    Task<FlashCard?> Get(Expression<Func<FlashCard?, bool>> predicate, CancellationToken cancellationToken);
    Task CreateAsync(FlashCard flashCard, CancellationToken cancellationToken);
    Task Delete(FlashCard flashCard, CancellationToken cancellationToken);
    Task UpdateAsync(Guid id, CreateFlashCardCommand command, CancellationToken cancellationToken);
    Task<List<FlashCardDto>> RunFlashCards(RunFlashCards request, CancellationToken cancellationToken);
}