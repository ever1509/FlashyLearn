using Application.Common.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.FlashCards.Commands.UpdateFlashCard;

public class UpdateFlashCard : IRequest<string>
{
    public string Id { get; set; } = string.Empty;
    public string FrontText { get; set; } = string.Empty;
    public string BackText { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;
    public Frequency Frequency { get; set; }
}

public class UpdateFlashCardHandler : IRequestHandler<UpdateFlashCard, string>
{
    private readonly IFlashyLearnContext _context;

    public UpdateFlashCardHandler(IFlashyLearnContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(UpdateFlashCard request, CancellationToken cancellationToken)
    {
        var entity = await _context.FlashCards.FindAsync(request.Id);
        
        if (entity is null)
            throw new Exception("Invalid ID");

        entity.FrontText = request.FrontText;
        entity.BackText = request.BackText;
        entity.CategoryID = Guid.Parse(request.CategoryId);
        entity.Frequency = request.Frequency;

        await _context.SaveChangesAsync(cancellationToken);

        return entity.FlashCardID.ToString();
    }
}