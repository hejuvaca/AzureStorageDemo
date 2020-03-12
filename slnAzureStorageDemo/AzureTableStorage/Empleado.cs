using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTableStorage.Entities
{
    public class Empleado : TableEntity
    {
        public string Nombre { get; set; }
        public string Apaterno { get; set; }
        public string Amaterno { get; set; }

        public Empleado(string nombre, string apaterno, string rowKey, string partitionKey)
        {
            Nombre = nombre;
            Apaterno = apaterno;
            RowKey = rowKey;
            PartitionKey = partitionKey;
        }

        public Empleado()
        {

        }
    }
}
