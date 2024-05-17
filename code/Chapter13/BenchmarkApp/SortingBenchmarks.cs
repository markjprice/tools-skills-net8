using BenchmarkDotNet.Attributes; // To use [GlobalSetup] and so on.

public class SortingBenchmarks
{
  private int[] data = null!; // Disable null warnings for data.
  private int[] dataArraySort = null!;
  private int[] dataBubbleSort = null!;

  [GlobalSetup]
  public void Setup()
  {
    // Initialize the data array with random values.
    data = new int[1000];
    for (int i = 0; i < data.Length; i++)
    {
      data[i] = Random.Shared.Next(0, 10000);
    }

    // Create copies of the data array to ensure each run uses the same unsorted data.
    dataArraySort = (int[])data.Clone();
    dataBubbleSort = (int[])data.Clone();
  }

  [Benchmark]
  public void ArraySort()
  {
    Array.Sort(dataArraySort);
  }

  [Benchmark]
  public void BubbleSort()
  {
    BubbleSort(dataBubbleSort);
  }

  private void BubbleSort(int[] array)
  {
    int n = array.Length;
    for (int i = 0; i < n - 1; i++)
    {
      for (int j = 0; j < n - i - 1; j++)
      {
        if (array[j] > array[j + 1])
        {
          // Swap array[j] and array[j + 1].
          int temp = array[j];
          array[j] = array[j + 1];
          array[j + 1] = temp;
        }
      }
    }
  }

  [GlobalCleanup]
  public void Cleanup()
  {
    // Clean up resources if necessary.
    data = [];
    dataArraySort = [];
    dataBubbleSort = [];
  }
}
