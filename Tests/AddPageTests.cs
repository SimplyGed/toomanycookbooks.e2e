using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

public class AddPageTests : PageTest
{
    private static string _baseURL = "http://localhost:5148/";
    
    private IPage _browserPage = null!;

    [SetUp]
    public async Task Setup()
    {
        _browserPage = await Browser.NewPageAsync(new() { BaseURL = _baseURL });
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
        await page.SetBookAsync("Angry cooking tips");
        await page.SetAuthorAsync("Ged");

        await page.BlurAsync();

        Assert.IsTrue(await page.SaveIsEnabledAsync());
    }

    [Test]
    public async Task SaveNavigatesBackToHomePage()
    {        
        var page = new AddPage(_browserPage);

        await page.GotoAsync();

        await page.SetNameAsync("Chicken Madass");
        await page.SetBookAsync("Angry cooking tips");
        await page.SetAuthorAsync("Ged");

        await page.BlurAsync();

        await page.SaveAsync();

        await _browserPage.WaitForSelectorAsync("#recipes");

        Assert.AreEqual(_baseURL, _browserPage.Url);
    }

    [Test]
    public async Task HomePageShowsNewRecipeAfterSave()
    {        
        var page = new AddPage(_browserPage);

        await page.GotoAsync();

        await page.SetNameAsync("Chicken Madass");
        await page.SetBookAsync("Angry cooking tips");
        await page.SetAuthorAsync("Ged");

        await page.BlurAsync();

        await page.SaveAsync();

        var home = new HomePage(_browserPage);

        var rows = await home.GetTableRows();

        Assert.AreEqual(5, rows.Count);
    }
}
