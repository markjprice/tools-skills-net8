# Visitor pattern

The Visitor pattern lets you separate algorithms from the objects on which they operate. This pattern allows you to add new operations to existing object structures without modifying those structures. It's particularly useful when you have a complex object structure, like a composite object, and you wish to perform operations on the components of the object structure that depend on their concrete classes.

In the Visitor pattern, you achieve this by creating a visitor class that implements operations (visits) to be performed on the elements of the object structure. The object structure's classes then accept the visitor and call the visit method that corresponds to their class.

Components of the Visitor Pattern:
- **Visitor**: An interface or abstract class used to declare a set of visiting methods for concrete element classes.
- **ConcreteVisitor**: Classes that implement the Visitor interface and define the operations to be performed on element objects.
- **Element**: An interface or abstract class declaring an accept method that takes a visitor as an argument.
- **ConcreteElement**: Classes implementing the Element interface and defining the accept method.
- **ObjectStructure**: A class or collection that holds and manages elements. It might offer a high-level interface to allow the visitor to visit its elements.

Let's illustrate the Visitor pattern with a simple example involving different types of documents that need to be rendered into different formats.

First, define the Visitor interface and ConcreteVisitor classes, as shown in the following code:
```cs
public interface IDocumentVisitor
{
  void Visit(PlainTextDocument plainText);
  void Visit(RichTextDocument richText);
}

public class HtmlRenderer : IDocumentVisitor
{
  public void Visit(PlainTextDocument plainText)
  {
    WriteLine($"<p>{plainText.Text}</p>");
  }

  public void Visit(RichTextDocument richText)
  {
    WriteLine($"<div style='font-weight:bold'>{richText.Text}</div>");
  }
}

public class PlainTextRenderer : IDocumentVisitor
{
  public void Visit(PlainTextDocument plainText)
  {
    WriteLine(plainText.Text);
  }

  public void Visit(RichTextDocument richText)
  {
    WriteLine($"**{richText.Text}**");
  }
}
```

Next, define the Element interface and ConcreteElement classes, as shown in the following code:
```cs
public interface IDocumentElement
{
  void Accept(IDocumentVisitor visitor);
}

public class PlainTextDocument : IDocumentElement
{
  public string Text { get; set; }

  public PlainTextDocument(string text)
  {
    Text = text;
  }

  public void Accept(IDocumentVisitor visitor)
  {
    visitor.Visit(this);
  }
}

public class RichTextDocument : IDocumentElement
{
  public string Text { get; set; }

  public RichTextDocument(string text)
  {
    Text = text;
  }

  public void Accept(IDocumentVisitor visitor)
  {
    visitor.Visit(this);
  }
}
```

Finally, demonstrate using the visitor with document elements, as shown in the following code:
```cs
List<IDocumentElement> documents = new()
{
  new PlainTextDocument("This is a plain text."),
  new RichTextDocument("This is a rich text.")
};

HtmlRenderer htmlRenderer = new();
PlainTextRenderer plainTextRenderer = new();

WriteLine("HTML Rendering:");
foreach (IDocumentElement doc in documents)
{
  doc.Accept(htmlRenderer);
}

WriteLine("\nPlain Text Rendering:");
foreach (IDocumentElement doc in documents)
{
  doc.Accept(plainTextRenderer);
}
```

In this example, `IDocumentElement` is the Element interface, and `PlainTextDocument` and `RichTextDocument` are the ConcreteElements. `IDocumentVisitor` is the Visitor interface, with `HtmlRenderer` and `PlainTextRenderer` as ConcreteVisitors. The `Accept` method in each document type takes a visitor and calls its `Visit` method, passing `this` as an argument, thereby allowing the visitor to perform its operation on the element.
