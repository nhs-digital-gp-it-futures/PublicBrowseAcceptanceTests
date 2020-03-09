using System;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Solutions
{
    public sealed class SolutionContactDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public Guid LastUpdatedBy { get; set; } = Guid.Empty;

        public void AddMarketingContactForSolution(string connectionString, string solutionId)
        {
            var query = Queries.AddMarketingContact;
            SqlExecutor.Execute<SolutionContactDetails>(query: query, connectionString: connectionString,
                param: new
                {
                    solutionId, FirstName, LastName, Email, PhoneNumber, Department, LastUpdated, LastUpdatedBy
                });
        }
    }
}