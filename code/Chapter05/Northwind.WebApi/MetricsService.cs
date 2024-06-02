using System.Diagnostics.Metrics; // To use Meter, Counter, and Histogram.

namespace Northwind.WebApi;

public class MetricsService
{
  private readonly Meter _meter;
  private readonly Counter<int> _requestCounter;
  private readonly Histogram<double> _requestDuration;

  public int RequestCount { get; private set; }
  public List<double> RequestDurations { get; private set; } = [];

  public MetricsService(IMeterFactory meterFactory)
  {
    _meter = meterFactory.Create("Northwind.WebApi.Metrics", "1.0");

    _requestCounter = _meter.CreateCounter<int>(name: "request_count", 
      description: "Number of requests received.");

    _requestDuration = _meter.CreateHistogram<double>(
      name: "request_duration", unit: "ms", 
      description: "Request duration in milliseconds.");
  }

  public void IncrementRequestCount()
  {
    _requestCounter.Add(1);
    RequestCount++;
  }

  public void RecordRequestDuration(double duration)
  {
    _requestDuration.Record(duration);
    RequestDurations.Add(duration);
  }
}
