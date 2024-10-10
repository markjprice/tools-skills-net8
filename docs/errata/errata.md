**Errata** (10 items)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/tools-skills-net8/issues) or email me at markjprice (at) gmail.com.

- [Breaking change in Aspire 8.2](#breaking-change-in-aspire-82)
- [Renaming "Components" to "Integrations" in Aspire 8.2 and later](#renaming-components-to-integrations-in-aspire-82-and-later)
- [Page 285 - Encrypting symmetrically with AES](#page-285---encrypting-symmetrically-with-aes)
- [Page 341 - OllamaSharp .NET package](#page-341---ollamasharp-net-package)
- [Page 356 - Registering multiple implementations](#page-356---registering-multiple-implementations)
- [Page 388 - Creating a SUT, Page 401 - Controlling test fixtures](#page-388---creating-a-sut-page-401---controlling-test-fixtures)
- [Page 392 - Test methods with parameters](#page-392---test-methods-with-parameters)
- [Page 415 - Generating fake data with Bogus](#page-415---generating-fake-data-with-bogus)
- [Page 427 - Walkthrough of an example integration test](#page-427---walkthrough-of-an-example-integration-test)
- [Page 509 - Generating tests with the Playwright Inspector](#page-509---generating-tests-with-the-playwright-inspector)

# Breaking change in Aspire 8.2

To use .NET Aspire 8.2, you will need to make sure that you have the latest version of the workload installed as well as make sure that your AppHost project references the latest version of the `Aspire.Hosting.AppHost` package. Otherwise, you may see a build error similar to this:
```
xxx.AppHost is a .NET Aspire AppHost project that needs a package reference to Aspire.Hosting.AppHost version 8.2.0 or above to work correctly.
```

To fix it, make sure that your AppHost project file contains the following package reference:
```xml
<PackageReference Include="Aspire.Hosting.AppHost" Version="8.2.0" />
```

Learn more about this breaking change at the following link: https://github.com/dotnet/aspire/issues/5501.

# Renaming "Components" to "Integrations" in Aspire 8.2 and later

The Aspire team has renamed "Components" to "Integrations" in Aspire 8.2 and later. You can learn more at the following link: https://devblogs.microsoft.com/dotnet/announcing-dotnet-aspire-8-2/.

# Page 285 - Encrypting symmetrically with AES

> Thanks to [P9avel](https://github.com/P9avel) for raising this [issue on September 26, 2024](https://github.com/markjprice/tools-skills-net8/issues/6).

In Step 7, in the `Decrypt` method, in the `using (MemoryStream ms = new())` code block, I call the `aes.CreateDecryptor()` method twice, as shown in the following code:
```cs
using (MemoryStream ms = new())
{
  using (ICryptoTransform transformer = aes.CreateDecryptor())
  {
    using (CryptoStream cs = new(
      ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
    {
...
```

The second call should be a reference to the `transformer` variable, as shown in the following code:
```cs
using (MemoryStream ms = new())
{
  using (ICryptoTransform transformer = aes.CreateDecryptor())
  {
    using (CryptoStream cs = new(
      ms, transformer, CryptoStreamMode.Write))
    {
...
```

# Page 341 - OllamaSharp .NET package

> Thanks to [P9avel](https://github.com/P9avel) for raising this [issue on September 29, 2024](https://github.com/markjprice/tools-skills-net8/issues/8).

In Step 2, I wrote, "add references to packages for Spectre Console and Ollama" when I should have written, "add references to packages for Spectre Console and OllamaSharp". 

# Page 356 - Registering multiple implementations

> Thanks to [P9avel](https://github.com/P9avel) for raising this [issue on October 2, 2024](https://github.com/markjprice/tools-skills-net8/issues/10).

In the first statement of the code block, I mis-cased the method name as `AddKeyedsingleton`. It should be `AddKeyedSingleton`.

# Page 388 - Creating a SUT, Page 401 - Controlling test fixtures

> Thanks to [P9avel](https://github.com/P9avel) for raising this [issue on October 2, 2024](https://github.com/markjprice/tools-skills-net8/issues/11).

In Step 2 on both pages 388 and 401, I wrote, "treat errors as errors", when I should have written "treat warnings as errors".

# Page 392 - Test methods with parameters

> Thanks to [P9avel](https://github.com/P9avel) for raising this [issue on October 2, 2024](https://github.com/markjprice/tools-skills-net8/issues/13).

In the third bullet I wrote, "Decorate the test method with `[ClassData]` and reference a method that represents an `IEnumerable` of arrays of types."

I should have written, "Decorate the test method with `[ClassData]` and reference a class that derives from `TheoryData<T1, T2, ...>` and call the inherited `Add` method in its constructor to add sets of expected parameter and return values."

# Page 415 - Generating fake data with Bogus

> Thanks to [P9avel](https://github.com/P9avel) for raising this [issue on October 3, 2024](https://github.com/markjprice/tools-skills-net8/issues/14).

In *Table 11.7*, `f.Finance.Currency().Code` should be `Finance.Currency().Code`. I don't know how the extra `f.` got there! 

# Page 427 - Walkthrough of an example integration test

> Thanks to [P9avel](https://github.com/P9avel) for raising this [issue on October 7, 2024](https://github.com/markjprice/tools-skills-net8/issues/15).

I wrote, "The preceding code is a unit test class named `GetById` ..." when I should have written, "The preceding code is an integration test class named `GetById` ..."

# Page 509 - Generating tests with the Playwright Inspector

> Thanks to [P9avel](https://github.com/P9avel) for raising this [issue on October 9, 2024](https://github.com/markjprice/tools-skills-net8/issues/16).

In the paths to "start the Playwright Inspector with emulation options like setting a view port size", I typed a slash `/` instead of a dot `.` between the `8` and `0`. For example, I typed `net8/0` instead of `net8.0`. 

