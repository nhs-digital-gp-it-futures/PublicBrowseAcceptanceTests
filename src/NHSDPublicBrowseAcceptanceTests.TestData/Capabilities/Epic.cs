using System;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Capabilities
{
    public class Epic
    {
        public string EpicRef { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Result { get; set; }
        public Guid CapabilityId { get; set; }
    }
}
