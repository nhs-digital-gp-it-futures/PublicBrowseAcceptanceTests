namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
    using NHSDPublicBrowseAcceptanceTests.TestData.Extensions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class ViewASolution
    {
        private readonly ScenarioContext context;
        private readonly UITest test;
        private readonly Settings settings;

        public ViewASolution(UITest test, ScenarioContext context, Settings settings)
        {
            this.test = test;
            this.context = context;
            this.settings = settings;
        }

        [Given(@"that a User views a Solution")]
        public void GivenThatAUserViewsASolution()
        {
            new ViewSolutionsList(test, context).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            test.Pages.SolutionsList.OpenRandomSolution();
        }

        [Given(@"that a User views a Random Solution")]
        public void GivenThatAUserViewsARandomSolution()
        {
            test.Pages.SolutionsList.OpenRandomSolution();
        }

        [Given(@"that a User views a created Solution")]
        public async Task GivenThatAUserViewsACreatedSolution()
        {
            test.CatalogueItem = await GenerateCatalogueItem.GenerateNewCatalogueItemAsync(
                checkForUnique: true,
                connectionString: test.ConnectionString,
                publishedStatus: 3);
            await test.CatalogueItem.CreateAsync(test.ConnectionString);

            test.Solution = GenerateSolution.GenerateNewSolution(test.CatalogueItem.CatalogueItemId, 0, false);
            await test.Solution.CreateAsync(test.ConnectionString);
            context.Add("DeleteSolution", true);

            await Capability.AddRandomCapabilityToSolutionAsync(test.ConnectionString, test.CatalogueItem.CatalogueItemId);
            test.Driver.Navigate().Refresh();

            test.ContactDetails.Add(CreateContactDetails.NewContactDetail());
            await test.ContactDetails[0].AddMarketingContactForSolution(test.ConnectionString, test.CatalogueItem.CatalogueItemId);

            new ViewSolutionsList(test, context).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            var oldDate = new DateTime(2001, 02, 03);
            await LastUpdatedHelper.UpdateLastUpdated(oldDate, "Solution", "id", test.CatalogueItem.CatalogueItemId, test.ConnectionString);
            await LastUpdatedHelper.UpdateLastUpdated(
                oldDate,
                "MarketingContact",
                "SolutionId",
                test.CatalogueItem.CatalogueItemId,
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
        public async Task WhenTheUserIsViewingTheSolutionPage()
        {
            test.Pages.ViewASolution.PageDisplayed(settings.PublicBrowseUrl);
            var id = test.Pages.ViewASolution.GetSolutionId();
            test.Solution = await new Solution { SolutionId = id }.RetrieveAsync(test.ConnectionString);
            test.CatalogueItem = await new CatalogueItem { CatalogueItemId = id }.RetrieveAsync(test.ConnectionString);
        }

        [Then(@"Framework is '(.*)'")]
        public void ThenFrameworkIs(string framework)
        {
            test.Pages.ViewASolution.GetFrameworks().Should().Contain(framework);
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
        public async Task ThenContactDetails()
        {
            test.ContactDetails = (await SqlExecutor.ExecuteAsync<SolutionContactDetails>(
                test.ConnectionString,
                Queries.GetSolutionContactDetails,
                new { solutionId = test.Solution.Id })).ToList();

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
            id.Should().Be(test.CatalogueItem.CatalogueItemId);
        }

        [Then(@"there is a link for the User to download an attachment")]
        public void ThenThereIsALinkForTheUserToDownloadAnAttachment()
        {
            test.Pages.ViewASolution.AttachmentDownloadLinkDisplayed().Should().BeTrue();
        }

        [Then(@"the page will contain an indication that the Solution meets the criteria for a Foundation Solution Set")]
        public void ThenThePageWillContainAnIndicationThatTheSolutionMeetsTheCriteriaForAFoundationSolutionSet()
        {
            test.Pages.ViewASolution.FoundationSolutionIndicatorDisplayed().Should().BeTrue();
        }

        [Then(@"the capabilities listed match the expected capabilities in the database")]
        public async Task ThenTheCapabilitiesListedMatchTheExpectedCapabilitiesInTheDatabase()
        {
            var solutionId = test.Pages.ViewASolution.GetSolutionId();
            var capabilities = (await Capability.GetSolutionCapabilitiesAsync(test.ConnectionString, test.CatalogueItem.CatalogueItemId))
                .Select(s => s.Name);
            var actualCapabilities = test.Pages.ViewASolution.GetSolutionCapabilities();
            actualCapabilities.Should().BeEquivalentTo(capabilities);
        }

        [Then(@"Features")]
        public void ThenFeatures()
        {
            test.Pages.ViewASolution.GetFeatures().Should().HaveCountGreaterThan(0);
        }
    }
}
