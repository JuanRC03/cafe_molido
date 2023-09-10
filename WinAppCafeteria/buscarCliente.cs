using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppCafeteria
{
    public partial class buscarCliente : Form
    {
        public buscarCliente()
        {
            InitializeComponent();
            txtCedula.MaxLength = 10;
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "")
            {
                dataSet11.Clear();
                //dataSet11.ReadXml("d:\\ArchCliente.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchCliente.xml");
                System.Data.DataRow[] dato;
                dato = dataSet11.tblCliente.Select("cedula='" + txtCedula.Text + "'");

                if (dato.Length > 0)
                {
                    lc.Text = dato[0]["cedula"].ToString();
                    ln.Text = dato[0]["nombre"].ToString();
                    le.Text = dato[0]["edad"].ToString();
                    lg.Text = dato[0]["genero"].ToString();
                    lem.Text = dato[0]["email"].ToString();
                    lciu.Text = dato[0]["ciudad"].ToString();
                    //salir.Enabled = true;
                    txtCedula.Clear();
                }
                else
                {
                    txtCedula.Clear();
                    MessageBox.Show("El cliente no existe");
                }
            }
            else
            {
                MessageBox.Show("Aún no ha ingresado la cédula del cliente para buscar");
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("En este campo, se coloca la cédula");
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string texto = "";
                if (txtCedula.Text != "")
                {
                    if (txtCedula.Text.Length == 10)
                    {
                        ValidarCedula ov = new ValidarCedula();
                        texto = ov.validar(txtCedula.Text);
                        if (texto == "V")
                        {
                            buscar.Focus();
                        }
                        else
                        {
                            MessageBox.Show(texto);
                            txtCedula.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cédula del cliente no está completa");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un número de cédula");
                }
            }
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCedula_MouseClick(object sender, MouseEventArgs e)
        {
            lc.Text = "";
            ln.Text = "";
            le.Text = "";
            lg.Text = "";
            lem.Text = "";
            lciu.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
