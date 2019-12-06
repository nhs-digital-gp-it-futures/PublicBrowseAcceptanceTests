using FluentAssertions;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.LayoutComponents
{
    [Binding]
    public sealed class Header
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;

        public Header(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Then(@"the Header is presented")]
        [Then(@"it contains a Header")]
        public void ThenTheHeaderIsPresented()
        {
            _test.pages.Header.ComponentDisplayed();
        }

        [Given(@"the User chooses to select the logo in the Header")]
        public void GivenTheUserChoosesToSelectTheLogoInTheHeader()
        {
        }

        [When(@"they click the NHS Digital logo")]
        public void WhenTheyClickTheNHSDigitalLogo()
        {
            _test.pages.Header.ClickLogo();
        }


        [Then(@"they are directed to the domain URL")]
        public void ThenTheyAreDirectedToTheDomainURL()
        {
            _test.pages.Common.GetUrl().Should().Be(_test.url + '/');
        }

        [Then(@"a Terms of use banner is displayed")]
        public void ThenATermsOfUseBannerIsDisplayed()
        {
            _test.pages.Header.TermsBannerDisplayed();
        }
    }
}
