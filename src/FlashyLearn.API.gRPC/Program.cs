using FlashyLearn.API.gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
    endpoints.MapGrpcService<CategoryService>();
    endpoints.MapGrpcService<FlashCardService>();
});



app.Run();