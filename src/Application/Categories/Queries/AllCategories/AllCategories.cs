using Application.Categories.Dtos;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Queries.AllCategories;

public class AllCategories : IRequest<List<CategoryDto>>
{
    public int Page { get; set; } = 1;
}

public class AllCategoriesHandler : IRequestHandler<AllCategories, List<CategoryDto>>
{
    private readonly IFlashyLearnContext _context;

    public AllCategoriesHandler(IFlashyLearnContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(AllCategories request, CancellationToken cancellationToken)
    {
        var categoriesDto = new List<CategoryDto>();
        var categories = await _context.Category.ToListAsync(cancellationToken);

        foreach (var category in categories)
        {
            categoriesDto.Add(new CategoryDto
            {
                CategoryID = category.CategoryID,
                Name = category.Name
            });
        }
        
        return categoriesDto;
    }
}