# Proxy pattern

The Proxy pattern provides an object that acts as a substitute or placeholder for another object. A proxy controls access to the original object, allowing you to perform something either before or after the request gets through to the original object. 

This pattern is useful in a variety of scenarios, such as lazy initialization, access control, logging, monitoring, and managing remote objects.

There are several types of proxies, including:
- **Virtual Proxy**: Lazily initializes an object.
- **Protection Proxy**: Controls access to the original object.
- **Remote Proxy**: Manages interaction with an object that resides in a different address space.
- **Smart Reference Proxy**: Performs additional actions when an object is accessed, for example, reference counting.

Imagine we have a `Document` class that contains a heavy resource-intensive object `Image`. We want to delay the loading of the Image until it's really needed, for example, only when rendering the document on screen, to improve the startup performance of our application.

First, define an interface for our image and a concrete implementation, as shown in the following code:
```cs
public interface IImage
{
  void Display();
}

public class RealImage : IImage
{
  private string _fileName;

  public RealImage(string fileName)
  {
    _fileName = fileName;
    LoadFromDisk(fileName);
  }

  private void LoadFromDisk(string fileName)
  {
    WriteLine($"Loading image {fileName} from disk...");
  }

  public void Display()
  {
    WriteLine($"Displaying image {_fileName}.");
  }
}
```

Next, implement the proxy class, as shown in the following code:
```cs
public class ImageProxy : IImage
{
  private RealImage _realImage;
  private string _fileName;

  public ImageProxy(string fileName)
  {
    _fileName = fileName;
  }

  public void Display()
  {
    if (_realImage == null)
    {
      _realImage = new RealImage(_fileName);
    }
    _realImage.Display();
  }
}
```

Finally, demonstrate how the proxy can be used, as shown in the following code:
```cs
IImage image = new ImageProxy("test_image.jpg");

WriteLine("Image object created. Image not loaded yet.");
// Image will be loaded only when it's actually needed.
image.Display(); // Loading and displaying happens here.
```

In this example, `ImageProxy` implements the same `IImage` interface as `RealImage`, acting as a stand-in for `RealImage`. The `ImageProxy` delays the creation and loading of the `RealImage` until the `Display` method is called. This approach can significantly improve the performance of your application when dealing with large numbers of resources or resources that are expensive to load.
