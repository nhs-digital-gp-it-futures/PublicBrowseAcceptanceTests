using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public sealed class ViewSingleSolution
    {
        public By SolutionId => CustomBy.DataTestId("view-solution-page-solution-id");
        public By SolutionSupplierName => CustomBy.DataTestId("view-solution-page-supplier-name");
        public By SolutionName => CustomBy.DataTestId("view-solution-page-solution-name");
        public By SolutionSummary => CustomBy.DataTestId("view-question-data-text-summary");
        public By SolutionCapabilities => CustomBy.DataTestId("view-solution-capabilities", "li");
        public By SolutionContactsSection => CustomBy.DataTestId("view-solution-contact-details");
        public By SolutionFoundationTag => CustomBy.DataTestId("solution-foundation-tag");

        public By SolutionLastUpdated => CustomBy.DataTestId("view-solution-page-last-updated");

        public By SolutionAboutUrl => CustomBy.DataTestId("view-section-question-link");

        public By AttachmentDownloadLink => CustomBy.DataTestId("view-solution-page-download-info-button", "a");

        public By FoundationSolutionIndicator => CustomBy.DataTestId("view-solution-foundation-tag");

        public By SolutionFullDescription => CustomBy.DataTestId("view-question-data-text-description");

        public By SolutionContactName => CustomBy.DataTestId("view-question-data-text-contact-name");
        public By SolutionContactDepartment => CustomBy.DataTestId("view-question-data-text-department-name");
        public By SolutionContactPhoneNumber => CustomBy.DataTestId("view-question-data-text-phone-number");
        public By SolutionContactEmail => CustomBy.DataTestId("view-question-data-text-email-address");
    }
}
