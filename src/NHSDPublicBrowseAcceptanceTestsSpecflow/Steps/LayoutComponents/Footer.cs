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

        [Then(@"the Footer is presented")]
        public void ThenTheFooterIsPresented()
        {
            _context.Pending();
        }

        [Given(@"the User chooses to select a URL in the Footer")]
        public void GivenTheUserChoosesToSelectAURLInTheFooter()
        {
            _context.Pending();
        }

        [When(@"they select a URL")]
        public void WhenTheySelectAURL()
        {
            _context.Pending();
        }

        [Then(@"they are directed according to the URL")]
        public void ThenTheyAreDirectedAccordingToTheURL()
        {
            _context.Pending();
        }

    }
}
