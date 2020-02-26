﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FluentAssertions;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Azure
{
    public sealed class AzureBlobStorage
    {
        public List<string> listOfSolutionIds = new List<string>();
        private List<string> listOfBlobContainerNames = new List<string>();
        private BlobServiceClient blobServiceClient;

        public AzureBlobStorage(string connectionString)
        {
            blobServiceClient = new BlobServiceClient(connectionString);            
        }

        public async Task InsertFileToStorage(string containerName, string solutionId, string fileName, string fullFilePath)
        {
            if(!listOfSolutionIds.Contains(solutionId))
            {
                listOfSolutionIds.Add(solutionId);
            }

            if (!listOfBlobContainerNames.Contains(containerName))
            {
                listOfBlobContainerNames.Add(containerName);
            }

            var currentContainer = blobServiceClient.GetBlobContainerClient(containerName);
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
            foreach (var directory in listOfSolutionIds)
            {
                foreach (var container in listOfBlobContainerNames)
                {
                    var currentContainer = blobServiceClient.GetBlobContainerClient(container);
                    foreach (var blob in currentContainer.GetBlobs(prefix: directory))
                    {
                        await currentContainer.DeleteBlobAsync(blob.Name);
                    }
                }
            }
        }
    }
}