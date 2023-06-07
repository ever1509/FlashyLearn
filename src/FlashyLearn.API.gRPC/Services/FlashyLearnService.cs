using Grpc.Core;

namespace FlashyLearn.API.gRPC.Services;

public class FlashyLearnService : FlashyLearn.FlashyLearnBase
{
    public override Task<HelloResponse> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloResponse
        {
            Message = $"Hello {request.Name}"
        });
    }
}