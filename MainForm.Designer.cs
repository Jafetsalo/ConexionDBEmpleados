using System.Drawing;
using System.Windows.Forms;

namespace ConexionDBEmpleados
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.buttonSelectTable = new System.Windows.Forms.Button();
            this.buttonUpdateSelected = new System.Windows.Forms.Button();
            this.buttonDeleteSelected = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.dBEmpleadosDataSet = new ConexionDBEmpleados.DBEmpleadosDataSet();
            this.dBEmpleadosDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empleadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empleadosTableAdapter = new ConexionDBEmpleados.DBEmpleadosDataSetTableAdapters.EmpleadosTableAdapter();
            this.empleadosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBEmpleadosDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBEmpleadosDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(489, 288);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(10, 10);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(490, 21);
            this.comboBoxTables.TabIndex = 1;
            // 
            // buttonSelectTable
            // 
            this.buttonSelectTable.Location = new System.Drawing.Point(505, 10);
            this.buttonSelectTable.Name = "buttonSelectTable";
            this.buttonSelectTable.Size = new System.Drawing.Size(116, 20);
            this.buttonSelectTable.TabIndex = 2;
            this.buttonSelectTable.Text = "Seleccionar tabla";
            this.buttonSelectTable.UseVisualStyleBackColor = true;
            this.buttonSelectTable.Click += new System.EventHandler(this.buttonSelectTable_Click);
            // 
            // buttonUpdateSelected
            // 
            this.buttonUpdateSelected.Location = new System.Drawing.Point(536, 165);
            this.buttonUpdateSelected.Name = "buttonUpdateSelected";
            this.buttonUpdateSelected.Size = new System.Drawing.Size(116, 20);
            this.buttonUpdateSelected.TabIndex = 3;
            this.buttonUpdateSelected.Text = "Actualizar Selección";
            this.buttonUpdateSelected.UseVisualStyleBackColor = true;
            this.buttonUpdateSelected.Click += new System.EventHandler(this.buttonUpdateSelected_Click);
            // 
            // buttonDeleteSelected
            // 
            this.buttonDeleteSelected.Location = new System.Drawing.Point(536, 204);
            this.buttonDeleteSelected.Name = "buttonDeleteSelected";
            this.buttonDeleteSelected.Size = new System.Drawing.Size(116, 20);
            this.buttonDeleteSelected.TabIndex = 4;
            this.buttonDeleteSelected.Text = "Eliminar Selección";
            this.buttonDeleteSelected.UseVisualStyleBackColor = true;
            this.buttonDeleteSelected.Click += new System.EventHandler(this.buttonDeleteSelected_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(505, 380);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(211, 20);
            this.buttonInsert.TabIndex = 5;
            this.buttonInsert.Text = "Insertar en tabla";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // dBEmpleadosDataSet
            // 
            this.dBEmpleadosDataSet.DataSetName = "DBEmpleadosDataSet";
            this.dBEmpleadosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dBEmpleadosDataSetBindingSource
            // 
            this.dBEmpleadosDataSetBindingSource.DataSource = this.dBEmpleadosDataSet;
            this.dBEmpleadosDataSetBindingSource.Position = 0;
            // 
            // empleadosBindingSource
            // 
            this.empleadosBindingSource.DataMember = "Empleados";
            this.empleadosBindingSource.DataSource = this.dBEmpleadosDataSet;
            // 
            // empleadosTableAdapter
            // 
            this.empleadosTableAdapter.ClearBeforeFill = true;
            // 
            // empleadosBindingSource1
            // 
            this.empleadosBindingSource1.DataMember = "Empleados";
            this.empleadosBindingSource1.DataSource = this.dBEmpleadosDataSet;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 423);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.buttonDeleteSelected);
            this.Controls.Add(this.buttonUpdateSelected);
            this.Controls.Add(this.buttonSelectTable);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "Gestión Tabla (Seleccionar, Insertar, Actualizar, Eliminar)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBEmpleadosDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBEmpleadosDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBoxTables;
        private Button buttonSelectTable;
        private Button buttonUpdateSelected;
        private Button buttonDeleteSelected;
        private Button buttonInsert;
        private BindingSource dBEmpleadosDataSetBindingSource;
        private DBEmpleadosDataSet dBEmpleadosDataSet;
        private BindingSource empleadosBindingSource;
        private DBEmpleadosDataSetTableAdapters.EmpleadosTableAdapter empleadosTableAdapter;
        private BindingSource empleadosBindingSource1;
    }
}