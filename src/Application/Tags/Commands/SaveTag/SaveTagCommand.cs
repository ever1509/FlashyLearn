using Application.Common.Interfaces;
using Application.Tags.Dtos;
using MediatR;

namespace Application.Tags.Commands.SaveTag;

public class SaveTagCommand : IRequest<TagResponseDto>
{
    public string Description { get; set; } = string.Empty;
    public string? TagID { get; set; } = string.Empty;
}

public class SaveTagCommandHandler : IRequestHandler<SaveTagCommand, TagResponseDto>
{
    private readonly ITagRepository _repository;

    public SaveTagCommandHandler(ITagRepository repository)
    {
        _repository = repository;
    }

    public async Task<TagResponseDto> Handle(SaveTagCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.TagID))
        {
            return await _repository.CreateTag(new Tag
            {
                Description = request.Description,
            }, cancellationToken);   
        }
        
        if (!Guid.TryParse(request.TagID, out var tagId)) throw new Exception("Invalid tagId");
        
        await _repository.UpdateAsync(tagId, request, cancellationToken);
        return new TagResponseDto
        {
            TagId = tagId,
            Description = request.Description
        };
    }
}