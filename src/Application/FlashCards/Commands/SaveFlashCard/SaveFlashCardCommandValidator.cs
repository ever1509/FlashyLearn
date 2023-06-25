using FluentValidation;

namespace Application.FlashCards.Commands.SaveFlashCard;

public class CreateFlashCardCommandValidator: AbstractValidator<SaveFlashCardCommand>
{
    public CreateFlashCardCommandValidator()
    {
        RuleFor(x => x.BackText).NotEmpty();
        RuleFor(x => x.FrontText).NotEmpty();
        RuleFor(x => x.CategoryID).NotEmpty();

    }
}