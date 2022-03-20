using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

public class HomePageTests : PageTest
{
    [Test]
    public async Task RecipeTableIsLoaded()
    {
        var page = await Browser.NewPageAsync(new() { BaseURL = "http://localhost:5148" });

        await page.GotoAsync("/");

        var recipes = await page.WaitForSelectorAsync("#recipes");

        await page.ScreenshotAsync(new PageScreenshotOptions{ Path = "tmc.png" });

        Assert.IsNotNull(recipes);

    }
}