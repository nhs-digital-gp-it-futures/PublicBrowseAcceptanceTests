namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    using FluentAssertions;
    using OpenQA.Selenium;

    public sealed class Header : Interactions
    {
        public Header(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickLogo()
        {
            Driver.FindElement(Objects.Pages.Header.Logo).Click();
        }

        public void ComponentDisplayed()
        {
            Driver.FindElement(Objects.Pages.Header.Container).Displayed.Should().BeTrue();
        }

        public void BannerDisplayed()
        {
            Driver.FindElement(Objects.Pages.Header.Banner).Displayed.Should().BeTrue();
        }
    }
}
