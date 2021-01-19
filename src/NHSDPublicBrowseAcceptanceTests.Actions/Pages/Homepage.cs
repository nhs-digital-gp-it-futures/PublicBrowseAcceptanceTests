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
            wait.Until(s => s.FindElement(Objects.Pages.Homepage.Title).Displayed);
        }

        public void WaitForPageNotToBeDisplayed()
        {
            wait.Until(s => s.FindElements(Objects.Pages.Homepage.BrowseSolutions).Count == 0);
        }

        public void AboutUsSectionDisplayed()
        {
            driver.FindElement(Objects.Pages.Homepage.AboutSection).Displayed.Should().BeTrue();
        }

        public void BrowseSolutionsControlDisplayed()
        {
            driver.FindElement(Objects.Pages.Homepage.BrowseSolutions).Displayed.Should().BeTrue();
        }

        public void ClickBuyersGuideControl()
        {
            driver.FindElement(Objects.Pages.Homepage.GuidanceContent).Click();
        }

        public void ClickBrowseSolutions()
        {
            driver.FindElement(Objects.Pages.Homepage.BrowseSolutions).Click();
            WaitForPageNotToBeDisplayed();
        }

        public void GuidanceContentControlDisplayed()
        {
            driver.FindElement(Objects.Pages.Homepage.GuidanceContent).Displayed.Should().BeTrue();
        }

        public void ClickLoginButton()
        {
            driver.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Click();
        }

        public string LoginLogoutLinkText()
        {
            wait.Until(s => s.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Displayed);
            return driver.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Text;
        }

        public void LogOut()
        {
            if (LoginLogoutLinkText().Equals("Log out", StringComparison.OrdinalIgnoreCase))
            {
                driver.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Click();
            }
            else
            {
                throw new WebDriverException("Log out text incorrect");
            }
        }
    }
}