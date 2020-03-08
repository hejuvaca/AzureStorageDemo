using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BlobDemo1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=demosypfsacc;AccountKey=jCEE52WGiFL6Vp2DDAvjAiocwydP9/7yyxZwfSUfS7CpOaeVM7nNAY8bbclD6PjywJ0MEbXhui+ycDFYACjVwg==;EndpointSuffix=core.windows.net";
            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient serviceClient = account.CreateCloudBlobClient();

            Console.WriteLine("Creando el Containers...");
            var container = serviceClient.GetContainerReference("micontenedor"); // MIN
            container.CreateIfNotExistsAsync().Wait();

            for (int i = 0; i < 10; i++)
            {
                CloudBlockBlob blob = container.GetBlockBlobReference($"Holamundo_{i}.txt");
                blob.UploadTextAsync($"Hola mundo {i}").Wait();
            }

            Console.WriteLine("Containers creados");
            Thread.Sleep(2000);
        }
    }
}
