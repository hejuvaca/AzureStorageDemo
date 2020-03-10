using System;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;

namespace QueueStorageDeomo
{
    class Program
    {
        // The string value is broken up for better onscreen formatting
        private const string connectionString = "";
        //private const string connectionString = "UseDevelopmentStorage=true";

        static async Task Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("myqueue2");

            if (args.Length > 0)
            {
                string value = String.Join(" ", args);
                await SendMessageAsync(queue, value);
                Console.WriteLine($"Enviando: {value}");
            }
            else
            {
                string value = await ReceiveMessageAsync(queue);
                Console.WriteLine($"Recibiendo {value}");
            }

            
            Console.Write("Press Enter...");
            Console.ReadLine();
        }

        static async Task SendMessageAsync(CloudQueue theQueue, string newMessage)
        {
            bool createdQueue = await theQueue.CreateIfNotExistsAsync();

            if (createdQueue)
            {
                Console.WriteLine("El queue fue creado.");
            }

            CloudQueueMessage message = new CloudQueueMessage(newMessage);
            await theQueue.AddMessageAsync(message);
        }

        static async Task<string> ReceiveMessageAsync(CloudQueue theQueue)
        {
            bool exists = await theQueue.ExistsAsync();

            if (exists)
            {
                CloudQueueMessage retrievedMessage = await theQueue.GetMessageAsync();

                if (retrievedMessage != null)
                {
                    string theMessage = retrievedMessage.AsString;
                    await theQueue.DeleteMessageAsync(retrievedMessage);
                    return theMessage;
                }
                else
                {
                    Console.Write("El queue está vacío. Lo borramos? (S/N) ");
                    string response = Console.ReadLine();

                    if (response == "S" || response == "s")
                    {
                        await theQueue.DeleteIfExistsAsync();
                        return "El queue fue eliminado.";
                    }
                    else
                    {
                        return "El queue no fue eliminado.";
                    }
                }
            }
            else
            {
                return "El queue no existe. Agregue un mensaje desde la línea de comandos para crear un queue y un mensaje.";
            }
        }
    }
}