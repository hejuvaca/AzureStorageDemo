using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSendApp
{
    class Program
    {
        static string ConnectionString = "";
        static string queueName = "queueDemo";
        static void Main(string[] args)
        {
            try
            {
                //Creación del cliente
                QueueClient queueCliente = QueueClient.CreateFromConnectionString(ConnectionString, queueName);

                string json = @"{
                    ""Id"": ""1"",
                    ""Tipo"": ""Demo"",
                    ""Mensaje"": ""Esto es una demostracion""
                }";

                byte[] bytes = Encoding.UTF8.GetBytes(json);
                MemoryStream stream = new MemoryStream(bytes, writable: false);
                BrokeredMessage message = new BrokeredMessage(stream) { ContentType = "application/json" };
                queueCliente.Send(message);
                queueCliente.Close();
            }
            catch 
            {
                throw;
            }
        }
    }
}
