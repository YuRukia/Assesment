using Microsoft.Playwright;
using Config;

namespace Pages;

public class ProductsPage : BasePage
{
    LoginPage loginPage = new LoginPage();
    private readonly string url = getUrl() + "/inventory.html";

    public async Task AddToCart(IPage page, List<Product> purchases)
    {
        
        if(page.Url != url){await loginPage.Login(page);}

        foreach(var purchase in purchases)
        {
            ILocator cartLocator = page.Locator("[data-test='shopping-cart-badge']");
            int cartItemCount = 0;
            if(await ElementPresent(cartLocator)){cartItemCount = int.Parse(await GetInnerText(cartLocator));}

            ILocator name = page.Locator("[data-test='inventory-item']").GetByText(purchase.Name);
            ILocator parent = name.Locator("..").Locator("..").Locator("..");
            ILocator cost = parent.GetByText(purchase.Cost);
            ILocator description = parent.GetByText(purchase.Description);
            ILocator addToCartButton = parent.GetByText("Add to cart");

            await CheckInnerText(name, purchase.Name);
            await CheckInnerText(cost, purchase.Cost);
            await CheckInnerText(description, purchase.Description);
            await ClickElement(addToCartButton);
            await Expect(cartLocator).ToHaveTextAsync((cartItemCount + 1).ToString());
        }
        
        await GoToCart(page);
    }

    public async Task GoToCart(IPage page)
    {
        ILocator cartLocator = page.Locator("[data-test='shopping-cart-link']");
        await ClickElement(cartLocator);
        await Expect(page).ToHaveURLAsync(getUrl() + "/cart.html");
    }

    public async Task Logout(IPage page)
    {
        ILocator openMenu = page.Locator("[id='react-burger-menu-btn']");
        await ClickElement(openMenu);

        ILocator logoutButton = page.Locator("[data-test='logout-sidebar-link']");
        await ClickElement(logoutButton);
        await Expect(page).ToHaveURLAsync(getUrl());
    }
}