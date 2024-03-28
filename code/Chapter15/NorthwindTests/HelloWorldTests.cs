using DotNet.Testcontainers.Builders; // To use ContainerBuilder.
using DotNet.Testcontainers.Containers; // To use IContainer.

namespace NorthwindTests;

public class HelloWorldTests
{
  [Fact]
  public async Task HelloWorldTest()
  {
    // Create a new instance of a container.
    ContainerBuilder builder = new();

    IContainer container = builder
      // Set the image for the container to "testcontainers/helloworld:1.1.0".
      .WithImage("testcontainers/helloworld:1.1.0")

      // Bind port 8080 of the container to a random port on the host.
      .WithPortBinding(8080, true)
      
      // Wait until the HTTP endpoint of the container is available.
      .WithWaitStrategy(Wait.ForUnixContainer().UntilHttpRequestIsSucceeded(r => r.ForPort(8080)))
      
      // Build the container configuration.
      .Build();

    // Start the container.
    await container.StartAsync();

    // Create a new instance of HttpClient to send HTTP requests.
    HttpClient httpClient = new();

    // Construct the request URI by specifying the scheme, hostname,
    // assigned random host port, and the endpoint "uuid".
    UriBuilder uriBuilder = new(
      Uri.UriSchemeHttp, 
      container.Hostname, 
      container.GetMappedPublicPort(8080), 
      "uuid");

    Uri requestUri = uriBuilder.Uri;

    // Send an HTTP GET request to the specified URI and retrieve the response as a string.
    string guid = await httpClient.GetStringAsync(requestUri);

    // Ensure that the retrieved UUID is a valid GUID.
    Assert.True(Guid.TryParse(guid, out _));
  }
}
