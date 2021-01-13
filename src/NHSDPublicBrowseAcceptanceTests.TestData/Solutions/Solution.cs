using System;
using System.Collections.Generic;
using System.Linq;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Solutions
{
    public sealed class Solution
    {
        public string Id { get; set; }
        public string SolutionId => Id;
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

        public Solution Retrieve(string connectionString)
        {
            var query = Queries.GetSolution;
            return SqlExecutor.Execute<Solution>(connectionString, query, this).Single();
        }

        public void Create(string connectionString)
        {
            var query = Queries.CreateNewSolution;
            SqlExecutor.Execute<Solution>(connectionString, query, this);
        }

        public void Update(string connectionString)
        {
            var query = Queries.UpdateSolution;
            SqlExecutor.Execute<Solution>(connectionString, query, this);
        }

        public void Delete(string connectionString)
        {
            var query = Queries.DeleteSolution;
            SqlExecutor.Execute<Solution>(connectionString, query, this);
        }

        public static IEnumerable<string> RetrieveAll(string connectionString)
        {
            var query = Queries.GetAllSolutions;

            return SqlExecutor.Execute<Solution>(connectionString, query, null).Select(s => s.Id);
        }
    }
}
