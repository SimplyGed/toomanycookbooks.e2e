using Microsoft.Extensions.Configuration;
using Microsoft.Playwright.NUnit;

public class TMCBPageTest : PageTest
{
    protected string URL { get; init; }

    protected ApiService ApiService { get; init; }

    public TMCBPageTest() : base()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.e2e.json")
            .Build();

        URL = config[nameof(URL)];

        var api = config["API"];
        ApiService = ApiServiceFactory.Create(api);
    }
}