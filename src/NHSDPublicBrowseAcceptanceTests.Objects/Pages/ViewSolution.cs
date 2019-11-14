using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public sealed class ViewSolution
    {
        public By SolutionName => By.ClassName("nhsuk-body-l");
        public By Capabilities => CustomBy.DataTestId("capability-section-value");
        public By Features => CustomBy.DataTestId("features-value");
    }
}