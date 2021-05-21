namespace NHSDPublicBrowseAcceptanceTests.TestData.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;

    internal sealed class SolutionCapability
    {
        public string CatalogueItemId { get; set; }

        public int Capabilities { get; set; }
    }
}
