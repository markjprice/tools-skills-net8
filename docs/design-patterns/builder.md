# Builder pattern

The core idea of the Builder pattern is to separate the construction of a complex object from its representation, allowing the same construction process to create different representations. This is especially useful in .NET when dealing with objects that have numerous properties, some of which may be optional.

The Builder pattern is beneficial when:
- You want to avoid a constructor with too many parameters.
- You have an object that requires intricate initialization.
- You want to provide a clear API for constructing complex objects.

Typically, the Builder pattern involves the following components:
- **Product**: The object being built.
- **Builder**: An abstract interface for creating parts of a Product object.
- **ConcreteBuilder**: Implements the Builder interface, constructs and assembles parts of the product by implementing the Builder interface. Defines and keeps track of the representation it creates.
- **Director**: Constructs an object using the Builder interface.

## Builder pattern example

Let's walk through an example of the Builder pattern in .NET, where we construct a complex `UserProfile` object, as shown in the following code:
```cs
public class UserProfile
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public int Age { get; set; }
  public string Email { get; set; }
  public string Address { get; set; }
}
```

First, you would create the Builder Interface, with methods to set each of the product's properties, and a Build method to return the constructed product, as shown in the following code:
```cs
public interface IUserProfileBuilder
{
  IUserProfileBuilder SetFirstName(string firstName);
  IUserProfileBuilder SetLastName(string lastName);
  IUserProfileBuilder SetAge(int age);
  IUserProfileBuilder SetEmail(string email);
  IUserProfileBuilder SetAddress(string address);
  UserProfile Build();
}
```

Next, you would implement the Concrete Builder, as shown in the following partial code:
```cs
public class UserProfileBuilder : IUserProfileBuilder
{
  private UserProfile _userProfile = new UserProfile();

  public IUserProfileBuilder SetFirstName(string firstName)
  {
    _userProfile.FirstName = firstName;
    return this;
  }

  public IUserProfileBuilder SetLastName(string lastName)
  {
    _userProfile.LastName = lastName;
    return this;
  }

  public IUserProfileBuilder SetAge(int age)
  {
    _userProfile.Age = age;
    return this;
  }

  ...

  public UserProfile Build()
  {
    return _userProfile;
  }
}
```

Then, you could utilize the Builder, as shown in the following code:
```cs
UserProfile userProfile = new UserProfileBuilder()
  .SetFirstName("John")
  .SetLastName("Doe")
  .SetAge(30)
  .SetEmail("john.doe@example.com")
  .SetAddress("123 Main St")
  .Build();
```

In this example, `UserProfileBuilder` serves as the ConcreteBuilder that implements the `IUserProfileBuilder` interface. It provides a fluent API for setting properties of `UserProfile`, allowing for clear and flexible object creation. The `Build()` method finalizes the construction process and returns the resulting `UserProfile` object.

This pattern shines in .NET, especially with its strong typing and object-oriented features, allowing for clean, maintainable code when constructing complex objects. It avoids the need for overloaded constructors or objects with partially initialized states, making your code more intuitive and less prone to errors.

## Builder pattern ASP.NET Core and other examples

The Builder pattern is prevalent in ASP.NET Core and many third-party libraries utilized by .NET developers. Its usage is particularly evident in setting up and configuring services, middleware, and applications through fluent APIs.

In ASP.NET Core, the `WebHostBuilder` and `HostBuilder` are used to configure and launch an ASP.NET Core application. These builders allow for the fluent configuration of various aspects, such as server settings, logging, dependency injection services, and more.

ASP.NET Core also uses the Builder pattern for configuring services within the application's dependency injection container. `IServiceCollection` uses builder pattern-like methods like `AddControllersWithViews` and `AddRazorPages` to register services for the application.

Entity Framework Core utilizes the Builder pattern extensively for model configuration in the `OnModelCreating` method of the `DbContext`. This approach allows for fluent configuration of entities, relationships, and database mappings.

Serilog, a widely used logging library, also uses the Builder pattern to configure logging options through a fluent API.
