using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FluentAssertions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Azure
{
    public sealed class AzureBlobStorage
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly List<string> _listOfBlobContainerNames = new List<string>();
        public List<string> ListOfSolutionIds = new List<string>();

        public AzureBlobStorage(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task InsertFileToStorage(string containerName, string solutionId, string fileName,
            string fullFilePath)
        {
            if (!ListOfSolutionIds.Contains(solutionId)) ListOfSolutionIds.Add(solutionId);

            if (!_listOfBlobContainerNames.Contains(containerName)) _listOfBlobContainerNames.Add(containerName);

            var currentContainer = _blobServiceClient.GetBlobContainerClient(containerName);
            currentContainer.CreateIfNotExists();

            var blobClient = currentContainer.GetBlobClient(Path.Combine(solutionId, fileName));
            using var uploadFileStream = File.OpenRead(fullFilePath);
            var response = await blobClient
                .UploadAsync(uploadFileStream, new BlobHttpHeaders())
                .ConfigureAwait(false);

            response.GetRawResponse().Status.Should().Be(201);
        }

        public async Task ClearStorage()
        {
            foreach (var directory in ListOfSolutionIds)
            foreach (var container in _listOfBlobContainerNames)
            {
                var currentContainer = _blobServiceClient.GetBlobContainerClient(container);
                foreach (var blob in currentContainer.GetBlobs(prefix: directory))
                    await currentContainer.DeleteBlobAsync(blob.Name);
            }
        }
    }
}