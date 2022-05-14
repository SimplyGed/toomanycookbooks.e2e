using Microsoft.Extensions.Configuration;
using Microsoft.Playwright.NUnit;

public class TMCBPageTest : PageTest
{
    protected string API { get; init; }
    protected IConfiguration Configuration { get; init; }

    public TMCBPageTest() : base()
    {
        Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.e2e.json")
            .AddEnvironmentVariables()
            .Build();

        API = Configuration[nameof(API)];
    }
}