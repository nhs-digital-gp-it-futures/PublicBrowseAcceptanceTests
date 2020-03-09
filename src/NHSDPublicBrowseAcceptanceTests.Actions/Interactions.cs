using System;
using NHSDPublicBrowseAcceptanceTests.Objects;
using NHSDPublicBrowseAcceptanceTests.Objects.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NHSDPublicBrowseAcceptanceTests.Actions
{
    public abstract class Interactions
    {
        internal readonly IWebDriver driver;

        internal readonly PageCollection pages;
        internal readonly WebDriverWait wait;

        public Interactions(IWebDriver driver)
        {
            this.driver = driver;

            // Initialize a WebDriverWait that can be reutilized by all that inherit from this class
            wait = new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(10),
                TimeSpan.FromMilliseconds(100));

            // Initialize the page objects
            pages = new PageObjects().Pages;
        }
    }
}