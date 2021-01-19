using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.LayoutComponents
{
    [Binding]
    public sealed class CommonLayoutSteps
    {
        private readonly UITest _test;

        public CommonLayoutSteps(UITest test)
        {
            _test = test;
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
