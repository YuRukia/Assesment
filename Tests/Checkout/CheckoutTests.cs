using Config;
using Constants;
using Microsoft.Playwright;
using Pages;

namespace CheckoutTests;

[Trait("Category","CheckoutTests")]
public class CheckoutTests : Setup
{  
    string testType = "Checkout:";
   
    [Fact]
    public async Task SuccessfulCheckout()
    {
        string testID = testType + "Successful Checkout";
        List<Product> purchases = new List<Product>
        {
            { Configuration.products[Products.SauceLabsBackpack]},
            { Configuration.products[Products.SauceLabsBikeLight]},
        };

        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Configuration.headless, SlowMo = Configuration.slowmode });
        var page = await browser.NewPageAsync();

        try
        {
            await SetUp(page, testID, Configuration.defaultUser, Configuration.password);
            await productsPage.AddToCart(page, purchases);
            await cartPage.CheckoutCart(page, purchases);
            await checkoutInformationPage.CheckoutInformation(page, new CustomerProfile());
            await checkoutOverviewPage.ConfirmCheckout(page, purchases);
            await checkoutCompletePage.ConfirmCheckout(page);
            await productsPage.Logout(page);
            await screenshotHelper.TakeScreenshot(page);
        }
        catch (Exception)
        {
            await screenshotHelper.TakeScreenshot(page);
            throw;
        }
    }
}