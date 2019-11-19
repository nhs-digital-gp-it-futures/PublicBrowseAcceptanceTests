using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using System;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.BrowseSolutions
{
    [Binding]
    public class ViewASolution
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;
        private SolutionDto SolutionDetails;

        public ViewASolution(UITest test, ScenarioContext context)        
        {
            _test = test;
            _context = context;
        }

        [Given(@"that a User views a Solution")]
        public void GivenThatAUserViewsASolution()
        {
            new ViewSolutionsList(_test, _context).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            _test.pages.SolutionsList.OpenRandomSolution();
        }

        [Given(@"that a User views a Foundation Solution")]
        public void GivenThatAUserViewsAFoundationSolution()
        {
            new ViewSolutionsList(_test, _context).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            _test.pages.SolutionsList.OpenFoundationSolution();
        }

        [When(@"the User is viewing the Solution Page")]
        public void WhenTheUserIsViewingTheSolutionPage()
        {
            _test.pages.ViewASolution.PageDisplayed();
            var id = _test.pages.ViewASolution.GetSolutionId();
            SolutionDetails = SqlHelper.GetSolutionDetailsObject(id, _test.connectionString);
        }
        
        [Then(@"the page will contain Supplier Name")]
        public void ThenThePageWillContainSupplierName()
        {
            var supplierName = _test.pages.ViewASolution.GetSupplierName();
            supplierName.Should().Be(SolutionDetails.SupplierName);
        }
        
        [Then(@"Solution Name")]
        public void ThenSolutionName()
        {
            var solutionName = _test.pages.ViewASolution.GetSolutionName();
            solutionName.Should().Be(SolutionDetails.Name);
        }
        
        [Then(@"Solution Summary")]
        public void ThenSolutionSummary()
        {
            var solutionSummary = _test.pages.ViewASolution.GetSolutionSummary();
            solutionSummary.Should().Be(SolutionDetails.Summary);
        }
        
        [Then(@"About Solution URL")]
        public void ThenAboutSolutionURL()
        {
            if (!string.IsNullOrEmpty(SolutionDetails.AboutUrl))
            {
                var solutionAboutUrl = _test.pages.ViewASolution.GetSolutionAboutUrl();
                solutionAboutUrl.Should().Be(SolutionDetails.AboutUrl);
            }
        }
        
        [Then(@"Contact Details")]
        public void ThenContactDetails()
        {
            _context.Pending();
        }
        
        [Then(@"Last Updated Date")]
        public void ThenLastUpdatedDate()
        {
            var lastUpdated = SolutionDetails.LastUpdated.ToString("dd-MMM-yyyy");
            var actualLastUpdated = _test.pages.ViewASolution.GetSolutionLastUpdated();
            actualLastUpdated.Should().Be(lastUpdated);
        }
        
        [Then(@"list of Capabilities")]
        public void ThenListOfCapabilities()
        {
            _test.pages.ViewASolution.CapabilitiesListDisplayed().Should().BeTrue();
        }
        
        [Then(@"Solution ID")]
        public void ThenSolutionID()
        {
            var id = _test.pages.ViewASolution.GetSolutionId();
            id.Should().Be(SolutionDetails.Id);
        }

        [Then(@"there is a link for the User to download an attachment")]
        public void ThenThereIsALinkForTheUserToDownloadAnAttachment()
        {
            _test.pages.ViewASolution.AttachmentDownloadLinkDisplayed().Should().BeTrue();
        }

        [Then(@"the page will contain an indication that the Solution meets the criteria for a Foundation Solution Set")]
        public void ThenThePageWillContainAnIndicationThatTheSolutionMeetsTheCriteriaForAFoundationSolutionSet()
        {
            _test.pages.ViewASolution.FoundationSolutionIndicatorDisplayed().Should().BeTrue();
        }

    }
}
