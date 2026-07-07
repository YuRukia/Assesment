using Config;
using Constants;
using Microsoft.Playwright;

namespace ItemTests;

[Trait("Category","ItemTests")]
public class ItemTests : Setup
{  
    string testType = "Items:";

    [Fact]
    public async Task AddItemFromItemPage()
    {
        string testID = testType + "Add Item from Item Page";

        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Configuration.headless, SlowMo = Configuration.slowmode });
        var page = await browser.NewPageAsync();

        try
        {
            await SetUp(page, testID, Configuration.defaultUser, Configuration.password);
            await loginPage.Login(page);
            await productsPage.EnterItem(page, Configuration.products[Products.SauceLabsBackpack]);
            await itemPage.AddItem(page, Configuration.products[Products.SauceLabsBackpack]);
            await screenshotHelper.TakeScreenshot(page);
        }
        catch (Exception)
        {
            await screenshotHelper.TakeScreenshot(page);
            throw;
        }
    }

    [Fact]
    public async Task AddAndRemoveItemFromItemPage()
    {
        string testID = testType + "Add and Remove Item from Item Page";

        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Configuration.headless, SlowMo = Configuration.slowmode });
        var page = await browser.NewPageAsync();

        try
        {
            await SetUp(page, testID, Configuration.defaultUser, Configuration.password);
            await loginPage.Login(page);
            await productsPage.EnterItem(page, Configuration.products[Products.SauceLabsBackpack]);
            await itemPage.AddItem(page, Configuration.products[Products.SauceLabsBackpack]);
            await itemPage.RemoveItem(page, Configuration.products[Products.SauceLabsBackpack]);
            await screenshotHelper.TakeScreenshot(page);
        }
        catch (Exception)
        {
            await screenshotHelper.TakeScreenshot(page);
            throw;
        }
    }

    
    [Fact]
    public async Task RemoveItemAddedInProducts()
    {
        string testID = testType + "Remove Item Added In Products";

        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Configuration.headless, SlowMo = Configuration.slowmode });
        var page = await browser.NewPageAsync();

        try
        {
            await SetUp(page, testID, Configuration.defaultUser, Configuration.password);
            await loginPage.Login(page);
            await productsPage.AddItem(page, Configuration.products[Products.SauceLabsBackpack]);
            await productsPage.EnterItem(page, Configuration.products[Products.SauceLabsBackpack]);
            await itemPage.RemoveItem(page, Configuration.products[Products.SauceLabsBackpack]);
            await screenshotHelper.TakeScreenshot(page);
        }
        catch (Exception)
        {
            await screenshotHelper.TakeScreenshot(page);
            throw;
        }
    }
}