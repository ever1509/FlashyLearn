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

    public void Create(Category category) => Category.Create(category.Id, category.Name, category.UserId);

    public void Delete(Category category) => _context.Remove(category);

    public async Task UpdateAsync(Guid id, Category category, CancellationToken cancellationToken)
    {
        var entity = await Get(x => x.Id == id, cancellationToken);

        if (entity is null)
            throw new Exception($"Category not found with id {id}");
        
        entity.Update(category.Name, category.UserId);
    }

    public async Task<List<CategoryDto>> GetCategories(AllCategories request, CancellationToken cancellationToken)
    {
        var categories = new List<Category>();
        if (request.UserId is null)
            categories = (await _context.Database.GetDbConnection().QueryAsync<Category>(@$"SELECT * FROM ""Category""")).ToList();
        else
            categories = (await _context.Database.GetDbConnection().QueryAsync<Category>(@$"SELECT * FROM ""Category"" WHERE ""UserId""=@UserID", new {UserID = request.UserId})).ToList();

        var categoriesDto = categories.Select(category => new CategoryDto {CategoryID = category.Id, Name = category.Name}).ToList();

        return await Task.FromResult(categoriesDto
            .Skip((request.PageNumber -1)* request.PageSize)
            .Take(request.PageSize).ToList());
        
    }
}