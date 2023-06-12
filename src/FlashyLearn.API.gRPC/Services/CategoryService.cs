using Application.Categories.Queries.AllCategories;
using Grpc.Core;
using MediatR;

namespace FlashyLearn.API.gRPC.Services;

public class CategoryService : Category.CategoryBase
{
    private readonly IMediator _mediator;

    public CategoryService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async  Task<GetAllCategoriesResponse> GetAllCategories(GetAllCategoriesRequest request, ServerCallContext context)
    {
        var categoryDtoList = await _mediator.Send(new AllCategories());

        var response = new GetAllCategoriesResponse();
        foreach (var categoryDto in categoryDtoList)
        {
            response.Categories.Add(new CategoryResponse()
            {
                CategoryId = categoryDto.CategoryID.ToString(),
                Name = categoryDto.Name
            });
        }
        return response;
    }
}