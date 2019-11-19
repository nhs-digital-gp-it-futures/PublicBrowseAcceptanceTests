using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public sealed class SolutionsList
    {
        public By Solutions => CustomBy.DataTestId("solution-card");
        public By SolutionName => CustomBy.DataTestId("solution-card-name");
        public By SolutionOrganisationName => CustomBy.DataTestId("solution-card-organisation");
        public By SolutionSummary => CustomBy.DataTestId("solution-card-summary");
        public By SolutionCapabilityList => CustomBy.DataTestId("capability-list");
        public By SolutionCapabilityName => CustomBy.DataTestId("capability-list-item");
        public By FoundationSolutionIndicators => CustomBy.DataTestId("solution-card-foundation-tag");
    }
}
