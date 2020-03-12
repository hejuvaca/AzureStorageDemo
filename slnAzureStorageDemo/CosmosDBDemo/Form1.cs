using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;


namespace CosmosDBDemo
{
    public partial class Form1 : Form
    {

        private const string ENDPOINTURL = "https://XXXXXXX.documents.azure.com:443/";
        private const string PRIMARYKEY = "";
        private const string DATABASE = "EmpleadosDB";
        private const string COLLECTION = "EmpleadosCollection";
        private DocumentClient client;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.client = new DocumentClient(new Uri(ENDPOINTURL), PRIMARYKEY);
        }

        private void btnCrearBaseDatos_Click(object sender, EventArgs e)
        {
            //Permite ejecutar el método de tal forma que termine de ejecutar completo y siga adelante.
            Task.Run(async () => {
                await this.client.CreateDatabaseIfNotExistsAsync(new Database { Id = DATABASE });
            }).GetAwaiter().GetResult();
            //Mensaje de Confirmación
            MessageBox.Show("Base de datos creada", "Azure Cosmos DB", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Deshabilitar botón 
            btnCrearBaseDatos.Enabled = false;
        }

        private void btnCrearColeccion_Click(object sender, EventArgs e)
        {
            //Permite ejecutar el método de tal forma que termine de ejecutar completo y siga adelante.
            Task.Run(async () => {
                await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DATABASE), new DocumentCollection { Id = COLLECTION });
            }).GetAwaiter().GetResult();
            //Mensaje de Confirmación
            MessageBox.Show("Contenedor creado", "Azure Cosmos DB", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Deshabilitar botón 
            btnCrearColeccion.Enabled = false;
        }

        private void btnCrearDocumentos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nudNumeroDocumentos.Value; i++)
            {
                Empleado emp = new Empleado
                {
                    Identificador = i,
                    Apaterno = $"Paterno_{i}",
                    Amaterno = $"Materno_{i}",
                    Correo = $"usuario{i}@outlook.com",
                    Departamento = "Sistemas",
                    Nombre = $"NombreEmpleado{i}",
                    Activo = true
                };

                Task.Run(async () => {
                    await this.CrearEmpleadoDocumentoSiNoExiste(DATABASE, COLLECTION, emp);
                }).GetAwaiter().GetResult();
            }


            
            //Mensaje de Confirmación
            MessageBox.Show("Documentos creados", "Azure Cosmos DB", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Deshabilitar botón 
            btnCrearDocumentos.Enabled = false;
        }

        private async Task CrearEmpleadoDocumentoSiNoExiste(string databaseName, string collectionName, Empleado emp)
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, emp.Identificador.ToString()));
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), emp);
                }
                else
                {
                    throw;
                }
            }
        }

        private void btnConsultarFamilias_Click(object sender, EventArgs e)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };
            IQueryable<Empleado> empQuery = this.client.CreateDocumentQuery<Empleado>(
                    UriFactory.CreateDocumentCollectionUri(DATABASE, COLLECTION), queryOptions)
                    ;//.Where(f => f.ApellidoFamilia == txtBusqueda.Text);

            DataTable table = new DataTable();
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Correo", typeof(string));

            foreach (Empleado emp in empQuery)
            {
                table.Rows.Add(emp.Nombre, emp.Correo);
            }

            dgvFamilias.DataSource = table;
            dgvFamilias.AutoGenerateColumns = true;
        }

        private void btnCosultaSQL_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtApaterno.Text.Equals(""))
                sql = $"SELECT * FROM c";
            else
                sql = $"SELECT * FROM c WHERE c.Apaterno = '{txtApaterno.Text}'";

            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };
            IQueryable<Empleado> empQuery =
                this.client.CreateDocumentQuery<Empleado>(UriFactory.CreateDocumentCollectionUri(DATABASE, COLLECTION), sql, queryOptions);

            DataTable table = new DataTable();
            table.Columns.Add("Apellido", typeof(string));

            foreach (Empleado f in empQuery)
            {
                table.Rows.Add(f.Correo);
            }

            dgvFamilias.DataSource = table;
            dgvFamilias.AutoGenerateColumns = true;
        }
    }
}
