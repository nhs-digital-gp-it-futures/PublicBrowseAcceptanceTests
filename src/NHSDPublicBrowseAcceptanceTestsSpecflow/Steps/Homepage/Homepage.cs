using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.Homepage
{
    [Binding]
    public class Homepage
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;

        public Homepage(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"the User chooses to view the Buying Catalogue Homepage")]
        public void GivenTheUserChoosesToViewTheBuyingCatalogueHomepage()
        {
            _context.Pending();
        }

        [When(@"the Homepage is presented")]
        public void WhenTheHomepageIsPresented()
        {
            _context.Pending();
        }

        [Then(@"it contains a Header")]
        public void ThenItContainsAHeader()
        {
            _context.Pending();
        }

        [Then(@"content about the Buying Catalogue")]
        public void ThenContentAboutTheBuyingCatalogue()
        {
            _context.Pending();
        }

        [Then(@"a Footer")]
        public void ThenAFooter()
        {
            _context.Pending();
        }

        [Then(@"a control to access Browse Solutions")]
        public void ThenAControlToAccessBrowseSolutions()
        {
            _context.Pending();
        }

        [Then(@"a control to access Guidance Content for Buyers")]
        public void ThenAControlToAccessGuidanceContentForBuyers()
        {
            _context.Pending();
        }
    }
}
