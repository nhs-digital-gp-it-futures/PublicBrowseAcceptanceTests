using NHSDPublicBrowseAcceptanceTests.Objects;
using NHSDPublicBrowseAcceptanceTests.Objects.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit.Abstractions;

namespace NHSDPublicBrowseAcceptanceTests.Actions
{
    public abstract class Interactions
    {
        internal readonly IWebDriver driver;
        internal readonly WebDriverWait wait;
        internal readonly ITestOutputHelper helper;

        internal PageCollection pages;

        public Interactions(IWebDriver driver, ITestOutputHelper helper)
        {
            this.driver = driver;
            this.helper = helper;

            // Initialize a WebDriverWait that can be reutilized by all that inherit from this class
            wait = new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(100));

            // Initialize the page objects
            pages = new PageObjects().Pages;
        }
    }
}