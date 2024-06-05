// To use ConfigurationBuilder and so on.
using Microsoft.Extensions.Configuration;

partial class Program
{
  private static Settings? GetSettings()
  {
    const string settingsFile = "appsettings.json";
    const string settingsSectionKey = nameof(Settings);

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
      WriteLine($"{settingsSectionKey} section not found in {settingsFile}.");
      return null;
    }
    else
    {
      return settings;
    }
  }
}
