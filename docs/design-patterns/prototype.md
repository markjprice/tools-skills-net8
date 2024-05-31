# Prototype pattern

The Prototype pattern is used when the creation of an object directly is costlier than copying an existing instance with some modifications. This pattern involves creating new objects by copying a prototype instance, thereby reducing the overhead of new instantiation and allowing for more efficient object creation.

In .NET, this can be particularly useful when you're dealing with complex object creation that involves expensive operations like database queries, file I/O, or extensive configuration, and you have objects that are similar but need slight variations.

The Prototype pattern typically requires an interface that supports cloning, often implemented in .NET through the `ICloneable` interface. However, it's worth noting that `ICloneable` does not specify deep vs. shallow copy, leading to potential confusion. As a best practice, it's often recommended to implement your own cloning mechanism where you can explicitly control the copying process and choose between deep vs. shallow cloning.

## Prototype pattern example

Let's illustrate this with an example of a complex `User` object that includes reference types. We'll explicitly implement deep copy logic to ensure all object references are cloned properly, avoiding the pitfalls of shallow copying.

First, let's define the User class, as shown in the following code:
```cs
public class User : ICloneable
{
  public string Name { get; set; }
  public int Age { get; set; }
  public Address Address { get; set; }  // Reference type property.

  public object Clone()
  {
    // Shallow copy of the current object.
    User clone = (User)this.MemberwiseClone();

    // Deep copy of the Address.
    clone.Address = new Address(Address.Street, Address.City); 

    return clone;
  }
}

public class Address
{
  public string Street { get; set; }
  public string City { get; set; }

  public Address(string street, string city)
  {
    Street = street;
    City = city;
  }
}
```

In this example, `User` implements `ICloneable`, and the `Clone` method is overridden to ensure a deep copy. This means that when `Clone` is called, not only is the `User` object itself cloned, but all its reference type fields (in this case, `Address`) are also cloned. This prevents the cloned `User` from sharing reference type fields with the original `User`, a common issue with shallow copying.

Now, we can clone the `User` object, as shown in the following code:
```cs
User originalUser = new User { Name = "John Doe", Age = 30,
  Address = new Address("123 Main St", "Anytown") };
User clonedUser = (User)originalUser.Clone();

clonedUser.Name = "Jane Doe";
clonedUser.Address.Street = "456 Elm St";

WriteLine($"Original Name: {originalUser.Name}, Original Address: {originalUser.Address.Street}");
WriteLine($"Cloned Name: {clonedUser.Name}, Cloned Address: {clonedUser.Address.Street}");
```

Shallow copying duplicates only the top-level object, while deep copying involves duplicating every object it references, recursively. In this example, deep copying is crucial to ensure that the cloned User has its own independent `Address`.

The Prototype pattern, especially with custom deep copy logic, provides a powerful mechanism for efficiently creating complex objects that are based on existing instances. This pattern is particularly useful in .NET applications where object creation is expensive or requires a high degree of customization.

## Prototype pattern .NET BCL example

The Prototype pattern, as formally defined, is not explicitly showcased in the .NET BCL through a dedicated mechanism or interface that highlights its use. The closest concept within .NET BCL related to the Prototype pattern is the `ICloneable` interface, which provides a mechanism for objects to return a clone of themselves. 

However, it's worth noting that `ICloneable` has been critiqued for not specifying whether the cloning should be deep or shallow, leaving ambiguity in its implementation. Despite this, some .NET classes implement `ICloneable`, allowing them to be used in a manner consistent with the Prototype pattern.

In the .NET BCL, examples of `ICloneable` usage have become less common due to the mentioned ambiguity and the potential for confusion over clone types. While the Prototype pattern, as a distinct and explicit pattern, is not widely showcased through dedicated interfaces or classes in ASP.NET Core or common third-party libraries, its principles are still applied.
