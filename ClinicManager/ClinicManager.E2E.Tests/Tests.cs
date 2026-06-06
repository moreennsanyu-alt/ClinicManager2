using DevExpress.EasyTest.Framework;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

// To run functional tests for ASP.NET Web Forms and ASP.NET Core Blazor XAF Applications,
// install browser drivers: https://www.selenium.dev/documentation/getting_started/installing_browser_drivers/.
//
// -For Google Chrome: download "chromedriver.exe" from https://chromedriver.chromium.org/downloads.
// -For Microsoft Edge: download "msedgedriver.exe" from https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/.
//
// Selenium requires a path to the downloaded driver. Add a folder with the driver to the system's PATH variable.
//
// Refer to the following article for more information: https://docs.devexpress.com/eXpressAppFramework/403852/

namespace ClinicManager.Module.E2E.Tests;

public class ClinicManagerTests : IDisposable {
    const string WinAppName = "ClinicManagerWin";
    const string AppDBName = "ClinicManager";
    EasyTestFixtureContext FixtureContext { get; } = new EasyTestFixtureContext();

    public ClinicManagerTests() {
        FixtureContext.RegisterApplications(
            new WinApplicationOptions(WinAppName, string.Format(@"{0}\..\..\..\..\ClinicManager.Win\bin\EasyTest\net9.0-windows\ClinicManager.Win.exe", Environment.CurrentDirectory))
        );
        FixtureContext.RegisterDatabases(new DatabaseOptions(AppDBName, "ClinicManagerEasyTest", server: @"Sqlite"));
    }
    public void Dispose() {
        FixtureContext.CloseRunningApplications();
    }
    [Theory]
    [InlineData(WinAppName)]
    public void TestWinApp(string applicationName) {
        FixtureContext.DropDB(AppDBName);
        var appContext = FixtureContext.CreateApplicationContext(applicationName);
        appContext.RunApplication();
        Assert.True(appContext.Navigate("My Details"));
        Assert.True(appContext.Navigate("Role"));
        Assert.True(appContext.Navigate("Users"));
    }
}
