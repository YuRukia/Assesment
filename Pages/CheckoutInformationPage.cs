using Microsoft.Playwright;
using Config;

namespace Pages;

public class CheckoutInformationPage : BasePage
{
    private readonly string url = getUrl() + "/checkout-step-one.html";

    public async Task CheckoutInformation(IPage page, CustomerProfile customer)
    {
        ILocator firstName = page.Locator("[data-test='firstName']");
        ILocator lastName = page.Locator("[data-test='lastName']");
        ILocator postCode = page.Locator("[data-test='postalCode']");

        await EnterField(firstName, customer.firstName);
        await EnterField(lastName, customer.lastName);
        await EnterField(postCode, customer.postCode);
        await ContinueCheckout(page);
    }

    public async Task ContinueCheckout(IPage page)
    {
        ILocator checkoutButton = page.Locator("[data-test='continue']");
        await ClickElement(checkoutButton);
        await Expect(page).ToHaveURLAsync(getUrl() + "/checkout-step-two.html");
    }
}