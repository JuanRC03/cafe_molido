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
    public partial class eliminarTipo : Form
    {
        System.Data.DataRow[] dato;
        public eliminarTipo()
        {
            InitializeComponent();
            dataSet12.Clear();
            dataSet11.Clear();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (txtcodTipo.Text != "")
            {
                dataSet11.Clear();
                //dataSet11.ReadXml("d:\\ArchTipo.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchTipo.xml");
                dato = dataSet11.tblTipoProducto.Select("codigoTipo='" + txtcodTipo.Text + "'");

                if (dato.Length > 0)
                {
                    l1.Text = dato[0]["codigoTipo"].ToString();
                    l2.Text = dato[0]["nombreTipo"].ToString();
                    Class1 ov = new Class1(dato[0]["descripcionTipo"].ToString());
                    l3.Text = ov.agregarEspacio();
                    txtcodTipo.Clear();
                    groupBox2.Enabled = true;
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

        private void guardar_Click(object sender, EventArgs e)
        {
            dataSet12.Clear();
            //dataSet12.ReadXml("d:\\ArchProductos.xml");
            dataSet12.ReadXml(Application.StartupPath + "\\ArchProductos.xml");
            System.Data.DataRow[] dato1;
            dato1 = dataSet12.tblProducto.Select("tipoProducto='" + l2.Text + "'");
            if (dato1.Length > 0)
            {
                MessageBox.Show("No se puede eliminar tipo de producto ya que se está usando en en los datos de los productos, puede modificar los datos del mismo o eliminarlos para poder realizar la solicitud");
            }
            else
            {
                dato[0].Delete();
                dataSet11.tblTipoProducto.WriteXml("d:\\ArchTipo.xml");
                MessageBox.Show("Se ha eliminado los datos del tipo de producto correctamente");
                l1.Text = "";
                l2.Text = "";
                l3.Text = "";
                groupBox2.Enabled = false;
                txtcodTipo.Focus();
            }
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
                        MessageBox.Show("El código ingresado no es correcto, debe tener 4 caracteres. Ejemplo: A001");
                    }

                }
                else
                {
                    MessageBox.Show("Por favor no deje en codigo del tipo de producto");
                }
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            l1.Text = "";
            l2.Text = "";
            l3.Text = "";
            groupBox2.Enabled = false;
            txtcodTipo.Focus();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txtcodTipo_MouseClick(object sender, MouseEventArgs e)
        {
            l1.Text = "";
            l2.Text = "";
            l3.Text = "";
            groupBox2.Enabled = false;
        }
    }
}
