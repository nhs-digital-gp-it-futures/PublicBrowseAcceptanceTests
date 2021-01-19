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
            driver.FindElement(Objects.Pages.Header.Logo).Click();
        }

        public void ComponentDisplayed()
        {
            driver.FindElement(Objects.Pages.Header.Container).Displayed.Should().BeTrue();
        }

        public void BannerDisplayed()
        {
            driver.FindElement(Objects.Pages.Header.Banner).Displayed.Should().BeTrue();
        }
    }
}
