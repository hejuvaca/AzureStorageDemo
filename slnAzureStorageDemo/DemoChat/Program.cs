using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoChat
{
    class Program
    {
        static string ConnectionString = "";
        static string TopicPath = "topicdemo";
        static void Main(string[] args)
        {
            Console.Write("Escriba su nombre..");
            var usuario = Console.ReadLine();
            //NamespaceManager: Usada para manejar entidades de mensajeo dentro de un servide bus namespace.
            //Premite crear, actualizar, y borrar queues, topics y subscriptions
            var manager = NamespaceManager.CreateFromConnectionString(ConnectionString);
            if (!manager.TopicExists(TopicPath))
                manager.CreateTopic(TopicPath);

            var description = new SubscriptionDescription(TopicPath, usuario)
            {
                AutoDeleteOnIdle = TimeSpan.FromMinutes(5)
            };
            manager.CreateSubscription(description);

            //Creación de los clientes CHAT
            //MessagingFactory: Usada para crear clientes de entidades de mensajeo para un específico service bus namespace
            var factory = MessagingFactory.CreateFromConnectionString(ConnectionString);

            //TopicClient: Usada por un cliente para enviar mensajes a un específico TOPIC
            var topicCliente = factory.CreateTopicClient(TopicPath);

            //SubscriptionClient: Usada por un cliente para recibir mensajes de una suscripcion y también para manejar reglas de filtros de suscripciones
            var suscripcionCliente = factory.CreateSubscriptionClient(TopicPath, usuario);

            suscripcionCliente.OnMessage(msg => ProcessMessage(msg));

            //BrokeredMessage: Usado para representar un mensaje transmitido a través de un service bus
            var mensajeBienvenida = new BrokeredMessage("Alguien ha entrado al chat");
            mensajeBienvenida.Label = usuario;
            topicCliente.Send(mensajeBienvenida);

            while (true)
            {
                string texto = Console.ReadLine();
                if (texto.Equals("salir"))
                    break;
                var mensajeChat = new BrokeredMessage(texto);
                mensajeChat.Label = usuario;
                topicCliente.Send(mensajeChat);
            }

            var mensajeSalida = new BrokeredMessage("Alguien se ha ido del chat...");
            mensajeSalida.Label = usuario;
            topicCliente.Send(mensajeSalida);

            factory.Close();
        }

        private static void ProcessMessage(BrokeredMessage msg)
        {
            string user = msg.Label;
            string text = msg.GetBody<string>();
            Console.WriteLine(user + "> " + text);
        }
    }
}
