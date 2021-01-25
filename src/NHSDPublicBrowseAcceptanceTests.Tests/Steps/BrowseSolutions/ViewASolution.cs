namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
    using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class ViewASolution
    {
        private const string DateFormat = "dd MMMM yyyy";
        private readonly ScenarioContext context;
        private readonly UITest test;
        private readonly Settings settings;
        private string expectedLastUpdatedDate;

        public ViewASolution(UITest test, ScenarioContext context, Settings settings)
        {
            this.test = test;
            this.context = context;
            this.settings = settings;
        }

        [Given(@"that a User views a Solution")]
        public void GivenThatAUserViewsASolution()
        {
            new ViewSolutionsList(test).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            test.Pages.SolutionsList.OpenRandomSolution();
        }

        [Given(@"that a User views a created Solution")]
        public void GivenThatAUserViewsACreatedSolution()
        {
            test.CatalogueItem = GenerateCatalogueItem.GenerateNewCatalogueItem(
                checkForUnique: true,
                connectionString: test.ConnectionString,
                publishedStatus: 3);
            test.CatalogueItem.Create(test.ConnectionString);
            test.Solution = GenerateSolution.GenerateNewSolution(test.CatalogueItem.CatalogueItemId, 0, false);
            test.Solution.Create(test.ConnectionString);
            context.Add("DeleteSolution", true);
            Capability.AddRandomCapabilityToSolution(test.ConnectionString, test.Solution.Id);
            test.Driver.Navigate().Refresh();

            test.ContactDetails.Add(CreateContactDetails.NewContactDetail());
            test.ContactDetails[0].AddMarketingContactForSolution(test.ConnectionString, test.Solution.Id);
            new ViewSolutionsList(test).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            var oldDate = new DateTime(2001, 02, 03);
            LastUpdatedHelper.UpdateLastUpdated(oldDate, "Solution", "id", test.Solution.Id, test.ConnectionString);
            LastUpdatedHelper.UpdateLastUpdated(
                oldDate,
                "MarketingContact",
                "SolutionId",
                test.Solution.Id,
                test.ConnectionString);
            test.Pages.SolutionsList.OpenNamedSolution(test.CatalogueItem.Name);
        }

        [Given(@"that a User views a Foundation Solution")]
        public void GivenThatAUserViewsAFoundationSolution()
        {
            test.Pages.Homepage.ClickBrowseSolutions();
            test.Pages.BrowseSolutions.OpenFoundationSolutions();
            test.Pages.SolutionsList.OpenRandomSolution();
        }

        [StepDefinition(@"the User is viewing the Solution Page")]
        public void WhenTheUserIsViewingTheSolutionPage()
        {
            test.Pages.ViewASolution.PageDisplayed(settings.PublicBrowseUrl);
            var id = test.Pages.ViewASolution.GetSolutionId();
            test.Solution = new Solution { Id = id }.Retrieve(test.ConnectionString);
            test.CatalogueItem = new CatalogueItem { CatalogueItemId = id }.Retrieve(test.ConnectionString);
        }

        [Then(@"the page will contain Supplier Name")]
        public void ThenThePageWillContainSupplierName()
        {
            test.Pages.ViewASolution.SupplierNameDisplayed();
        }

        [Then(@"Solution Name")]
        public void ThenSolutionName()
        {
            var solutionName = test.Pages.ViewASolution.GetSolutionName();
            solutionName.Should().Be(test.CatalogueItem.Name);
        }

        [Then(@"Solution Summary")]
        public void ThenSolutionSummary()
        {
            var expected = Regex.Replace(test.Solution.Summary, @"\s", string.Empty);
            var solutionSummary = Regex.Replace(test.Pages.ViewASolution.GetSolutionSummary(), @"\s", string.Empty);
            solutionSummary.Should().Be(expected);
        }

        [Then(@"Solution Full Description")]
        public void ThenSolutionFullDescription()
        {
            var expected = Regex.Replace(test.Solution.FullDescription, @"\s", string.Empty);
            var solutionFullDescription = Regex.Replace(test.Pages.ViewASolution.GetSolutionFullDescription(), @"\s", string.Empty);
            solutionFullDescription.Should().Be(expected);
        }

        [Then(@"About Solution URL")]
        public void ThenAboutSolutionURL()
        {
            if (!string.IsNullOrEmpty(test.Solution.AboutUrl))
            {
                var solutionAboutUrl = test.Pages.ViewASolution.GetSolutionAboutUrl();
                solutionAboutUrl.Should().Be(test.Solution.AboutUrl);
            }
        }

        [Then(@"Contact Details")]
        public void ThenContactDetails()
        {
            test.ContactDetails = SqlExecutor.Execute<SolutionContactDetails>(
                test.ConnectionString,
                Queries.GetSolutionContactDetails,
                new { solutionId = test.Solution.Id }).ToList();

            if (test.ContactDetails.Count > 0)
            {
                var contactDetails = test.Pages.ViewASolution.GetSolutionContactDetails(
                    !string.IsNullOrEmpty(test.ContactDetails[0].ContactName.Trim()),
                    !string.IsNullOrEmpty(test.ContactDetails[0].Department),
                    !string.IsNullOrEmpty(test.ContactDetails[0].PhoneNumber),
                    !string.IsNullOrEmpty(test.ContactDetails[0].Email));
                contactDetails.ContactName.Should().Be(test.ContactDetails[0].ContactName);
                contactDetails.Department.Should().Be(test.ContactDetails[0].Department);
                contactDetails.Email.Should().Be(test.ContactDetails[0].Email);
                contactDetails.PhoneNumber.Should().Be(test.ContactDetails[0].PhoneNumber);
            }
        }

        [Then(@"list of Capabilities")]
        public void ThenListOfCapabilities()
        {
            test.Pages.ViewASolution.CapabilitiesListDisplayed().Should().BeTrue();
        }

        [Then(@"Solution ID")]
        public void ThenSolutionID()
        {
            var id = test.Pages.ViewASolution.GetSolutionId();
            id.Should().Be(test.Solution.Id);
        }

        [Then(@"there is a link for the User to download an attachment")]
        public void ThenThereIsALinkForTheUserToDownloadAnAttachment()
        {
            test.Pages.ViewASolution.AttachmentDownloadLinkDisplayed().Should().BeTrue();
        }

        [Then(
            @"the page will contain an indication that the Solution meets the criteria for a Foundation Solution Set")]
        public void ThenThePageWillContainAnIndicationThatTheSolutionMeetsTheCriteriaForAFoundationSolutionSet()
        {
            test.Pages.ViewASolution.FoundationSolutionIndicatorDisplayed().Should().BeTrue();
        }

        [Then(@"the capabilities listed match the expected capabilities in the database")]
        public void ThenTheCapabilitiesListedMatchTheExpectedCapabilitiesInTheDatabase()
        {
            var solutionId = test.Pages.ViewASolution.GetSolutionId();
            var capabilities = Capability.GetSolutionCapabilities(test.ConnectionString, test.Solution.Id)
                .Select(s => s.Name);
            var actualCapabilities = test.Pages.ViewASolution.GetSolutionCapabilities();
            actualCapabilities.Should().BeEquivalentTo(capabilities);
        }

        [Then(@"the Download more information button downloads a '(.*)' file")]
        public void ThenTheDownloadMoreInformationButtonDownloadsAFile(string fileFormat)
        {
            // Filename is to match the solution ID at all times
            var solId = test.Pages.ViewASolution.GetSolutionId();
            var fileName = $"{solId}.{fileFormat.ToLower()}";
            var downloadLink = test.Pages.ViewASolution.GetAttachmentDownloadLinkUrl();

            var downloadPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            downloadLink.Should().Contain(fileName);

            Actions.Pages.Common.DownloadFile(fileName, downloadPath, downloadLink);
        }

        [When(@"the LastUpdated value in the (.*) table is updated")]
        public void WhenTheLastUpdatedValueInTheSolutionTableIsUpdated(string tableName)
        {
            var updatedDate = DateTime.Now;

            // Use long variant of date (i.e. 12 December 2019)
            expectedLastUpdatedDate = ConvertDateToLongDateTime(updatedDate);

            var whereKey = tableName.Equals("Solution") ? "Id" : "SolutionId";

            LastUpdatedHelper.UpdateLastUpdated(
                updatedDate,
                tableName,
                whereKey,
                test.Solution.Id,
                test.ConnectionString);
        }

        [Then(@"the page last updated date shown is updated as expected")]
        public void ThenThePageLastUpdatedDateShownIsUpdatedAsExpected()
        {
            test.Driver.Navigate().Refresh();
            var actualLastUpdated = test.Pages.ViewASolution.GetSolutionLastUpdated();

            var convertedDate = ConvertDateToLongDateTime(actualLastUpdated);

            convertedDate.Should().Be(expectedLastUpdatedDate);
        }

        [Then(@"Features")]
        public void ThenFeatures()
        {
            test.Pages.ViewASolution.GetFeatures().Should().HaveCountGreaterThan(0);
        }

        private static string ConvertDateToLongDateTime(string date)
        {
            return ConvertDateToLongDateTime(Convert.ToDateTime(date));
        }

        private static string ConvertDateToLongDateTime(DateTime date)
        {
            return date.ToString(DateFormat);
        }
    }
}
