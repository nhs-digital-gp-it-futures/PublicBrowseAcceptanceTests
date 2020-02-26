using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.Actions.Utils;
using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.BrowseSolutions
{
    [Binding]
    public class DownloadAttachmentSteps
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;
        private const string providedDataDocumentDownloadFile = "downloaded authority provided solution document.pdf";
        private const string integrationsDownloadFile = "downloadedIntegrations.pdf";
        private const string roadmapDownloadFile = "downloadedRoadmap.pdf";

        public DownloadAttachmentSteps(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that a new Solution has been created to view attachments")]
        public void GivenThatANewSolutionHasBeenCreatedToViewAttachments()
        {
            _test.solution = GenerateSolution.GenerateNewSolution(checkForUnique: true, connectionString: _test.connectionString, publishedStatus: 3);
            _test.solution.Create(_test.connectionString);
            _test.solutionDetail = GenerateSolutionDetails.GenerateNewSolutionDetail(_test.solution.Id, Guid.NewGuid(), 0, false, roadMap: true, integrationsUrl: true );
            _test.solutionDetail.Create(_test.connectionString);
            _test.solution.SolutionDetailId = _test.solutionDetail.SolutionDetailId;
            _test.solution.Update(_test.connectionString);
            _context.Add("DeleteSolution", true);
            _test.contactDetails.Add(CreateContactDetails.NewContactDetail());
            _test.contactDetails[0].AddMarketingContactForSolution(_test.connectionString, _test.solution.Id);
            new Capability().AddRandomCapabilityToSolution(_test.connectionString, _test.solution.Id);
        }

        [StepDefinition(@"the User views the created solution")]
        public void GivenTheUserViewsTheCreatedSolution()
        {
            new ViewSolutionsList(_test, _context).GivenThatAUserHasChosenToViewAListOfAllSolutions();
            _test.pages.SolutionsList.OpenNamedSolution(_test.solution.Name);
            _test.pages.ViewASolution.PageDisplayed(_test.url);
        }


        [Given(@"(a|an) (Roadmap|NHS Assured Integrations|Authority Provided Solution Document) attachment has been provided for the Solution")]
        public async Task GivenAnAttachmentHasBeenProvidedForTheSolution(string s1, string documentType)
        {
            string fileName;
            if (documentType.Equals("NHS Assured Integrations", StringComparison.OrdinalIgnoreCase))
            {
                documentType = "Integrations";
            }
            fileName = documentType.ToLower() + ".pdf";
            var path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Azure", "SampleData", fileName);
            await _test.AzureBlobStorage.InsertFileToStorage(_test.DefaultAzureBlobStorageContainerName, _test.solution.Id, fileName, path);

        }

        [Given(@"(a|an) (Roadmap|NHS Assured Integrations|Authority Provided Solution Document) attachment has not been provided for the Solution")]
        public void GivenAnIntegrationsAttachmentHasNotBeenProvidedForTheSolution(string s1, string s2)
        {
        }

        [When(@"the User chooses to download the Authority Provided Data Document")]
        public void WhenTheUserChoosesToDownloadTheAuthorityProvidedDataDocument()
        {
            var url = _test.pages.ViewASolution.GetAttachmentDownloadLinkUrl();
            DownloadFileUtility.DownloadFile(providedDataDocumentDownloadFile, _test.DownloadPath, url);
        }

        [When(@"the User chooses to download the Integrations attachment")]
        public void WhenTheUserChoosesToDownloadTheIntegrationsAttachment()
        {
            var url = _test.pages.ViewASolution.GetNhsAssuredIntegrationsDownloadLinkUrl();
            DownloadFileUtility.DownloadFile(integrationsDownloadFile, _test.DownloadPath, url);
        }

        [When(@"the User chooses to download the Roadmap attachment")]
        public void WhenTheUserChoosesToDownloadTheRoadmapAttachment()
        {
            var url = _test.pages.ViewASolution.GetRoadmapDownloadLinkUrl();
            DownloadFileUtility.DownloadFile(roadmapDownloadFile, _test.DownloadPath, url);
        }

        [Then(@"the Authority Provided Data Document is downloaded")]
        public void ThenTheAuthorityProvidedDataDocumentIsDownloaded()
        {
            var downloadedFile = Path.Combine(_test.DownloadPath, providedDataDocumentDownloadFile);
            File.Exists(downloadedFile).Should().BeTrue();
        }

        [Then(@"the Integrations attachment is downloaded")]
        public void ThenTheIntegrationsAttachmentIsDownloaded()
        {
            var downloadedFile = Path.Combine(_test.DownloadPath, integrationsDownloadFile);
            File.Exists(downloadedFile).Should().BeTrue();
        }      

        [Then(@"the Roadmap attachment is downloaded")]
        public void ThenTheRoadmapAttachmentIsDownloaded()
        {
            var downloadedFile = Path.Combine(_test.DownloadPath, roadmapDownloadFile);
            File.Exists(downloadedFile).Should().BeTrue();
        }              

        [Then(@"the attachment contains the Supplier's Authority Provided Data Document")]
        public void ThenTheAttachmentContainsTheSupplierSAuthorityProvidedDataDocument()
        {
            var sourceFile = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Azure", "SampleData", "authority provided solution document.pdf");
            var downloadedFile = Path.Combine(_test.DownloadPath, providedDataDocumentDownloadFile);
            DownloadFileUtility.CompareTwoFiles(downloadedFile, sourceFile).Should().BeTrue();
        }

        [Then(@"the attachment contains the Supplier's NHS Assured Integrations")]
        public void ThenTheAttachmentContainsTheSupplierSNHSAssuredIntegrations()
        {
            var sourceFile = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Azure", "SampleData", "integrations.pdf");
            var downloadedFile = Path.Combine(_test.DownloadPath, integrationsDownloadFile);
            DownloadFileUtility.CompareTwoFiles(downloadedFile, sourceFile).Should().BeTrue();
        }

        [Then(@"the attachment contains the Supplier's Roadmap")]
        public void ThenTheAttachmentContainsTheSupplierSRoadmap()
        {
            var sourceFile = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Azure", "SampleData", "roadmap.pdf");
            var downloadedFile = Path.Combine(_test.DownloadPath, roadmapDownloadFile);
            DownloadFileUtility.CompareTwoFiles(downloadedFile, sourceFile).Should().BeTrue();
        }

        [Then(@"there is no call to action to download a file in the Integrations section")]
        public void ThenThereIsNoCallToActionToDownloadAFileInTheIntegrationsSection()
        {
            _test.pages.ViewASolution.NhsAssuredIntegrationsDownloadLinkDisplayed().Should().BeFalse();
        }

        [Then(@"there is no call to action to download a file in the Roadmap section")]
        public void ThenThereIsNoCallToActionToDownloadAFileInTheRoadmapSection()
        {
            _test.pages.ViewASolution.RoadmapDownloadLinkDisplayed().Should().BeFalse();
        }

        [Given(@"the Learn more section is presented")]
        public void GivenTheLearnMoreSectionIsPresented()
        {
            _test.pages.ViewASolution.IsLearnMoreSectionDisplayed().Should().BeTrue();
        }

        [Then(@"the Learn more section is not presented")]
        public void ThenTheLearnMoreSectionIsNotPresented()
        {
            _test.pages.ViewASolution.IsLearnMoreSectionDisplayed().Should().BeFalse();
        }

        [Given(@"the Integrations section is presented")]
        public void GivenTheIntegrationsSectionIsPresented()
        {
            _test.pages.ViewASolution.IsIntegrationsSectionDisplayed().Should().BeTrue();
        }

        [Given(@"the Roadmap section is presented")]
        public void GivenTheRoadmapSectionIsPresented()
        {
            _test.pages.ViewASolution.IsRoadmapSectionDisplayed().Should().BeTrue();
        }


    }
}
