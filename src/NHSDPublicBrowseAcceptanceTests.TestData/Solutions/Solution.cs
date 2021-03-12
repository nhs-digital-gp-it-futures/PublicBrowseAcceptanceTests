namespace NHSDPublicBrowseAcceptanceTests.TestData.Solutions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;

    public sealed class Solution
    {
        public string Id => SolutionId;

        public string SolutionId { get; set; }

        public string Version { get; set; }

        public string SolutionVersion => Version;

        public string Summary { get; set; }

        public string FullDescription { get; set; }

        public string Features { get; set; }

        public string ClientApplication { get; set; }

        public string Hosting { get; set; }

        public string ImplementationDetail { get; set; }

        public string RoadMap { get; set; }

        public string IntegrationsUrl { get; set; }

        public string AboutUrl { get; set; }

        public string ServiceLevelAgreement { get; set; }

        public DateTime LastUpdated { get; set; }

        public Guid LastUpdatedBy { get; set; }
    }
}
