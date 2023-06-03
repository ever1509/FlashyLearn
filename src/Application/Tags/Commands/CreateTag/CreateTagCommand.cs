using Application.Common.Interfaces;
using Application.Tags.Dtos;
using MediatR;

namespace Application.Tags.Commands.CreateTag;

public class CreateTagCommand : IRequest<TagResponseDto>
{
    public string Description { get; set; } = string.Empty;
}

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, TagResponseDto>
{
    private readonly ITagRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTagCommandHandler(ITagRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TagResponseDto> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var tagResponseDto = await _repository.CreateTag(new Tag
        {
            Description = request.Description,
        }, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return tagResponseDto;
    }
}