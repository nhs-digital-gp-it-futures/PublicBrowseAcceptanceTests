namespace NHSDPublicBrowseAcceptanceTests.Tests.Utils
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Remote;

    public sealed class BrowserFactory
    {
        private readonly Settings settings;

        public BrowserFactory(Settings settings)
        {
            this.settings = settings;
            Driver = GetBrowser();
        }

        public IWebDriver Driver { get; }

        private static IWebDriver GetLocalChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("start-maximized", "no-sandbox", "auto-open-devtools-for-tabs", "ignore-certificate-errors");

            return new ChromeDriver(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), options);
        }

        private static IWebDriver GetChromeDriver(string hubURL)
        {
            var options = new ChromeOptions();
            options.AddArguments("headless", "window-size=1920,1080", "no-sandbox", "ignore-certificate-errors");

            return new RemoteWebDriver(new Uri(hubURL), options);
        }

        private static IWebDriver GetFirefoxDriver(string hubURL)
        {
            var options = new FirefoxOptions();
            options.AddArguments("headless", "window-size=1920,1080", "no-sandbox", "acceptInsecureCerts");

            return new RemoteWebDriver(new Uri(hubURL), options);
        }

        private IWebDriver GetBrowser()
        {
            IWebDriver driver;
            var browser = settings.Browser;
            var huburl = settings.HubUrl;

            if (Debugger.IsAttached)
            {
                driver = GetLocalChromeDriver();
            }
            else
            {
                driver = browser.ToLower() switch
                {
                    "chrome" or "googlechrome" => GetChromeDriver(huburl),
                    "firefox" or "ff" or "mozilla" => GetFirefoxDriver(huburl),
                    _ => GetLocalChromeDriver(),
                };
            }

            return driver;
        }
    }
}
