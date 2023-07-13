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
        var schema = await TestServices.Executor.GetSchemaAsync(default);
        
        schema.ToString().MatchSnapshot();
    }

    [Fact]
    public async Task FetchAllCategories()
    {
        var result =await TestServices.ExecuteRequestAsync(b=> b.SetQuery( @"  allCategories {
                                                categoryID,
                                                name,
                                                userID
                                            }"));
        result.MatchSnapshot();
    }

    [Fact]
    public async Task FetchRunFlashCards()
    {
        var result =await TestServices.ExecuteRequestAsync(b=> b.SetQuery( @"  runFlashCards{
                                                categoryID,
                                                flashCardID,
                                                frontText,
                                                backText,
                                                frequency
                                              }"));
        result.MatchSnapshot();
    }
}