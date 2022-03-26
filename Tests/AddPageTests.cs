using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

public class AddPageTests : PageTest
{
    [Test]
    public async Task SaveButtonIsInitiallyDisabled()
    {        
        var page = new AddPage(await Browser.NewPageAsync(new() { BaseURL = "http://localhost:5148" }));

        await page.GotoAsync();

        Assert.IsTrue(await page.SaveIsDisabledAsync());
    }

    [Test]
    public async Task SaveButtonIsEnabledOnceFieldsAreFilled()
    {        
        var page = new AddPage(await Browser.NewPageAsync(new() { BaseURL = "http://localhost:5148" }));

        await page.GotoAsync();

        await page.SetNameAsync("Chicken Madass");
        await page.SetBookAsync("Angry cooking tips");
        await page.SetAuthorAsync("Ged");

        await page.BlurAsync();

        await page.Page.ScreenshotAsync(new PageScreenshotOptions { Path = "tmc-add-filled.png"});

        Assert.IsTrue(await page.SaveIsEnabledAsync());
    }
}
