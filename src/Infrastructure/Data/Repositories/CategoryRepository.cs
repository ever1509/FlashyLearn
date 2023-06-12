using System.Linq.Expressions;
using Application.Categories.Dtos;
using Application.Categories.Queries.AllCategories;
using Application.Common.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly FlashyLearnContext _context;
    public CategoryRepository(FlashyLearnContext context) => _context = context;

    public async Task<Category?> Get(Expression<Func<Category?, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<Category>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<Category> Create(Category category, CancellationToken cancellationToken)
    {
        await _context.AddAsync(category);
        await _context.SaveChangesAsync(cancellationToken);
        return category;
    }

    public void Delete(Category category) => _context.Remove(category);

    public async Task UpdateAsync(Guid id, Category category, CancellationToken cancellationToken)
    {
        var entity = await Get(x => x.CategoryID == id, cancellationToken);

        if (entity is null)
            throw new Exception($"Category not found with id {id}");

        entity.Name = category.Name;
        entity.UserID = category.UserID;
    }

    public async Task<List<CategoryDto>> GetCategories(AllCategories request, CancellationToken cancellationToken)
    {
        var categoryDtoList = new List<CategoryDto>();
        if (request.UserId is null)
            categoryDtoList = (await _context.Database.GetDbConnection().QueryAsync<CategoryDto>(@$"SELECT ""CategoryID"", ""Name"" FROM ""Category""")).ToList();
        else
            categoryDtoList = (await _context.Database.GetDbConnection().QueryAsync<CategoryDto>(@$"SELECT ""CategoryID"", ""Name"" FROM ""Category"" WHERE ""UserId""=@UserID", new {UserID = request.UserId})).ToList();

        return await Task.FromResult(categoryDtoList
            .Skip((request.PageNumber -1)* request.PageSize)
            .Take(request.PageSize).ToList());
        
    }
}