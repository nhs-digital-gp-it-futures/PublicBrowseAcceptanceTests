using FluentAssertions;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public sealed class Header : Interactions
    {
        public Header(IWebDriver driver) : base(driver)
        {
        }

        public void ClickLogo()
        {
            driver.FindElement(pages.Header.Logo).Click();
        }

        public void ComponentDisplayed()
        {
            driver.FindElement(pages.Header.Container).Displayed.Should().BeTrue();
        }

        public void TermsBannerDisplayed()
        {
            driver.FindElement(pages.Header.TermsBanner).Displayed.Should().BeTrue();
        }
    }
}