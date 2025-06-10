namespace BusinessLogicUnitTests;

internal class AddingNumbersDataTyped : TheoryData<double, double, double>
{
    public AddingNumbersDataTyped()
    {
        // Test adding 2 and 2 to give 4.
        Add(4, 2, 2);
        
        // Test adding 2 and 3 to give 5.
        Add(5, 2, 3);
    }
}