using System;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class Homepage : Interactions
    {
        public Homepage(IWebDriver driver) : base(driver)
        {
        }

        public void PageDisplayed()
        {
            wait.Until(s => s.FindElement(pages.Homepage.Title).Displayed);
        }
    }
}