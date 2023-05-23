using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionDBEmpleados
{
    public partial class MainForm : Form
    {
        Broker BrokerToSelect;

        public MainForm()
        {
            InitializeComponent();
            BrokerToSelect = new Broker();
            BrokerToSelect.SelectTables();
            
            foreach (string table in BrokerToSelect.InformationSchemaTables)
            { 
                comboBoxTables.Items.Add(table);
            }
            BrokerToSelect.InformationSchemaTables.Clear();
        }

        private void buttonSelectTable_Click(object sender, EventArgs e)
        {
            if (comboBoxTables.Text == "" ) 
            {
                MessageBox.Show("Ninguna tabla ha sido elegida","Por favor elige una tabla válida",MessageBoxButtons.OK);

                return;
            }
            else
            {
                DataTable data = BrokerToSelect.SelectFillDataGrid(comboBoxTables.Text);
                dataGridView1.DataSource = data;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell viewCell in row.Cells) 
                    {
                        if (viewCell.ColumnIndex == 0) 
                        {
                            viewCell.ReadOnly = true;
                        }
                    }
                }
                //dataGridView1.Columns[0].CellTemplate.ReadOnly = true;
                BrokerToSelect = new Broker();
                

            }

            //When clicked should read the combobox selected table DONE
            //Then, send a request to the server DONE
            //Finally, load the DataGridView with that data SUPERHARD DONE
            // Of course, you can do it! DONE




        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBEmpleadosDataSet.Empleados' table. You can move, or remove it, as needed.
            this.empleadosTableAdapter.Fill(this.dBEmpleadosDataSet.Empleados);

        }

        private void buttonUpdateSelected_Click(object sender, EventArgs e)
        {
            try
            {
                //First: Let's create this dataTable cloning dataGridView1
                if (comboBoxTables.Text == "")
                {
                    MessageBox.Show("Ninguna tabla ha sido elegida para actualizar", "Por favor elige una tabla válida", MessageBoxButtons.OK);

                    return;
                }
                else 
                {
                    DataTable dataClone = new DataTable();
                    DataTable dataQuery = new DataTable();
                    Broker brokerToUpdate = new Broker();   
                    dataQuery = brokerToUpdate.SelectFillDataGrid(comboBoxTables.Text);

                    foreach (DataGridViewColumn column in dataGridView1.Columns) 
                    {
                        dataClone.Columns.Add(column.Name,column.CellTemplate.ValueType);
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows) 
                    {
                        DataRow dataRow = dataClone.NewRow();
                        foreach (DataGridViewCell dataCell in row.Cells) 
                        {
                            dataRow[dataCell.ColumnIndex] = dataCell.Value;
                          //  MessageBox.Show($"Valor agregado a dataClone {dataRow[dataCell.ColumnIndex]}");
                        }
                        dataClone.Rows.Add(dataRow);
                    }


                    //Now let's compare dataClone and dataQuery

                    System.Data.DataRowCollection dataRowArrayQuery = dataQuery.Rows;
                    System.Data.DataRowCollection dataRowArrayClone = dataClone.Rows;
                    System.Data.DataColumnCollection dataColumnArrayQuery = dataQuery.Columns;
                    System.Data.DataColumnCollection dataColumnArrayClone = dataClone.Columns;
                    int rowIndex = 0;
                    int columnIndex = 0;
                    foreach (DataRow dataRow in dataQuery.Rows) 
                    {
                        columnIndex = 0;
                        bool changeDetected = false;
                        DataRow dataRowQuery = dataRowArrayQuery[rowIndex];
                        DataRow dataRowClone = dataRowArrayClone[rowIndex];

                        foreach (DataColumn dataColumn1 in dataClone.Columns)
                        {
                           

                            if (dataRowQuery[columnIndex].ToString() != dataRowClone[columnIndex].ToString()) 
                            {
                                MessageBox.Show($"Diferencia de valores encontrada, procederemos a actualizar: " +
                                    $" Valor Previo {dataRowQuery[columnIndex]}" +
                                    $" Valor nuevo {dataRowClone[columnIndex]}","Actualizacion en camino");
                                changeDetected = true;
                            }
                            columnIndex++;

                        }
                        if(changeDetected) 
                        {
                           // int dataRowClone[0]
                            BrokerToSelect.UpdateInTable(comboBoxTables.Text, "IDEmpleado", dataRowClone);
                        }

                        rowIndex++;
                    }

                }



            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error al actualizar los campos {ex}","Hubo un error al actualizar la tabla");
            }


            //It may be harder to change the selected row, isn't it?
            //We'll create a DataTable with the stored information in the DB DONE
            //Once this button is clicked it will compare the data in the dataGridView cloned into a dataTable vs the query dataTable
            //If there are changes in said row, you'll send a query to update the whole row with the new information
            //After looping scouting for changes you'll update the table to reflect the changes 
        }

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            //Basically, retrieve the primaryKey on selected rows
            //Then run a Delete query on that list of items 
            //Of course, you can do it! 
            if (comboBoxTables.Text == "" || dataGridView1.DataSource == null)
            {
                MessageBox.Show("Ninguna tabla ha sido elegida", "Por favor elige una tabla válida", MessageBoxButtons.OK);

                return;
            }
            else 
            {
                
                DataTable dataClone = new DataTable();
                Broker brokerToDelete = new Broker();
                

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    dataClone.Columns.Add(column.Name, column.CellTemplate.ValueType);
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool rowIsSelected = false;
                    DataRow dataRow = dataClone.NewRow();
                    foreach (DataGridViewCell dataCell in row.Cells)
                    {
                        if (dataCell.Selected == true)
                        {
                            rowIsSelected = true;
                           
                        }
                        dataRow[dataCell.ColumnIndex] = dataCell.Value;
                        //  MessageBox.Show($"Valor agregado a dataClone {dataRow[dataCell.ColumnIndex]}");
                    }
                    if (rowIsSelected == true) { dataClone.Rows.Add(dataRow); }
                }

                foreach (DataRow deleteRow in dataClone.Rows) 
                {
                    brokerToDelete.DeleteRow(comboBoxTables.Text,deleteRow);
                }

                buttonSelectTable.PerformClick();

                    //Call delete in broker for this row :p

                //dataGridView1.Columns[0].CellTemplate.ReadOnly = true;
                

            }

            


        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            InsertForm insert = new InsertForm();
            insert.ShowDialog();
            buttonSelectTable.PerformClick();
        }
    }
}
