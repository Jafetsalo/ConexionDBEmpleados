using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using ConexionBDEmpleados;
using System.Windows.Forms;
using System.Data;

namespace ConexionDBEmpleados
{

    internal class Broker
    {

        SqlConnection connection_DBEmpleado;
        SqlConnectionStringBuilder connection_DBEmpleado_StringBuilder;
        //La función del String Builder es crear el conexion string a partir de campos que vamos llenando en la instancia
        //Para no complicarse haciendo el string completo

        internal Broker() { SetConnection(); }
        internal List<string> InformationSchemaTables = new List<string>();
        internal List<string> InformationSchemaColumns = new List<string>();
        internal DataTable dataTable = new DataTable();
        public void SetConnection()
        {
            connection_DBEmpleado_StringBuilder = new SqlConnectionStringBuilder();
            connection_DBEmpleado_StringBuilder.DataSource = @"DESKTOP-JBTEHG0\SQLEXPRESS";
            connection_DBEmpleado_StringBuilder.IntegratedSecurity = true;
            connection_DBEmpleado_StringBuilder.InitialCatalog = "DBEmpleados";

            connection_DBEmpleado = new SqlConnection(@"Data Source=DESKTOP-JBTEHG0\SQLEXPRESS;Initial Catalog=DBEmpleados;Integrated Security=True");
            //Data Source=DESKTOP-JBTEHG0\SQLEXPRESS;Initial Catalog=DBEmpleados;Integrated Security=True
            //Thanks to my old self from 12 months ago who allowed me to solve a difficult technical challenge -- Server not found

        }

        public void DeleteRow(string tableName, DataRow dataRow) 
        {
            try
            {
                int rows = 0;
                DataRow localDataRow = dataRow;
                string QueryForDB = "USE DBEmpleados Delete from dbo.Empleados where IDEmpleado = @IDEmpleado";
                SqlCommand SqlAction = new SqlCommand(QueryForDB,connection_DBEmpleado);
                //USE DBEmpleados Delete from dbo.Empleados where IDEmpleado = 777
                SqlAction.Parameters.AddWithValue("Empleados", tableName);
                SqlAction.Parameters.AddWithValue("@IDEmpleado", dataRow[0]);
                connection_DBEmpleado.Open();
                rows += SqlAction.ExecuteNonQuery();
                MessageBox.Show($"Se eliminó con éxito la información con {rows} filas modificadas", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un problema eliminando {ex}", "No se pudo eliminar en Base de datos");
            }
            finally 
            {
                if (connection_DBEmpleado != null)
                {
                    connection_DBEmpleado.Close();
                }
            }

        }
        public void UpdateInTable(string tableName, string NameOfPrimaryKey, DataRow dataRow) 
        {
            try
            {
                int rows = 0;
                DataRow localDataRow = dataRow;
                dataTable.Clear();
                SelectColumnsInTable(tableName);
                int columnIndex = 0;
                string QueryForDB = "USE DBEmpleados Update dbo.Empleados set ";
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (column.ToString() != NameOfPrimaryKey)
                    {
                        QueryForDB += column.ColumnName;
                        if (column.ToString() != dataTable.Columns[dataTable.Columns.Count - 1].ToString())
                        { QueryForDB += $" = '{localDataRow[columnIndex]}', "; }
                        else 
                        { QueryForDB += $" = '{localDataRow[columnIndex]}' "; }
                        //
                        //{ QueryForDB += $" = '@{column.ColumnName}' "; return; }
                        
                    }
                    columnIndex++;
                    //Apellido = '@Apellido', Nombre = '@Nombre', Direccion = '@Direccion', Email = '@Email' Where IDEmpleado = @IDEmpleado";
                }
                QueryForDB += $"Where {NameOfPrimaryKey} = @{NameOfPrimaryKey}";
                
                SqlCommand SqlAction = new SqlCommand(QueryForDB, connection_DBEmpleado);
                //MessageBox.Show("Comando SQL es: _" + QueryForDB, "");
                columnIndex = 0;
                foreach (DataColumn column in dataTable.Columns)
                {
                    SqlAction.Parameters.AddWithValue($"@{column.ColumnName}", localDataRow[columnIndex].ToString());
                    //MessageBox.Show($"Valor que debe ser agregado a parámetro @{column.ColumnName} es igual a: {localDataRow[columnIndex]}","");
                    columnIndex++;
                }
                SqlAction.Parameters.AddWithValue("Empleados", tableName);
                //MessageBox.Show("Comando SQL es: _" + SqlAction.CommandText, "");
                connection_DBEmpleado.Open();
                rows = SqlAction.ExecuteNonQuery();
                MessageBox.Show($"Se actualizó con éxito la información con {rows} filas modificadas", "", MessageBoxButtons.OK);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se encontró un error actualizando la tabla {ex}","No se pudo actualizar tabla en Base de datos");
            }
            finally 
            {
                if (connection_DBEmpleado != null)
                {
                    connection_DBEmpleado.Close();
                }
            }




        }
        public DataTable SelectFillDataGrid(string tableName)
        {
            try
            {
                SelectColumnsInTable(tableName);
                string QueryForDB = "Select * from Empleados";
                SqlCommand SqlAction = new SqlCommand(QueryForDB, connection_DBEmpleado);
                SqlAction.Parameters.AddWithValue("Empleados", tableName);
                connection_DBEmpleado.Open();
                SqlDataReader sqlDataReader = SqlAction.ExecuteReader();
                
                while (sqlDataReader.Read() == true)
                {
                    int index = 0;
                    DataRow row = dataTable.NewRow();
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        row[column] = sqlDataReader[column.ColumnName];
                        

                        index++;
                    }
                    dataTable.Rows.Add(row);
                }
                return dataTable;
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"No fue posible leer la tabla {ex}", "", MessageBoxButtons.OK);
                return null;
            }
            finally
            {
                if (connection_DBEmpleado != null)
                {
                    connection_DBEmpleado.Close();
                }
            }

        }
        public void SelectTables() 
        {
            try {
                InformationSchemaTables.Clear();
                int index = 0;
                string QueryForDB = "USE DBEmpleados Select Distinct Table_Name AS NombreTabla from INFORMATION_SCHEMA.COLUMNS";
                SqlCommand SqlAction = new SqlCommand(QueryForDB, connection_DBEmpleado);
                connection_DBEmpleado.Open();
                //MessageBox.Show("Conexión abierta con éxito", "", MessageBoxButtons.OK);

                SqlDataReader sqlDataReader = SqlAction.ExecuteReader();
                while (sqlDataReader.Read() == true)
                {
                    InformationSchemaTables.Add(sqlDataReader.GetString(0));
                    //MessageBox.Show("Conexión abierta con éxito", $"Encontrada con éxito tabla {InformationSchemaTables.ElementAt(index)}", MessageBoxButtons.OK);
                    index++;
                }
            }
            catch
            {
                //MessageBox.Show("No fue posible leer las tablas", "", MessageBoxButtons.OK);
            }
            finally
            {
                if (connection_DBEmpleado != null)
                {
                    connection_DBEmpleado.Close();
                }
            }


        }
        public void Insert(Empleado empleado) 
        {
            try
            {
                string QueryForDB = "INSERT INTO dbo.Empleados(Apellido, Nombre, Direccion, Email) VALUES (@Nombre, @Apellido, @Direccion, @Correo)";
                SqlCommand SqlAction = new SqlCommand(QueryForDB, connection_DBEmpleado);
                SqlAction.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                SqlAction.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                SqlAction.Parameters.AddWithValue("@Direccion", empleado.Direccion);
                SqlAction.Parameters.AddWithValue("@Correo", empleado.Email);
                connection_DBEmpleado.Open();
                MessageBox.Show("Conexión abierta con éxito", "", MessageBoxButtons.OK);

                int rows = SqlAction.ExecuteNonQuery();
                MessageBox.Show($"Se ingresó con éxito la información con {rows} filas modificadas", "", MessageBoxButtons.OK);

                //You can do it :)
                //Lesson learnt. AddWithValue works ONLY when a class instance has the data we want to place in the query



            }
            catch 
            {
                MessageBox.Show("Hubo un problema al ingresar la información", "", MessageBoxButtons.OK);
            }
            finally 
            {
                if (connection_DBEmpleado != null) 
                {
                    connection_DBEmpleado.Close();
                    
                }

                
            }
        }


        public void SelectColumnsInTable(string tableName)
        {
            try
            {

                int index = 0;
                string QueryForDB = "USE DBEmpleados Select COLUMN_NAME AS NombreColumna from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Empleados'";
                SqlCommand SqlAction = new SqlCommand(QueryForDB, connection_DBEmpleado);
                SqlAction.Parameters.AddWithValue("Empleados",tableName);
                connection_DBEmpleado.Open();
                //MessageBox.Show($"Conexión abierta con éxito con parámetro {tableName}", "", MessageBoxButtons.OK);

                SqlDataReader sqlDataReader = SqlAction.ExecuteReader();
                while (sqlDataReader.Read() == true)
                {
                    
                    
                    
                    dataTable.Columns.Add(sqlDataReader.GetString(0), sqlDataReader.GetFieldType(0));
                    
                    InformationSchemaColumns.Add(sqlDataReader.GetString(0));
                    //MessageBox.Show("Conexión abierta con éxito", $"Encontrada con éxito columna {sqlDataReader.GetString(0)}", MessageBoxButtons.OK);
                    index++;
                }
            }
            catch
            {
                //MessageBox.Show("No fue posible leer las tablas", "", MessageBoxButtons.OK);
            }
            finally
            {
                if (connection_DBEmpleado != null)
                {
                    connection_DBEmpleado.Close();
                }
            }


        }

    }

    /*using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DemoAppDB
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Server=localhost; Database=TestDBConnection; Integrated Security=True; Server=DESKTOP-JBTEHG0\SQLEXPRESS";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            MessageBox.Show("Connection done");
            cnn.Close();
        }
    }
}*/

    /* --REFERENCE ONLY
USE DBBiblioteca2016
Select Table_Name AS NombreTabla, COLUMN_NAME AS NombreColumna, DATA_TYPE AS TipoDato from INFORMATION_SCHEMA.COLUMNS*/
}
