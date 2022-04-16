using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

public class HomePageTests : PageTest
{
    [Test]
    public async Task RecipeTableIsLoaded()
    {
        var page = await Browser.NewPageAsync(new() { BaseURL = "https://toomanycookbooks-dev.azurewebsites.net" });

        await page.GotoAsync("/");

        var recipes = await page.WaitForSelectorAsync("#recipes");

        var rows = await recipes!.QuerySelectorAllAsync("tbody tr");
        
        Assert.AreEqual(4, rows.Count);
    }

    // [Test]
    // public async Task AddRecordUpdatesHomePage()
    // {
    //     var page = await Browser.NewPageAsync(new() { BaseURL = "http://localhost:5148" });

    //     await page.GotoAsync("/");

    //     await page.ClickAsync("#add");

    //     await page.ScreenshotAsync(new PageScreenshotOptions{ Path = "tmc-add.png" });

    //     await page.ClickAsync("#save");
        
    //     var recipes = await page.WaitForSelectorAsync("#recipes");

    //     var rows = await recipes!.QuerySelectorAllAsync("tbody tr");
        
    //     Assert.AreEqual(5, rows.Count);
    // }
}