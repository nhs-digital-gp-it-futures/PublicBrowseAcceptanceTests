using NHSDPublicBrowseAcceptanceTests.Objects.Pages;

namespace NHSDPublicBrowseAcceptanceTests.Objects
{
    public sealed class PageObjects
    {
        public PageObjects()
        {
            Pages = new PageCollection
            {
                SolutionsList = new SolutionsList(),
                ViewSolution = new ViewSolution(),
                CapabilityFilter = new CapabilityFilter(),
                Common = new Common(),
                Homepage = new Homepage(),
                Footer = new Footer(),
                Header = new Header()
            };
        }

        public PageCollection Pages;
    }
}
