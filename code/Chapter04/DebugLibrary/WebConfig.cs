using System.Diagnostics;

namespace Packt.Shared;

public class WebConfig
{
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  public string? DbConnectionString { get; set; }

  public string? Base64Encoded { get; set; }

  public string? JsonWebToken { get; set; }

  public WebConfig()
  {
    DbConnectionString = "Server="
      + "(localdb)\\mssqllocaldb;"
      + "Database=Northwind;"
      + "Trusted_Connection=true";

    byte[] data = UTF8.GetBytes("Debugging is cool!");
    Base64Encoded = ToBase64String(data);

    // Set a string for the JWT from the example at:
    // https://jwt.io/
    JsonWebToken = 
      "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9." +
      "eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6I" +
      "kpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ." +
      "SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
  }

  [DebuggerStepThrough]
  public void OutputAll()
  {
    WriteLine($"DbConnectionString: {DbConnectionString}");
    WriteLine($"Base64Encoded: {Base64Encoded}");
    WriteLine($"JsonWebToken: {JsonWebToken}");
  }
}
