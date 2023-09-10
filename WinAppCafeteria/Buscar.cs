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
    public partial class Buscar : Form
    {
        System.Data.DataRow[] dato;
        public Buscar()
        {
            InitializeComponent();
            dataSet11.Clear();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (txtCodigo.Text != "")
                {
                    if (txtCodigo.Text.Length == 9)
                    {
                        dataSet11.Clear();
                        //dataSet11.ReadXml("d:\\ArchProductos.xml");
                        dataSet11.ReadXml(Application.StartupPath + "\\ArchProductos.xml");

                        dato = dataSet11.tblProducto.Select("codigoProducto='" + txtCodigo.Text + "'");

                        if (dato.Length > 0)
                        {
                            lc.Text = dato[0]["codigoProducto"].ToString();
                            lnom.Text = dato[0]["nombreProducto"].ToString();
                            lt.Text = dato[0]["tipoProducto"].ToString();
                            lpres.Text = dato[0]["presentacionProducto"].ToString();
                            lp.Text = dato[0]["precioProducto"].ToString();
                            Class1 ov = new Class1(dato[0]["DescripcionProducto"].ToString());
                            ld.Text = ov.agregarEspacio() ;
                            txtCodigo.Clear();
                        }
                        else
                        {
                            txtCodigo.Clear();
                            txtCodigo.Focus();
                            MessageBox.Show("El producto no existe");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un código valido, ejemplo: A001-0001");
                        txtCodigo.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco el recuadro");
                }
                
            }
            else
            {
                MessageBox.Show("Aún no ha ingresado el código de producto a buscar");
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCodigo.Text != "")
                {
                    if (txtCodigo.Text.Length == 9)
                    {
                        iconButton2.Focus();
                        groupBox2.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un código valido, ejemplo: A001-0001");
                        txtCodigo.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco el recuadro");
                }
            }
        }

        private void txtCodigo_MouseClick(object sender, MouseEventArgs e)
        {
            lc.Text = "";
            lnom.Text = "";
            lt.Text = "";
            lpres.Text = "";
            lp.Text = "";
            ld.Text = "";
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salir_Click(object sender, EventArgs e)
        {

        }
    }
}
