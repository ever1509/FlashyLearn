using FluentValidation;

namespace Application.Categories.Commands.SaveCategory;

public class SaveCategoryCommandValidator : AbstractValidator<SaveCategoryCommand>
{
    public SaveCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("You have to introduce a category name");
        RuleFor(x => x.Name).MaximumLength(50);
    }
}