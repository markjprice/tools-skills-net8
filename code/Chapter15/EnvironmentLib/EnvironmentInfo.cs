using System.Net; // To use Dns.
using System.Runtime.InteropServices; // To use RuntimeInformation.

namespace EnvironmentLib;

public class EnvironmentInfo
{
  public string UserName { get; } = Environment.UserName;
  public string HostName { get; } = Dns.GetHostName();
  public string DotNet { get; } = RuntimeInformation.FrameworkDescription;
  public string OS { get; } = RuntimeInformation.OSDescription;
  public string Architecture { get; } = RuntimeInformation.OSArchitecture.ToString();
  public int Processors { get; } = Environment.ProcessorCount;
  public bool InContainer { get; } = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") is not null;
}
