using Application.Tags.Dtos;
using Application.Tags.Queries.AllTags;

namespace Application.Common.Interfaces;

public interface ITagRepository
{
    Task<List<TagDto>> GetTags(AllTags request, CancellationToken cancellationToken);
}