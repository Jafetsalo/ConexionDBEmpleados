using ConexionBDEmpleados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionDBEmpleados
{

    
    public partial class InsertForm : Form 
    {
        Broker BrokerToInsert;
        Empleado EmpleadoToInsert;
        public InsertForm()
        {
            BrokerToInsert = new Broker();
            InitializeComponent();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            EmpleadoToInsert = new Empleado();
            try
            {
                EmpleadoToInsert.Apellido = textBoxInsApellido.Text;
                EmpleadoToInsert.Nombre = textBoxInsNombre.Text;
                EmpleadoToInsert.Email = textBoxInsEmail.Text;
                EmpleadoToInsert.Direccion = textBoxInsDireccion.Text;

                if (EmpleadoToInsert.Direccion == "" || EmpleadoToInsert.Nombre == "" || EmpleadoToInsert.Apellido == "" || EmpleadoToInsert.Email == "")
                {

                    throw new Exception();
                }
                else 
                {
                    MessageBox.Show($"Enviando {EmpleadoToInsert.Nombre} {EmpleadoToInsert.Apellido} {EmpleadoToInsert.Direccion} {EmpleadoToInsert.Email}");
                    BrokerToInsert.Insert(EmpleadoToInsert); 
                }
                

            }
            catch  
            {
                MessageBox.Show("Faltan datos o hay información incompleta","Llene el cuadro con información", MessageBoxButtons.OK);
            }

            this.Close();

            //We want to call the Broker and then it's method to Insert
            //Also it's necesary to create a Empleado instance --DONE

        }

    }
}
