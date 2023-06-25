using Application.Common.Interfaces;
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
}