using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public sealed class Hooks
    {
        private readonly UITest _test;

        public Hooks(UITest test)
        {
            _test = test;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _test.driver.Close();
            _test.driver.Quit();
        }
    }
}
