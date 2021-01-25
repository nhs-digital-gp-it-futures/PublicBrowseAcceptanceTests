namespace NHSDPublicBrowseAcceptanceTests.Actions
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public abstract class Interactions
    {
        protected readonly IWebDriver Driver;

        protected readonly WebDriverWait Wait;

        public Interactions(IWebDriver driver)
        {
            Driver = driver;

            // Initialize a WebDriverWait that can be reutilized by all that inherit from this class
            Wait = new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(100));
        }
    }
}
