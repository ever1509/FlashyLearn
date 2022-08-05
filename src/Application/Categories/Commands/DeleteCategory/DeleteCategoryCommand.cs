using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand: IRequest<Unit>
{
    public string Id { get; set; }
}

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly IFlashyLearnContext _context;
    public DeleteCategoryCommandHandler(IFlashyLearnContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id);
        var entity = await _context.Category.FirstOrDefaultAsync(x => x.CategoryID == id, cancellationToken: cancellationToken);
        if (entity is null)
            throw new Exception("Invalid ID");

        _context.Category.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}