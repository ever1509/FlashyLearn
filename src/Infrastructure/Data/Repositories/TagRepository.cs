using Application.Common.Interfaces;
using Application.Tags.Dtos;
using Application.Tags.Queries.AllTags;

namespace Infrastructure.Data.Repositories;

public class TagRepository: ITagRepository
{
    private readonly FlashyLearnContext _context;

    public TagRepository(FlashyLearnContext context)
    {
        _context = context;
    }

    public Task<List<TagDto>> GetTags(AllTags request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}