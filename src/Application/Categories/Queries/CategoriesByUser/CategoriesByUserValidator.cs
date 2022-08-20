using FluentValidation;

namespace Application.Categories.Queries.CategoriesByUser;

public class CategoriesByUserValidator: AbstractValidator<CategoriesByUser>
{
    public CategoriesByUserValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}