﻿using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public sealed class ViewSingleSolution
    {
        public By SolutionId => CustomBy.DataTestId("view-solution-page-solution-id");
        public By SolutionSupplierName => CustomBy.DataTestId("view-solution-page-supplier-name");
        public By SolutionName => CustomBy.DataTestId("view-solution-page-solution-name");
        public By SolutionSummary => CustomBy.DataTestId("view-question-data-text-summary");
        public By Features => CustomBy.DataTestId("view-question-data-bulletlist", "li");
        public By SolutionCapabilities => CustomBy.DataTestId("view-section-table-row-capabilities");
        public By CapabilityTitle => CustomBy.DataTestId("view-section-table-row-title");
        public By SolutionContactsSection => CustomBy.DataTestId("view-solution-contact-details");
        public By SolutionFoundationTag => CustomBy.DataTestId("solution-foundation-tag");

        public By SolutionLastUpdated => CustomBy.DataTestId("view-solution-page-last-updated");

        public By SolutionAboutUrl => CustomBy.DataTestId("view-question-data-link");

        public By AttachmentDownloadLink => CustomBy.DataTestId("view-section-question-document-link", "a");

        public By DownloadNHSAssuredIntegrationsDocumentLink =>
            CustomBy.DataTestId("view-question-data-text-link-authority-integrations", "a");

        public By DownloadRoadmapDocumentLink => CustomBy.DataTestId("view-question-data-link-document-link", "a");

        public By FoundationSolutionIndicator => CustomBy.DataTestId("view-solution-foundation");

        public By SolutionFullDescription => By.CssSelector("[data-test-id=view-solution-description] [data-test-id=view-question-data-text-description]");

        public By SolutionContactName => CustomBy.DataTestId("view-question-data-text-contact-name");
        public By SolutionContactDepartment => CustomBy.DataTestId("view-question-data-text-department-name");
        public By SolutionContactPhoneNumber => CustomBy.DataTestId("view-question-data-text-phone-number");
        public By SolutionContactEmail => CustomBy.DataTestId("view-question-data-text-email-address");

        public By RoadmapSection => CustomBy.DataTestId("view-roadmap");
        public By IntegrationsSection => CustomBy.DataTestId("view-integrations");
        public By LearnMoreSection => CustomBy.DataTestId("view-learn-more");
    }
}
