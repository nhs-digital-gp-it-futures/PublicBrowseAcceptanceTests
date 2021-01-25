﻿namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.Homepage
{
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class Homepage
    {
        private readonly UITest test;

        public Homepage(UITest test)
        {
            this.test = test;
        }

        [Given(@"the User chooses to view the Buying Catalogue Homepage")]
        public void GivenTheUserChoosesToViewTheBuyingCatalogueHomepage()
        {
            test.Pages.Homepage.PageDisplayed();
        }

        [When(@"the Homepage is presented")]
        public void WhenTheHomepageIsPresented()
        {
            test.Pages.Homepage.PageDisplayed();
        }

        [Then(@"content about the Buying Catalogue")]
        public void ThenContentAboutTheBuyingCatalogue()
        {
            test.Pages.Homepage.AboutUsSectionDisplayed();
        }

        [Then(@"a control to access Browse Solutions")]
        public void ThenAControlToAccessBrowseSolutions()
        {
            test.Pages.Homepage.BrowseSolutionsControlDisplayed();
        }

        [Then(@"a control to access Guidance Content for Buyers")]
        public void ThenAControlToAccessGuidanceContentForBuyers()
        {
            test.Pages.Homepage.GuidanceContentControlDisplayed();
        }
    }
}
