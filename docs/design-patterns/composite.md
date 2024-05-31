# Composite pattern

The Composite pattern lets you compose objects into tree structures to represent hierarchies. It allows clients to treat individual objects and compositions of objects uniformly. This pattern is particularly useful when you have an operation that needs to be performed on a group of similar objects or on a single object. With the Composite pattern, you can treat both single objects and compositions of objects the same way, which simplifies your code and makes it more flexible.

Imagine a scenario where you're building a file system representation. In this system, both files and directories can be treated as "items" that can be moved, copied, or deleted. Directories can contain files as well as other directories, but files cannot contain other items. This is a perfect scenario for the Composite pattern, as it allows you to treat both files and directories through a common interface, simplifying operations on them.

Components of the Composite Pattern:
- Component: An interface for all objects in the composition, both composite and leaf nodes.
- Leaf: Represents leaf objects in the composition. A leaf has no children.
- Composite: Defines behavior for components having children and stores child components.

First, let's define the Component interface, which will include common operations like displaying the item's name and a method to add or remove child components if applicable, as shown in the following code:
```cs
public abstract class FileSystemItem
{
  protected string Name;

  public FileSystemItem(string name)
  {
    Name = name;
  }

  public abstract void Display(int depth);
}
```

Now, we'll define Leaf (in this case, `File`) and Composite (in this case, `Directory`) classes, as shown in the following code:
```cs
public class File : FileSystemItem
{
  public File(string name) : base(name) { }

  public override void Display(int depth)
  {
    WriteLine(new String('-', depth) + Name);
  }
}

public class Directory : FileSystemItem
{
  private List<FileSystemItem> items = new List<FileSystemItem>();

  public Directory(string name) : base(name) { }

  public void Add(FileSystemItem item)
  {
    items.Add(item);
  }

  public void Remove(FileSystemItem item)
  {
    items.Remove(item);
  }

  public override void Display(int depth)
  {
    WriteLine(new String('-', depth) + Name);

    // Recursively display child nodes
    foreach (var item in items)
    {
      item.Display(depth + 2);
    }
  }
}
```

Let's see how we can use these classes to build a file system structure and display it, as shown in the following code:
```cs
Directory rootDirectory = new("root");
File file1 = new("file1.txt");
File file2 = new("file2.txt");
Directory subDirectory = new("subdirectory");

rootDirectory.Add(file1);
rootDirectory.Add(subDirectory);
subDirectory.Add(file2);

rootDirectory.Display(depth: 1);
```

In this example, both `File` and `Directory` classes extend `FileSystemItem`, making them compatible with the Composite pattern. The `Directory` class, acting as a Composite, can contain both `File` and `Directory` items, allowing you to create a tree structure. The `Display` method recursively displays the names of the items in the tree, illustrating how operations can be uniformly performed on both leaf and composite objects.
