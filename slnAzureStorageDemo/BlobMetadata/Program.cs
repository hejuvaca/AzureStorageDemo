using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace BlobMetadata
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Asignar Metadata en Portal Azure

            string connectionString = "DefaultEndpointsProtocol=https;AccountName=demosypfsacc;AccountKey=jCEE52WGiFL6Vp2DDAvjAiocwydP9/7yyxZwfSUfS7CpOaeVM7nNAY8bbclD6PjywJ0MEbXhui+ycDFYACjVwg==;EndpointSuffix=core.windows.net";
            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient serviceClient = account.CreateCloudBlobClient();

            //Hacemos referencia el contenedor
            var container = serviceClient.GetContainerReference("micontenedor"); 

            //Buscamos todos los atributos con FETCH y esperamos a que se complete la ejecución
            container.FetchAttributesAsync().Wait();

            //Escribimos las propiedades obtenidas, es posible comparar con el portal Azure
            Console.WriteLine("Properties for container {0}", container.StorageUri.PrimaryUri);
            Console.WriteLine("Public access level: {0}", container.Properties.PublicAccess);
            Console.WriteLine("Last modified time in UTC: {0}", container.Properties.LastModified);

            //Asignando Metadata nueva al contenedor
            container.Metadata.Add("tipoDocumentos", "Documentos de prueba");
            container.Metadata["categoria"] = "Demostraciones";

            //Asignación de la Metadata de nuevo al contenedor cpon SetMetadataAsync()
            container.SetMetadataAsync().Wait();

            //Nuevamente Fetch y esperamos a que termine
            container.FetchAttributesAsync().Wait();

            //Escribimos los metadatos en pantalla
            Console.WriteLine("Container metadata:");
            foreach (var metadataItem in container.Metadata)
            {
                Console.WriteLine("\tKey: {0}", metadataItem.Key);
                Console.WriteLine("\tValue: {0}", metadataItem.Value);
                Console.WriteLine("");
            }


            Console.WriteLine("Valide estos metadatos en el portal Azure");
            Console.ReadLine();

            //NOTA: Si vuelve a ejecutar este código, recibirá un error indicando que los metadatos ya existen.

        }
    }
}
