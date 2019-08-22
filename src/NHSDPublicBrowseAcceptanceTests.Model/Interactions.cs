using NHSDPublicBrowseAcceptanceTests.Objects;
using NHSDPublicBrowseAcceptanceTests.Objects.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public abstract class Interactions
    {
        internal readonly IWebDriver driver;
        internal readonly WebDriverWait wait;
        internal PageCollection pages;

        public Interactions(IWebDriver driver)
        {
            this.driver = driver;
            // Initialize a WebDriverWait that can be reutilized by all that inherit from this class
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Initialize the page objects
            pages = new PageObjects().Pages;
        }
    }
}