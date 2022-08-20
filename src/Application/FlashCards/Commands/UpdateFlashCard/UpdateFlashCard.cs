using Application.Common.Interfaces;
using MediatR;

namespace Application.FlashCards.Commands.UpdateFlashCard;

public class UpdateFlashCard : IRequest<string>
{
    public string Id { get; set; }
    public string FrontText { get; set; }
    public string BackText { get; set; }
    public string CategoryId { get; set; }
    public string FrequencyId { get; set; }
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
        entity.FrequencyID = Guid.Parse(request.FrequencyId);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.FlashCardID.ToString();
    }
}