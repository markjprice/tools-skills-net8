# Chain of Responsibility pattern

The **Chain of Responsibility pattern** passes a request along a chain of handlers. Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain. This pattern allows an object to send a command without knowing which object will handle the request. It's particularly useful for implementing various types of request handling scenarios where the handler is only determined at runtime.

The pattern involves two key participants:
- **Handler**: Defines an interface for handling requests and an optional link to the next handler in the chain.
- **Concrete Handlers**: Performs specific actions based on the request, decides whether to pass the request along the chain or handle it themselves.

Imagine an application where user support requests are handled differently based on their type, for example, Technical, Billing, General.

First, define the Handler, as shown in the following code:
```cs
public abstract class SupportHandler
{
  protected SupportHandler _nextHandler;

  public void SetNextHandler(SupportHandler nextHandler)
  {
    _nextHandler = nextHandler;
  }

  public abstract void HandleRequest(SupportRequest request);
}

public class SupportRequest
{
  public string RequestType { get; set; }
  public string Description { get; set; }

  public SupportRequest(string requestType, string description)
  {
    RequestType = requestType;
    Description = description;
  }
}
```

Next, implement Concrete Handlers, as shown in the following code:
```cs
public class TechnicalSupportHandler : SupportHandler
{
  public override void HandleRequest(SupportRequest request)
  {
    if (request.RequestType == "Technical")
    {
      WriteLine($"Technical Support handling request: {request.Description}");
    }
    else if (_nextHandler is not null)
    {
      _nextHandler.HandleRequest(request);
    }
  }
}

public class BillingSupportHandler : SupportHandler
{
  public override void HandleRequest(SupportRequest request)
  {
    if (request.RequestType == "Billing")
    {
      WriteLine($"Billing Support handling request: {request.Description}");
    }
    else if (_nextHandler != null)
    {
      _nextHandler.HandleRequest(request);
    }
  }
}

public class GeneralSupportHandler : SupportHandler
{
  public override void HandleRequest(SupportRequest request)
  {
    // GeneralSupportHandler is the end of the chain in this example.
    WriteLine($"General Support handling request: {request.Description}");
  }
}
```

Now, set up the chain and process some requests, as shown in the following code:
```cs
// Set up the chain.
TechnicalSupportHandler technical = new();
BillingSupportHandler billing = new();
GeneralSupportHandler general = new();

technical.SetNextHandler(billing);
billing.SetNextHandler(general);

// Create some requests.
List<SupportRequest> requests = new()
{
  new("Technical", "My computer is not turning on."),
  new("Billing", "I have been overcharged."),
  new("General", "I have a question about your product.")
};

// Process the requests.
foreach (SupportRequest request in requests)
{
  technical.HandleRequest(request);
}
```

In this example, requests are passed through a chain of handlers (`TechnicalSupportHandler`, `BillingSupportHandler`, `GeneralSupportHandler`). Each handler has a chance to process the request if it matches their responsibility, otherwise, they pass the request along to the next handler in the chain. This decouples the sender of the request from the receivers, providing flexibility in distributing responsibilities among objects.

The Chain of Responsibility pattern is useful for scenarios where multiple objects can handle a request, but the handler doesn't need to be a specific object. This pattern promotes loose coupling and is often used in conjunction with composite objects, where an object's parent can act as its successor.

[Previous: Visitor](visitor.md) | [Parent: Behavioral patterns](behavioral.md) | [Next: Template Method](template-method.md)
