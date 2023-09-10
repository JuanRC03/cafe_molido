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
    public partial class DuscarEliminar : Form
    {
        System.Data.DataRow[] dato;
        public DuscarEliminar()
        {
            InitializeComponent();
            dataSet11.Clear();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (txtcod.Text != "")
            {
                if (txtcod.Text.Length == 9)
                {
                    dataSet11.Clear();
                    //dataSet11.ReadXml("d:\\ArchProductos.xml");
                    dataSet11.ReadXml(Application.StartupPath + "\\ArchProductos.xml");

                    dato = dataSet11.tblProducto.Select("codigoProducto='" + txtcod.Text + "'");

                    if (dato.Length > 0)
                    {
                        lc.Text = dato[0]["codigoProducto"].ToString();
                        lnom.Text = dato[0]["nombreProducto"].ToString();
                        lt.Text = dato[0]["tipoProducto"].ToString();
                        lpres.Text = dato[0]["presentacionProducto"].ToString();
                        lp.Text = dato[0]["precioProducto"].ToString();
                        Class1 ov = new Class1(dato[0]["DescripcionProducto"].ToString());
                        ld.Text = ov.agregarEspacio();
                        groupBox2.Enabled = true;
                        txtcod.Clear();
                    }
                    else
                    {
                        txtcod.Clear();
                        MessageBox.Show("El producto no existe");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un código valido. Ejemplo: A001-0001");
                    txtcod.Clear();
                }
                
            }
            else
            {
                MessageBox.Show("Aún no ha ingresado el código de producto a buscar");
            }
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            dato[0].Delete();
            //dataSet11.tblProducto.WriteXml("d:\\ArchProductos.xml");
            dataSet11.tblProducto.WriteXml(Application.StartupPath + "\\ArchProductos.xml");
            MessageBox.Show("Se ha eliminado los datos del producto correctamente");
            lnom.Text = "";
            lc.Text = "";
            lt.Text = "";
            lpres.Text = "";
            lp.Text = "";
            ld.Text = "";
            groupBox2.Enabled = false;
        }

        private void txtcod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtcod.Text != "")
                {
                    if (txtcod.Text.Length == 9)
                    {
                        buscar.Focus();
                        groupBox2.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un código valido. Ejemplo: A001-0001");
                        txtcod.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco el recuadro");
                }
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            lnom.Text = "";
            lc.Text = "";
            lt.Text = "";
            lpres.Text = "";
            lp.Text = "";
            ld.Text = "";
            groupBox2.Enabled = false;
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtcod_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcod_MouseClick(object sender, MouseEventArgs e)
        {
            lnom.Text = "";
            lc.Text = "";
            lt.Text = "";
            lpres.Text = "";
            lp.Text = "";
            ld.Text = "";
            groupBox2.Enabled = false;
        }
    }
}
