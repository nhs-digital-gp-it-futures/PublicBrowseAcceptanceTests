namespace NHSDPublicBrowseAcceptanceTests.TestData.Solutions
{
    using System;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;

    public sealed class SolutionContactDetails
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactName => $"{FirstName} {LastName}";

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        public Guid LastUpdatedBy { get; set; } = Guid.Empty;

        public void AddMarketingContactForSolution(string connectionString, string solutionId)
        {
            var query = Queries.AddMarketingContact;
            _ = SqlExecutor.Execute<SolutionContactDetails>(
                query: query,
                connectionString: connectionString,
                param: new { solutionId, FirstName, LastName, Email, PhoneNumber, Department, LastUpdated, LastUpdatedBy });
        }
    }
}
