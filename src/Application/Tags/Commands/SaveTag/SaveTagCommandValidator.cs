using FluentValidation;

namespace Application.Tags.Commands.SaveTag;

public class SaveTagCommandValidator : AbstractValidator<SaveTagCommand>
{
    public SaveTagCommandValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
    }
}