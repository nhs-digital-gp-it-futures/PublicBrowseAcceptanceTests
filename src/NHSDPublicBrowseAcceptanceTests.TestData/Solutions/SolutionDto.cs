using System;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Solutions
{
    public class SolutionDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdated { get; set; }
        public string AboutUrl { get; set; }
        public string Summary { get; set; }
        public string SupplierName{ get; set; }
        public string FullDescription { get; set; }
        public SolutionContactDetails SolutionContactDetails { get; set; }
    }
}