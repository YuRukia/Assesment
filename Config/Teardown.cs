using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using Pages;

namespace Config;

public class Teardown : Setup
{
    public async Task TearDown(IPage Page)
    {
        await Page.CloseAsync();
    }
}