using System.Threading.Tasks;
using Microsoft.Playwright;

public class AddPage
{
    public readonly IPage _page;

    private readonly ILocator _saveButton;
    private readonly ILocator _addIngredientButton;
    private readonly ILocator _nameField;
    private readonly ILocator _bookField;

    public IPage Page => _page;

    public AddPage(IPage page)
    {
        _page = page;

        _saveButton = _page.Locator("#save");
        _addIngredientButton = _page.Locator("#add-ingredient");

        _nameField = _page.Locator("#name");
        _bookField = _page.Locator("#book");
    }

    public async Task GotoAsync()
    {
        await _page.GotoAsync("/add");
    }

    public async Task<bool> SaveIsDisabledAsync()
    {
        return await _saveButton.IsDisabledAsync();
    }

    public async Task<bool> SaveIsEnabledAsync()
    {
        return await _saveButton.IsEnabledAsync();
    }

    public async Task SaveAsync()
    {
        await _saveButton.ClickAsync();
    }

    public async Task SetNameAsync(string name) => await _nameField.FillAsync(name);

    public async Task SetBookAsync(string book) => await _bookField.SelectOptionAsync(new SelectOptionValue { Label = book });

    public async Task BlurAsync() => await _addIngredientButton.FocusAsync();
}