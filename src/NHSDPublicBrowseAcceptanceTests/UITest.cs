using NHSDPublicBrowseAcceptanceTests.Actions;
using NHSDPublicBrowseAcceptanceTests.Actions.Pages;
using NHSDPublicBrowseAcceptanceTests.Utils;
using OpenQA.Selenium;
using System;

namespace NHSDPublicBrowseAcceptanceTests
{
    public abstract class UITest : IDisposable
    {
        internal readonly IWebDriver driver;
        internal readonly PageActionCollection pages;        

        public UITest()
        {
            // Get process only environment variables
            var (url, hubUrl, browser) = EnvironmentVariables.Get();

            // Initialize the browser and get the page action collections
            driver = BrowserFactory.GetBrowser(browser, hubUrl);
            pages = new PageActions(driver).PageActionCollection;

            // Navigate to the site url
            driver.Navigate().GoToUrl(url);

            pages.Common.WaitForPageLoad();
        }        

        public void Dispose()
        {
            var ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile($"{DateTime.Now.ToString("yyyyMMddHHmmss")}.png", ScreenshotImageFormat.Png);

            // Exits all browser windows and disposes of the driver instance
            driver.Close();
            driver.Quit();
        }
    }
}
