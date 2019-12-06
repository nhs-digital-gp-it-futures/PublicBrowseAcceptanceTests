﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
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
            _test.pages.SolutionsList.OpenRandomFoundationSolution();
        }

        [When(@"the User is viewing the Solution Page")]
        public void WhenTheUserIsViewingTheSolutionPage()
        {
            _test.pages.ViewASolution.PageDisplayed(_test.url);
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
            var solutionSummary = _test.pages.ViewASolution.GetSolutionSummary().TrimEnd();
            solutionSummary.Should().Be(SolutionDetails.Summary.TrimEnd());
        }

        [Then(@"Solution Full Description")]
        public void ThenSolutionFullDescription()
        {
            var solutionFullDescription = _test.pages.ViewASolution.GetSolutionFullDescription().TrimEnd();
            solutionFullDescription.Should().Be(SolutionDetails.FullDescription.TrimEnd());
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
            var contactDetails = _test.pages.ViewASolution.GetSolutionContactDetails();

            contactDetails.Should().BeEquivalentTo(SolutionDetails.SolutionContactDetails);
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

        [Then(@"the capabilities listed match the expected capabilities in the database")]
        public void ThenTheCapabilitiesListedMatchTheExpectedCapabilitiesInTheDatabase()
        {
            var solutionId = _test.pages.ViewASolution.GetSolutionId();
            var capabilities = SqlHelper.GetSolutionCapabilities(solutionId, _test.connectionString).Split(',').ToList();
            var actualCapabilities = _test.pages.ViewASolution.GetSolutionCapabilities();
            actualCapabilities.Should().BeEquivalentTo(capabilities);
        }

        [Then(@"the Download more information button downloads a '(.*)' file")]
        public void ThenTheDownloadMoreInformationButtonDownloadsAFile(string fileFormat)
        {
            // Filename is to match the solution ID at all times
            var solId = _test.pages.ViewASolution.GetSolutionId();
            var fileName = $"{solId}.{fileFormat.ToLower()}";
            var downloadLink = _test.pages.ViewASolution.GetDownloadUrl();
            var downloadPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            downloadLink.Should().Contain(fileName);

            // Does the download. Will fail test if download fails
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(downloadLink, Path.Combine(downloadPath, fileName));
            }
        }
    }
}
