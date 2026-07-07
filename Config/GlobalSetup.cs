using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using Pages;

namespace Config;

public class Setup : PageTest
{
    public Screenshot screenshotHelper;
    public BasePage basePage;
    public LoginPage loginPage;
    public ProductsPage productsPage;
    public CartPage cartPage;
    public CheckoutInformationPage checkoutInformationPage;
    public CheckoutOverviewPage checkoutOverviewPage;
    public CheckoutCompletePage checkoutCompletePage;
    public ItemPage itemPage;

    public async Task SetUp(IPage page, string testID, string user = "-1", string password = "-1")
    {
        if(user == "-1") {user = Configuration.defaultUser;}
        if(password == "-1") {password = Configuration.password;}

        screenshotHelper = new Screenshot(page, testID);
        basePage = new BasePage(user, password);
        loginPage = new LoginPage();
        productsPage = new ProductsPage();
        cartPage = new CartPage();
        checkoutInformationPage = new CheckoutInformationPage();
        checkoutOverviewPage = new CheckoutOverviewPage();
        checkoutCompletePage = new CheckoutCompletePage();
        itemPage = new ItemPage();

        await basePage.NavigateTo(page, Configuration.url);
    }
}