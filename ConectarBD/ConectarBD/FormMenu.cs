using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConectarBD
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void registrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistroUniMed Form = new RegistroUniMed();
            Form.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUsuario Form = new FormUsuario();
            Form.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCliente Form = new FormCliente();
            Form.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
