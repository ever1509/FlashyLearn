using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.FlashCards.Commands.CreateFlashCard;

public class CreateFlashCardCommand : IRequest<string>
{
    public string FrontText { get; set; }
    public string BackText { get; set; }
    public string CategoryID { get; set; }
}

public class CreateFlashCardCommandHandler : IRequestHandler<CreateFlashCardCommand, string>
{
    private readonly IFlashyLearnContext _context;

    public CreateFlashCardCommandHandler(IFlashyLearnContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(CreateFlashCardCommand request, CancellationToken cancellationToken)
    {
        var newFlashCard = new FlashCard()
        {
            BackText = request.BackText,
            FrontText = request.FrontText,
            CategoryID = Guid.Parse(request.CategoryID),
            CreatedDate = DateTime.Now
        };

        _context.FlashCards.Add(newFlashCard);

        await _context.SaveChangesAsync(cancellationToken);

        return newFlashCard.FlashCardID.ToString();

    }
}