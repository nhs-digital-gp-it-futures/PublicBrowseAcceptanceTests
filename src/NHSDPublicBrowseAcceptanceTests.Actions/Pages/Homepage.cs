namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    using System;
    using FluentAssertions;
    using OpenQA.Selenium;

    public class Homepage : Interactions
    {
        public Homepage(IWebDriver driver)
            : base(driver)
        {
        }

        public void PageDisplayed()
        {
            Wait.Until(s => s.FindElement(Objects.Pages.Homepage.Title).Displayed);
        }

        public void WaitForPageNotToBeDisplayed()
        {
            Wait.Until(s => s.FindElements(Objects.Pages.Homepage.BrowseSolutions).Count == 0);
        }

        public void AboutUsSectionDisplayed()
        {
            Driver.FindElement(Objects.Pages.Homepage.AboutSection).Displayed.Should().BeTrue();
        }

        public void BrowseSolutionsControlDisplayed()
        {
            Driver.FindElement(Objects.Pages.Homepage.BrowseSolutions).Displayed.Should().BeTrue();
        }

        public void ClickBuyersGuideControl()
        {
            Driver.FindElement(Objects.Pages.Homepage.GuidanceContent).Click();
        }

        public void ClickBrowseSolutions()
        {
            Driver.FindElement(Objects.Pages.Homepage.BrowseSolutions).Click();
            WaitForPageNotToBeDisplayed();
        }

        public void GuidanceContentControlDisplayed()
        {
            Driver.FindElement(Objects.Pages.Homepage.GuidanceContent).Displayed.Should().BeTrue();
        }

        public void ClickDFOCVCSolutionsCard()
        {
            Driver.FindElement(Objects.Pages.Homepage.DFOCVCSolutions).Click();
        }

        public void ClickLoginButton()
        {
            Driver.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Click();
        }

        public string LoginLogoutLinkText()
        {
            Wait.Until(s => s.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Displayed);
            return Driver.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Text;
        }

        public void LogOut()
        {
            if (LoginLogoutLinkText().Equals("Log out", StringComparison.OrdinalIgnoreCase))
            {
                Driver.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Click();
            }
            else
            {
                throw new WebDriverException("Log out text incorrect");
            }
        }
    }
}