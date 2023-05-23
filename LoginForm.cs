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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "123" && textBoxPassword.Text == "123")
            {
                MessageBox.Show("Login Exitoso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
                
            }
            else 
            {
                MessageBox.Show("Error de login", "Revisar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
