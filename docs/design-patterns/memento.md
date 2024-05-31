# Memento pattern

The Memento pattern allows an object to save its state so that it can be restored to this state at a later time. This pattern is particularly useful for implementing features such as undo mechanisms in applications. 

The pattern involves three key roles:
- **Originator**: The object whose state needs to be saved and restored.
- **Memento**: An object that stores the state of the originator. It’s a value object with no behavior, only data, so it is often implemented as a record in C#.
- **Caretaker**: Manages the memento. It keeps track of the originator's state but does not modify it directly.

The Memento pattern provides a way to encapsulate and save the internal state of an object without exposing its internal structure. The saved state can be kept either by the originator or by another object (the caretaker), and can be restored without violating encapsulation.

Let’s create a simple example to demonstrate how you can use the Memento pattern to implement an undo functionality in a text editor.

First, define the Memento class which will store the state, as shown in the following code:
```cs
public class EditorMemento
{
  public string Content { get; private set; }

  public EditorMemento(string content)
  {
    Content = content;
  }
}
```

Next, implement the Originator class, which in this case is a text editor, as shown in the following code:
```cs
public class TextEditor
{
  private string _content;

  public void SetContent(string content)
  {
    _content = content;
  }

  public EditorMemento Save()
  {
    return new EditorMemento(_content);
  }

  public void Restore(EditorMemento memento)
  {
    _content = memento.Content;
  }

  public void PrintContent()
  {
    WriteLine(_content);
  }
}
```

Finally, the `Caretaker` class, which manages the mementos (in this case, this could be the undo feature), is shown in the following code:
```cs
public class Caretaker
{
  private Stack<EditorMemento> _history = new();
  private TextEditor _editor;

  public Caretaker(TextEditor editor)
  {
    _editor = editor;
  }

  public void Backup()
  {
    _history.Push(_editor.Save());
  }

  public void Undo()
  {
    if (_history.Count == 0) return;

    EditorMemento memento = _history.Pop();
    _editor.Restore(memento);
  }
}
```

Now, let's see how these components work together, as shown in the following code:
```cs
TextEditor editor = new();
Caretaker caretaker = new(editor);

editor.SetContent("First Sentence.");
caretaker.Backup();

editor.SetContent("Second Sentence.");
caretaker.Backup();

editor.SetContent("Third Sentence.");

editor.PrintContent(); // Outputs: Third Sentence.
caretaker.Undo();

editor.PrintContent(); // Outputs: Second Sentence.
caretaker.Undo();

editor.PrintContent(); // Outputs: First Sentence.
```

In this example, the `TextEditor` class is the Originator, which can create a memento of its current state and restore its state from a memento. The `EditorMemento` class is the Memento that stores the state of the `TextEditor`. The `Caretaker` class (which manages undo operations here) requests a save from the `TextEditor` before changing its state and uses the saved mementos to revert the `TextEditor`'s state to a previous state.

This setup enables the implementation of undo functionality while adhering to the principle of encapsulation. The internal state of the `TextEditor` is never exposed outside of the object itself, yet it can still be saved and restored by the caretaker.
