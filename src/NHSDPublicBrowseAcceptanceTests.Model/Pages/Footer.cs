using System;
using System.Linq;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class Footer : Interactions
    {
        public Footer(IWebDriver driver) : base(driver)
        {
        }

        public void ComponentDisplayed()
        {
            wait.Until(s => s.FindElement(pages.Footer.Container).Displayed);
        }

        public void SelectURL(string linkText)
        {
            var links = driver.FindElements(pages.Footer.Links);

            links.Single(s => s.Text.Equals(linkText)).Click();
        }
    }
}