// To use [Generator], ISourceGenerator, and so on.
using Microsoft.CodeAnalysis;

namespace Packt.Shared;

[Generator]
public class MessageSourceGenerator : ISourceGenerator
{
  public void Execute(GeneratorExecutionContext execContext)
  {
    IMethodSymbol mainMethod = execContext.Compilation
      .GetEntryPoint(execContext.CancellationToken);

    string sourceCode = $$"""
      // The source-generated code.

      partial class {{mainMethod.ContainingType.Name}}
      {
        static partial void Message(string message)
        {
          System.Console.WriteLine($"Generator says: '{message}'");
        }
      }
      """;

    string typeName = mainMethod.ContainingType.Name;

    execContext.AddSource($"{typeName}.Methods.g.cs", sourceCode);
  }

  public void Initialize(GeneratorInitializationContext initContext)
  {
    // This source generator does not need any initialization.
  }
}
