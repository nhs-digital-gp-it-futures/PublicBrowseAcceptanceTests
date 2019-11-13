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
        public void ThenTheHeaderIsPresented()
        {
            _context.Pending();
        }

        [Given(@"the User chooses to select the logo in the Header")]
        public void GivenTheUserChoosesToSelectTheLogoInTheHeader()
        {
            _context.Pending();
        }

        [When(@"they select the logo")]
        public void WhenTheySelectTheLogo()
        {
            _context.Pending();
        }

        [Then(@"they are directed to the domain URL")]
        public void ThenTheyAreDirectedToTheDomainURL()
        {
            _context.Pending();
        }

    }
}
