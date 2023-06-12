using System.Linq.Expressions;
using Application.Categories.Dtos;
using Application.Categories.Queries.AllCategories;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> Get(Expression<Func<Category?, bool>> predicate, CancellationToken cancellationToken);
    Task<Category> Create(Category category, CancellationToken cancellationToken);
    void Delete(Category category);
    Task UpdateAsync(Guid id, Category category, CancellationToken cancellationToken);
    Task<List<CategoryDto>> GetCategories(AllCategories request, CancellationToken cancellationToken);
}