using System.Threading.Tasks;
using Microsoft.Playwright;

public class AddPage
{
    public readonly IPage _page;

    private readonly ILocator _saveButton;
    private readonly ILocator _nameField;
    private readonly ILocator _authorField;
    private readonly ILocator _bookField;

    public IPage Page => _page;

    public AddPage(IPage page)
    {
        _page = page;

        _saveButton = _page.Locator("#save");
        _nameField = _page.Locator("#name");
        _authorField = _page.Locator("#author");
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

    public async Task SetNameAsync(string name) => await _nameField.FillAsync(name);

    public async Task SetAuthorAsync(string author) => await _authorField.FillAsync(author);

    public async Task SetBookAsync(string book) => await _bookField.FillAsync(book);

    public async Task BlurAsync() => await _nameField.FocusAsync();
}