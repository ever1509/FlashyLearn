using Application.Categories.Dtos;
using Application.Categories.Queries.AllCategories;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Queries.CategoriesByUser;

public class CategoriesByUser : IRequest<List<CategoryDto>>
{
    public string UserId { get; set; }
}

public class CategoriesByUserHandler : IRequestHandler<CategoriesByUser, List<CategoryDto>>
{
    private readonly IFlashyLearnContext _context;

    public CategoriesByUserHandler(IFlashyLearnContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(CategoriesByUser request, CancellationToken cancellationToken)
    {
        var categoriesDto = new List<CategoryDto>();
        var categories = await _context.Category.Where(x => x.CategoryID == Guid.Parse(request.UserId))
            .ToListAsync(cancellationToken);

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