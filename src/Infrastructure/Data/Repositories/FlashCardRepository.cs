using System.Linq.Expressions;
using Application.Common.Interfaces;
using Application.FlashCards.Dtos;
using Application.FlashCards.Queries.RunFlashCards;
using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class FlashCardRepository : IFlashCardRepository
{
    private readonly FlashyLearnContext _context;

    public FlashCardRepository(FlashyLearnContext context) =>  _context = context;

    public async Task<FlashCard?> Get(Expression<Func<FlashCard?, bool>> predicate, CancellationToken cancellationToken) =>
        await _context.Set<FlashCard>().FirstOrDefaultAsync(predicate, cancellationToken);
    public async Task CreateAsync(FlashCard flashCard) => await _context.Set<FlashCard>().AddAsync(flashCard);
    public void Delete(FlashCard flashCard) => _context.Remove(flashCard);

    public async Task UpdateAsync(Guid id, FlashCard flashCard, CancellationToken cancellationToken)
    {
        var entity = await Get(x => x.FlashCardID == id, cancellationToken);
        if (entity is null)
            throw new Exception($"Not found flashcard with id {id}");

        entity.FrontText = flashCard.FrontText;
        entity.BackText = flashCard.BackText;
        entity.CategoryID = flashCard.CategoryID;
        entity.Frequency = flashCard.Frequency;
        //entity.Update(flashCard.FrontText, flashCard.FrontText, flashCard.CategoryID, flashCard.Frequency);
    }

    public async Task<List<FlashCardDto>> RunFlashCards(RunFlashCards request, CancellationToken cancellationToken)
    {
        var flashCards = (await _context.Database.GetDbConnection()
            .QueryAsync<FlashCard>(@$"SELECT * FROM ""FlashCards"" where ""Frequency""=@frequency", new { frequency = request.Frequency})).ToList();

        var flashCardsDto = flashCards
            .Select(flashCard => new FlashCardDto {FrontText = flashCard.FrontText, BackText = flashCard.BackText, CategoryId = flashCard.CategoryID.ToString()}).ToList();

        return await Task.FromResult(flashCardsDto);
    }
}