namespace NHSDPublicBrowseAcceptanceTests.TestData.Capabilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;

    public sealed class Capability
    {
        public Guid CapabilityId { get; set; }

        public string CapabilityRef { get; set; }

        public string Name { get; set; }

        public List<Epic> Epics { get; set; }

        public static IList<Capability> GetSolutionCapabilities(string connectionString, string solutionId)
        {
            var query = Queries.GetSolutionCapabilities;
            return SqlExecutor.Execute<Capability>(connectionString, query, new { solutionId }).ToList();
        }

        public static void AddRandomCapabilityToSolution(string connectionString, string solutionId)
        {
            var query = Queries.AddRandomSolutionCapability;

            SqlExecutor.Execute<Capability>(connectionString, query, new { solutionId });
        }
    }
}
