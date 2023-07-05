using HotChocolate;
using HotChocolate.Execution;
using Infrastructure.GraphQL;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;

namespace FlashyLearn.API.GraphQL.Tests;

public class GraphqlTests
{
    [Fact]
    public async Task SchemaChangeTest()
    {
        var schema = await new ServiceCollection()
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddFiltering()
            .BuildSchemaAsync();
        
        schema.ToString().MatchSnapshot();
    }

    [Fact]
    public async Task FetchAllCategories()
    {
        var result = await new ServiceCollection()
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddFiltering()
            .ExecuteRequestAsync(@"  allCategories {
                                                categoryID,
                                                name,
                                                userID
                                            }");
        result.ToJson().MatchSnapshot();
    }
}