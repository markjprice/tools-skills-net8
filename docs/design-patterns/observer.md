# Observer pattern

The Observer pattern defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically. This pattern is widely used for implementing distributed event handling systems and for creating a publish/subscribe model.

In .NET, the Observer pattern can be implemented using interfaces, such as `IObservable<T>` and `IObserver<T>`, which are part of the .NET framework. However, for educational purposes, let's build a simple example from scratch to understand the core concepts.

Imagine we're building a weather station system. The weather station (the "subject") provides regular updates on weather data (like temperature, humidity, and so on), and multiple display elements (the "observers") need to show this data in different formats.

First, define the `ISubject` interface and the `IObserver` interface, as shown in the following code:
```cs
public interface ISubject
{
  void RegisterObserver(IObserver observer);
  void RemoveObserver(IObserver observer);
  void NotifyObservers();
}

public interface IObserver
{
  void Update(float temperature, float humidity, float pressure);
}
```

Next, implement the concrete Subject, as shown in the following code:
```cs
public class WeatherData : ISubject
{
  private List<IObserver> _observers;
  private float _temperature;
  private float _humidity;
  private float _pressure;

  public WeatherData()
  {
    _observers = new List<IObserver>();
  }

  public void RegisterObserver(IObserver observer)
  {
    _observers.Add(observer);
  }

  public void RemoveObserver(IObserver observer)
  {
    _observers.Remove(observer);
  }

  public void NotifyObservers()
  {
    foreach (IObserver observer in _observers)
    {
      observer.Update(temperature, humidity, pressure);
    }
  }

  public void MeasurementsChanged()
  {
    NotifyObservers();
  }

  public void SetMeasurements(float temperature, float humidity, float pressure)
  {
    _temperature = temperature;
    _humidity = humidity;
    _pressure = pressure;
    MeasurementsChanged();
  }
}
```

Now, implement a couple of concrete Observers, as shown in the following code:
```cs
public class CurrentConditionsDisplay : IObserver
{
  private float _temperature;
  private float _humidity;

  public void Update(float temperature, float humidity, float pressure)
  {
    _temperature = temperature;
    _humidity = humidity;
    Display();
  }

  public void Display()
  {
    WriteLine($"Current conditions: {temperature}F degrees and {humidity}% humidity");
  }
}

public class StatisticsDisplay : IObserver
{
  private float _maxTemp = 0.0f;
  private float _minTemp = 200;
  private float _tempSum = 0.0f;
  private int _numReadings;

  public void Update(float temperature, float humidity, float pressure)
  {
    _tempSum += temperature;
    _numReadings++;

    if (temperature > _maxTemp)
    {
      _maxTemp = temperature;
    }

    if (temperature < _minTemp)
    {
      _minTemp = temperature;
    }

    Display();
  }

  public void Display()
  {
    WriteLine($"Avg/Max/Min temperature = {tempSum / 
      numReadings}/{maxTemp}/{minTemp}");
  }
}
```

Finally, wire everything together, as shown in the following code:
```cs
WeatherData weatherData = new();

CurrentConditionsDisplay currentDisplay = new();
StatisticsDisplay statisticsDisplay = new();

weatherData.RegisterObserver(currentDisplay);
weatherData.RegisterObserver(statisticsDisplay);

weatherData.SetMeasurements(80, 65, 30.4f);
weatherData.SetMeasurements(82, 70, 29.2f);
weatherData.SetMeasurements(78, 90, 29.2f);
```

In this example, `WeatherData` acts as the Subject, maintaining a list of its Observers and notifying them of changes by calling their `Update` method. `CurrentConditionsDisplay` and `StatisticsDisplay` are concrete Observers that display the weather in different formats. When `WeatherData` receives new measurements, it notifies all registered observers, allowing them to update their displays.

The Observer pattern allows for a flexible and loosely coupled design where objects can interact without being tightly bound to each other. This pattern is particularly useful for creating event-driven systems or implementing various aspects of the model-view-controller (MVC) architectural pattern.
