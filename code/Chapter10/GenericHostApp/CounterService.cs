namespace Packt.Shared;

public interface ICounterService
{
  int Counter { get; set; }

  void IncrementCounter();
}

public class CounterService : ICounterService
{
  public int Counter { get; set; } = 0;

  public void IncrementCounter()
  {
    ++Counter;
  }
}
