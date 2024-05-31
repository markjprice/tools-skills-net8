# Decorator pattern

The Decorator pattern allows you to attach new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors. It's a flexible alternative to subclassing for extending functionality. This pattern is particularly useful when you need to dynamically add responsibilities to objects without modifying their code. Imagine it as wrapping a gift: the item inside is your original object, and each layer of wrapping paper represents a new behavior you're adding to it.

Imagine we're building an application that processes text messages. We start with a simple message and want to enhance it incrementally, perhaps by adding a timestamp, encrypting it, or compressing it, depending on various runtime conditions.

Components of the Decorator Pattern:
- **Component**: Defines the interface for objects that can have responsibilities added to them dynamically.
- **ConcreteComponent**: Defines an object to which additional responsibilities can be attached.
- **Decorator**: Maintains a reference to a Component object and defines an interface that conforms to Component's interface.
- **ConcreteDecorator**: Adds responsibilities to the component.

First, define the Component interface and a ConcreteComponent that implements this interface, as shown in the following code:
```cs
public interface IMessage
{
  string GetContent();
}

public class SimpleMessage : IMessage
{
  private string _content;

  public SimpleMessage(string content)
  {
    _content = content;
  }

  public string GetContent()
  {
    return _content;
  }
}
```

Next, create an abstract Decorator class that also implements the `IMessage` interface, as shown in the following code:
```cs
public abstract class MessageDecorator : IMessage
{
  protected IMessage _message;

  public MessageDecorator(IMessage message)
  {
    _message = message;
  }

  public abstract string GetContent();
}
```

Now, let's implement a couple of ConcreteDecorator classes to enhance our message, as shown in the following code:
```cs
public class TimestampedMessage : MessageDecorator
{
  public TimestampedMessage(IMessage message) : base(message) { }

  public override string GetContent()
  {
    return $"[{DateTime.Now}] {_message.GetContent()}";
  }
}

public class EncryptedMessage : MessageDecorator
{
  public EncryptedMessage(IMessage message) : base(message) { }

  public override string GetContent()
  {
    // Imagine a real encryption mechanism here.
    return $"Encrypted({_message.GetContent()})";
  }
}
```

Now we can use the Decorator pattern, as shown in the following code:
```cs
IMessage message = new SimpleMessage("Hello, Decorator Pattern!");

// Decorate the message with a timestamp.
IMessage timestampedMessage = new TimestampedMessage(message);
WriteLine(timestampedMessage.GetContent());

// Further decorate the message by encrypting it (on top of the timestamp).
IMessage encryptedMessage = new EncryptedMessage(timestampedMessage);
WriteLine(encryptedMessage.GetContent());
```

In this example, `SimpleMessage` is the ConcreteComponent that holds the original text. `MessageDecorator` is an abstract decorator class that implements the `IMessage` interface and contains a reference to an `IMessage` object. `TimestampedMessage` and `EncryptedMessage` are ConcreteDecorators that add new behaviors. The great thing about this pattern is that it allows for flexible addition of functionalities to objects without changing the objects themselves or the system that uses them. You can easily create more decorators to add more behaviors as needed.
