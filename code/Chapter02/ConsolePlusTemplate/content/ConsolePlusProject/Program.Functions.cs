using System.Globalization;

partial class Program
{
  static void ConfigureConsole(string culture = "en-US",
    bool useComputerCulture = false)
  {
    // To enable Unicode characters like Euro symbol in the console.
    OutputEncoding = System.Text.Encoding.UTF8;

    if (!useComputerCulture)
    {
      CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
    }

    WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}");
  }
}