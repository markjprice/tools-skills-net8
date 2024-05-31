# Flyweight pattern

The Flyweight pattern aims to minimize memory usage or computational expenses by sharing as much as possible with related objects. It's about using sharing to support large numbers of objects efficiently. This pattern is particularly useful when a program must handle a huge number of objects with similar state, known as intrinsic state. Instead of storing identical data in each object, flyweight objects share it among themselves.

Components of the Flyweight Pattern:
- **Flyweight**: An interface through which flyweights can receive and act on extrinsic state, i.e. state that is different per instance.
- **ConcreteFlyweight**: Implements the Flyweight interface and stores intrinsic state. The intrinsic state is shared across many objects.
- **FlyweightFactory**: Creates and manages flyweight objects. Ensures that flyweights are shared properly.

Let's use a simple example where we must render a large number of squares on a screen. Each square can be of a certain color (intrinsic state), but its size and position (extrinsic states) might vary.

First, define the Flyweight interface and a ConcreteFlyweight class, as shown in the following code:
```cs
public interface ISquare
{
  void Draw(int x, int y, int size);
}

public class Square : ISquare
{
  private readonly string _color;

  public Square(string color)
  {
    _color = color;
  }

  public void Draw(int x, int y, int size)
  {
    WriteLine($"Drawing square of color {_color}, at position ({
      x},{y}) with size {size}");
  }
}
```

Next, implement the FlyweightFactory, as shown in the following code:
```cs
public class SquareFactory
{
  private readonly Dictionary<string, ISquare> _squares = new();

  public ISquare GetSquare(string color)
  {
    if (!_squares.ContainsKey(color))
    {
      _squares[color] = new Square(color);
      WriteLine($"Creating square of color {color}");
    }

    return _squares[color];
  }
}
```

Now we can use the Flyweight Pattern, as shown in the following code:
```cs
SquareFactory factory = new();

ISquare redSquare = factory.GetSquare("Red");
redSquare.Draw(1, 2, 5);

ISquare blueSquare = factory.GetSquare("Blue");
blueSquare.Draw(3, 4, 7);

ISquare redSquareAgain = factory.GetSquare("Red");
redSquareAgain.Draw(5, 6, 8);
```

In this example, the `SquareFactory` ensures that only one `Square` object is created for each color, thereby reducing the memory footprint. The `Draw` method simulates drawing a square on the screen, which accepts extrinsic states (position and size) as arguments. This allows us to share a single `Square` instance across multiple drawing operations with different positions and sizes.

The key benefit of the Flyweight pattern is its ability to save a significant amount of system resources, especially when the program requires a large number of similar objects. However, it's important to balance between the complexity it introduces and the memory optimizations it offers, applying it only when the memory savings outweigh the additional complexity.
