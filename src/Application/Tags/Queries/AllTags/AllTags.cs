using Application.Common.Interfaces;
using Application.Tags.Dtos;
using MediatR;

namespace Application.Tags.Queries.AllTags;

public class AllTags : IRequest<List<TagDto>>
{
    public string? FlashCardId { get; set; }
}

public class AllTagsHandler : IRequestHandler<AllTags, List<TagDto>>
{
    private readonly ITagRepository _tagRepository;

    public AllTagsHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<List<TagDto>> Handle(AllTags request, CancellationToken cancellationToken)
    {
        return await _tagRepository.GetTags(request, cancellationToken);
    }
}