# Mediator pattern

The Mediator pattern reduces the direct communication between objects to a minimum, making them communicate instead through a mediator object. This pattern is used to centralize complex communications and control between related objects in a system. The mediator makes it easier to maintain and modify communications between objects as the system evolves. It's like having a controller in an air traffic control tower coordinating the arrivals and departures of airplanes, rather than each plane talking directly to each other.

In a .NET context, implementing the Mediator pattern involves creating a Mediator interface that defines the method for communicating with objects, a ConcreteMediator class that implements this interface and coordinates communication, and finally, Colleague classes that communicate with each other through the Mediator.

Let's create a simple chat room as an example. In this chat room, participants send messages to each other via a chat room mediator, which controls and moderates the communication.

First, define the `IMediator` interface and the `Colleague` class, as shown in the following code:
```cs
public interface IMediator
{
  void SendMessage(string message, Colleague colleague);
}

public abstract class Colleague
{
  protected IMediator _mediator;

  public Colleague(IMediator mediator)
  {
    _mediator = mediator;
  }

  public virtual void Send(string message)
  {
    _mediator.SendMessage(message, this);
  }

  public abstract void Receive(string message);
}
```

Next, implement the ConcreteMediator class, as shown in the following code:
```cs
public class ChatRoomMediator : IMediator
{
  private List<Colleague> _colleagues;

  public ChatRoomMediator()
  {
    _colleagues = new List<Colleague>();
  }

  public void Register(Colleague colleague)
  {
    _colleagues.Add(colleague);
  }

  public void SendMessage(string message, Colleague originator)
  {
    foreach (Colleague colleague in _colleagues)
    {
      if (colleague != originator) // Do not send the message back to the sender
      {
        colleague.Receive(message);
      }
    }
  }
}
```

Implement concrete Colleague classes, as shown in the following code:
```cs
public class Participant : Colleague
{
  public string Name { get; }

  public Participant(IMediator mediator, string name) : base(mediator)
  {
    Name = name;
  }

  public override void Receive(string message)
  {
    WriteLine($"{Name} received: {message}");
  }
}
```

Finally, demonstrate how participants can interact in the chat room, as shown in the following code:
```cs
ChatRoomMediator mediator = new();

Participant john = new(mediator, "John");
Participant jane = new(mediator, "Jane");

mediator.Register(john);
mediator.Register(jane);

john.Send("Hi there!");
jane.Send("Hey!");
```

In this setup, `ChatRoomMediator` acts as the mediator coordinating the messages between `Participant` objects. When a participant sends a message, it goes through the mediator, which then relays it to the other participants. This decouples the participants from each other, as they no longer communicate directly but through the mediator. Changes in the communication logic, such as adding message filtering or broadcasting messages to a specific group of participants, can be handled in the mediator without affecting the participant classes.

The Mediator pattern centralizes complex communications and controls between related objects, reducing the dependencies between objects to a single point of communication. This simplifies object protocols and makes the system easier to understand and maintain.
