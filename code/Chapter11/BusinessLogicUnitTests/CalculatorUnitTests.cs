using Packt.Shared; // To use Calculator.
using Xunit.Abstractions; // To use ITestOutputHelper.

namespace BusinessLogicUnitTests;

public class CalculatorUnitTests : IDisposable
{
  private readonly Calculator _sut;
  private readonly ITestOutputHelper _output;

  public CalculatorUnitTests(ITestOutputHelper output)
  {
    _sut = new();
    _output = output;

    _output.WriteLine("Constructor runs before each test.");
  }

  [Fact]
  public void TestAdding2And2()
  {
    _output.WriteLine($"Running {nameof(TestAdding2And2)}.");

    // Arrange: Set up the inputs, output, and the SUT.
    double number1 = 2;
    double number2 = 2;
    double expected = 4;
    // Calculator sut = new();

    // Act: Execute the MUT.
    double actual = _sut.Add(number1, number2);

    // Assert: Make assertions to compare expected to actual results.
    Assert.Equal(expected, actual);
  }

  [Fact(Timeout = 3000)] // 3 seconds.
  public void TestAdding2And3()
  {
    _output.WriteLine($"Running {nameof(TestAdding2And3)}.");

    // Arrange: Set up the inputs, output, and the SUT.
    double number1 = 2;
    double number2 = 3;
    double expected = 5;
    // Calculator sut = new();

    // Act: Execute the MUT.
    double actual = _sut.Add(number1, number2);

    // Assert: Make assertions to compare expected to actual results.
    Assert.Equal(expected, actual);
  }

  [Theory]
  // [InlineData(4, 2, 2)]
  // [InlineData(5, 2, 3)]
  // [ClassData(typeof(AddingNumbersData))]
  [MemberData(memberName: nameof(GetTestData))]
  public void TestAdding(double expected, 
    double number1, double number2)
  {
    _output.WriteLine($"Running {nameof(TestAdding)}.");
    _output.WriteLine($"  {nameof(number1)}: {number1}");
    _output.WriteLine($"  {nameof(number2)}: {number2}");
    _output.WriteLine($"  {nameof(expected)}: {expected}");

    // Arrange: Set up the SUT.
    // Calculator sut = new();

    // Act: Execute the MUT.
    double actual = _sut.Add(number1, number2);

    // Assert: Make assertions to compare expected to actual results.
    Assert.Equal(expected, actual);
  }

  public static IEnumerable<object[]> GetTestData()
  {
    // Simplify using C# 12 or later collection syntax.
    return [ [4, 2, 2], [5, 2, 3] ];

    /*
    // Test adding 2 and 2 to give 4.
    yield return new object[] { 4, 2, 2 };

    // Test adding 2 and 3 to give 5.
    yield return new object[] { 5, 2, 3 };
    */
  }

  public void Dispose()
  {
    // Cleanup the _sut if necessary.

    _output.WriteLine("Dispose runs after each test.");
  }
}
