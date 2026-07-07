using Microsoft.Playwright;
using Config;

namespace Pages;

public class ItemPage : BasePage
{
    public async Task AddItem(IPage page, Product purchase)
    {
        ILocator cartLocator = page.Locator("[data-test='shopping-cart-badge']");
        int cartItemCount = 0;
        if(await ElementPresent(cartLocator)){cartItemCount = int.Parse(await GetInnerText(cartLocator));}

        ILocator name = page.Locator("[data-test='inventory-item-name']");
        ILocator cost = page.Locator("[data-test='inventory-item-price']");
        ILocator description = page.Locator("[data-test='inventory-item-desc']");
        ILocator addButton = page.Locator("[data-test='add-to-cart']");
        ILocator removeButton = page.Locator("[data-test='remove']");

        await ClickElement(addButton);
        await Expect(addButton).ToHaveCountAsync(0);
        await Expect(removeButton).ToBeEnabledAsync();
        await CheckInnerText(removeButton, "Remove");

        await CheckInnerText(name, purchase.Name);
        await CheckInnerText(cost, purchase.Cost);
        await CheckInnerText(description, purchase.Description);
        await Expect(cartLocator).ToHaveTextAsync((cartItemCount + 1).ToString());
    }

    public async Task RemoveItem(IPage page, Product purchase)
    {
        ILocator cartLocator = page.Locator("[data-test='shopping-cart-badge']");
        int cartItemCount = 0;
        if(await ElementPresent(cartLocator)){cartItemCount = int.Parse(await GetInnerText(cartLocator));}

        ILocator name = page.Locator("[data-test='inventory-item-name']");
        ILocator cost = page.Locator("[data-test='inventory-item-price']");
        ILocator description = page.Locator("[data-test='inventory-item-desc']");
        ILocator addButton = page.Locator("[data-test='add-to-cart']");
        ILocator removeButton = page.Locator("[data-test='remove']");

        await ClickElement(removeButton);
        await Expect(removeButton).ToHaveCountAsync(0);
        await Expect(addButton).ToBeEnabledAsync();
        await CheckInnerText(addButton, "Add to cart");

        await CheckInnerText(name, purchase.Name);
        await CheckInnerText(cost, purchase.Cost);
        await CheckInnerText(description, purchase.Description);

        if(cartItemCount - 1 > 0){await Expect(cartLocator).ToHaveTextAsync((cartItemCount - 1).ToString());}
        else{await Expect(cartLocator).ToHaveCountAsync(0);}
    }
}