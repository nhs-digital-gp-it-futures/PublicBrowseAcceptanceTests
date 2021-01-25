namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.LayoutComponents
{
    using FluentAssertions;
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class Header
    {
        private readonly UITest test;
        private readonly Settings settings;

        public Header(UITest test, Settings settings)
        {
            this.test = test;
            this.settings = settings;
        }

        [Given(@"the User chooses to select the logo in the Header")]
        public static void GivenTheUserChoosesToSelectTheLogoInTheHeader()
        {
        }

        [Then(@"the Header is presented")]
        [Then(@"it contains a Header")]
        public void ThenTheHeaderIsPresented()
        {
            test.Pages.Header.ComponentDisplayed();
        }

        [When(@"they click the NHS Digital logo")]
        public void WhenTheyClickTheNHSDigitalLogo()
        {
            test.Pages.Header.ClickLogo();
        }

        [Then(@"they are directed to the domain URL")]
        public void ThenTheyAreDirectedToTheDomainURL()
        {
            test.Pages.Common.GetUrl().Should().Be(settings.PublicBrowseUrl + '/');
        }

        [Then(@"a banner is displayed")]
        public void ThenABannerIsDisplayed()
        {
            test.Pages.Header.BannerDisplayed();
        }
    }
}
