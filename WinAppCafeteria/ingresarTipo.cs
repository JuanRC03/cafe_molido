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
    public partial class ingresarTipo : Form
    {
        public ingresarTipo()
        {
            InitializeComponent();
        }

        private void txtcodTipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void ingresarTipo_Load(object sender, EventArgs e)
        {
            txtcodTipo.Focus();
        }

        private void txtcodTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtcodTipo.Text != "")
                {
                    if (txtcodTipo.Text.Length == 4)
                    {
                        Limpiar.Enabled = true;
                        txtnomTipo.Focus();
                    }
                    else {
                        MessageBox.Show("Por favor ingrese un código que tenga 4 caracteres. Ejemplo: A001");
                    }

                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco el código de tipo producto");
                }
                
            }
        }

        private void txtnomTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtnomTipo.Text == "")
                {
                    MessageBox.Show("Por favor no deje en blanco el nombre del tipo de producto");
                }
                else
                {
                    txtDexcTipo.Focus();
                }
            }
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            dataSet11.Clear();
            if (txtcodTipo.Text != "" && txtnomTipo.Text != "" && txtDexcTipo.Text != "" )
            {
                dataSet11.Clear();
                //dataSet11.ReadXml("d:\\ArchTipo.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchTipo.xml");
                System.Data.DataRow[] dato;
                dato = dataSet11.tblTipoProducto.Select("codigoTipo='" + txtcodTipo.Text + "'");

                if (dato.Length > 0)
                {
                    MessageBox.Show("El codigo de tipo de producto " + txtcodTipo.Text + " ya existe");
                }
                else
                {
                    dataSet11.Clear();
                    //dataSet11.ReadXml("d:\\ArchTipo.xml");
                    dataSet11.ReadXml(Application.StartupPath + "\\ArchTipo.xml");
                    string cod = txtcodTipo.Text;
                    string nom = txtnomTipo.Text;
                    string des = txtDexcTipo.Text;
                    object[] dato1 = new object[3];
                    dato1[0] = cod;
                    dato1[1] = nom;
                    dato1[2] =des;
                    dataSet11.tblTipoProducto.Rows.Add(dato1);
                    //dataSet11.WriteXml("d:\\ArchTipo.xml");
                    dataSet11.WriteXml(Application.StartupPath + "\\ArchTipo.xml");
                    dataSet11.Clear();
                    txtcodTipo.Clear();
                    txtnomTipo.Clear();
                    txtDexcTipo.Clear();
                    txtcodTipo.Focus();
                    guardar.Enabled = false;
                    Limpiar.Enabled = false;

                    MessageBox.Show("Se ha ingresado correctamente los datos del tipo de producto");
                }

            }
            else
            {
                MessageBox.Show("Algunos datos no están completos");
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            txtcodTipo.Focus();
            txtcodTipo.Clear();
            txtnomTipo.Clear();
            txtDexcTipo.Clear();
            Limpiar.Enabled = false;
            
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDexcTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtDexcTipo.Text == "")
                {
                    MessageBox.Show("Por favor no deje en blanco la descripción del producto");
                }
                else
                {
                    guardar.Enabled = true;
                    guardar.Focus();
                }
            }
        }
    }
}
