using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public sealed class SolutionsList
    {
        public By Solutions => CustomBy.DataTestId("solution-card");

        public By FoundationSolutionIndicators => CustomBy.DataTestId("solution-card-foundation-tag");
    }
}
