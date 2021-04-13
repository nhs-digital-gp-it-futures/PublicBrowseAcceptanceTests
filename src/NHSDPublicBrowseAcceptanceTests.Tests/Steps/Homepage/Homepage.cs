namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.Homepage
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

        [StepDefinition(@"the Buying Catalogue homepage is presented")]
        [Given(@"that the user is on the Buying Catalogue Homepage")]
        [StepDefinition(@"the user navigates to the Buying Catalogue Homepage")]
        [Given(@"that the user wants to begin the Proxy Buyer registration journey")]
        [Given(@"the User chooses to view the Buying Catalogue Homepage")]
        [StepDefinition(@"the Homepage is presented")]
        public void GivenTheUserChoosesToViewTheBuyingCatalogueHomepage()
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

        [Given(@"that the user chooses to view DFOCVC solutions")]
        public void GivenThatTheUserChoosesToViewDFOCVCSolutions()
        {
            test.Pages.Homepage.ClickDFOCVCSolutionsCard();
        }

        [StepDefinition(@"the user chooses to nominate an organisation")]
        public void TheUserChoosesToNominate()
        {
            test.Pages.Homepage.ClickNominateOrg();
        }
        
        [Then(@"there is a control to nominate an organisation")]
        public void ThenThereIsAControlToNominateAnOrganisation()
        {
            test.Pages.Homepage.NominateAnOrgControlDisplayed();
        }

        [StepDefinition(@"the user is on the proxy buyer information page")]
        [Then(@"the Proxy Buyer Information page is presented")]
        public void ThenTheProxyBuyerInformationPageIsPresented()
        {
            test.Pages.Homepage.ProxyInfoPageDisplayed();
        }

        [Then(@"there is a Link to nominate an organisation")]
        public void ThenThereIsALinkToNominateAnOrganisation()
        {
            test.Pages.Homepage.NominateAnOrgLink();
        }

        [Then(@"there is a link for the Procurement Hub")]
        public void ThenThereIsALinkForTheProcurementHub()
        {
            test.Pages.Homepage.ProcurementHubLink();
        }


        [When(@"the user chooses to go back")]
        public void WhenTheUserChoosesToGoBack()
        {
            test.Pages.Homepage.ClickBackLink();
        }

        [Given(@"that the user is on the proxy buyer information page")]
        public void GivenThatTheUserIsOnTheProxyBuyerInformationPage()
        {
            GivenTheUserChoosesToViewTheBuyingCatalogueHomepage();
            ThenThereIsAControlToNominateAnOrganisation();
            ThenTheProxyBuyerInformationPageIsPresented();
        }

    }
}
