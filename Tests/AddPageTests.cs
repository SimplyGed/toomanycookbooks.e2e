using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

public class AddPageTests : TMCBPageTest
{
    private IPage _browserPage = null!;

    [SetUp]
    public async Task Setup()
    {
        _browserPage = await Browser.NewPageAsync(new() { BaseURL = URL, IgnoreHTTPSErrors = true });
    }

    [Test]
    public async Task SaveButtonIsInitiallyDisabled()
    {        
        var page = new AddPage(_browserPage);

        await page.GotoAsync();

        Assert.IsTrue(await page.SaveIsDisabledAsync());
    }

    [Test]
    public async Task SaveButtonIsEnabledOnceFieldsAreFilled()
    {        
        var page = new AddPage(_browserPage);

        await page.GotoAsync();

        await page.SetNameAsync("Chicken Madass");
        await page.SetBookAsync("Cookbook 2");

        await page.BlurAsync();

        Assert.IsTrue(await page.SaveIsEnabledAsync());
    }

    [Test]
    public async Task SaveNavigatesBackToHomePage()
    {        
        var page = new AddPage(_browserPage);

        await page.GotoAsync();

        await page.SetNameAsync("Chicken Madass");
        await page.SetBookAsync("Cookbook 5");

        await page.BlurAsync();

        await page.SaveAsync();

        await _browserPage.WaitForSelectorAsync("#recipes");

        Assert.AreEqual(URL, _browserPage.Url);
    }

    [Test]
    public async Task HomePageShowsNewRecipeAfterSave()
    {        
        var page = new AddPage(_browserPage);

        await page.GotoAsync();

        await page.SetNameAsync("Chicken Madass");
        await page.SetBookAsync("Cookbook 4");

        await page.BlurAsync();

        await page.SaveAsync();

        var home = new HomePage(_browserPage);

        await _browserPage.ScreenshotAsync(new PageScreenshotOptions{ Path = "./HomePageShowsNewRecipeAfterSave.png" });

        var rows = await home.GetTableRows();

        var records = await ApiService.GetExistingRecipesAsync();

        Assert.AreEqual(records.Count(), rows.Count);
    }
}
