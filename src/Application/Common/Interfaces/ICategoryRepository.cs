using System.Linq.Expressions;
using Application.Categories.Dtos;
using Application.Categories.Queries.AllCategories;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> Get(Expression<Func<Category?, bool>> predicate, CancellationToken cancellationToken);
    void Create(Category category);
    void Delete(Category category);
    Task UpdateAsync(int id, Category category);
    Task<List<CategoryDto>> GetCategories(AllCategories request, CancellationToken cancellationToken);
}