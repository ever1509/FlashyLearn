using Application.Common.Interfaces;
using Application.Tags.Dtos;
using MediatR;

namespace Application.Tags.Commands.DeleteTag;

public class DeleteTagCommand : IRequest<TagResponseDto>
{
    public string TagId { get; set; } = string.Empty;
}

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, TagResponseDto>
{
    private readonly ITagRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTagCommandHandler(ITagRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public Task<TagResponseDto> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}