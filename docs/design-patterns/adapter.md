# Adapter aka Wrapper pattern

The Adapter pattern allows objects with incompatible interfaces to collaborate. It's like having two different electronic devices with different power plugs but using an adapter to make one fit into the other's socket, allowing them to work together seamlessly.

In the world of software, the Adapter pattern is used when you want an existing class to work with another class that has an incompatible interface. This situation often arises in software development when you need to integrate new features or components that weren't initially designed to work with your existing codebase.

The Adapter pattern involves three key components:
- Target: The interface that the client expects or uses.
- Adaptee: The class that needs to be adapted to fit the target interface.
- Adapter: The class that implements the target interface and translates calls to the adaptee.

Imagine you're working on a system that processes text data. You have an existing system component that expects data in a structured format defined by an `ITextProcessor` interface, but you're now integrating a new component that has a valuable text analytics capability, only it presents a completely different interface, `IAdvancedTextAnalytics`.

You might define these interfaces and classes, as shown in the following code:
```cs
public interface ITextProcessor
{
  void ProcessText(string text);
}

public class TextProcessor : ITextProcessor
{
  public void ProcessText(string text)
  {
    // Implementation for processing text in a basic way.
    WriteLine($"Processing text: {text}");
  }
}

public interface IAdvancedTextAnalytics
{
  void AnalyzeTextComplexity(string text);
  void FindKeyPhrases(string text);
}

public class AdvancedTextAnalytics : IAdvancedTextAnalytics
{
  public void AnalyzeTextComplexity(string text)
  {
    // Imagine some complex text analysis here.
    WriteLine($"Analyzing text complexity: {text}");
  }

  public void FindKeyPhrases(string text)
  {
    // And some advanced key phrase detection here.
    WriteLine($"Finding key phrases in: {text}");
  }
}
```

Here is an Adapter that makes `AdvancedTextAnalytics` compatible with `ITextProcessor`, as shown in the following code:
```cs
public class TextAnalyticsAdapter : ITextProcessor
{
  private readonly IAdvancedTextAnalytics _advancedTextAnalytics;

  public TextAnalyticsAdapter(IAdvancedTextAnalytics advancedTextAnalytics)
  {
    _advancedTextAnalytics = advancedTextAnalytics;
  }

  public void ProcessText(string text)
  {
    // Adapter translates the method call to the new system.
    _advancedTextAnalytics.AnalyzeTextComplexity(text);
    _advancedTextAnalytics.FindKeyPhrases(text);
  }
}
```

And finally, how you might use this adapter in your application, as shown in the following code:
```cs
ITextProcessor processor = new TextProcessor();
processor.ProcessText("Hello, world!");

// Now let's use the advanced analytics via the adapter.
IAdvancedTextAnalytics analytics = new AdvancedTextAnalytics();
ITextProcessor advancedProcessor = new TextAnalyticsAdapter(analytics);
advancedProcessor.ProcessText("Exploring the Adapter pattern in .NET");
```

In this example, `TextAnalyticsAdapter` allows you to use `AdvancedTextAnalytics` in places where `ITextProcessor` is expected, without altering the original classes. This approach keeps your code flexible and open for extension, adhering to SOLID design principles while accommodating new requirements or third-party components.
