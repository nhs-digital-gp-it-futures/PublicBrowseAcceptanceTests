using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.LayoutComponents
{
    [Binding]
    public sealed class CommonLayoutSteps
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;

        public CommonLayoutSteps(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"the User chooses any Page in the application")]
        public void GivenTheUserChoosesAnyPageInTheApplication()
        {
            _test.pages.Homepage.PageDisplayed();
        }

        [When(@"they are on a Page")]
        public void WhenTheyAreOnAPage()
        {
            _test.pages.Homepage.PageDisplayed();
        }
    }
}
