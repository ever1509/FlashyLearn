using System.Linq.Expressions;
using Application.Common.Interfaces;
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
    public Task DeleteAsync(FlashCard flashCard)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, FlashCard flashCard)
    {
        throw new NotImplementedException();
    }
}