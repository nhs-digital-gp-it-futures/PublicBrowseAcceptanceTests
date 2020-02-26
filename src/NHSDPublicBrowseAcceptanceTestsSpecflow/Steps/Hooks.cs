using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using System;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public sealed class Hooks
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;

        public Hooks(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _test.driver.Close();
            _test.driver.Quit();

            if (_context.ContainsKey("DeleteSolution") && (bool)_context["DeleteSolution"])
            {                
                _test.solution.Delete(_test.ConnectionString);
            }
        }
    }
}
