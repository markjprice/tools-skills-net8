# Bridge pattern

The Bridge pattern decouples an abstraction from its implementation so that the two can vary independently. This pattern is particularly useful when both the abstraction and its implementation can have multiple variations. 

By separating the abstraction from its implementation, you can modify, extend, and mix them without affecting each other. It’s akin to having a remote control (the abstraction) that can be programmed to control various devices (the implementations) like TVs, stereos, or lights, allowing for flexibility in how the controls are used without changing the remote's interface.

Let's consider an example where you have a report generating system. The system can generate reports in different formats (like PDF, HTML) and might retrieve data from various sources (like a database or a web service). Using the Bridge pattern, you can separate the report generation logic (the abstraction) from the data access logic (the implementation).

You can define these components, as shown in the following code:
```cs
// The abstraction for report generation.
public abstract class Report
{
  protected IDataSource _dataSource;

  public Report(IDataSource dataSource)
  {
    _dataSource = dataSource;
  }

  public abstract void GenerateReport();
}

// Refined abstraction for a specific type of report.
public class SalesReport : Report
{
  public SalesReport(IDataSource dataSource) : base(dataSource) { }

  public override void GenerateReport()
  {
    string data = _dataSource.GetData();
    WriteLine($"Generating sales report with data: {data}");
    // Implement the logic to generate a sales report
  }
}
```

Implementations of the Bridge pattern, as shown in the following code:
```cs
// Implementor interface.
public interface IDataSource
{
  string GetData();
}

// Concrete implementor for a database source.
public class DatabaseSource : IDataSource
{
  public string GetData()
  {
    return "Data from database";
    // Implement data fetching logic from a database
  }
}

// Concrete implementor for a web service source.
public class WebServiceSource : IDataSource
{
  public string GetData()
  {
    return "Data from web service";
    // Implement data fetching logic from a web service
  }
}
```

Now we can use the Bridge pattern, as shown in the following code:
```cs
// Create an instance of the concrete implementor.
IDataSource dataSource = new DatabaseSource();
// Pass the implementor to the abstraction
Report report = new SalesReport(dataSource);
report.GenerateReport();

// Easily switch to a different data source without changing the report logic.
IDataSource anotherDataSource = new WebServiceSource();
Report anotherReport = new SalesReport(anotherDataSource);
anotherReport.GenerateReport();
```

In this example, `Report` is the abstraction, and `IDataSource` is the implementer interface. `SalesReport` extends `Report` to provide concrete functionality for generating a sales report, but it doesn't care about how or where the data comes from. The data could come from a `DatabaseSource` or a `WebServiceSource`, which are concrete implementations of the `IDataSource` interface. This separation allows you to add new types of reports or new data sources without altering existing classes, adhering to OCP in SOLID.
