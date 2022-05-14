using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

public class AddPageTests : TMCBPageTest
{
    private IPage _browserPage = null!;

    [SetUp]
    public async Task Setup()
    {
        _browserPage = await Browser.NewPageAsync(new() { BaseURL = API });
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

        Assert.AreEqual(API, _browserPage.Url);
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

        Assert.AreEqual(9, rows.Count);
    }
}
