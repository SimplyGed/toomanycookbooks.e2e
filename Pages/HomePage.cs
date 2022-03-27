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

    public Task<IReadOnlyList<IElementHandle>> GetTableRows()
    {
        return _page.QuerySelectorAllAsync("tbody tr");
    }
}
