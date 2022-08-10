using FluentValidation;

namespace Application.FlashCards.Commands.CreateFlashCard;

public class CreateFlashCardCommandValidator: AbstractValidator<CreateFlashCardCommand>
{
    public CreateFlashCardCommandValidator()
    {
        RuleFor(x => x.BackText).NotEmpty();
        RuleFor(x => x.FrontText).NotEmpty();
        RuleFor(x => x.CategoryID).NotEmpty();

    }
}