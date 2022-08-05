using FluentValidation;

namespace Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("You have to introduce a category name");
        RuleFor(x => x.Name).MaximumLength(50);
    }
}