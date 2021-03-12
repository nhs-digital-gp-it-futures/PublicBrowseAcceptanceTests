namespace NHSDPublicBrowseAcceptanceTests.TestData.Capabilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;

    public sealed class Capability
    {
        public Guid CapabilityId { get; set; }

        public string CapabilityRef { get; set; }

        public string Name { get; set; }

        public List<Epic> Epics { get; set; }

        public static async Task<IList<Capability>> GetSolutionCapabilitiesAsync(string connectionString, string solutionId)
        {
            var query = Queries.GetSolutionCapabilities;
            return (await SqlExecutor.ExecuteAsync<Capability>(connectionString, query, new { solutionId })).ToList();
        }

        public static async Task AddRandomCapabilityToSolutionAsync(string connectionString, string solutionId)
        {
            var query = Queries.AddRandomSolutionCapability;

            await SqlExecutor.ExecuteAsync<Capability>(connectionString, query, new { solutionId });
        }
    }
}
