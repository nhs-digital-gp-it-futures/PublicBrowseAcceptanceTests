using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions
{
    [Binding]
    public class ViewASolution
    {
        private const string dateFormat = "dd MMMM yyyy";
        private readonly ScenarioContext _context;
        private readonly UITest _test;
        private string expectedLastUpdatedDate;

        public ViewASolution(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that a User views a Solution")]
        public void GivenThatAUserViewsASolution()
        {
            new ViewSolutionsList(_test, _context).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            _test.Pages.SolutionsList.OpenRandomSolution();
        }

        [Given(@"that a User views a created Solution")]
        public void GivenThatAUserViewsACreatedSolution()
        {
            new ViewSolutionOnlyWhenPublished(_test, _context).GivenThatASolutionHasAPublishedStatusOf(3);
            _test.ContactDetails.Add(CreateContactDetails.NewContactDetail());
            _test.ContactDetails[0].AddMarketingContactForSolution(_test.ConnectionString, _test.Solution.Id);
            new ViewSolutionsList(_test, _context).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            var oldDate = new DateTime(2001, 02, 03);
            LastUpdatedHelper.UpdateLastUpdated(oldDate, "Solution", "id", _test.Solution.Id, _test.ConnectionString);
            LastUpdatedHelper.UpdateLastUpdated(oldDate, "SolutionDetail", "SolutionId", _test.Solution.Id,
                _test.ConnectionString);
            LastUpdatedHelper.UpdateLastUpdated(oldDate, "MarketingContact", "SolutionId", _test.Solution.Id,
                _test.ConnectionString);
            _test.Pages.SolutionsList.OpenNamedSolution(_test.Solution.Name);
        }


        [Given(@"that a User views a Foundation Solution")]
        public void GivenThatAUserViewsAFoundationSolution()
        {
            _test.Pages.Homepage.ClickBrowseSolutions();
            _test.Pages.BrowseSolutions.OpenFoundationSolutions();
            _test.Pages.SolutionsList.OpenRandomSolution();
        }

        [StepDefinition(@"the User is viewing the Solution Page")]
        public void WhenTheUserIsViewingTheSolutionPage()
        {
            _test.Pages.ViewASolution.PageDisplayed(_test.Url);
            var id = _test.Pages.ViewASolution.GetSolutionId();
            _test.Solution = new Solution {Id = id}.Retrieve(_test.ConnectionString);
            _test.SolutionDetail = new SolutionDetail {SolutionId = _test.Solution.Id}.Retrieve(_test.ConnectionString);
        }

        [Then(@"the page will contain Supplier Name")]
        public void ThenThePageWillContainSupplierName()
        {
            _test.Pages.ViewASolution.SupplierNameDisplayed();
        }

        [Then(@"Solution Name")]
        public void ThenSolutionName()
        {
            var solutionName = _test.Pages.ViewASolution.GetSolutionName();
            solutionName.Should().Be(_test.Solution.Name);
        }

        [Then(@"Solution Summary")]
        public void ThenSolutionSummary()
        {
            var solutionSummary = _test.Pages.ViewASolution.GetSolutionSummary().TrimEnd();
            solutionSummary.Should().Be(_test.SolutionDetail.Summary.TrimEnd().Replace("/r", ""));
        }

        [Then(@"Solution Full Description")]
        public void ThenSolutionFullDescription()
        {
            var solutionFullDescription = _test.Pages.ViewASolution.GetSolutionFullDescription().TrimEnd();
            solutionFullDescription.Should().Be(_test.SolutionDetail.FullDescription.TrimEnd().Replace("/r", ""));
        }


        [Then(@"About Solution URL")]
        public void ThenAboutSolutionURL()
        {
            if (!string.IsNullOrEmpty(_test.SolutionDetail.AboutUrl))
            {
                var solutionAboutUrl = _test.Pages.ViewASolution.GetSolutionAboutUrl();
                solutionAboutUrl.Should().Be(_test.SolutionDetail.AboutUrl);
            }
        }

        [Then(@"Contact Details")]
        public void ThenContactDetails()
        {
            var contactDetails = _test.Pages.ViewASolution.GetSolutionContactDetails();
            _test.ContactDetails = SqlExecutor.Execute<SolutionContactDetails>(_test.ConnectionString,
                Queries.GetSolutionContactDetails, new {solutionId = _test.Solution.Id}).ToList();

            contactDetails.ContactName.Should().Be(_test.ContactDetails[0].ContactName);
            contactDetails.Department.Should().Be(_test.ContactDetails[0].Department);
            contactDetails.Email.Should().Be(_test.ContactDetails[0].Email);
            contactDetails.PhoneNumber.Should().Be(_test.ContactDetails[0].PhoneNumber);
        }

        [Then(@"list of Capabilities")]
        public void ThenListOfCapabilities()
        {
            _test.Pages.ViewASolution.CapabilitiesListDisplayed().Should().BeTrue();
        }

        [Then(@"Solution ID")]
        public void ThenSolutionID()
        {
            var id = _test.Pages.ViewASolution.GetSolutionId();
            id.Should().Be(_test.Solution.Id);
        }

        [Then(@"there is a link for the User to download an attachment")]
        public void ThenThereIsALinkForTheUserToDownloadAnAttachment()
        {
            _test.Pages.ViewASolution.AttachmentDownloadLinkDisplayed().Should().BeTrue();
        }

        [Then(
            @"the page will contain an indication that the Solution meets the criteria for a Foundation Solution Set")]
        public void ThenThePageWillContainAnIndicationThatTheSolutionMeetsTheCriteriaForAFoundationSolutionSet()
        {
            _test.Pages.ViewASolution.FoundationSolutionIndicatorDisplayed().Should().BeTrue();
        }

        [Then(@"the capabilities listed match the expected capabilities in the database")]
        public void ThenTheCapabilitiesListedMatchTheExpectedCapabilitiesInTheDatabase()
        {
            var solutionId = _test.Pages.ViewASolution.GetSolutionId();
            var capabilities = new Capability().GetSolutionCapabilities(_test.ConnectionString, _test.Solution.Id)
                .Select(s => s.Name);
            var actualCapabilities = _test.Pages.ViewASolution.GetSolutionCapabilities();
            actualCapabilities.Should().BeEquivalentTo(capabilities);
        }

        [Then(@"the Download more information button downloads a '(.*)' file")]
        public void ThenTheDownloadMoreInformationButtonDownloadsAFile(string fileFormat)
        {
            // Filename is to match the solution ID at all times
            var solId = _test.Pages.ViewASolution.GetSolutionId();
            var fileName = $"{solId}.{fileFormat.ToLower()}";
            var downloadLink = _test.Pages.ViewASolution.GetAttachmentDownloadLinkUrl();

            var downloadPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            downloadLink.Should().Contain(fileName);

            _test.Pages.Common.DownloadFile(fileName, downloadPath, downloadLink);
        }

        [When(@"the LastUpdated value in the (.*) table is updated")]
        public void WhenTheLastUpdatedValueInTheSolutionTableIsUpdated(string tableName)
        {
            var updatedDate = DateTime.Now;

            // Use long variant of date (i.e. 12 December 2019)
            expectedLastUpdatedDate = ConvertDateToLongDateTime(updatedDate);

            var whereKey = tableName.Equals("Solution") ? "Id" : "SolutionId";

            LastUpdatedHelper.UpdateLastUpdated(updatedDate, tableName, whereKey, _test.Solution.Id,
                _test.ConnectionString);
        }

        [Then(@"the page last updated date shown is updated as expected")]
        public void ThenThePageLastUpdatedDateShownIsUpdatedAsExpected()
        {
            _test.Driver.Navigate().Refresh();
            var actualLastUpdated = _test.Pages.ViewASolution.GetSolutionLastUpdated();

            var convertedDate = ConvertDateToLongDateTime(actualLastUpdated);

            convertedDate.Should().Be(expectedLastUpdatedDate);
        }

        [Then(@"Features")]
        public void ThenFeatures()
        {
            _test.Pages.ViewASolution.GetFeatures().Should().HaveCountGreaterThan(0);
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