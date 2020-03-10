namespace CosmosDBDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCrearBaseDatos = new System.Windows.Forms.Button();
            this.btnCrearColeccion = new System.Windows.Forms.Button();
            this.nudNumeroDocumentos = new System.Windows.Forms.NumericUpDown();
            this.btnCrearDocumentos = new System.Windows.Forms.Button();
            this.dgvFamilias = new System.Windows.Forms.DataGridView();
            this.btnConsultarFamilias = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnCosultaSQL = new System.Windows.Forms.Button();
            this.txtApaterno = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrearBaseDatos
            // 
            this.btnCrearBaseDatos.Location = new System.Drawing.Point(23, 22);
            this.btnCrearBaseDatos.Name = "btnCrearBaseDatos";
            this.btnCrearBaseDatos.Size = new System.Drawing.Size(127, 23);
            this.btnCrearBaseDatos.TabIndex = 0;
            this.btnCrearBaseDatos.Text = "Crear BD Cosmos DB";
            this.btnCrearBaseDatos.UseVisualStyleBackColor = true;
            this.btnCrearBaseDatos.Click += new System.EventHandler(this.btnCrearBaseDatos_Click);
            // 
            // btnCrearColeccion
            // 
            this.btnCrearColeccion.Location = new System.Drawing.Point(23, 62);
            this.btnCrearColeccion.Name = "btnCrearColeccion";
            this.btnCrearColeccion.Size = new System.Drawing.Size(127, 23);
            this.btnCrearColeccion.TabIndex = 1;
            this.btnCrearColeccion.Text = "Crear Contenedor";
            this.btnCrearColeccion.UseVisualStyleBackColor = true;
            this.btnCrearColeccion.Click += new System.EventHandler(this.btnCrearColeccion_Click);
            // 
            // nudNumeroDocumentos
            // 
            this.nudNumeroDocumentos.Location = new System.Drawing.Point(23, 107);
            this.nudNumeroDocumentos.Name = "nudNumeroDocumentos";
            this.nudNumeroDocumentos.Size = new System.Drawing.Size(120, 20);
            this.nudNumeroDocumentos.TabIndex = 2;
            // 
            // btnCrearDocumentos
            // 
            this.btnCrearDocumentos.Location = new System.Drawing.Point(23, 133);
            this.btnCrearDocumentos.Name = "btnCrearDocumentos";
            this.btnCrearDocumentos.Size = new System.Drawing.Size(120, 23);
            this.btnCrearDocumentos.TabIndex = 3;
            this.btnCrearDocumentos.Text = "Crear Documentos";
            this.btnCrearDocumentos.UseVisualStyleBackColor = true;
            this.btnCrearDocumentos.Click += new System.EventHandler(this.btnCrearDocumentos_Click);
            // 
            // dgvFamilias
            // 
            this.dgvFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFamilias.Location = new System.Drawing.Point(169, 22);
            this.dgvFamilias.Name = "dgvFamilias";
            this.dgvFamilias.Size = new System.Drawing.Size(566, 177);
            this.dgvFamilias.TabIndex = 4;
            // 
            // btnConsultarFamilias
            // 
            this.btnConsultarFamilias.Location = new System.Drawing.Point(23, 204);
            this.btnConsultarFamilias.Name = "btnConsultarFamilias";
            this.btnConsultarFamilias.Size = new System.Drawing.Size(120, 20);
            this.btnConsultarFamilias.TabIndex = 5;
            this.btnConsultarFamilias.Text = "Consultar Familias";
            this.btnConsultarFamilias.UseVisualStyleBackColor = true;
            this.btnConsultarFamilias.Click += new System.EventHandler(this.btnConsultarFamilias_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(23, 178);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(120, 20);
            this.txtBusqueda.TabIndex = 6;
            // 
            // btnCosultaSQL
            // 
            this.btnCosultaSQL.Location = new System.Drawing.Point(23, 265);
            this.btnCosultaSQL.Name = "btnCosultaSQL";
            this.btnCosultaSQL.Size = new System.Drawing.Size(120, 23);
            this.btnCosultaSQL.TabIndex = 7;
            this.btnCosultaSQL.Text = "Consulta SQL";
            this.btnCosultaSQL.UseVisualStyleBackColor = true;
            this.btnCosultaSQL.Click += new System.EventHandler(this.btnCosultaSQL_Click);
            // 
            // txtApaterno
            // 
            this.txtApaterno.Location = new System.Drawing.Point(23, 239);
            this.txtApaterno.Name = "txtApaterno";
            this.txtApaterno.Size = new System.Drawing.Size(120, 20);
            this.txtApaterno.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 331);
            this.Controls.Add(this.txtApaterno);
            this.Controls.Add(this.btnCosultaSQL);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.btnConsultarFamilias);
            this.Controls.Add(this.dgvFamilias);
            this.Controls.Add(this.btnCrearDocumentos);
            this.Controls.Add(this.nudNumeroDocumentos);
            this.Controls.Add(this.btnCrearColeccion);
            this.Controls.Add(this.btnCrearBaseDatos);
            this.Name = "Form1";
            this.Text = "Cosmos DB Demos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearBaseDatos;
        private System.Windows.Forms.Button btnCrearColeccion;
        private System.Windows.Forms.NumericUpDown nudNumeroDocumentos;
        private System.Windows.Forms.Button btnCrearDocumentos;
        private System.Windows.Forms.DataGridView dgvFamilias;
        private System.Windows.Forms.Button btnConsultarFamilias;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnCosultaSQL;
        private System.Windows.Forms.TextBox txtApaterno;
    }
}

