using Application.Tags.Dtos;
using MediatR;

namespace Application.Tags.Queries.AllTags;

public class AllTags : IRequest<List<TagDto>>
{
    public string? FlashCardId { get; set; }
}

public class AllTagsHandler : IRequestHandler<AllTags, List<TagDto>>
{
    public Task<List<TagDto>> Handle(AllTags request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}