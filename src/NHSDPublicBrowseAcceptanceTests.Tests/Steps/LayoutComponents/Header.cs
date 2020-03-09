using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.LayoutComponents
{
    [Binding]
    public sealed class Header
    {
        private readonly ScenarioContext _context;
        private readonly UITest _test;

        public Header(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Then(@"the Header is presented")]
        [Then(@"it contains a Header")]
        public void ThenTheHeaderIsPresented()
        {
            _test.Pages.Header.ComponentDisplayed();
        }

        [Given(@"the User chooses to select the logo in the Header")]
        public void GivenTheUserChoosesToSelectTheLogoInTheHeader()
        {
        }

        [When(@"they click the NHS Digital logo")]
        public void WhenTheyClickTheNHSDigitalLogo()
        {
            _test.Pages.Header.ClickLogo();
        }


        [Then(@"they are directed to the domain URL")]
        public void ThenTheyAreDirectedToTheDomainURL()
        {
            _test.Pages.Common.GetUrl().Should().Be(_test.Url + '/');
        }

        [Then(@"a Terms of use banner is displayed")]
        public void ThenATermsOfUseBannerIsDisplayed()
        {
            _test.Pages.Header.TermsBannerDisplayed();
        }
    }
}