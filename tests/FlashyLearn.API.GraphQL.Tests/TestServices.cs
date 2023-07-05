using HotChocolate;
using HotChocolate.Execution;
using Infrastructure.GraphQL;
using Microsoft.Extensions.DependencyInjection;

namespace FlashyLearn.API.GraphQL.Tests;

public static class TestServices
{
    static TestServices()
    {
        Services = new ServiceCollection()
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddFiltering()
            .Services
            .AddSingleton(sp => new RequestExecutorProxy(
                sp.GetRequiredService<IRequestExecutorResolver>(),
                Schema.DefaultName))
            .BuildServiceProvider();

        Executor = Services.GetRequiredService<RequestExecutorProxy>();
    }

    public static IServiceProvider Services { get; }
    public static RequestExecutorProxy Executor { get; }

    public static async Task<string> ExecuteRequestAsync(Action<IQueryRequestBuilder> configureRequest, CancellationToken cancellationToken = default)
    {
        await using var scope = Services.CreateAsyncScope();
        var requestBuilder = new QueryRequestBuilder();
        requestBuilder.SetServices(scope.ServiceProvider);

        configureRequest(requestBuilder);
        IQueryRequest request = requestBuilder.Create();

        await using var result = await Executor.ExecuteAsync(request, cancellationToken);

        result.ExpectQueryResult();

        return result.ToJson();
    }
}