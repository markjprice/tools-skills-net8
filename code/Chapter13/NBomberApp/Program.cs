using NBomber.Contracts; // To use ScenarioProps.
using NBomber.CSharp; // To use Scenario, Simulation, NBomberRunner.
using NBomber.Http; // To use HttpMetricsPlugin.
using NBomber.Http.CSharp; // To use Http.
using NBomber.Plugins.Network.Ping; // To use PingPlugin.

// Use System.Net.Http.HttpClient to make HTTP requests.
using HttpClient client = new();

LoadSimulation[] loads = [
  // Ramp up to 50 RPS during one minute.
  Simulation.RampingInject(rate: 50, 
    interval: TimeSpan.FromSeconds(1), 
    during: TimeSpan.FromMinutes(1)),
  // Maintain 50 RPS for another minute.
  Simulation.Inject(rate: 50, 
    interval: TimeSpan.FromSeconds(1), 
    during: TimeSpan.FromMinutes(1)),
  // Ramp down to 0 RPS during one minute.
  Simulation.RampingInject(rate: 0, 
    interval: TimeSpan.FromSeconds(1), 
    during: TimeSpan.FromMinutes(1))
];

ScenarioProps scenario = Scenario.Create(
  name: "http_scenario", 
  run: async context =>
{
  HttpRequestMessage request = Http.CreateRequest(
    "GET", "http://localhost:5131/weatherforecast")
    .WithHeader("Accept", "application/json");

  // Use WithHeader and WithBody to send a JSON payload.
  // .WithHeader("Content-Type", "application/json")
  // .WithBody(new StringContent("{ some JSON }", Encoding.UTF8, "application/json"));

  Response<HttpResponseMessage> response = await Http.Send(client, request);

  return response;
})
  .WithoutWarmUp()
  .WithLoadSimulations(loads);

NBomberRunner
  .RegisterScenarios(scenario)
  .WithWorkerPlugins(
    new PingPlugin(PingPluginConfig.CreateDefault("nbomber.com")),
    new HttpMetricsPlugin([ HttpVersion.Version1 ])
  )
  .Run();
