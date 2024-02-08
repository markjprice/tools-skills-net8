using Packt.Shared; // To use WebConfig.

namespace DebugTests;

public class DebugLibraryTests
{
  [Fact]
  public void WebConfigPropertiesInstantiated()
  {
    WebConfig config = new();

    Assert.NotNull(config.DbConnectionString);
    Assert.NotNull(config.Base64Encoded);
    Assert.NotNull(config.JsonWebToken);
  }
}