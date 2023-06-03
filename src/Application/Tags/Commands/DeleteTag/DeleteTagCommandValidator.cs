using FluentValidation;

namespace Application.Tags.Commands.DeleteTag;

public class DeleteTagCommandValidator : AbstractValidator<DeleteTagCommand>
{
    public DeleteTagCommandValidator()
    {
        RuleFor(x => x.TagId).NotEmpty();
    }
}