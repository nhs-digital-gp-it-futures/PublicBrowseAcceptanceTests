namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    using System;
    using System.Linq;
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

        public void NominateAnOrgControlDisplayed()
        {
            Driver.FindElement(Objects.Pages.Homepage.NominateAnOrgControl).Displayed.Should().BeTrue();
        }

        public void ClickDFOCVCSolutionsCard()
        {
            Driver.FindElement(Objects.Pages.Homepage.DFOCVCSolutions).Click();
        }

        public void ClickLoginButton()
        {
            Driver.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Click();
        }

        public void ClickNominateOrg()
        {
            Driver.FindElement(Objects.Pages.Homepage.NominateAnOrgControl).Click();
        }

        public string LoginLogoutLinkText()
        {
            Wait.Until(s => s.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Displayed);
            return Driver.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Text;
        }

        public void ProxyInfoPageDisplayed()
        {
            Driver.FindElement(Objects.Pages.Common.PageTitle).Text.Should().ContainEquivalentOf("Nominate an organisation");
        }

        public void NominateAnOrgLink()
        {
            Driver.FindElement(By.LinkText("Nominate an organisation")).Displayed.Should().BeTrue();
        }

        public void ClickBackLink()
        {
            Driver.FindElement(Objects.Pages.Homepage.ProxyBackLink).Click();
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

        public void ProcurementHubLink()
        {
            Driver.FindElement(By.LinkText("National Commercial and Procurement Hub")).Displayed.Should().BeTrue();
        }

        public void CookieBannerIsDisplayed()
        {
            Wait.Until(s => s.FindElements(Objects.Pages.Homepage.CookieBanner).Count == 1);
        }

        public void CookieBannerIsNotDisplayed()
        {
            Wait.Until(s => s.FindElements(Objects.Pages.Homepage.CookieBanner).Count == 0);
        }

        public void ClickCookieButton()
        {
            Driver.FindElement(Objects.Pages.Homepage.CookieButton).Click();
        }

        public void CookieButtonIsDisplayed()
        {
            Wait.Until(s => s.FindElements(Objects.Pages.Homepage.CookieButton).Count == 1);
        }

        public void WaitForCookieButtonNotToBeDisplayed()
        {
            Wait.Until(s => s.FindElements(Objects.Pages.Homepage.CookieButton).Count == 0);
        }

        public void ClickCookieLink()
        {
            Driver.FindElement(By.LinkText("cookies and privacy policy")).Click();
        }

        public void PrivacyAndCookiesPageDisplayed()
        {
            Driver.FindElement(Objects.Pages.Homepage.PrivacyAndCookiesPage).Displayed.Should().BeTrue();
        }
    }
}