using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Playwright;

public class HomePage
{
    private readonly IPage _page;

    private readonly ILocator _recipeTable;

    public HomePage(IPage page)
    {
        _page = page;
        _page.PageError += (_, ex) => {
            System.Console.WriteLine($"ERROR: {ex}");
        };

        _recipeTable = page.Locator("#recipes");
    }

    public async Task GotoAsync()
    {
        await _page.GotoAsync("/");
    }

    public async Task<IReadOnlyList<IElementHandle>> GetTableRows()
    {
        var table = await _page.WaitForSelectorAsync("#recipes");

        var recipe = await table!.WaitForSelectorAsync("tbody tr");

        return await table!.QuerySelectorAllAsync("tbody tr");
    }
}
