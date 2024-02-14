// To use ConfigurationBuilder and so on.
using Microsoft.Extensions.Configuration; 
using Microsoft.SemanticKernel; // To use Kernel.

const string settingsFile = "appsettings.json";
const string settingsSectionKey = "Settings";

// Build a config object, using JSON and environment
// variables providers.
IConfigurationRoot config = new ConfigurationBuilder()
  .AddJsonFile(settingsFile)
  .AddEnvironmentVariables()
  .Build();

// Get settings from the config given the key and the
// strongly-typed class.
Settings? settings = config.GetRequiredSection(
  settingsSectionKey).Get<Settings>();

if (settings is null)
{
  WriteLine($"{settingsSectionKey
    } section not found in {settingsFile}.");
  return;
}

// Initialize a semantic kernel using settings.
Kernel kernel = Kernel.CreateBuilder()
  .AddOpenAIChatCompletion(
    settings.ModelId, 
    settings.OpenAISecretKey)
  .Build();

ConsoleKey key = ConsoleKey.A;

while (key is not ConsoleKey.X)
{
  Write("Enter your question: ");
  WriteLine(await kernel.InvokePromptAsync(ReadLine()!));
  WriteLine();
  WriteLine("Press X to exit or any other key to ask another question.");
  key = ReadKey().Key;
}

