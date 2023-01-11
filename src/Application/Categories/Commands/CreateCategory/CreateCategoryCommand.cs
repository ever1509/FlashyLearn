using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}

public class CreateCategoryCommandHandler: IRequestHandler<CreateCategoryCommand, Unit>
{
    private readonly IFlashyLearnContext _context;
    public CreateCategoryCommandHandler(IFlashyLearnContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var newCategory = new Category()
        {
            CategoryID = Guid.NewGuid(),
            Name = request.Name,
            UserID = Guid.Parse(request.UserId)
        };
        _context.Category.Add(newCategory);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
