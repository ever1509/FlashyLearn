using System.Data;
using System.Linq.Expressions;
using Application.Categories.Dtos;
using Application.Categories.Queries.AllCategories;
using Application.Common.Interfaces;
using Dapper;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IDbConnection _dbConnection;

    public CategoryRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

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

    public async Task<List<CategoryDto>> GetCategories(AllCategories request, CancellationToken cancellationToken)
    {
        var categories = new List<Category>();
        var categoriesDto = new List<CategoryDto>();
        if (request.UserId is null)
        {
            categories = (await _dbConnection.QueryAsync<Category>($"SELECT * FROM Categories")).ToList();
        }
        else
        {
            categories = (await _dbConnection.QueryAsync<Category>($"SELECT * FROM Categories WHERE UserId=@UserID", new {UserID = request.UserId})).ToList();
        }

        foreach (var category in categories)
        {
                categoriesDto.Add(new CategoryDto
                 {
                     CategoryID = category.Id,
                     Name = category.Name
                 });
        }
        
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
        return categoriesDto;
    }
}