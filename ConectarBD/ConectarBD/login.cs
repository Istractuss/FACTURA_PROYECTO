using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ConectarBD
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Estas Segur@ de Salir", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-KMMH605;Initial Catalog=dbFactura;Integrated Security=True";


            string usuario = txtUsuario.Text;

            string clave = txtcontra.Text;


            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show("Debe ingresar usuario y clave.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM SFTUSUA0 WHERE USUARIO = @USUARIO AND PASSWORD = @PASSWORD";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@USUARIO", usuario);
                        command.Parameters.AddWithValue("@PASSWORD", clave);

                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            //MessageBox.Show("¡Login exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            FormMenu mainForm = new FormMenu();
                            mainForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
