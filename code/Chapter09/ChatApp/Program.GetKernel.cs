using Microsoft.Extensions.DependencyInjection; // To use AddLogging.
using Microsoft.Extensions.Logging; // To use LogLevel.
using Microsoft.SemanticKernel; // To use Kernel.

partial class Program
{
  private static Kernel GetKernel(Settings settings)
  {
    IKernelBuilder kernelBuilder = Kernel.CreateBuilder();

    // Configure the OpenAI chat with model and secret key.
    kernelBuilder.AddOpenAIChatCompletion(
        settings.ModelId,
        settings.OpenAISecretKey);

    // Add logging and resilience.
    kernelBuilder.Services.AddLogging(c => 
      c.AddConsole().SetMinimumLevel(LogLevel.Trace));
    kernelBuilder.Services.ConfigureHttpClientDefaults(c => 
      c.AddStandardResilienceHandler());

    Kernel kernel = kernelBuilder.Build();

    // Create a prompt function as part of a plugin and add it to the kernel.
    kernel.ImportPluginFromFunctions(pluginName: "AuthorInformation",
    [
      kernel.CreateFunctionFromMethod(
        method: GetAuthorBiography,
        functionName: nameof(GetAuthorBiography),
        description: "Gets the author's biography.")
    ]);

    kernel.ImportPluginFromFunctions(pluginName: "NorthwindProducts",
    [
      kernel.CreateFunctionFromMethod(
        method: GetProductsInCategory,
        functionName: nameof(GetProductsInCategory),
        description: "Get the products in a category from the Northwind database.")
    ]);

    return kernel;
  }
}
