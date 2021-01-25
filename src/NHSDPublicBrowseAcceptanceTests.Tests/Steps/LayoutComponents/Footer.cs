namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.LayoutComponents
{
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class Footer
    {
        private readonly UITest test;

        public Footer(UITest test)
        {
            this.test = test;
        }

        [Then(@"it contains a Footer")]
        [Then(@"the Footer is presented")]
        public void ThenTheFooterIsPresented()
        {
            test.Pages.Footer.ComponentDisplayed();
        }

        [Given(@"the User chooses to select a URL in the Footer")]
        public void GivenTheUserChoosesToSelectAURLInTheFooter()
        {
            ThenTheFooterIsPresented();
        }

        [When(@"they select (.*)")]
        public void WhenTheySelectAURL(string linkText)
        {
            test.Pages.Footer.SelectURL(linkText);
        }

        [Then(@"they are directed according to the URL (.*)")]
        public void ThenTheyAreDirectedAccordingToTheURL(string href)
        {
            test.Pages.Common.URLContains(href);
        }
    }
}
