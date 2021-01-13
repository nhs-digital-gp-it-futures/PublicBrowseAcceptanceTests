using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.Actions.Utils;
using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.BrowseSolutions
{
    [Binding]
    public class DownloadAttachmentSteps
    {
        private const string providedDataDocumentDownloadFile = "downloaded authority provided solution document.pdf";
        private const string integrationsDownloadFile = "downloadedIntegrations.pdf";
        private const string roadmapDownloadFile = "downloadedRoadmap.pdf";
        private readonly ScenarioContext _context;
        private readonly UITest _test;
        private readonly Settings _settings;

        public DownloadAttachmentSteps(UITest test, ScenarioContext context, Settings settings)
        {
            _test = test;
            _context = context;
            _settings = settings;
        }

        [Given(@"that a new Solution has been created to view attachments")]
        public void GivenThatANewSolutionHasBeenCreatedToViewAttachments()
        {
            _test.CatalogueItem = GenerateCatalogueItem.GenerateNewCatalogueItem(checkForUnique: true,
                connectionString: _test.ConnectionString, publishedStatus: 3);
            _test.CatalogueItem.Create(_test.ConnectionString);
            _test.Solution = GenerateSolution.GenerateNewSolution(_test.CatalogueItem.CatalogueItemId, 0, false, true, integrationsUrl: true);
            _test.Solution.Create(_test.ConnectionString);
            _context.Add("DeleteSolution", true);
            _test.ContactDetails.Add(CreateContactDetails.NewContactDetail());
            _test.ContactDetails[0].AddMarketingContactForSolution(_test.ConnectionString, _test.Solution.Id);
            Capability.AddRandomCapabilityToSolution(_test.ConnectionString, _test.Solution.Id);
        }

        [StepDefinition(@"the User views the created solution")]
        public void GivenTheUserViewsTheCreatedSolution()
        {
            new ViewSolutionsList(_test).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            _test.Pages.SolutionsList.OpenNamedSolution(_test.CatalogueItem.Name);
            _test.Pages.ViewASolution.PageDisplayed(_settings.PublicBrowseUrl);
        }

        [Given(
            @"(a|an) (Roadmap|NHS Assured Integrations|Authority Provided Solution Document) attachment has not been provided for the Solution")]
        public static void GivenAnIntegrationsAttachmentHasNotBeenProvidedForTheSolution(string _1, string _2)
        {
        }

        [When(@"the User chooses to download the Authority Provided Data Document")]
        public void WhenTheUserChoosesToDownloadTheAuthorityProvidedDataDocument()
        {
            var url = _test.Pages.ViewASolution.GetAttachmentDownloadLinkUrl();
            var client = DownloadFileUtility.DownloadFile(providedDataDocumentDownloadFile, _settings.DownloadPath, url, DownloadFileUtility.GetHeadersFromDriver(_test.Driver));
            _context.Add("ResponseHeaderContentType", client.ResponseHeaders.Get("Content-Type"));
        }

        [When(@"the User chooses to download the Integrations attachment")]
        public void WhenTheUserChoosesToDownloadTheIntegrationsAttachment()
        {
            var url = _test.Pages.ViewASolution.GetNhsAssuredIntegrationsDownloadLinkUrl();
            var client = DownloadFileUtility.DownloadFile(integrationsDownloadFile, _settings.DownloadPath, url, DownloadFileUtility.GetHeadersFromDriver(_test.Driver));
            _context.Add("ResponseHeaderContentType", client.ResponseHeaders.Get("Content-Type"));
        }

        [When(@"the User chooses to download the Roadmap attachment")]
        public void WhenTheUserChoosesToDownloadTheRoadmapAttachment()
        {
            var url = _test.Pages.ViewASolution.GetRoadmapDownloadLinkUrl();
            var client = DownloadFileUtility.DownloadFile(roadmapDownloadFile, _settings.DownloadPath, url, DownloadFileUtility.GetHeadersFromDriver(_test.Driver));
            _context.Add("ResponseHeaderContentType", client.ResponseHeaders.Get("Content-Type"));
        }

        [Then(@"the Authority Provided Data Document is downloaded")]
        public void ThenTheAuthorityProvidedDataDocumentIsDownloaded()
        {
            var downloadedFile = Path.Combine(_settings.DownloadPath, providedDataDocumentDownloadFile);
            File.Exists(downloadedFile).Should().BeTrue();
        }

        [Then(@"the Integrations attachment is downloaded")]
        public void ThenTheIntegrationsAttachmentIsDownloaded()
        {
            var downloadedFile = Path.Combine(_settings.DownloadPath, integrationsDownloadFile);
            File.Exists(downloadedFile).Should().BeTrue();
        }

        [Then(@"the Roadmap attachment is downloaded")]
        public void ThenTheRoadmapAttachmentIsDownloaded()
        {
            var downloadedFile = Path.Combine(_settings.DownloadPath, roadmapDownloadFile);
            File.Exists(downloadedFile).Should().BeTrue();
        }

        [Then(@"the attachment contains the Supplier's Authority Provided Data Document")]
        public void ThenTheAttachmentContainsTheSupplierSAuthorityProvidedDataDocument()
        {
            var sourceFile = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Azure",
                "SampleData", "authority provided solution document.pdf");
            var downloadedFile = Path.Combine(_settings.DownloadPath, providedDataDocumentDownloadFile);
            DownloadFileUtility.CompareTwoFiles(downloadedFile, sourceFile).Should().BeTrue();
            var responseHeaderContentType = (string)_context["ResponseHeaderContentType"];
            responseHeaderContentType.Should().ContainEquivalentOf("pdf");
        }

        [Then(@"the attachment contains the Supplier's NHS Assured Integrations")]
        public void ThenTheAttachmentContainsTheSupplierSNHSAssuredIntegrations()
        {
            var sourceFile = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Azure",
                "SampleData", "integrations.pdf");
            var downloadedFile = Path.Combine(_settings.DownloadPath, integrationsDownloadFile);
            DownloadFileUtility.CompareTwoFiles(downloadedFile, sourceFile).Should().BeTrue();
            var responseHeaderContentType = (string)_context["ResponseHeaderContentType"];
            responseHeaderContentType.Should().ContainEquivalentOf("pdf");
        }

        [Then(@"the attachment contains the Supplier's Roadmap")]
        public void ThenTheAttachmentContainsTheSupplierSRoadmap()
        {
            var sourceFile = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Azure",
                "SampleData", "roadmap.pdf");
            var downloadedFile = Path.Combine(_settings.DownloadPath, roadmapDownloadFile);
            DownloadFileUtility.CompareTwoFiles(downloadedFile, sourceFile).Should().BeTrue();
            var responseHeaderContentType = (string)_context["ResponseHeaderContentType"];
            responseHeaderContentType.Should().ContainEquivalentOf("pdf");
        }

        [Then(@"there is no call to action to download a file in the Integrations section")]
        public void ThenThereIsNoCallToActionToDownloadAFileInTheIntegrationsSection()
        {
            _test.Pages.ViewASolution.NhsAssuredIntegrationsDownloadLinkDisplayed().Should().BeFalse();
        }

        [Then(@"there is no call to action to download a file in the Roadmap section")]
        public void ThenThereIsNoCallToActionToDownloadAFileInTheRoadmapSection()
        {
            _test.Pages.ViewASolution.RoadmapDownloadLinkDisplayed().Should().BeFalse();
        }

        [Given(@"the Learn more section is presented")]
        public void GivenTheLearnMoreSectionIsPresented()
        {
            _test.Pages.ViewASolution.WaitForLearnMoreSectionDisplayed().Should().BeTrue();
        }

        [Then(@"the Learn more section is not presented")]
        public void ThenTheLearnMoreSectionIsNotPresented()
        {
            _test.Pages.ViewASolution.WaitForLearnMoreSectionDisplayed().Should().BeFalse();
        }

        [Given(@"the Integrations section is presented")]
        public void GivenTheIntegrationsSectionIsPresented()
        {
            _test.Pages.ViewASolution.WaitForIntegrationsSectionDisplayed();
        }

        [Given(@"the Roadmap section is presented")]
        public void GivenTheRoadmapSectionIsPresented()
        {
            _test.Pages.ViewASolution.WaitForRoadmapSectionDisplayed();
        }
    }
}