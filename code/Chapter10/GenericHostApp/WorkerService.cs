using Microsoft.Extensions.Hosting; // To use IHostedService.
using Microsoft.Extensions.Logging; // To use ILogger.

namespace Packt.Shared;

public sealed class WorkerService : IHostedService
{
  private readonly ILogger _logger;
  private readonly IHostEnvironment _environment;
  private readonly IHostApplicationLifetime _appLifetime;

  public WorkerService(
      ILogger<WorkerService> logger,
      IHostApplicationLifetime appLifetime,
      IHostEnvironment hostEnvironment)
  {
    _logger = logger;
    _logger.LogInformation("WorkerService constructor has been called.");

    appLifetime.ApplicationStarted.Register(OnStarted);
    appLifetime.ApplicationStopping.Register(OnStopping);
    appLifetime.ApplicationStopped.Register(OnStopped);
    _appLifetime = appLifetime;

    _environment = hostEnvironment;
    WriteLine($"_environment.EnvironmentName: {_environment.EnvironmentName}");
    WriteLine($"_environment.ApplicationName: {_environment.ApplicationName}");
    WriteLine($"_environment.ContentRootPath: {_environment.ContentRootPath}");

  }

  public Task StartAsync(CancellationToken cancellationToken)
  {
    _logger.LogInformation("1. StartAsync has been called.");

    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    _logger.LogInformation("4. StopAsync has been called.");

    return Task.CompletedTask;
  }

  private void OnStarted()
  {
    _logger.LogInformation("2. OnStarted has been called.");
  }

  private void OnStopping()
  {
    _logger.LogInformation("3. OnStopping has been called.");
  }

  private void OnStopped()
  {
    _logger.LogInformation("5. OnStopped has been called.");
  }

  private void GracefulShutdown()
  {
    _appLifetime.StopApplication();
  }
}
