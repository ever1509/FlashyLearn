using Application;
using GraphQL.Server.Ui.Voyager;
using Infrastructure;
using Infrastructure.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(p =>
{
    var frontedURL = builder.Configuration.GetValue<string>("frontend_url") ?? "*";
    p.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontedURL).AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

//app cors
app.UseCors("flashy-learn");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();
app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions() {GraphQLEndPoint = "graphql"});

app.Run();