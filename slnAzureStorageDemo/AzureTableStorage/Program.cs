using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureTableStorage.Entities;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureTableStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "";
            
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("Empleados");

            table.CreateIfNotExists();

            Console.Write("Cual es tu nombre? ");
            string nombre = Console.ReadLine();

            Console.WriteLine("");
            Console.Write("Cual es tu apellido paterno? ");
            string apaterno = Console.ReadLine();

            Console.WriteLine("");
            Console.Write("Cual es tu apellido materno? ");
            string amaterno = Console.ReadLine();

            Console.WriteLine("");
            Console.Write("Cual es tu correo? ");
            string correo = Console.ReadLine();

            Console.WriteLine("");
            Console.Write("Donde vives? ");
            string localidad = Console.ReadLine();

            //added this line
            //CreaMensaje(table, new Empleado(nombre, apaterno, correo, localidad.ToUpper()));

            CreaMensaje(table,
                new Empleado
                {
                    Nombre = nombre,
                    Apaterno = apaterno,
                    Amaterno = amaterno,
                    RowKey = correo,
                    PartitionKey = localidad.ToUpper()
                });
            //added this line

            Console.WriteLine("Entidad creada");

            //Table service returns a maximum of 1000 entities in a single call to it. 
            //If there're more than 1000 entities available in your table, it returns a continuation token which can be used to fetch next set of entities

            TableContinuationToken token = null;
            var entities = new List<Empleado>();
            do
            {
                var queryResult = table.ExecuteQuerySegmented(new TableQuery<Empleado>(), token);
                entities.AddRange(queryResult.Results);
                token = queryResult.ContinuationToken;
            } while (token != null);


            foreach (var item in entities)
            {
                Console.WriteLine(item.Nombre);
            }


            Console.ReadKey();

        }

        static void CreaMensaje(CloudTable table, Empleado emp)
        {
            TableOperation insert = TableOperation.Insert(emp);
            table.Execute(insert);
        }
    }
}
