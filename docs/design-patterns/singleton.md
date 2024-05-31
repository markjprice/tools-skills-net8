# Singleton pattern

The Singleton pattern ensures that a class has only one instance and provides a global point of access to that instance. It's a conceptually simple pattern, but it's tricky to implement in a thread-safe manner.

## Singleton pattern requirements

To implement the Singleton pattern correctly, a few key requirements must be met:
- **Single Instance**: The class must ensure that only one instance of the class is created. This is useful when exactly one object is needed to coordinate actions across the system. In .NET, this is typically enforced by making the class constructor private, which prevents external instantiation.
- **Global Access**: There must be a well-defined access point that allows clients to access the unique instance of the class. This is usually implemented via a static method or property on the Singleton class itself.
- **Thread Safety**: In a multithreaded application, the Singleton must be implemented in a way that ensures that the class is thread-safe. This means that it must guarantee that only one instance is created even when multiple threads are attempting to create the instance simultaneously. This is typically achieved through synchronization techniques or static initialization.
- **Lazy Initialization** (optional but recommended): Ideally, the Singleton should not be created until it's needed. This is known as lazy initialization and helps to reduce resource usage and ensure that the instance is created when the application is in a state to properly do so. However, this is not a strict requirement for the pattern; it's more of an optimization.

## Singleton pattern example

In .NET, a common way to implement the Singleton pattern is by using a static property to manage the instance, combined with a private constructor to prevent other classes from instantiating it directly. This technique is now discouraged, and it is better to use DI instead as you will see later in this section. But it is important to recognize the classic way of doing it so you can replace it with something better!

In a multithreaded environment, we need a thread-safe version, as shown in the following code:
```cs
public class Singleton
{
  // 'volatile' ensures that assignment to the instance variable
  // completes before the instance variable can be accessed.
  private static volatile Singleton _instance;
  private static object _syncRoot = new Object();

  private Singleton() { }

  public static Singleton Instance
  {
    get
    {
      // Double-check locking mechanism.
      if (_instance is null)
      {
        lock (_syncRoot)
        {
          if (_instance == null)
          {
            _instance = new Singleton();
          }
        }
      }
      return _instance;
    }
  }
}
```

This example includes the basic elements needed to enforce the Singleton pattern:
- A private constructor prevents the direct instantiation of the class.
- A private static variable holds the instance of the Singleton. The `_instance` field is marked as volatile, which ensures that memory writes to that field are immediately visible to other threads.
- A public static property named `Instance` provides the global access point. It includes a check to ensure the instance is created only when needed so this is an example of lazy initialization and uses locking to ensure thread safety.

To use the Singleton, you simply access its Instance property, as shown in the following code:
```cs
Singleton singletonInstance = Singleton.Instance;
```

This approach ensures that you always have access to the same instance of the `Singleton` class throughout your application, making the Singleton pattern an effective way to manage shared resources or coordinate actions across the system.

## Singleton pattern .NET BCL example

In the .NET Base Class Library (BCL), the Singleton pattern is not explicitly implemented in the way academics describe it. However, several classes exhibit behavior like the Singleton pattern, primarily because they are designed to provide a single, globally accessible instance or a central point of access. One classic example is the `System.Diagnostics.Trace` class.

The `System.Diagnostics.Trace` class is used for emitting debugging and tracing information. It behaves like a Singleton in the sense that its methods are static and it's globally accessible. However, it doesn't limit instantiation of itself because it doesn't need to be instantiated to be used. 

It's important to differentiate between the Singleton pattern, which restricts instantiation of a class to one object, and the use of static classes or members, which provide global access without instantiation. In practice, .NET favors the latter approach for most of its framework design, particularly for utility and helper classes where global access without the overhead of object instantiation is desired.

## Singleton pattern ASP.NET Core example

In ASP.NET Core and third-party libraries for .NET, the Singleton pattern is commonly encountered in the context of dependency injection (DI). ASP.NET Core's built-in DI container allows developers to configure services with various lifetimes, including Singleton. When a service is registered as a Singleton in ASP.NET Core, the DI container ensures that only one instance of the service is created and shared across the entire application. This aligns closely with the traditional Singleton pattern's goal of limiting a class to a single instance.

In ASP.NET Core, you might register a service as a Singleton, as shown in the following code:
```cs
// Registering a service as a Singleton.
services.AddSingleton<IMySingletonService, MySingletonService>();
```
In this example, `IMySingletonService` is an interface, and `MySingletonService` is a class that implements this interface. The `AddSingleton` method is used to register `MySingletonService` as a Singleton. This means that the first time `IMySingletonService` is requested, the DI container will create an instance of `MySingletonService` and then provide this same instance for every subsequent request in the application.

## Singleton pattern third-party example

Serilog is a popular third-party library for logging in .NET applications, and it often uses the Singleton pattern, or at least a similar concept, especially when configuring the static logger. When you set up Serilog, you typically configure a static logger instance at the application's start, which then acts as a Singleton throughout your application.

## Singleton pattern and DI

In the .NET ecosystem, third-party libraries that implement specific functionality often avoid providing their functionality through a strict Singleton pattern. However, many libraries are designed to be easily used as Singletons, especially when integrated with dependency injection (DI) frameworks, like the built-in DI container in ASP.NET Core, which manages object lifetimes including Singleton lifetimes.
A built-in base class library or a third-party library that enforces its use strictly as a Singleton is rare because it imposes a usage pattern that might not align with all consumers' architectural decisions. For instance, a logging library or a configuration library might be typically used as a Singleton, but it's the application's responsibility (or the DI container's responsibility) to ensure that it's only instantiated once.
In modern .NET applications, especially those built with .NET Core or ASP.NET Core, the preferred way to enforce Singleton behavior is through the application's dependency injection container. For instance, when registering services in an ASP.NET Core application, specifying the service lifetime as Singleton ensures that only one instance of the service is created and shared.
This approach is preferred over implementing the Singleton pattern directly within the class because it provides more flexibility, allowing the application to control the instantiation and lifecycle of the class, and it integrates cleanly with the application's overall architecture.

> **Good Practice**: Implementing the Singleton pattern is almost never done by third-party or BCL library types. You should only implement the Singleton pattern in your own projects that need it, not in any shared libraries. Instead, design your libraries to allow the consumer to choose to register your type as a singleton using DI.
