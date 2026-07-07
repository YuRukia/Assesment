using Microsoft.Playwright;
using Config;

namespace Pages;

public class CartPage : BasePage
{
    private readonly string url = getUrl() + "/cart.html";

    public async Task CheckoutCart(IPage page, List<Product> purchases)
    {
        foreach(var purchase in purchases)
        {
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

            await GoToCheckout(page);
    }

    public async Task GoToCheckout(IPage page)
    {
        ILocator checkoutButton = page.Locator("[data-test='checkout']");
        await ClickElement(checkoutButton);
        await Expect(page).ToHaveURLAsync(getUrl() + "/checkout-step-one.html");
    }
}