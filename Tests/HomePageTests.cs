using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

public class HomePageTests : TMCBPageTest
{
    private IPage _browserPage = null!;
    
    [SetUp]
    public async Task Setup()
    {
        _browserPage = await Browser.NewPageAsync(new() { BaseURL = API });
    }

    [Test]
    public async Task RecipeTableIsLoaded()
    {
        var page = new HomePage(_browserPage);

        await page.GotoAsync();

        var rows = await page.GetTableRows();
        
        Assert.AreEqual(8, rows.Count);
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