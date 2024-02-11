namespace PacktLibrary;

/// <summary>
/// This class contains utility methods like <c>ConfigureConsole</c>.
/// <para>
///   Sets console encoding to UTF-8 to support special characters like Euro currency symbol, 
///   and sets the current culture to one of the following:
///   <list type="bullet">
///     <item>A default culture of <b>US English</b> (<c>en-US</c>).</item>
///     <item>A specified culture code like <i>French in France</i> (<c>fr-FR</c>).</item>
///     <item>The <u>local</u> computer's culture.</item>
///   </list>
/// </para>
/// </summary>
public class Utility
{
  /// <summary>
  /// Gets the current console culture in its native language.
  /// </summary>
  /// <returns>The current console culture as a string.</returns>
  public static string CurrentConsoleCulture()
  {
    return $"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}";
  }

  /// <summary>
  /// Configure the console to support Unicode characters and set the culture to en-US (by default), or to a specified culture, or to the local computer culture.
  /// <para>This method calls the <seealso cref="M:PacktLibrary.Utility.CurrentConsoleCulture" /> method to output the current culture.</para>
  /// </summary>
  /// <param name="culture">Set to an ISO culture code like fr-FR, en-GB, or es-AR.</param>
  /// <param name="useComputerCulture">Set to true to change the culture to the local computer's culture.</param>
  public static void ConfigureConsole(string culture = "en-US",
    bool useComputerCulture = false)
  {
    // To enable Unicode characters like Euro symbol in the console.
    OutputEncoding = UTF8;

    if (!useComputerCulture)
    {
      CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
    }

    WriteLine(CurrentConsoleCulture());
  }

  /// <summary>
  /// Write a message to the console in the specified color.
  /// </summary>
  /// <param name="text">The text of the message.</param>
  /// <param name="color">The color of the text.</param>
  public static void WriteLineInColor(string text, ConsoleColor color)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = color;
    WriteLine(text);
    ForegroundColor = previousColor;
  }
}
