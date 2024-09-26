**Errata** (3 items)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/tools-skills-net8/issues) or email me at markjprice (at) gmail.com.

- [Breaking change in Aspire 8.2](#breaking-change-in-aspire-82)
- [Renaming "Components" to "Integrations" in Aspire 8.2 and later](#renaming-components-to-integrations-in-aspire-82-and-later)
- [Page 285 - Encrypting symmetrically with AES](#page-285---encrypting-symmetrically-with-aes)

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
