using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace PracticaBlobStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "";

            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient serviceClient = account.CreateCloudBlobClient();
            Console.WriteLine("Creando el contenedor");

            var container = serviceClient.GetContainerReference("errores");
            container.CreateIfNotExistsAsync().Wait();

            CloudBlockBlob blob = container.GetBlockBlobReference("helloworld.txt");
            blob.UploadTextAsync("Hola mundo desde C#");

            Console.WriteLine("Listo");
            Console.ReadLine();


        }
    }
}
