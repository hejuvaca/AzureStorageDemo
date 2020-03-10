using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRecieveApp
{
    class Program
    {
        static string ConnectionString = "";
        static string QueuePath = "";
        static void Main(string[] args)
        {
            //QueueClient: Es usada por las aplciaciones cliente para enviar y recibir mensajes de una cola de service bus
            var queueCliente = QueueClient.CreateFromConnectionString(ConnectionString, QueuePath);
            queueCliente.OnMessage(msg => ProcesaMensaje(msg));
            Console.ReadLine();
            queueCliente.Close();
        }

        private static void ProcesaMensaje(BrokeredMessage msg)
        {            
            string s = new StreamReader(msg.GetBody<Stream>(), Encoding.UTF8).ReadToEnd();
            Console.WriteLine("Mensaje: " + s + " recibido.");
        }
    }
}
