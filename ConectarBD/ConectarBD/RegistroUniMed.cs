using MiLibreria;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ConectarBD
{
    public partial class RegistroUniMed : Form
    {
        public RegistroUniMed()
        {
            InitializeComponent();
        }

        public int encontrado = 0;
        public string cmd;

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "insert into sftunid0 (coduni,desuni) values ('{0}','{1}')";
                SqlConnection conexion = new SqlConnection("Data Source = DESKTOP-N9CHCKB\\SQLEXPRESS; Initial Catalog = dbFactura; Integrated Security = True");
                conexion.Open();
                MessageBox.Show("Conecto con la base de datos");

            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error "+error.Message);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
               
                string cmd = (encontrado==0 ? string.Format("insert into sftunid0 (coduni,desuni) values ('{0}','{1}')", txtCodUni.Text.Trim(), txtDesUni.Text.Trim()): string.Format("update sftunid0 set desuni='{0}' where coduni='{1}'", txtDesUni.Text.Trim(), txtCodUni.Text.Trim()));
                string letrero = (encontrado == 0 ? "Registro Guardado Correctamente..." : "Registro Actualizado Correctamente...");
                DataSet ds = Utilidades.Ejecutar(cmd);
                MessageBox.Show(letrero);


                /* if (encontrado == 0)
                 {
                     string cmd = string.Format("insert into sftunid0 (coduni,desuni) values ('{0}','{1}')", txtCodUni.Text.Trim(), txtDesUni.Text.Trim());
                     DataSet ds = Utilidades.Ejecutar(cmd);

                     MessageBox.Show("Registro Guardado Correctamente...");
                 }
                 else
                 {
                     string cmd = string.Format("update sftunid0 set desuni='{0}' where coduni='{1}'", txtDesUni.Text.Trim(), txtCodUni.Text.Trim());
                     DataSet ds = Utilidades.Ejecutar(cmd);

                     MessageBox.Show("Registro Actualizado Correctamente...");
                 }*/
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error " + error.Message);
            }
            BorrarCampos(this);
            txtCodUni.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = string.Format("select * from sftunid0 where coduni='{0}'", txtCodUni.Text.Trim());
                DataSet ds = Utilidades.Ejecutar(cmd);
                txtDesUni.Text = ds.Tables[0].Rows[0]["desuni"].ToString().Trim();
                encontrado = 1;
            }
            catch (Exception Err)
            {
                encontrado = 0;
            }
            txtDesUni.Focus();
                      
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            /*  try
              {                
                  string cmd = string.Format("update sftunid0 set desuni='{0}' where coduni='{1}'", txtDesUni.Text.Trim(), txtCodUni.Text.Trim());               
                  SqlConnection conexion = new SqlConnection("Data Source = LAPTOP-6N6L60V8; Initial Catalog = dbFactura; Integrated Security = True");
                  conexion.Open();                

                  DataSet Ds = new DataSet();
                  SqlDataAdapter DA = new SqlDataAdapter(cmd, conexion);
                  DA.Fill(Ds);
                  conexion.Close();
                  MessageBox.Show("Registro Guardado Correctamente...");
              }
              catch (Exception error)
              {
                  MessageBox.Show("Ha ocurrido un error " + error.Message);
              }
              txtDesUni.Text = "";
              txtCodUni.Focus();
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Para evitar se cambie el contenido del combobox desde la ejecucion (no edita)
            //  cmbUniMed.DropDownStyle = ComboBoxStyle.DropDownList;
            try
            {
                DataSet ds;
                string cmd = "SELECT * FROM sftunid0";
                ds = Utilidades.Ejecutar(cmd);
                cmbUniMed.DataSource = ds.Tables[0].DefaultView;
                cmbUniMed.ValueMember = "coduni";
                cmbUniMed.DisplayMember = "desuni";                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void cmbUniMed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodUni.Text = cmbUniMed.SelectedValue.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas Segur@ de Salir", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas Segur@ de Eliminar", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string cmd = string.Format("delete from sftunid0 where coduni='{0}'", txtCodUni.Text.Trim());
                DataSet ds = Utilidades.Ejecutar(cmd);

                MessageBox.Show("Registro Eliminado Correctamente...");
                BorrarCampos(this);
            }

        }

        private void BorrarCampos(Control control)
        {
            foreach(var txt in control.Controls)
            {
                if(txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {           
            BorrarCampos(this);
            encontrado = 0;
        }
    }
}
