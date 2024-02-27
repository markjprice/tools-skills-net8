namespace Packt.Shared;

// System under test (SUT)
public class Calculator
{
  // Method under test (MUT)
  public double Add(double number1, double number2)
  {
    return number1 + number2; // Deliberate bug!
  }
}
