using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> Get(Expression<Func<Category?, bool>> predicate, CancellationToken cancellationToken);
    Task CreateAsync(Category category);
    Task DeleteAsync(Category category);
    Task UpdateAsync(int id, Category category);
}