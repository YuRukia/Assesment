using Microsoft.Playwright;
using Config;
using Microsoft.Playwright.Xunit;

namespace Pages;

public class BasePage : PageTest
{
    private static string url = Configuration.url;
    private static string username;
    private static string password;

    public BasePage(string usrnm, string pswrd)
    {
        username = usrnm;
        password = pswrd;
    }

    public BasePage(){}

    public static string getUrl() { return url; }
    public static string getUsername() { return username; }
    public static string getPassword() { return password; }


    public async Task NavigateTo(IPage page, string url)
    {
        await page.GotoAsync(url);
    }

    public async Task EnterField(ILocator locator, string input)
    {
        await locator.FillAsync(input);
        await CheckValue(locator, input);
    }

    public async Task ClearField(ILocator locator)
    {
        await locator.ClearAsync();
        await CheckValue(locator, "");
    }

    public async Task CheckValue(ILocator locator, string input)
    {
        await Expect(locator).ToHaveValueAsync(input);
    }

    public async Task CheckInnerText(ILocator locator, string input)
    {
        await Expect(locator).ToContainTextAsync(input);
    }

    public async Task<string> GetInnerText(ILocator locator)
    {
        return await locator.InnerTextAsync();
    }

    public async Task ClickElement(ILocator locator)
    {
        await locator.ClickAsync();
    }

    public async Task<bool> ElementPresent(ILocator locator)
    {
        return await locator.CountAsync() > 0;
    }
}