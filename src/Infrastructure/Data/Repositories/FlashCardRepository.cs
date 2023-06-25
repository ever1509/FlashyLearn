using System.Linq.Expressions;
using Application.Common.Interfaces;
using Application.FlashCards.Commands.SaveFlashCard;
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

    public async Task CreateAsync(FlashCard flashCard, CancellationToken cancellationToken)
    {
        await _context.AddAsync(flashCard, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(FlashCard flashCard, CancellationToken cancellationToken)
    {
        _context.Remove(flashCard);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid id, SaveFlashCardCommand command, CancellationToken cancellationToken)
    {
        var flashCard = await Get(x => x.FlashCardID == id, cancellationToken);
        if (flashCard is null)
            throw new Exception("Invalid Flashcard Id");
        flashCard.FrontText = command.FrontText;
        flashCard.BackText = command.BackText;
        flashCard.Frequency = command.Frequency;
        flashCard.CategoryID = Guid.Parse(command.CategoryID);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<FlashCardDto>> RunFlashCards(RunFlashCards request, CancellationToken cancellationToken)
    {
        var flashCardDtoList = (await _context.Database.GetDbConnection()
            .QueryAsync<FlashCardDto>(@$"
                            SELECT ""FlashCardID""
                            ,""FrontText""
                            ,""BackText""
                            ,""Frequency""
                            ,""CategoryID"" FROM 
                           ""FlashCard""")).ToList();
        
        return await Task.FromResult(flashCardDtoList);
    }
}