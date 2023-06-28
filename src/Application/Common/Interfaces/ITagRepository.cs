using Application.Tags.Commands.SaveTag;
using Application.Tags.Dtos;
using Application.Tags.Queries.AllTags;

namespace Application.Common.Interfaces;

public interface ITagRepository
{
    Task<List<TagDto>> GetTags(AllTags request, CancellationToken cancellationToken);

    Task<TagResponseDto> CreateTag(Tag entity, CancellationToken cancellationToken);
    Task UpdateAsync(Guid tagId, SaveTagCommand request, CancellationToken cancellationToken);
}