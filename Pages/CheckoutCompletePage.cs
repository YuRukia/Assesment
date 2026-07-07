using Microsoft.Playwright;
using Config;

namespace Pages;

public class CheckoutCompletePage : BasePage
{
    private readonly string url = getUrl() + "/checkout-complete.html";
    private readonly string orderThankText = "Thank you for your order!";

    public async Task ConfirmCheckout(IPage page)
    {
        ILocator orderThanks = page.Locator("[data-test='complete-header']");
        await CheckInnerText(orderThanks, orderThankText);
        await ReturnToHome(page);
    }

    public async Task ReturnToHome(IPage page)
    {
        ILocator finishButton = page.Locator("[data-test='back-to-products']");
        await ClickElement(finishButton);
        await Expect(page).ToHaveURLAsync(getUrl() + "/inventory.html");
    }
}