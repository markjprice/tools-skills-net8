# Command pattern

The Command pattern turns a request into a stand-alone object that contains all information about the request. This transformation allows you to parameterize methods with different requests, delay or queue a request's execution, and support undoable operations. 

In the Command pattern, there are several key components:
- **Command**: An interface that declares a method for executing a command.
- **ConcreteCommand**: Implements the Command interface and defines the binding between a Receiver object and an action.
- **Client**: Creates a ConcreteCommand object and sets its receiver.
- **Invoker**: Asks the command to carry out the request.
- **Receiver**: Knows how to perform the operations associated with carrying out the request.

In .NET, the Command pattern is implemented by types like WPF commanding that you can read about at the following link: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/advanced/commanding-overview.
