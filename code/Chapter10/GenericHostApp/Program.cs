// To use GetRequiredService, AddSingleton, AddScoped, AddTransient.
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting; // To use IHostBuilder, Host.
using Packt.Shared; // To use ICounterService, CounterService.

WriteLine("Creating a CounterService instance directly:");
ICounterService counterService = new CounterService();
counterService.IncrementCounter();
counterService.IncrementCounter();
WriteLine($"Counter: {counterService.Counter}");

WriteLine("Creating a CounterService instance indirectly using DI:");

// Create a host builder and pass the args passed to the console app.
IHostBuilder builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services =>
{
  // services.AddSingleton<ICounterService, CounterService>();
  // services.AddTransient<ICounterService, CounterService>();
  services.AddScoped<ICounterService, CounterService>();

  // Register a hosted service that will start when the host starts.
  services.AddHostedService<WorkerService>();
});

IHost host = builder.Build();

ICounterService service1, service2, service3;

// If we are getting a scoped service then we need at least one scope.
using (IServiceScope scope = host.Services.CreateScope())
{
  service1 = scope.ServiceProvider.GetRequiredService<ICounterService>();
  service2 = scope.ServiceProvider.GetRequiredService<ICounterService>();

  WriteLine($"Are the instances the same? {service1 == service2}");
  service1.IncrementCounter();
  service2.IncrementCounter();
  WriteLine($"service1.Counter: {service1.Counter}");
  WriteLine($"service2.Counter: {service2.Counter}");
}

using (IServiceScope scope = host.Services.CreateScope())
{
  service3 = scope.ServiceProvider.GetRequiredService<ICounterService>();

  WriteLine($"Are the instances the same? {service1 == service3}");
  WriteLine($"service1.Counter: {service1.Counter}");
  WriteLine($"service2.Counter: {service2.Counter}");
  WriteLine($"service3.Counter: {service3.Counter}");
}

// Start the host and any hosted services and wait for them to complete.
await host.RunAsync();
