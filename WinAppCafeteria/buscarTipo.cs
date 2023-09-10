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
    public partial class buscarTipo : Form
    {
        public buscarTipo()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (txtcodTipo.Text != "")
            {
                dataSet11.Clear();
                //dataSet11.ReadXml("d:\\ArchTipo.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchTipo.xml");
                System.Data.DataRow[] dato;
                dato = dataSet11.tblTipoProducto.Select("codigoTipo='" + txtcodTipo.Text + "'");

                if (dato.Length > 0)
                {
                    l1.Text = dato[0]["codigoTipo"].ToString();
                    l2.Text = dato[0]["nombreTipo"].ToString();
                    Class1 ov = new Class1(dato[0]["descripcionTipo"].ToString());
                    l3.Text = ov.agregarEspacio();
                    txtcodTipo.Clear();
                }
                else
                {
                    txtcodTipo.Clear();
                    MessageBox.Show("El tipo de producto no existe");
                }
            }
            else
            {
                MessageBox.Show("Aún no ha ingresado el código del tipo de producto a buscar");
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

        private void txtcodTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                
                if (txtcodTipo.Text != "")
                {
                    if (txtcodTipo.Text.Length == 4)
                    {
                        iconButton2.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El código ingresado no es correcto. Debe tener 4 caracteres. Ejemplo: A001");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Por favor no deje el código del tipo de producto");
                }
            }
        }

        private void txtcodTipo_MouseClick(object sender, MouseEventArgs e)
        {
            l1.Text = "";
            l2.Text = "";
            l3.Text = "";

        }
    }
}
