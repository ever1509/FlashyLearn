using FluentValidation;

namespace Application.FlashCards.Commands.UpdateFlashCard;

public class UpdateFlashCardValidator: AbstractValidator<UpdateFlashCard>
{
    public UpdateFlashCardValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.BackText).NotEmpty();
        RuleFor(x => x.FrontText).NotEmpty();
        RuleFor(x => x.CategoryId).NotEmpty();
    }
}