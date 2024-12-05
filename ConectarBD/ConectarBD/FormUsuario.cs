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
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void Salir_U_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas Segur@ de Salir", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();



            }
        }

        private void Guardar_U_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-6N6L60V8;Initial Catalog=dbFactura;Integrated Security=True";


            string usuario = textUsuario.Text;

            string clave = textContraseña.Text;


        }
    }
}
