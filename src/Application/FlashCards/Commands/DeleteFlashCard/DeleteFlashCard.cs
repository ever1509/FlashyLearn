using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.FlashCards.Commands.DeleteFlashCard;

public class DeleteFlashCard : IRequest<Unit>
{
    public string Id { get; set; }
}

public class DeleteFlashCardHandler : IRequestHandler<DeleteFlashCard, Unit>
{
    private readonly IFlashyLearnContext _context;

    public DeleteFlashCardHandler(IFlashyLearnContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteFlashCard request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id);
        
        var entity = await _context.FlashCards.FirstOrDefaultAsync(x => x.FlashCardID == id, cancellationToken: cancellationToken);
        if (entity is null)
            throw new Exception("Invalid ID");

        _context.FlashCards.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}