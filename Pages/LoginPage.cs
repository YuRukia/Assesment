using Microsoft.Playwright;

namespace Pages;

public class LoginPage : BasePage
{
    private readonly string url = getUrl();
    private readonly string username = getUsername();
    private readonly string password = getPassword();
    private readonly string invalidUsernamePasswordError = "Epic sadface: Username and password do not match any user in this service";
    private readonly string emptyUsernameError = "Epic sadface: Username is required";
    private readonly string emptyPasswordError = "Epic sadface: Password is required";
    private readonly string lockedOutUserError = "Epic sadface: Sorry, this user has been locked out.";

    public async Task EnterUsername(IPage page)
    {
        ILocator locator = page.Locator("[id='user-name']");
        await EnterField(locator, username);
    }

    public async Task EnterPassword(IPage page)
    {
        ILocator locator = page.Locator("[id='password']");
        await EnterField(locator, password);
    }

    public async Task ClickLogin(IPage page)
    {
        ILocator locator = page.Locator("[id='login-button']");
        await ClickElement(locator);
    }

    public async Task Login(IPage page, string loginType = "")
    {
        await EnterUsername(page);
        await EnterPassword(page);
        await ClickLogin(page);
        if(loginType == ""){ await ValidLogin(page); }
        else{ await InvalidLogin(page, loginType); }
    }

    public async Task ValidLogin(IPage page)
    {
        await Expect(page).ToHaveURLAsync(url + "/inventory.html");
    }

    public async Task InvalidLogin(IPage page, string loginType)
    {
        await Expect(page).ToHaveURLAsync(url);
        
        if(loginType == "Invalid Username" || loginType == "Invalid Password")
        {
            ILocator locator = page.Locator("[data-test='error']");
            await CheckInnerText(locator, invalidUsernamePasswordError);
        }

        if(username == "" || password == "")
        {
            ILocator locator = page.Locator("[data-test='error']");
            if(username == ""){ await CheckInnerText(locator, emptyUsernameError); }
            else { await CheckInnerText(locator, emptyPasswordError); }
        }

        if(loginType == "lockedUser")
        {
            ILocator locator = page.Locator("[data-test='error']");
            await CheckInnerText(locator, lockedOutUserError);
        }
    }
}