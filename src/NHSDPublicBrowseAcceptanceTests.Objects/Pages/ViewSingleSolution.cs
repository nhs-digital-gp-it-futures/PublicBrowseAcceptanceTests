namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public sealed class ViewSingleSolution
    {
        public static By SolutionId => CustomBy.DataTestId("view-solution-page-solution-id");

        public static By SolutionSupplierName => CustomBy.DataTestId("view-solution-page-supplier-name");

        public static By SolutionName => CustomBy.DataTestId("view-solution-page-solution-name");

        public static By SolutionSummary => CustomBy.DataTestId("view-question-data-text-summary");

        public static By Features => CustomBy.DataTestId("view-question-data-bulletlist", "li");

        public static By SolutionCapabilities => CustomBy.DataTestId("view-section-table-row-capabilities");

        public static By CapabilityTitle => CustomBy.DataTestId("view-section-table-row-title");

        public static By SolutionContactsSection => CustomBy.DataTestId("view-solution-contact-details");

        public static By SolutionFoundationTag => CustomBy.DataTestId("solution-foundation-tag");

        public static By SolutionLastUpdated => CustomBy.DataTestId("view-solution-page-last-updated");

        public static By SolutionAboutUrl => CustomBy.DataTestId("view-question-data-link");

        public static By AttachmentDownloadLink => CustomBy.DataTestId("view-section-question-document-link", "a");

        public static By DownloadNHSAssuredIntegrationsDocumentLink =>
            CustomBy.DataTestId("view-question-data-text-link-authority-integrations", "a");

        public static By DownloadRoadmapDocumentLink => CustomBy.DataTestId("view-question-data-link-document-link", "a");

        public static By FoundationSolutionIndicator => CustomBy.DataTestId("view-solution-foundation");

        public static By SolutionFullDescription => By.CssSelector("[data-test-id=view-solution-description] [data-test-id=view-question-data-text-description]");

        public static By SolutionContactName => CustomBy.DataTestId("view-question-data-text-contact-name");

        public static By SolutionContactDepartment => CustomBy.DataTestId("view-question-data-text-department-name");

        public static By SolutionContactPhoneNumber => CustomBy.DataTestId("view-question-data-text-phone-number");

        public static By SolutionContactEmail => CustomBy.DataTestId("view-question-data-text-email-address");

        public static By RoadmapSection => CustomBy.DataTestId("view-roadmap");

        public static By IntegrationsSection => CustomBy.DataTestId("view-integrations");

        public static By LearnMoreSection => CustomBy.DataTestId("view-learn-more");

        public static By Frameworks => CustomBy.DataTestId("view-solution-page-frameworks");
    }
}
