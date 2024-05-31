# Factory method

The **Factory Method** uses a method to perform the object creation. This allows for introducing new types of objects without altering the code that uses these objects. It encapsulates the instantiation logic and refers to the newly created object through a common interface.

## Factory Method pattern example

Imagine you're running a software firm, and you need to manage various types of projects like Mobile, Web, and Desktop applications. Each project type requires different setup, team skills, and resources. Instead of lumping all this logic into a single class, you encapsulate the project creation for each type into separate classes. But you also want a unified way to create these projects without hardcoding their types into your code.

You define an interface for creating an object but let subclasses decide which class to instantiate. The Factory Method lets a class defer instantiation to subclasses. We'll create an abstract class called `Project` and a method inside it named `CreateProject()`. Different project types will inherit from `Project` and implement their version of `CreateProject()`, as shown in the following code:
```cs
public abstract class Project
{
  // This is the factory method.
  public abstract IProjectManager CreateProject();
}

public interface IProjectManager
{
  void HandleProject();
}

// Concrete class for Web projects.
public class WebProject : Project
{
  public override IProjectManager CreateProject()
  {
    return new WebProjectManager();
  }
}

public class WebProjectManager : IProjectManager
{
  public void HandleProject()
  {
    WriteLine("Handling a Web project");
  }
}

// Concrete class for Mobile projects.
public class MobileProject : Project
{
  public override IProjectManager CreateProject()
  {
    return new MobileProjectManager();
  }
}

public class MobileProjectManager : IProjectManager
{
  public void HandleProject()
  {
    WriteLine("Handling a Mobile project");
  }
}
```

Now let's use the classes, as shown in the following code:
```cs
Project project = new WebProject();
IProjectManager manager = project.CreateProject();
manager.HandleProject();  // Output: Handling a Web project

project = new MobileProject();
manager = project.CreateProject();
manager.HandleProject();  // Output: Handling a Mobile project
```

In this example, `Project` acts as the creator, defining the factory method `CreateProject()`. `WebProject` and `MobileProject` are concrete creators that override the factory method to return an instance of a concrete product, `WebProjectManager` or `MobileProjectManager`, respectively. 

Both project managers implement the `IProjectManager` interface, ensuring they have a common method, `HandleProject()`, which is used for handling the project. This setup allows us to instantiate project managers for different types of projects without knowing the details of how each project is handled.

The beauty of this pattern is its scalability and flexibility. If you need to add another project type, say `DesktopProject`, you just create a new class that inherits from `Project` and implement the `CreateProject()` method to return a `DesktopProjectManager`. Your existing code doesn't change, adhering to the open/closed principle (OCP), one of the SOLID principles.

## Factory Method pattern .NET BCL example

In the .NET BCL, the Factory Method pattern is used extensively, although it might not always be explicitly documented as such. A classic example is found in the `System.Net.WebRequest` class, which serves as a base class for making requests to Uniform Resource Identifiers (URIs).

The `WebRequest.Create(string)` method is a factory method that returns a `WebRequest` instance. Depending on the URI scheme (HTTP, HTTPS, FTP, and so on), this method returns an instance of a derived class suitable for handling that scheme. This is a textbook implementation of the Factory Method pattern, where the exact type of the object created is determined at runtime based on the input.
```cs
// Create an HTTP request.
WebRequest httpRequest = WebRequest.Create("http://www.example.com");
WriteLine(httpRequest.GetType());  // Output: System.Net.HttpWebRequest

// Create an FTP request.
WebRequest ftpRequest = WebRequest.Create("ftp://example.com");
WriteLine(ftpRequest.GetType());  // Output: System.Net.FtpWebRequest
```

Note the following about the preceding code:
- `WebRequest` acts as the creator in the Factory Method pattern context.
- The `Create(string)` method is the factory method. It determines the specific type of `WebRequest` to return based on the URI scheme provided.
- Derived classes like `HttpWebRequest` or `FtpWebRequest` are the concrete types. They inherit from `WebRequest` and implement protocol-specific functionality.

In this example, when `WebRequest.Create` is called with an HTTP URL, it returns an instance of `HttpWebRequest`. When called with an FTP URL, it returns an instance of `FtpWebRequest`. The client code doesn't need to know the specifics about different types of web requests. It just uses the `WebRequest` "interface" to work with the returned object. This encapsulates the instantiation logic and decouples the client code from the concrete classes.

Another example of the Factory Method pattern in the context of modern .NET development is the `HttpClientFactory` introduced in ASP.NET Core 2.1. This factory is an advanced implementation of the Factory Method pattern, providing a central way to configure and create `HttpClient` instances in a web application.

The `HttpClientFactory` addresses several issues associated with the direct instantiation and management of `HttpClient` instances, such as socket exhaustion and DNS changes. It allows for the configuration of named or typed client instances that can be injected into consuming services, encapsulating the logic for creating these instances based on the defined configurations.

Here's how you might set up and use the HttpClientFactory, as shown in the following code:
```cs
builder.Services.AddHttpClient();
```

Then inject and use the `IHttpClientFactory` to create `HttpClient` instances, as shown in the following code:
```cs
public class MyService
{
  private readonly HttpClient _httpClient;

  public MyService(IHttpClientFactory httpClientFactory)
  {
    _httpClient = httpClientFactory.CreateClient();
  }

  public async Task<string> GetSomeDataAsync(string url)
  {
      HttpResponseMessage response = await _httpClient.GetAsync(url);
      response.EnsureSuccessStatusCode();

      return await response.Content.ReadAsStringAsync();
  }
}
```

In this setup, `IHttpClientFactory` acts as the factory that abstracts the complexities of creating and managing `HttpClient` instances. It allows for the centralized configuration and management of these instances, leveraging a pattern like the Factory Method to provide a flexible and robust solution to common issues encountered when directly using `HttpClient`.
