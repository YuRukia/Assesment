using Config;
using Constants;
using Microsoft.Playwright;
using Pages;

namespace InventoryTests;

[Trait("Category","InventoryTests")]
public class InventoryTests : Setup
{  
    string testType = "Inventory:";

    [Fact]
    public async Task AddAndRemoveItemsFromCart()
    {
        string testID = testType + "Add and Remove Items from Cart";

        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Configuration.headless, SlowMo = Configuration.slowmode });
        var page = await browser.NewPageAsync();

        try
        {
            await SetUp(page, testID, Configuration.defaultUser, Configuration.password);
            await loginPage.Login(page);
            await productsPage.AddItem(page, Configuration.products[Products.SauceLabsBackpack]);
            await productsPage.AddItem(page, Configuration.products[Products.SauceLabsBikeLight]);
            await productsPage.RemoveItem(page, Configuration.products[Products.SauceLabsBackpack]);
            await productsPage.RemoveItem(page, Configuration.products[Products.SauceLabsBikeLight]);
            await screenshotHelper.TakeScreenshot(page);
        }
        catch (Exception)
        {
            await screenshotHelper.TakeScreenshot(page);
            throw;
        }
    }
}