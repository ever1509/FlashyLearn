using System.Linq.Expressions;
using Application.Common.Interfaces;
using Application.Tags.Commands.SaveTag;
using Application.Tags.Dtos;
using Application.Tags.Queries.AllTags;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class TagRepository: ITagRepository
{
    private readonly FlashyLearnContext _context;

    public TagRepository(FlashyLearnContext context)
    {
        _context = context;
    }
    
    public async Task<Tag?> Get(Expression<Func<Tag?, bool>> predicate, CancellationToken cancellationToken) =>
        await _context.Set<Tag>().FirstOrDefaultAsync(predicate, cancellationToken);

    public async Task<List<TagDto>> GetTags(AllTags request, CancellationToken cancellationToken)
    {
        var tagDtoList = new List<TagDto>();
        if (request.FlashCardId is not null)
        {
            tagDtoList = (await _context.Database.GetDbConnection()
                .QueryAsync<TagDto>(@$"SELECT ""TagId"", ""Name"" FROM ""Tag"" WHERE ""FlashCardId""=@flashCardId", 
                    new { flashCardId = request.FlashCardId })).ToList();
        }
        else
        {
            tagDtoList = (await _context.Database.GetDbConnection()
                .QueryAsync<TagDto>(@$"SELECT ""TagId"", ""Name"" FROM ""Tag""")).ToList();
        }

        return tagDtoList;
    }

    public async Task<TagResponseDto> CreateTag(Tag entity, CancellationToken cancellationToken)
    {
        await _context.AddAsync(entity, cancellationToken);

        return new TagResponseDto
        {
            TagId = entity.TagID,
            Description = entity.Description
        };
    }

    public async Task UpdateAsync(Guid tagId, SaveTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await Get(x => x.TagID == tagId, cancellationToken);
        if (tag is null)
            throw new Exception("Invalid Tag Id");
        tag.Description = request.Description;
        await _context.SaveChangesAsync(cancellationToken);
    }
}