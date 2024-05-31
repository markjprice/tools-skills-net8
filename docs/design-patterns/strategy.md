# Strategy pattern

The Strategy pattern enables an algorithm's behavior to be selected at runtime. Essentially, the pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. Strategy lets the algorithm vary independently from clients that use it. This is particularly useful when you have several different ways of doing something, and you want to be able to switch between those methods easily without changing the objects that use them.

Components of the Strategy Pattern:
- **Strategy**: This defines the interface common to all supported algorithms. Context uses this interface to call the algorithm defined by Concrete Strategies.
- **Concrete Strategies**: Implements different variations of an algorithm the Strategy interface defines.
- **Context**: Contains a reference to a Strategy object. It might define an interface that lets Strategy access its data.

Imagine we're building a navigation application where the route calculation can vary greatly depending on the mode of transportation, for example, driving, biking, public transport.

First, define the Strategy interface, which in this case is the route calculation algorithm for different modes of transportation, as shown in the following code:
```cs
public interface IRouteStrategy
{
  string CalculateRoute(string origin, string destination);
}
```

Next, implement a couple of Concrete Strategies for different modes of transportation, as shown in the following code:
```cs
public class DrivingStrategy : IRouteStrategy
{
  public string CalculateRoute(string origin, string destination)
  {
    return $"Driving route from {origin} to {destination}";
  }
}

public class BikingStrategy : IRouteStrategy
{
  public string CalculateRoute(string origin, string destination)
  {
    return $"Biking route from {origin} to {destination}";
  }
}

public class PublicTransportStrategy : IRouteStrategy
{
  public string CalculateRoute(string origin, string destination)
  {
    return $"Public transport route from {origin} to {destination}";
  }
}
```

Then, define the Context class that will use these strategies, as shown in the following code:
```cs
public class Navigator
{
  private IRouteStrategy _routeStrategy;

  public Navigator(IRouteStrategy routeStrategy)
  {
    _routeStrategy = routeStrategy;
  }

  public void SetRouteStrategy(IRouteStrategy routeStrategy)
  {
    _routeStrategy = routeStrategy;
  }

  public void Navigate(string origin, string destination)
  {
    string route = _routeStrategy.CalculateRoute(origin, destination);
    WriteLine(route);
  }
}
```

Finally, demonstrate how to use the Context with different strategies, as shown in the following code:
```cs
string origin = "Home";
string destination = "Work";

Navigator navigator = new(new DrivingStrategy());
navigator.Navigate(origin, destination); // Use driving strategy.

navigator.SetRouteStrategy(new BikingStrategy());
navigator.Navigate(origin, destination); // Switch to biking strategy.

navigator.SetRouteStrategy(new PublicTransportStrategy());
navigator.Navigate(origin, destination); // Switch to public transport strategy.
```

In this example, `Navigator` acts as the Context, and it can use different IRouteStrategy implementations to calculate routes. This design allows for the route calculation strategy to be switched at runtime depending on the user's preferences or conditions without changing the `Navigator` class.

The Strategy pattern is powerful for scenarios where you need to dynamically change the behavior of an object. It adheres to OCP, one of the SOLID principles, enabling the extension of object behavior without modifying the object itself. This makes the system more flexible and easier to maintain and extend.
