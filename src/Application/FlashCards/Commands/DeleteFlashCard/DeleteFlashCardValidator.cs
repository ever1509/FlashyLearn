using FluentValidation;

namespace Application.FlashCards.Commands.DeleteFlashCard;

public class DeleteFlashCardValidator: AbstractValidator<DeleteFlashCard>
{
    public DeleteFlashCardValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}