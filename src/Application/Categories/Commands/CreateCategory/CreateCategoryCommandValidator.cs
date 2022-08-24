using FluentValidation;

namespace Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("You have to introduce a category name");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("You must to introduce an Id for User");
        RuleFor(x => x.Name).MaximumLength(50);
    }
}