using Application.Common.Interfaces;
using Application.Tags.Dtos;
using MediatR;

namespace Application.Tags.Commands.UpdateTag;

public class UpdateTagCommand : IRequest<TagResponseDto>
{
    public string TagId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, TagResponseDto>
{
    private readonly ITagRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTagCommandHandler(ITagRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public Task<TagResponseDto> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}