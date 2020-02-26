using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.Homepage
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
            _test.Pages.Homepage.PageDisplayed();
        }

        [When(@"the Homepage is presented")]
        public void WhenTheHomepageIsPresented()
        {
            _test.Pages.Homepage.PageDisplayed();
        }

        [Then(@"content about the Buying Catalogue")]
        public void ThenContentAboutTheBuyingCatalogue()
        {
            _test.Pages.Homepage.AboutUsSectionDisplayed();
        }

        [Then(@"a control to access Browse Solutions")]
        public void ThenAControlToAccessBrowseSolutions()
        {
            _test.Pages.Homepage.BrowseSolutionsControlDisplayed();
        }

        [Then(@"a control to access Guidance Content for Buyers")]
        public void ThenAControlToAccessGuidanceContentForBuyers()
        {
            _test.Pages.Homepage.GuidanceContentControlDisplayed();
        }
    }
}
