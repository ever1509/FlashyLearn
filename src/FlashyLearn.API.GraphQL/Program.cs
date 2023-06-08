using Application;
using GraphQL.Server.Ui.Voyager;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(p =>
{
    //var frontedURL = builder.Configuration.GetValue<string>("frontend_url") ?? "*";
    p.AddPolicy("flashy-learn" ,builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
    });
});
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering();

//configuration to call react app
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

var app = builder.Build();

//-----Configuration to use React App-------
app.UseRouting();
app.UseMvc();
app.UseDefaultFiles();
app.UseStaticFiles();
//------------------------------------------

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

//app cors
app.UseCors("flashy-learn");

app.MapGraphQL();

app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions() {GraphQLEndPoint = "graphql"});


//------Configuration to Use Endpoint to call React App from Index Controller
app.UseEndpoints(endpoints =>
{
    endpoints.MapFallbackToController("Index", "WebSite");
});


// Migrate Database
// try
// {
//     var scope = app.Services.CreateScope();
//     var context = scope.ServiceProvider.GetRequiredService<FlashyLearnContext>();
//     context.Database.Migrate();
// }
// catch (Exception e)
// {
//     Console.WriteLine(e);
//     throw;
// }

app.Run();