using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public sealed class ViewSingleSolution
    {
        public By SolutionId => CustomBy.DataTestId("view-solution-page-solution-id");
        public By SolutionOrganisationName => CustomBy.DataTestId("view-solution-page-organisation-name");
        public By SolutionName => CustomBy.DataTestId("view-solution-page-solution-name");
        public By SolutionSummary => CustomBy.DataTestId("view-question-data-text-summary");
        public By SolutionCapabilities => CustomBy.DataTestId("view-solution-capabilities", "li label.nhsuk-label");
        public By SolutionContactsSection => CustomBy.DataTestId("view-solution-contact-details");
        public By SolutionFoundationTag => CustomBy.DataTestId("solution-foundation-tag");

        public By SolutionLastUpdated => CustomBy.DataTestId("view-solution-page-last-updated");

        public By SolutionAboutUrl => CustomBy.DataTestId("view-section-question-link");

        public By AttachmentDownloadLink => CustomBy.DataTestId("view-solution-page-download-info-button", "a");

        public By FoundationSolutionIndicator => CustomBy.DataTestId("solution-foundation-tag");

        public By SolutionFullDescription => CustomBy.DataTestId("view-question-data-text-description");

        public By SolutionContactName => CustomBy.DataTestId("view-question-data-text-contact-name", "label");
        public By SolutionContactDepartment => CustomBy.DataTestId("view-question-data-text-department-name", "label");
        public By SolutionContactPhoneNumber => CustomBy.DataTestId("view-question-data-text-phone-number", "label");
        public By SolutionContactEmail => CustomBy.DataTestId("view-question-data-text-email-address", "label");
    }
}
