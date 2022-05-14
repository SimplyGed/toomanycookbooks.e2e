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

        _recipeTable = page.Locator("#recipes");
    }

    public async Task GotoAsync()
    {
        await _page.GotoAsync("/");
    }

    public async Task<IReadOnlyList<IElementHandle>> GetTableRows()
    {
        await _page.WaitForSelectorAsync("#recipes tbody tr");

        return await _page.QuerySelectorAllAsync("#recipes tbody tr");
    }
}
