using Packt.Shared; // To use INorthwindService.

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<INorthwindService, NorthwindService>();
WebApplication app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
  INorthwindService service = scope.ServiceProvider
    .GetRequiredService<INorthwindService>();
  
  // Use the service here.
}

app.MapGet("/", () => "Hello World!");
app.Run();
