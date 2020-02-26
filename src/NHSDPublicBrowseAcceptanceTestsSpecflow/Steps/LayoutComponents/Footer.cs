using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.LayoutComponents
{
    [Binding]
    public sealed class Footer
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;

        public Footer(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Then(@"it contains a Footer")]
        [Then(@"the Footer is presented")]
        public void ThenTheFooterIsPresented()
        {
            _test.Pages.Footer.ComponentDisplayed();
        }

        [Given(@"the User chooses to select a URL in the Footer")]
        public void GivenTheUserChoosesToSelectAURLInTheFooter()
        {
            ThenTheFooterIsPresented();
        }

        [When(@"they select (.*)")]
        public void WhenTheySelectAURL(string linkText)
        {
            _test.Pages.Footer.SelectURL(linkText);
        }

        [Then(@"they are directed according to the URL (.*)")]
        public void ThenTheyAreDirectedAccordingToTheURL(string href)
        {
            _test.Pages.Common.URLContains(href);
        }

    }
}
