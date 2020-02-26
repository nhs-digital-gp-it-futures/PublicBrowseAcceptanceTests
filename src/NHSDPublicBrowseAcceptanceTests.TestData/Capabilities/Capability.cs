﻿using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Capabilities
{
    public sealed class Capability
    {
        public Guid CapabilityId { get; set; }
        public string CapabilityRef { get; set; }
        public string Name { get; set; }
        public List<Epic> Epics { get; set; }

        public IList<Capability> GetSolutionCapabilities(string connectionString, string solutionId)
        {
            var query = Queries.GetSolutionCapabilities;
            return SqlExecutor.Execute<Capability>(connectionString, query, new { solutionId }).ToList();
        }

        public void AddRandomCapabilityToSolution(string connectionString, string solutionId)
        {
            var query = Queries.AddRandomSolutionCapability;

            SqlExecutor.Execute<Capability>(connectionString, query, new { solutionId });
        }
    }
}