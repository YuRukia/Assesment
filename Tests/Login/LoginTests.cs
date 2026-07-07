using Config;
using Microsoft.Playwright;
using Pages;

namespace LoginTests;

[Trait("Category","LoginTests")]
public class LoginTests : Setup
{
    string testType = "Login:";
    
    [Fact]
    public async Task ValidLogin()
    {
        string testID = testType + "Valid Login";
        
        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Configuration.headless, SlowMo = Configuration.slowmode });
        var page = await browser.NewPageAsync();

        try
        {
            await SetUp(page, testID);
            await loginPage.Login(page);
            await screenshotHelper.TakeScreenshot(page);
        }
        catch (Exception)
        {
            await screenshotHelper.TakeScreenshot(page);
            throw;
        };
    }
        
    [Fact]
    public async Task InvalidUsername()
    {
        string testID = testType + "Invalid Username";

        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Configuration.headless, SlowMo = Configuration.slowmode });
        var page = await browser.NewPageAsync();

        try
        {
            await SetUp(page, testID, "Invalid", Configuration.password);
            await loginPage.Login(page, "Invalid Username");
            await screenshotHelper.TakeScreenshot(page);
        }
        catch (Exception)
        {
            await screenshotHelper.TakeScreenshot(page);
            throw;
        }
    }
        
    [Fact]
    public async Task InvalidPassword()
    {
        string testID = testType + "Invalid Password";

        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Configuration.headless, SlowMo = Configuration.slowmode });
        var page = await browser.NewPageAsync();

        try
        {
            await SetUp(page, testID, Configuration.defaultUser, "Invalid");
            await loginPage.Login(page, "Invalid Password");
            await screenshotHelper.TakeScreenshot(page);
        }
        catch (Exception)
        {
            await screenshotHelper.TakeScreenshot(page);
            throw;
        }
    }

    [Fact]
    public async Task EmptyUsername()
    {
        string testID = testType + "Empty Username";

        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Configuration.headless, SlowMo = Configuration.slowmode });
        var page = await browser.NewPageAsync();

        try
        {
            await SetUp(page, testID, "", Configuration.password);
            await loginPage.Login(page, "Empty Username");
            await screenshotHelper.TakeScreenshot(page);

        }
        catch (Exception)
        {
            await screenshotHelper.TakeScreenshot(page);
            throw;
        }
    }

    [Fact]
    public async Task EmptyPassword()
    {
        string testID = testType + "Empty Password";

        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Configuration.headless, SlowMo = Configuration.slowmode });
        var page = await browser.NewPageAsync();

        try
        {
            await SetUp(page, testID, Configuration.defaultUser, "");
            await loginPage.Login(page, "Empty Password");
            await screenshotHelper.TakeScreenshot(page);
        }
        catch (Exception)
        {
            await screenshotHelper.TakeScreenshot(page);
            throw;
        }
    }

    [Fact]
    public async Task LockedOutUser()
    {
        string testID = testType + "Locked Out User";

        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Configuration.headless, SlowMo = Configuration.slowmode });
        var page = await browser.NewPageAsync();

        try
        {
            await SetUp(page, testID, Configuration.lockedUser, Configuration.password);
            await loginPage.Login(page, "Locked User");
            await screenshotHelper.TakeScreenshot(page);
        }
        catch (Exception)
        {
            await screenshotHelper.TakeScreenshot(page);
            throw;
        }
    }
}