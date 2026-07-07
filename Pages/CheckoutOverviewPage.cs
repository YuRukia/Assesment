using Microsoft.Playwright;
using Config;

namespace Pages;

public class CheckoutOverviewPage : BasePage
{
    private readonly string url = getUrl() + "/checkout-step-two.html";

    public async Task ConfirmCheckout(IPage page, List<Product> purchases)
    {
        double itemTotal = 0;
        foreach(var purchase in purchases)
        {
            itemTotal += double.Parse(purchase.Cost);
            ILocator name = page.Locator("[data-test='inventory-item']").GetByText(purchase.Name);
            ILocator parent = name.Locator("..").Locator("..").Locator("..");
            ILocator cost = parent.GetByText(purchase.Cost);
            ILocator description = parent.GetByText(purchase.Description);
            ILocator quantity = parent.Locator("[data-test='item-quantity']");

            await CheckInnerText(name, purchase.Name);
            await CheckInnerText(cost, purchase.Cost);
            await CheckInnerText(description, purchase.Description);
            await CheckInnerText(quantity, "1");
        }

        ILocator itemTotalLocator = page.Locator("[data-test='subtotal-label']");
        ILocator TaxLocator = page.Locator("[data-test='tax-label']");
        ILocator totalLocator = page.Locator("[data-test='total-label']");

        double taxAmount = Math.Round(itemTotal * 0.08, 2);
        double totalAmount = itemTotal + taxAmount;

        await CheckInnerText(itemTotalLocator, itemTotal.ToString());
        await CheckInnerText(TaxLocator, taxAmount.ToString());
        await CheckInnerText(totalLocator, totalAmount.ToString());

        await FinishCheckout(page);
    }

    public async Task FinishCheckout(IPage page)
    {
        ILocator finishButton = page.Locator("[data-test='finish']");
        await ClickElement(finishButton);
        await Expect(page).ToHaveURLAsync(getUrl() + "/checkout-complete.html");
    }
}