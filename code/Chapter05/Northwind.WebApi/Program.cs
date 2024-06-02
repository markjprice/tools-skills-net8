using Northwind.EntityModels; // To use the AddNorthwindContext method.
using Packt.Extensions; // To use MapGets.
using Northwind.WebApi; // To use the MetricsService class.
using OpenTelemetry.Logs; // To use AddConsoleExporter.
using OpenTelemetry.Metrics; // To use WithMetrics.
using OpenTelemetry.Resources; // To use ResourceBuilder.
using OpenTelemetry.Trace; // To use WithTracing.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNorthwindContext();
builder.Services.AddSingleton<MetricsService>();

// Add and configure OpenTelemetry to logging and services.
const string serviceName = "Northwind.WebApi";

builder.Logging.AddOpenTelemetry(options =>
{
  options
    .SetResourceBuilder(ResourceBuilder.CreateDefault()
      .AddService(serviceName))
    .AddConsoleExporter();
});

builder.Services.AddOpenTelemetry()
  .ConfigureResource(resource => resource.AddService(serviceName))
  .WithTracing(tracing => tracing
    .AddAspNetCoreInstrumentation()
    .AddEntityFrameworkCoreInstrumentation()
    .AddSqlClientInstrumentation()
    .AddConsoleExporter())
  .WithMetrics(metrics => metrics
    .AddAspNetCoreInstrumentation()
    .AddConsoleExporter());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMetricsMiddleware();

app.MapGets(); // Default pageSize: 10.

app.Run();
