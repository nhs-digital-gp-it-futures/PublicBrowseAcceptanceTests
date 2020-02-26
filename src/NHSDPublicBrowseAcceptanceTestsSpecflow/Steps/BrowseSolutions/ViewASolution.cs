﻿using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using System;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.BrowseSolutions
{
    [Binding]
    public class ViewASolution : CommonSteps
    {
        private string expectedLastUpdatedDate;
        private const string dateFormat = "dd MMMM yyyy";

        public ViewASolution(UITest test, ScenarioContext context): base (test, context)
        {
        }

        [Given(@"that a User views a Solution")]
        public void GivenThatAUserViewsASolution()
        {
            new ViewSolutionsList(_test, _context).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            _test.pages.SolutionsList.OpenRandomSolution();
        }

        [Given(@"that a User views a created Solution")]
        public void GivenThatAUserViewsACreatedSolution()
        {
            new ViewSolutionOnlyWhenPublished(_test, _context).GivenThatASolutionHasAPublishedStatusOf(3);
            _test.contactDetails.Add(CreateContactDetails.NewContactDetail());
            _test.contactDetails[0].AddMarketingContactForSolution(_test.connectionString, _test.solution.Id);
            new ViewSolutionsList(_test, _context).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            var oldDate = new DateTime(2001, 02, 03);
            LastUpdatedHelper.UpdateLastUpdated(oldDate, "Solution", "id", _test.solution.Id, _test.connectionString);
            LastUpdatedHelper.UpdateLastUpdated(oldDate, "SolutionDetail", "SolutionId", _test.solution.Id, _test.connectionString);
            LastUpdatedHelper.UpdateLastUpdated(oldDate, "MarketingContact", "SolutionId", _test.solution.Id, _test.connectionString);
            _test.pages.SolutionsList.OpenNamedSolution(_test.solution.Name);
        }


        [Given(@"that a User views a Foundation Solution")]
        public void GivenThatAUserViewsAFoundationSolution()
        {
            _test.pages.Homepage.ClickBrowseSolutions();
            _test.pages.BrowseSolutions.OpenFoundationSolutions();
            _test.pages.SolutionsList.OpenRandomSolution();
        }

        [StepDefinition(@"the User is viewing the Solution Page")]
        public void WhenTheUserIsViewingTheSolutionPage()
        {
            _test.pages.ViewASolution.PageDisplayed(_test.url);
            var id = _test.pages.ViewASolution.GetSolutionId();
            _test.solution = new Solution() { Id = id }.Retrieve(_test.connectionString);
            _test.solutionDetail = new SolutionDetail() { SolutionId = _test.solution.Id }.Retrieve(_test.connectionString);            
        }

        [Then(@"the page will contain Supplier Name")]
        public void ThenThePageWillContainSupplierName()
        {
            _test.pages.ViewASolution.SupplierNameDisplayed();
        }

        [Then(@"Solution Name")]
        public void ThenSolutionName()
        {
            var solutionName = _test.pages.ViewASolution.GetSolutionName();
            solutionName.Should().Be(_test.solution.Name);
        }

        [Then(@"Solution Summary")]
        public void ThenSolutionSummary()
        {
            var solutionSummary = _test.pages.ViewASolution.GetSolutionSummary().TrimEnd();
            solutionSummary.Should().Be(_test.solutionDetail.Summary.TrimEnd());
        }

        [Then(@"Solution Full Description")]
        public void ThenSolutionFullDescription()
        {
            var solutionFullDescription = _test.pages.ViewASolution.GetSolutionFullDescription().TrimEnd();
            solutionFullDescription.Should().Be(_test.solutionDetail.FullDescription.TrimEnd());
        }


        [Then(@"About Solution URL")]
        public void ThenAboutSolutionURL()
        {
            if (!string.IsNullOrEmpty(_test.solutionDetail.AboutUrl))
            {
                var solutionAboutUrl = _test.pages.ViewASolution.GetSolutionAboutUrl();
                solutionAboutUrl.Should().Be(_test.solutionDetail.AboutUrl);
            }
        }

        [Then(@"Contact Details")]
        public void ThenContactDetails()
        {
            var contactDetails = _test.pages.ViewASolution.GetSolutionContactDetails();
            _test.contactDetails = SqlExecutor.Execute<SolutionContactDetails>(_test.connectionString, Queries.GetSolutionContactDetails, new { solutionId = _test.solution.Id }).ToList();

            contactDetails.ContactName.Should().Be(_test.contactDetails[0].ContactName);
            contactDetails.Department.Should().Be(_test.contactDetails[0].Department);
            contactDetails.Email.Should().Be(_test.contactDetails[0].Email);
            contactDetails.PhoneNumber.Should().Be(_test.contactDetails[0].PhoneNumber);
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
            id.Should().Be(_test.solution.Id);
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
            var capabilities = new Capability().GetSolutionCapabilities(_test.connectionString, _test.solution.Id).Select(s => s.Name);
            var actualCapabilities = _test.pages.ViewASolution.GetSolutionCapabilities();
            actualCapabilities.Should().BeEquivalentTo(capabilities);
        }

        [Then(@"the Download more information button downloads a '(.*)' file")]
        public void ThenTheDownloadMoreInformationButtonDownloadsAFile(string fileFormat)
        {
            // Filename is to match the solution ID at all times
            var solId = _test.pages.ViewASolution.GetSolutionId();
            var fileName = $"{solId}.{fileFormat.ToLower()}";
            var downloadLink = _test.pages.ViewASolution.GetAttachmentDownloadLinkUrl();

            var downloadPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            downloadLink.Should().Contain(fileName);

            _test.pages.Common.DownloadFile(fileName, downloadPath, downloadLink);
        }

        [When(@"the LastUpdated value in the (.*) table is updated")]
        public void WhenTheLastUpdatedValueInTheSolutionTableIsUpdated(string tableName)
        {
            var updatedDate = DateTime.Now;

            // Use long variant of date (i.e. 12 December 2019)
            expectedLastUpdatedDate = ConvertDateToLongDateTime(updatedDate);

            var whereKey = tableName.Equals("Solution") ? "Id" : "SolutionId";

            LastUpdatedHelper.UpdateLastUpdated(updatedDate, tableName, whereKey, _test.solution.Id, _test.connectionString);
        }

        [Then(@"the page last updated date shown is updated as expected")]
        public void ThenThePageLastUpdatedDateShownIsUpdatedAsExpected()
        {
            _test.driver.Navigate().Refresh();
            var actualLastUpdated = _test.pages.ViewASolution.GetSolutionLastUpdated();

            var convertedDate = ConvertDateToLongDateTime(actualLastUpdated);
            
            convertedDate.Should().Be(expectedLastUpdatedDate);
        }

        [Then(@"Features")]
        public void ThenFeatures()
        {
            _test.pages.ViewASolution.GetFeatures().Should().HaveCountGreaterThan(0);
        }

        private string ConvertDateToLongDateTime(string date)
        {
            return ConvertDateToLongDateTime(Convert.ToDateTime(date));
        }
        private string ConvertDateToLongDateTime(DateTime date)
        {
            return date.ToString(dateFormat);
        }
    }
}
