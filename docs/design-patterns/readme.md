# Design patterns

Design patterns are like templates for solving common problems in software design. They're not finished designs you can transform directly into code but guidelines you can follow to solve problems in a variety of contexts. Essentially, they're solutions to problems that software developers have found themselves facing repeatedly.

There are three major kinds of design patterns: creational, structural, and behavioral:
- **[Creational patterns](creational.md)** are about object creation mechanisms, in a manner suitable to the situation. The basic form of object creation could result in design problems or added complexity to the design because the developer must manually create every instance using the new keyword and then compose complex objects themselves in ways that might not be expected. Creational design patterns solve this problem by controlling this object creation. Examples include the Singleton, Factory Method, Abstract Factory, Builder, and Prototype patterns.
- **[Structural patterns](structural.md)** are about class and object composition. They help ensure that if one part of a system changes, the entire system doesn't need to do the same. They help to create a structure that promotes flexibility. Examples include the Adapter, Bridge, Composite, Decorator, Facade, Flyweight, and Proxy patterns.
- **[Behavioral patterns](behavioral.md)** are about identifying common communication patterns between objects and provide implements of them. These patterns increase flexibility in carrying out communication. Examples include the Observer, Mediator, Iterator, Strategy, Command, Memento, State, Visitor, Chain of Responsibility, and Template Method patterns.

Why use them? They can speed up the development process by providing tested, proven development paradigms. Effective software design requires considering issues that may not become visible until later in the implementation. Reusing design patterns helps to prevent subtle issues that can cause major problems later and improves code readability for coders and architects familiar with the patterns.

> **Good Practice**: Do not force patterns into your problems. Patterns are solutions to problems, not solutions looking for a problem. They should be applied judiciously and wisely. Overusing them can lead to code that's harder to understand and maintain.

Before we look at design patterns in more detail, let's review a summary of common design patterns, including a brief description, and examples of their implementation in the .NET Base Class Library, ASP.NET Core, or common third-party libraries.

First, [creational design patterns](creational.md), as shown in *Table 17.1*:

| Design Pattern          | Brief Description                                                                                   | .NET / ASP.NET Core / Third-Party Types Examples     |
|-------------------------|-----------------------------------------------------------------------------------------------------|------------------------------------------------------|
| [Singleton](singleton.md) | Ensures a class has only one instance, and provides a global point of access to it.                 | `System.Data.SqlClient.SqlConnection` (BCL, for connection pooling), `ILogger` in ASP.NET Core (when configured as singleton) |
| [Factory Method](factory-method.md) | Defines an interface for creating an object, but lets subclasses decide which class to instantiate. | `WebClient` (BCL), `HttpClientFactory` (ASP.NET Core)|
| [Abstract Factory](abstract-factory.md) | Provides an interface for creating families of related or dependent objects without specifying their concrete classes. | `DbProviderFactory` (BCL), `ILoggerFactory` (ASP.NET Core) |
| [Builder](builder.md) | Separates the construction of a complex object from its representation, allowing the same construction process to create various representations. | `StringBuilder` (BCL), `WebHostBuilder` (ASP.NET Core) |
| [Prototype](prototype.md) | Creates new objects by copying an existing object, known as the prototype.                          | `ICloneable` (BCL)                                    |

*Table 17.1: Creational design patterns, concepts, and usage in .NET*

Next, [structural design patterns](structural.md), as shown in *Table 17.2*:

| Design Pattern          | Brief Description                                                                                   | .NET / ASP.NET Core / Third-Party Types Examples     |
|-------------------------|-----------------------------------------------------------------------------------------------------|------------------------------------------------------|
| [Adapter](adapter.md) | Allows incompatible interfaces to work together. Uses a 'wrapper' to translate calls to an interface into a different interface. | `StreamAdapter` (BCL), Various ORM adapters like `Dapper`|
| [Bridge](bridge.md) | Decouples an abstraction from its implementation, allowing the two to vary independently.          | `DbConnection` (BCL), `ILogger` (ASP.NET Core)       |
| [Composite](composite.md) | Composes objects into tree structures to represent part-whole hierarchies, allowing clients to treat individual objects and compositions uniformly. | `DirectoryInfo` (BCL), `IApplicationBuilder` (ASP.NET Core) |
| [Decorator](decorator.md) | Allows behavior to be added to an individual object, either statically or dynamically, without affecting the behavior of other objects from the same class. | `Stream` (BCL, e.g., `FileStream`, `MemoryStream`), `Middleware` in ASP.NET Core |
| [Façade](facade.md) | Provides a simplified interface to a complex subsystem.                                            | `HttpClient` (BCL), `WebClient` (BCL)                |
| [Flyweight](flyweight.md) | Minimizes memory usage or computational expenses by sharing as much as possible with similar objects. | `String.Intern` (BCL)                                |
| [Proxy](proxy.md) | Provides a surrogate or placeholder for another object to control access to it.                     | `WCF Proxy` (BCL), `IActionResult` in ASP.NET Core for action result proxies |

*Table 17.2: Structural design patterns, concepts, and usage in .NET*

Next, [behavioral design patterns](behavioral.md), as shown in *Table 17.3*:

| Design Pattern          | Brief Description                                                                                   | .NET / ASP.NET Core / Third-Party Types Examples     |
|-------------------------|-----------------------------------------------------------------------------------------------------|------------------------------------------------------|
| [Observer](observer.md) | Defines a dependency between objects so that when one object changes state, all its dependents are notified and updated automatically. | `IObservable<T>` / `IObserver<T>` (BCL), `INotifyPropertyChanged` (BCL) |
| [Mediator](mediator.md) | Reduces coupling between classes communicating with each other by having them communicate indirectly through a mediator object. | `IMediator` in MediatR (Third-party)                |
| [Iterator](iterator.md) | Provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation. | `IEnumerable` / `IEnumerator` (BCL)                 |
| [Strategy](strategy.md) | Defines a family of algorithms, encapsulates each one, and makes them interchangeable. Strategy lets the algorithm vary independently from clients that use it. | `IComparer` / `IComparable` (BCL)                   |
| [Command](command.md) | Encapsulates a request as an object, thereby allowing for parameterization of clients with queues, requests, and operations. | `ICommand` in WPF (BCL), `CommandHandler` in MediatR |
| [Memento](memento.md) | Without violating encapsulation, capture and externalize an object's internal state so that the object can be returned to this state later. | `DataContractSerializer` (BCL) for state snapshot  |
| State                   | Allows an object to alter its behavior when its internal state changes. The object will appear to change its class. | `StateServerMode` in ASP.NET (BCL)                  |
| [Visitor](visitor.md) | Represents an operation to be performed on elements of an object structure. Visitor lets a new operation be defined without changing the classes of the elements on which it operates. | `ExpressionVisitor` (BCL)                           |
| [Chain of Responsibility](chain-of-responsibility.md) | Passes the request along a chain of handlers. Upon receiving the request, each handler decides either to process the request or to pass it to the next handler in the chain. | `DelegatingHandler` in HttpClient (ASP.NET Core), Middleware in ASP.NET Core |
| [Template Method](template-method.md) | Defines the skeleton of an algorithm in the superclass but lets subclasses override specific steps of the algorithm without changing its structure. | `Stream` (BCL, with methods like `Read` and `Write` that subclasses implement), `ControllerBase` in ASP.NET Core (with action methods overridden in derived controllers) |

*Table 17.3: Behavioral design patterns, concepts, and usage in .NET*
