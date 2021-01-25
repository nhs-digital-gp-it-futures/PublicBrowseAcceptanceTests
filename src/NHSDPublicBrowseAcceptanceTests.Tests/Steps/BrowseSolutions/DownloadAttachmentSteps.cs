namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.BrowseSolutions
{
    using System;
    using System.IO;
    using FluentAssertions;
    using NHSDPublicBrowseAcceptanceTests.Actions.Utils;
    using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
    using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
    using NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions;
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class DownloadAttachmentSteps
    {
        private const string ProvidedDataDocumentDownloadFile = "downloaded authority provided solution document.pdf";
        private const string IntegrationsDownloadFile = "downloadedIntegrations.pdf";
        private const string RoadmapDownloadFile = "downloadedRoadmap.pdf";
        private readonly ScenarioContext context;
        private readonly UITest test;
        private readonly Settings settings;

        public DownloadAttachmentSteps(UITest test, ScenarioContext context, Settings settings)
        {
            this.test = test;
            this.context = context;
            this.settings = settings;
        }

        [Given(
            @"(a|an) (Roadmap|NHS Assured Integrations|Authority Provided Solution Document) attachment has not been provided for the Solution")]
        public static void GivenAnIntegrationsAttachmentHasNotBeenProvidedForTheSolution(string unused, string unused2)
        {
        }

        [Given(@"that a new Solution has been created to view attachments")]
        public void GivenThatANewSolutionHasBeenCreatedToViewAttachments()
        {
            test.CatalogueItem = GenerateCatalogueItem.GenerateNewCatalogueItem(
                checkForUnique: true,
                connectionString: test.ConnectionString,
                publishedStatus: 3);
            test.CatalogueItem.Create(test.ConnectionString);
            test.Solution = GenerateSolution.GenerateNewSolution(test.CatalogueItem.CatalogueItemId, 0, false, true, integrationsUrl: true);
            test.Solution.Create(test.ConnectionString);
            context.Add("DeleteSolution", true);
            test.ContactDetails.Add(CreateContactDetails.NewContactDetail());
            test.ContactDetails[0].AddMarketingContactForSolution(test.ConnectionString, test.Solution.Id);
            Capability.AddRandomCapabilityToSolution(test.ConnectionString, test.Solution.Id);
        }

        [StepDefinition(@"the User views the created solution")]
        public void GivenTheUserViewsTheCreatedSolution()
        {
            new ViewSolutionsList(test).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            test.Pages.SolutionsList.OpenNamedSolution(test.CatalogueItem.Name);
            test.Pages.ViewASolution.PageDisplayed(settings.PublicBrowseUrl);
        }

        [When(@"the User chooses to download the Authority Provided Data Document")]
        public void WhenTheUserChoosesToDownloadTheAuthorityProvidedDataDocument()
        {
            var url = test.Pages.ViewASolution.GetAttachmentDownloadLinkUrl();
            var client = DownloadFileUtility.DownloadFile(ProvidedDataDocumentDownloadFile, settings.DownloadPath, url, DownloadFileUtility.GetHeadersFromDriver(test.Driver));
            context.Add("ResponseHeaderContentType", client.ResponseHeaders.Get("Content-Type"));
        }

        [When(@"the User chooses to download the Integrations attachment")]
        public void WhenTheUserChoosesToDownloadTheIntegrationsAttachment()
        {
            var url = test.Pages.ViewASolution.GetNhsAssuredIntegrationsDownloadLinkUrl();
            var client = DownloadFileUtility.DownloadFile(IntegrationsDownloadFile, settings.DownloadPath, url, DownloadFileUtility.GetHeadersFromDriver(test.Driver));
            context.Add("ResponseHeaderContentType", client.ResponseHeaders.Get("Content-Type"));
        }

        [When(@"the User chooses to download the Roadmap attachment")]
        public void WhenTheUserChoosesToDownloadTheRoadmapAttachment()
        {
            var url = test.Pages.ViewASolution.GetRoadmapDownloadLinkUrl();
            var client = DownloadFileUtility.DownloadFile(RoadmapDownloadFile, settings.DownloadPath, url, DownloadFileUtility.GetHeadersFromDriver(test.Driver));
            context.Add("ResponseHeaderContentType", client.ResponseHeaders.Get("Content-Type"));
        }

        [Then(@"the Authority Provided Data Document is downloaded")]
        public void ThenTheAuthorityProvidedDataDocumentIsDownloaded()
        {
            var downloadedFile = Path.Combine(settings.DownloadPath, ProvidedDataDocumentDownloadFile);
            File.Exists(downloadedFile).Should().BeTrue();
        }

        [Then(@"the Integrations attachment is downloaded")]
        public void ThenTheIntegrationsAttachmentIsDownloaded()
        {
            var downloadedFile = Path.Combine(settings.DownloadPath, IntegrationsDownloadFile);
            File.Exists(downloadedFile).Should().BeTrue();
        }

        [Then(@"the Roadmap attachment is downloaded")]
        public void ThenTheRoadmapAttachmentIsDownloaded()
        {
            var downloadedFile = Path.Combine(settings.DownloadPath, RoadmapDownloadFile);
            File.Exists(downloadedFile).Should().BeTrue();
        }

        [Then(@"the attachment contains the Supplier's Authority Provided Data Document")]
        public void ThenTheAttachmentContainsTheSupplierSAuthorityProvidedDataDocument()
        {
            var sourceFile = Path.Combine(
                Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory),
                "Azure",
                "SampleData",
                "authority provided solution document.pdf");
            var downloadedFile = Path.Combine(settings.DownloadPath, ProvidedDataDocumentDownloadFile);
            DownloadFileUtility.CompareTwoFiles(downloadedFile, sourceFile).Should().BeTrue();
            var responseHeaderContentType = (string)context["ResponseHeaderContentType"];
            responseHeaderContentType.Should().ContainEquivalentOf("pdf");
        }

        [Then(@"the attachment contains the Supplier's NHS Assured Integrations")]
        public void ThenTheAttachmentContainsTheSupplierSNHSAssuredIntegrations()
        {
            var sourceFile = Path.Combine(
                Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory),
                "Azure",
                "SampleData",
                "integrations.pdf");
            var downloadedFile = Path.Combine(settings.DownloadPath, IntegrationsDownloadFile);
            DownloadFileUtility.CompareTwoFiles(downloadedFile, sourceFile).Should().BeTrue();
            var responseHeaderContentType = (string)context["ResponseHeaderContentType"];
            responseHeaderContentType.Should().ContainEquivalentOf("pdf");
        }

        [Then(@"the attachment contains the Supplier's Roadmap")]
        public void ThenTheAttachmentContainsTheSupplierSRoadmap()
        {
            var sourceFile = Path.Combine(
                Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory),
                "Azure",
                "SampleData",
                "roadmap.pdf");
            var downloadedFile = Path.Combine(settings.DownloadPath, RoadmapDownloadFile);
            DownloadFileUtility.CompareTwoFiles(downloadedFile, sourceFile).Should().BeTrue();
            var responseHeaderContentType = (string)context["ResponseHeaderContentType"];
            responseHeaderContentType.Should().ContainEquivalentOf("pdf");
        }

        [Then(@"there is no call to action to download a file in the Integrations section")]
        public void ThenThereIsNoCallToActionToDownloadAFileInTheIntegrationsSection()
        {
            test.Pages.ViewASolution.NhsAssuredIntegrationsDownloadLinkDisplayed().Should().BeFalse();
        }

        [Then(@"there is no call to action to download a file in the Roadmap section")]
        public void ThenThereIsNoCallToActionToDownloadAFileInTheRoadmapSection()
        {
            test.Pages.ViewASolution.RoadmapDownloadLinkDisplayed().Should().BeFalse();
        }

        [Given(@"the Learn more section is presented")]
        public void GivenTheLearnMoreSectionIsPresented()
        {
            test.Pages.ViewASolution.WaitForLearnMoreSectionDisplayed().Should().BeTrue();
        }

        [Then(@"the Learn more section is not presented")]
        public void ThenTheLearnMoreSectionIsNotPresented()
        {
            test.Pages.ViewASolution.WaitForLearnMoreSectionDisplayed().Should().BeFalse();
        }

        [Given(@"the Integrations section is presented")]
        public void GivenTheIntegrationsSectionIsPresented()
        {
            test.Pages.ViewASolution.WaitForIntegrationsSectionDisplayed();
        }

        [Given(@"the Roadmap section is presented")]
        public void GivenTheRoadmapSectionIsPresented()
        {
            test.Pages.ViewASolution.WaitForRoadmapSectionDisplayed();
        }
    }
}
