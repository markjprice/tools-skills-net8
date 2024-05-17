using Microsoft.Playwright; // To use Playwright, IBrowser, and so on.
using static Microsoft.Playwright.Assertions; // To use Expect.

namespace WebUITests;

public class eShopWebUITests
{
  private IBrowser? _browser;
  private IBrowserContext? _session;
  private IPage? _page;
  private IResponse? _response;

  private async Task GotoHomePage(IPlaywright playwright)
  {
    _browser = await playwright.Chromium.LaunchAsync(
      new BrowserTypeLaunchOptions { Headless = true });

    _session = await _browser.NewContextAsync();
    _page = await _session.NewPageAsync();
    _response = await _page.GotoAsync("https://localhost:5001/");
  }

  [Fact]
  public async void HomePage_Title()
  {
    // Arrange: Launch Chrome browser and navigate to home page.
    // using to make sure Dispose is called at the end of the test.
    using IPlaywright? playwright = await Playwright.CreateAsync();
    await GotoHomePage(playwright);

    string actualTitle = await _page.TitleAsync();

    // Assert: Navigating to home page worked and its title is as expected.
    string expectedTitle = "Catalog - Microsoft.eShopOnWeb";
    Assert.NotNull(_response);
    Assert.True(_response.Ok);
    Assert.Equal(expectedTitle, actualTitle);

    // Universal sortable ("u") format: 2009-06-15 13:45:30Z
    // : and spaces will cause problems in a filename
    // so replace them with dashes.
    string timestamp = DateTime.Now.ToString("u")
      .Replace(":", "-").Replace(" ", "-");

    await _page.ScreenshotAsync(new PageScreenshotOptions
    {
      Path = Path.Combine(Environment.GetFolderPath(
        Environment.SpecialFolder.Desktop),
        $"homepage-{timestamp}.png")
    });
  }

  [Fact]
  public async void HomePage_CartEmptyAndVisible()
  {
    // Arrange: Launch Chrome browser and navigate to home page.
    using IPlaywright? playwright = await Playwright.CreateAsync();
    await GotoHomePage(playwright);

    // The only way to select the cart badge is to use a CSS selector.
    ILocator element = _page.Locator("css=div.esh-basketstatus-badge");

    // The text content will contain whitespace like \n so we 
    // must trim that away.
    string? actualCount = (await element.TextContentAsync())?.Trim();

    // Assert: Shopping cart badge is as expected.
    string expectedCount = "0";
    Assert.Equal(expectedCount, actualCount);
    await Expect(element).ToBeVisibleAsync();
  }

  [Fact]
  public async void HomePage_FilterCategories()
  {
    // Arrange: Launch Chrome browser and navigate to home page.
    using IPlaywright? playwright = await Playwright.CreateAsync();
    await GotoHomePage(playwright);

    // By default, GetByTestId looks for the data-testid attribute
    // which is not used by eShopOnWeb so we must tell Playwright
    // to use the id attribute instead.
    playwright.Selectors.SetTestIdAttribute("id");

    // Set the BRAND list box to .NET.
    ILocator brand = _page.GetByTestId("CatalogModel_BrandFilterApplied");
    await brand.SelectOptionAsync(".NET");

    // Set the TYPE list box to Mug.
    ILocator type = _page.GetByTestId("CatalogModel_TypesFilterApplied");
    await type.SelectOptionAsync("Mug");

    // Click the image to apply the filter.
    ILocator apply = _page.Locator("css=input.esh-catalog-send");
    await apply.ClickAsync();

    // Assert: One product is shown.
    ILocator topPager = _page.Locator("css=span.esh-pager-item").First;

    string? actualPager = (await topPager.TextContentAsync())?.Trim();
    string expectedPager = "Showing 1 of 1 products - Page 1 - 1";
    Assert.Equal(expectedPager, actualPager);

    string timestamp = DateTime.Now.ToString("u")
      .Replace(":", "-").Replace(" ", "-");

    await _page.ScreenshotAsync(new PageScreenshotOptions
    {
      Path = Path.Combine(Environment.GetFolderPath(
        Environment.SpecialFolder.Desktop),
        $"dotnet-mug-{timestamp}.png")
    });
  }
}