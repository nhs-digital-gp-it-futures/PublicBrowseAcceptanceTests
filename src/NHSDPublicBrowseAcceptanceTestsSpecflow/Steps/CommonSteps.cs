using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public sealed class CommonSteps
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;

        public CommonSteps(UITest test,  ScenarioContext context)
        {
            _test = test;
            _context = context;
        }
    }
}
