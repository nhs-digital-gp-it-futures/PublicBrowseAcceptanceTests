namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.LayoutComponents
{
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class CommonLayoutSteps
    {
        private readonly UITest test;

        public CommonLayoutSteps(UITest test)
        {
            this.test = test;
        }

        [Given(@"the User chooses any Page in the application")]
        public void GivenTheUserChoosesAnyPageInTheApplication()
        {
            test.Pages.Homepage.PageDisplayed();
        }

        [When(@"they are on a Page")]
        public void WhenTheyAreOnAPage()
        {
            test.Pages.Homepage.PageDisplayed();
        }
    }
}
