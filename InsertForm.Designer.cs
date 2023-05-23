namespace ConexionDBEmpleados
{
    partial class InsertForm
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
            this.textBoxInsNombre = new System.Windows.Forms.TextBox();
            this.textBoxInsApellido = new System.Windows.Forms.TextBox();
            this.textBoxInsEmail = new System.Windows.Forms.TextBox();
            this.textBoxInsDireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxInsNombre
            // 
            this.textBoxInsNombre.Location = new System.Drawing.Point(134, 122);
            this.textBoxInsNombre.Name = "textBoxInsNombre";
            this.textBoxInsNombre.Size = new System.Drawing.Size(234, 20);
            this.textBoxInsNombre.TabIndex = 0;
            // 
            // textBoxInsApellido
            // 
            this.textBoxInsApellido.Location = new System.Drawing.Point(134, 148);
            this.textBoxInsApellido.Name = "textBoxInsApellido";
            this.textBoxInsApellido.Size = new System.Drawing.Size(234, 20);
            this.textBoxInsApellido.TabIndex = 1;
            // 
            // textBoxInsEmail
            // 
            this.textBoxInsEmail.Location = new System.Drawing.Point(134, 195);
            this.textBoxInsEmail.Name = "textBoxInsEmail";
            this.textBoxInsEmail.Size = new System.Drawing.Size(234, 20);
            this.textBoxInsEmail.TabIndex = 2;
            // 
            // textBoxInsDireccion
            // 
            this.textBoxInsDireccion.Location = new System.Drawing.Point(134, 238);
            this.textBoxInsDireccion.Name = "textBoxInsDireccion";
            this.textBoxInsDireccion.Size = new System.Drawing.Size(234, 20);
            this.textBoxInsDireccion.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dirección";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(224, 309);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(144, 23);
            this.buttonInsert.TabIndex = 8;
            this.buttonInsert.Text = "Insertar";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 424);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxInsDireccion);
            this.Controls.Add(this.textBoxInsEmail);
            this.Controls.Add(this.textBoxInsApellido);
            this.Controls.Add(this.textBoxInsNombre);
            this.Name = "InsertForm";
            this.Text = "Insertar Registro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInsNombre;
        private System.Windows.Forms.TextBox textBoxInsApellido;
        private System.Windows.Forms.TextBox textBoxInsEmail;
        private System.Windows.Forms.TextBox textBoxInsDireccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonInsert;
    }
}