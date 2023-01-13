using System.Linq.Expressions;
using Application.Categories.Dtos;
using Application.Categories.Queries.AllCategories;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public Task<Category?> Get(Expression<Func<Category?, bool>> predicate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Category category)
    {
        throw new NotImplementedException();
    }

    public Task<List<CategoryDto>> GetCategories(AllCategories request, CancellationToken cancellationToken)
    {
        // if (request.UserId is null)
        // categories = await _context.Category.ToListAsync(cancellationToken);
        // else
        // categories = await _context.Category.Where(x => x.UserID == Guid.Parse(request.UserId))                 
        //     .ToListAsync(cancellationToken);

        // foreach (var category in categories)
        // {
        //     categoriesDto.Add(new CategoryDto
        //     {
        //         CategoryID = category.CategoryID,
        //         Name = category.Name
        //     });
        // }
        
        // return  Task.FromResult(categoriesDto
        //     .Skip((request.PageNumber -1)* request.PageSize)
        //     .Take(request.PageSize).ToList());
        throw new NotImplementedException();
    }
}