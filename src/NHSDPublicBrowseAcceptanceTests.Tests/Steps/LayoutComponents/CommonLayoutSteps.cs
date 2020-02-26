using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.LayoutComponents
{
    [Binding]
    public sealed class CommonLayoutSteps
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;

        public CommonLayoutSteps(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"the User chooses any Page in the application")]
        public void GivenTheUserChoosesAnyPageInTheApplication()
        {
            _test.Pages.Homepage.PageDisplayed();
        }

        [When(@"they are on a Page")]
        public void WhenTheyAreOnAPage()
        {
            _test.Pages.Homepage.PageDisplayed();
        }
    }
}
