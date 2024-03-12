using BenchmarkDotNet.Attributes; // To use [Benchmark].

public class FibonacciBenchmarks
{
  private const long n = 10;

  public long RecursiveFibonacci(long n)
  {
    if (n <= 0) return 0;
    if (n == 1) return 1;
    return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
  }

  [Benchmark(Baseline = true)]
  public long RecursiveTest()
  {
    return RecursiveFibonacci(n);
  }

  public static long BinetsFibonacci(long n)
  {
    double sqrt5 = Math.Sqrt(5);
    double phi = (1 + sqrt5) / 2;
    double psi = (1 - sqrt5) / 2;

    return (long)((Math.Pow(phi, n) - Math.Pow(psi, n)) / sqrt5);
  }

  [Benchmark]
  public long BinetsTest()
  {
    return BinetsFibonacci(n);
  }
}
