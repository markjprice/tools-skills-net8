**Improvements** (12 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/tools-skills-net8/issues) or email me at markjprice (at) gmail.com.

- [Page 6 - Setting up your development environment](#page-6---setting-up-your-development-environment)
- [Page 24 - Setting up SQL Server and the Northwind database](#page-24---setting-up-sql-server-and-the-northwind-database)
- [Page 29 - Creating a class library for entity models using SQL Server](#page-29---creating-a-class-library-for-entity-models-using-sql-server)
- [Page 156 - Understanding stack and heap memory](#page-156---understanding-stack-and-heap-memory)
- [Page 355 - Method injection example](#page-355---method-injection-example)
- [Page 385 - Naming unit tests](#page-385---naming-unit-tests)
- [Page 411 - Making fluent assertions in unit testing](#page-411---making-fluent-assertions-in-unit-testing)
- [Page 433 - Installing the dev tunnel CLI](#page-433---installing-the-dev-tunnel-cli)
- [Page 433 - Exploring a dev tunnel with the CLI and an echo service](#page-433---exploring-a-dev-tunnel-with-the-cli-and-an-echo-service)
- [Page 453 - BenchmarkDotNet for benchmarking performance](#page-453---benchmarkdotnet-for-benchmarking-performance)
- [Page 497 - Page navigation and title verification](#page-497---page-navigation-and-title-verification)
- [Page 524 - Docker command-line interface (CLI) commands, Page 527 - Configuring ports and running a container](#page-524---docker-command-line-interface-cli-commands-page-527---configuring-ports-and-running-a-container)

# Page 6 - Setting up your development environment

The bullet for Visual Studio currently says:
- Visual Studio: Visual Studio 2022 for Windows. (Visual Studio 2022 for Mac reaches end-of-life on August 31, 2024, and is not recommended.)

In the next edition, I will add a note that you could also use Visual Studio in a virtual machine, or use Microsoft Dev Box: https://azure.microsoft.com/en-us/products/dev-box.

A reader, `@automaton` posed a thought in the Discord channel for this book: "I wonder if the idea long term is to merge Code and VS."

`@markjprice`: "My best guess is that .NET developers on Windows will continue to prefer Visual Studio, and everyone else will prefer VS Code. Microsoft has been clear about their commitment to improving both Visual Studio and VS Code but keeping them distinct in their roles. While VS Code continues to be enhanced with new features and cross-platform capabilities, Visual Studio remains focused on being a best-in-class IDE for development on Windows. Visual Studio is deeply integrated with Windows-specific technologies and APIs. It leverages components such as the Windows Presentation Foundation (WPF), which is not natively supported on other operating systems. Rewriting or adapting these dependencies for other platforms would require significant effort and resources. Microsoft will never port Visual Studio to other platforms or merge the two products. Instead, they will continue to add features from each to the other e.g. Solution Explorer added to VS Code, and HTTP Editor added to Visual Studio."

In the next edition, I will add a note similar to the above explaining why Microsoft won't merge or replace either product any time soon.

# Page 24 - Setting up SQL Server and the Northwind database

> Thanks to `CoericK` for asking a question in the book's Discord channel that prompted this improvement item.

`@CoericK`: "Hello @markjprice , I have a question, I'm running MacOS Catalina, according to your suggestions on page 24, your recommend to install Azure SQL Edge container for linux (i assume macos as well), https://github.com/markjprice/tools-skills-net8/blob/main/docs/sql-server/edge.md, however I already have an existing docker container running this image as base mcr.microsoft.com/mssql/server:2022-latest and installing mssqlserver via apt-get  apt-get install -y mssql-server-fts, can I just use my existing container? or would it be better to follow along your instructions for this book using Azure SQL Edge?"

`@markjprice`: "You can use your existing container. Just be aware that the SQL script will create a database named `Northwind` in a schema named `dbo`. That shouldn't be an issue or conflict with any existing SQL objects that you have. I say to use SQL Edge partly to provide extra separation between what you'll do in the book, and what you might already have. "Use at your own risk." as they say. 🙂 You sound like you know what you're doing."

`@CoericK`: "Thanks Mark, I think that I will create an azure sql edge container, and run it at a different port, I assume I will have to customize the conection port where required"

`@CoericK`: "created it on port 1434, worked like a charm. I'm using Azure Data Studio on MacOS btw"

`@CoericK`: "i used this tool to generate the connection string https://www.aireforge.com/tools/sql-server-connection-string-generator"

`@automaton`: "My issue was with the Trust certificate in the connection string, something that isn't prompted necessarily though the VSCode extension."

`@CoericK`: "I'm on mac, So in order to follow along the guide I had to create a virtual machine with windows install visual studio a connect to thee db in the host machine, since I'm using SQL Server Edge I had to run this command to get the classes created on page 28
 `dotnet ef dbcontext scaffold "Data Source=HOSTNAME,PORT;Integrated Security=false;User ID=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True;Initial Catalog=Northwind;" Microsoft.EntityFrameworkCore.SqlServer --namespace Northwind.EntityModels --data-annotations`"

In the next edition, *Tools and Skills for .NET 10*, I will add notes about how to use existing SQL Server instances, how to customize the port number to avoid conflicts with existing container images, and tools like Azure Data Studio and websites for generating database connection strings. I will also add a note about trusting the certificate in the connection string too.

# Page 29 - Creating a class library for entity models using SQL Server

> Thanks to [OpticOrange](https://github.com/OpticOrange) and [P9avel](https://github.com/P9avel) for raising this [issue on October 13, 2024](https://github.com/markjprice/tools-skills-net8/issues/19).

In Step 12, I wrote, "In `Customer.cs`, the `dotnet-ef` tool correctly identified that the `CustomerId` column is the primary key and it is limited to a maximum of five characters, but we also want the values to always be uppercase. So, add a regular expression to validate its primary key value to only allow uppercase Western characters, as shown highlighted in the following code:
```cs
[Key]
[StringLength(5)]
[RegularExpression("[A-Z]{5}")]
public string CustomerId { get; set; } = null!;"
```

The phrase "limited to a maximum of five characters" is implemented by the `dotnet-ef` tool by adding the `[StringLength(5)]`. But what the tool cannot assume is that the rule should be more restrictive than a *maximum*. All `CustomerId` values should be five upper case characters. In the next edition, I will add more text to clarify:

"In `Customer.cs`, the `dotnet-ef` tool identified that the `CustomerId` column is the primary key and it is limited to a maximum of five characters by decorating the property with `[StringLength(5)]`, but the tool did not make any further assumptions. We also want the values to always be uppercase and always exactly five characters. So, add a regular expression to validate its primary key value to only allow five uppercase Western characters, as shown highlighted in the following code:"

# Page 156 - Understanding stack and heap memory

> Thanks to [P9avel](https://github.com/P9avel) for raising an [issue on September 18, 2024](https://github.com/markjprice/tools-skills-net8/issues/5) that led to this improvement.

At the start of the third paragraph, I wrote, "On Windows, for ARM64, x86, and x64 machines, the default stack size is 1 MB." 

This sentence is correct. 

Mark Russinovich is a Microsoft expert and he wrote a deep dive article about memory and threads that is worth reading. You can find it at the following link:
https://learn.microsoft.com/en-us/archive/blogs/markrussinovich/pushing-the-limits-of-windows-processes-and-threads

Here are some relevant highlights:

![Stack size for the main thread defaults to 1MB](stack-1mb-01.png)

Note that the 1MB limit is a default and that "developers can override these values". The .NET team decided to override the default so that .NET apps have 1.5 MB of stack memory, but this was a "completely accidental change", as you can read about in the following comment to a GitHub issue in the .NET repository: https://github.com/dotnet/runtime/issues/96347#issuecomment-1871528297

"Prior to this change, we have been using the Windows native toolset default before that is 1MB."

If this issue might affect your projects, I recommend reading the following issue, especially the comments below from Microsoft employees who made the change from 1MB to 1.5MB: [Migration from .NET Framework 4.7.2 to .NET 8 results in StackOverflowException due to reduced stack size](https://github.com/dotnet/runtime/issues/96347).

# Page 355 - Method injection example

> Thanks to [P9avel](https://github.com/P9avel) for raising this [issue on September 29, 2024](https://github.com/markjprice/tools-skills-net8/issues/9).

In the code example, I show a Minimal APIs endpoint defined using `MapGet` that requires a dependency service to be passed as parameter, as shown in the following code:
```cs
app.MapGet("/weather", (IWeatherService weatherService) =>
{
  return Results.Ok(new { Weather = weatherService.GetWeather() });
});
```

Often, the parameter will be decorated with `[FromServices]` but this is not necessary.

You don't always need to use the `[FromServices]` attribute when injecting services into an endpoint. Minimal APIs automatically resolve services from the dependency injection (DI) container if the parameter is of a service type that has been registered in the container. This implicit resolution happens based on the type of the parameter. 

In the code example above, `IWeatherService` will automatically be resolved from the DI container without needing to use `[FromServices]`.

However, if you want to explicitly signal that a parameter is coming from the service container or need to disambiguate in certain situations (for example, if a parameter could come from multiple sources like query strings, route data, or services), you should use `[FromServices]`, as shown in the following code:
```cs
app.MapGet("/weather", ([FromServices] IWeatherService weatherService) =>
{
  return Results.Ok(new { Weather = weatherService.GetWeather() });
});
```

You may want to explicitly use `[FromServices]` in the following cases:
- **Ambiguity**: If there is ambiguity between where the parameter value comes from, for example, route parameters versus services.
- **Explicitness**: For code clarity and to signal that a parameter is explicitly being injected from services.
- **Non-service types**: If the parameter type isn't obviously a service, for example `HttpContext`, ASP.NET Core might not infer it correctly unless you specify `[FromServices]`.

In general, if the type is clearly a service and registered in the DI container, ASP.NET Core will resolve it without the attribute.

In the next edition, I will add this extra explanation.

# Page 385 - Naming unit tests

> Thanks to [P9avel](https://github.com/P9avel) for raising this [issue on October 2, 2024](https://github.com/markjprice/tools-skills-net8/issues/12).

In this section, I try to explain that although, "[s]ome advocate for a standardized naming scheme for unit test methods, for example, `[MethodName]_
[Scenario]_[Result]`, ..." "However, adopting a mechanical naming scheme like this is less useful than you might think ..." and therefore that I am NOT recommending that you prefix all your unit test names with `[MethodName]_`.

I also wrote, "Here are three examples of test names that use simple phrases in plain language:
- `Checkout_fails_when_item_is_out_of_stock`
- `User_receives_confirmation_email_after_successful_registration`
- `Login_is_blocked_after_three_failed_attempts`"

In the next edition, I will rewrite this section to make my point clearer, and I will use different examples here to make it clearer that `Checkout_`, `User_`, and `Login_` are NOT method name prefixes.

# Page 411 - Making fluent assertions in unit testing

In this section, I show how to use the `FluentAssertions` package. At the time of publishing, the latest version of this package was `6.12.0`. 

Since version `8.0.0`, released on January 14, 2025, there has been a license change, as described at the following links: https://fluentassertions.com/releases/#800 and https://github.com/fluentassertions/fluentassertions/pull/2943.

Comments from the owner `dennisdoomen`: "v7 will remain free indefinitely and will still receive critical fixes. v8 will only require a license when you use it in non-commercial projects." (https://github.com/fluentassertions/fluentassertions/pull/2943#issuecomment-2590187813 and https://github.com/fluentassertions/fluentassertions/pull/2943#issuecomment-2590286302)

In the next edition, I will recommend the use of v7.1 or later: https://www.nuget.org/packages/FluentAssertions/7.1.0

Alternatively, there is a v7-forked repo named `AwesomeAssertions`: https://www.nuget.org/packages/AwesomeAssertions/7.0.0. You should be able to replace the package reference and everything will continue to work.

# Page 433 - Installing the dev tunnel CLI

> Thanks to [Paul Marangoni](https://github.com/pmarangoni) for raising [this issue on May 7, 2025](https://github.com/markjprice/web-dev-net9/issues/51).

In the next edition, if the CLI is still in preview, then I will add a warning:

> **Warning!** This feature is currently in public preview. The CLI might have bugs that are introduced and fixed over time. Command names and options may change in future releases. The preview version is provided without a service-level agreement, and it's not recommended for production workloads. Certain features might not be supported or might have constrained capabilities. Read the latest about the CLI at the following link: https://learn.microsoft.com/en-us/azure/developer/dev-tunnels/cli-commands

# Page 433 - Exploring a dev tunnel with the CLI and an echo service

After Step 2, I will add a note:

> If you get error, `Missing wamcompat_id_token in WAM case`, then try using device flow to login instead, as shown in the following command: `devtunnel login -d`

# Page 453 - BenchmarkDotNet for benchmarking performance

> Thanks to **Giuseppe Guerra** / `giuse_guerra` who asked a question about this in the book's Discord channel on May 22, 2025.

Giuseppe asked "in certain contexts, in order to run benchmarks, is it also necessary to modify the code under examination?"

No, you don't need to modify your code to run benchmarks with BenchmarkDotNet — unless your code is inaccessible, untestable, or relies heavily on side effects or state. Even then, you're usually refactoring to improve testability rather than doing anything BenchmarkDotNet-specific.

BenchmarkDotNet is designed to isolate and test performance characteristics of existing code, and its architecture reflects that goal. However, there are a few caveats and edge cases where *some* modification or structural adjustments may be necessary or beneficial.

What you don’t need to do:
* You do not need to rewrite your core business logic or algorithms to use BenchmarkDotNet. It works by creating a separate benchmarking project or class that invokes your code.
* Unlike profilers, BenchmarkDotNet doesn't require you to inject timers or logging manually into the code you're testing.

When you might need modifications:
* Your benchmark class needs to access the methods or classes you want to test. This might require making methods `public` or `internal`, adding `InternalsVisibleTo("BenchmarkDotNet...")` if you're benchmarking internal members, and avoiding `private` scope unless the benchmark is declared within the same class (which I've done in the book examples, so in the next edition I might move that code into a separate class library project to make it more realistic).
* Sometimes your code is tightly coupled to dependencies, static classes, or environment-specific state like file system, network, database. In these cases, for benchmarking purposes, you may want to refactor into smaller, pure functions or extract interfaces, and use dependency injection to mock or replace I/O-heavy dependencies. This isn't BenchmarkDotNet's fault — it's a general principle of testability and applies to benchmarking just like it does to unit testing.
* The benchmarked method should be written in a way that avoids dead code elimination. If a method doesn’t return a result or the result is unused, the JIT may optimize it away. Use `return` or `Consume()` via `BenchmarkDotNet.Engines.Consumer`, and loop hoisting or constant folding (artificial patterns may not reflect real-world performance if the compiler or runtime optimizes them out). This sometimes means restructuring trivial samples to ensure meaningful benchmarking.

# Page 497 - Page navigation and title verification

In Step 5, I wrote, "Navigate to `WebUITests\bin\Debug\net8.0` and, at the command prompt or terminal, install browsers for Playwright to automate, as shown in the following command:"
```shell
pwsh playwright.ps1 install
```

A note links to the official Playwright guide for installing its custom browsers.

> Playwright needs special versions of browser binaries to operate. You must use the Playwright PowerShell script to install these browsers. If you have issues, you can learn more at the following link: https://playwright.dev/dotnet/docs/browsers.

Some readers might get an error, `The command “pwsh” is not recognized.` 

The most likely problem is that PowerShell is not installed properly on their computer (i.e. not installed at all, or installed but not set up so it is found from the command prompt).

In the next edition, I will add extra links to help readers who struggle with this, for example:

**Install PowerShell on Windows, Linux, and macOS**
https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell

Some of the answers here might help: **getting started instructions dont work** #1865:
https://github.com/microsoft/playwright-dotnet/issues/1865 

# Page 524 - Docker command-line interface (CLI) commands, Page 527 - Configuring ports and running a container

> Thanks to [P9avel](https://github.com/P9avel) for raising this [issue on October 10, 2024](https://github.com/markjprice/tools-skills-net8/issues/17).

In Table 15.4, I give an example of a Docker command to run an image, as shown in the following command:
```
docker run -d -p 8080:80 --name webapp mcr.microsoft.com/dotnet/aspnet:8.0
```
Although the example image path is valid (see: https://hub.docker.com/r/microsoft/dotnet-aspnet), that image only contains the ASP.NET Core Runtime without an app, so it's not a useful example. That image is designed to pulled and then added to with your own project. 

A better example would be one that also contain a sample app so that you have something to interact with immediately, as shown in the following command:
```
docker run -d -p 8080:80 --name webapp mcr.microsoft.com/dotnet/samples:aspnetapp:8.0
```

Similarly, on page 527, I show an example of setting ports, as shown in the following command:
```
docker run -p 8000:8080 -d --name myaspnetapp mcr.microsoft.com/dotnet/aspnet:latest
```

Although the specific image used is not important because it's just showing how to set ports, a better example would use the image with an app, as shown in the following command:
```
docker run -p 8000:8080 -d --name myaspnetapp mcr.microsoft.com/dotnet/samples:aspnetapp:latest
```

And on page 528, I show an example of configuring for HTTPS. The example would be better with the sample app image, although again, the point is not the specific image, it's just to show the additional switches for configuring HTTPS.
