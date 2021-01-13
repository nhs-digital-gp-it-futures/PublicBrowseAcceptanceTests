using FluentAssertions;
using OpenQA.Selenium;
using System;

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

        public void WaitForPageNotToBeDisplayed()
        {
            wait.Until(s => s.FindElements(pages.Homepage.BrowseSolutions).Count == 0);
        }

        public void AboutUsSectionDisplayed()
        {
            driver.FindElement(pages.Homepage.AboutSection).Displayed.Should().BeTrue();
        }

        public void BrowseSolutionsControlDisplayed()
        {
            driver.FindElement(pages.Homepage.BrowseSolutions).Displayed.Should().BeTrue();
        }

        public void ClickBuyersGuideControl()
        {
            driver.FindElement(pages.Homepage.GuidanceContent).Click();
        }

        public void ClickBrowseSolutions()
        {
            driver.FindElement(pages.Homepage.BrowseSolutions).Click();
            WaitForPageNotToBeDisplayed();
        }

        public void GuidanceContentControlDisplayed()
        {
            driver.FindElement(pages.Homepage.GuidanceContent).Displayed.Should().BeTrue();
        }

        public void ClickLoginButton()
        {
            driver.FindElement(pages.Homepage.LoginLogoutLink).Click();
        }

        public string LoginLogoutLinkText()
        {
            wait.Until(s => s.FindElement(pages.Homepage.LoginLogoutLink).Displayed);
            return driver.FindElement(pages.Homepage.LoginLogoutLink).Text;
        }

        public void LogOut()
        {
            if (LoginLogoutLinkText().Equals("Log out", StringComparison.OrdinalIgnoreCase))
            {
                driver.FindElement(pages.Homepage.LoginLogoutLink).Click();
            }
            else
            {
                throw new WebDriverException("Log out text incorrect");
            }
        }
    }
}