using System.Data;
using Application.Categories.Dtos;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Categories.Queries.AllCategories;

public class AllCategories : IRequest<List<CategoryDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string? UserId { get; set; }
}

public class AllCategoriesHandler : IRequestHandler<AllCategories, List<CategoryDto>>
{
    private readonly ICategoryRepository _repository;
    public AllCategoriesHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CategoryDto>> Handle(AllCategories request, CancellationToken cancellationToken)
    {
        return await _repository.GetCategories(request, cancellationToken);
    }
}