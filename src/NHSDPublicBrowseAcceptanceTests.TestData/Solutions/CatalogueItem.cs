using Bogus.DataSets;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Solutions
{
    public sealed class CatalogueItem
    {

        public string CatalogueItemId { get; set; }
        public string Name { get; set; }
        public int CatalogueItemTypeId { get; set; } = 1;
        public string SupplierId { get; set; } = "100000";
        public int PublishedStatusId { get; set; } = 1;
        public DateTime Created { get; set; }

        public CatalogueItem Retrieve(string connectionString)
        {
            var query = Queries.GetCatalogueItem;
            return SqlExecutor.Execute<CatalogueItem>(connectionString, query, this).Single();
        }

        public void Create(string connectionString)
        {
            var query = Queries.CreateNewCatalogueItem;
            SqlExecutor.Execute<CatalogueItem>(connectionString, query, this);
        }

        public void Update(string connectionString)
        {
            var query = Queries.UpdateCatalogueItem;
            SqlExecutor.Execute<CatalogueItem>(connectionString, query, this);
        }

        public void Delete(string connectionString)
        {
            var query = Queries.DeleteCatalogueItem;
            SqlExecutor.Execute<CatalogueItem>(connectionString, query, this);
        }

        public IEnumerable<string> RetrieveAll(string connectionString)
        {
            var query = Queries.GetAllCatalogueItems;
            return SqlExecutor.Execute<CatalogueItem>(connectionString, query, null).Select(c => c.CatalogueItemId);
        }
    }
}
