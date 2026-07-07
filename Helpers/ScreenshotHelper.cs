using Microsoft.Playwright;

namespace Config;

public class Screenshot : Setup
{
    new IPage page;
    string testType;
    string testName;
    public Screenshot(IPage page, string testID)
    {
        this.page = page;
        this.testType = testID.Split(":").First();
        this.testName = testID.Split(":").Last();
    }

    public async Task TakeScreenshot(IPage page)
    {
        await page.ScreenshotAsync(new()
        {
            Path = Configuration.testPath + "/"+ testType + "/Screenshots/" + testName + "/" + testName + ".png",
            FullPage = true,
        });
    }
}