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
   
    public partial class modificarTipo : Form
    {
        System.Data.DataRow[] dato;
        public string tipo;
        public modificarTipo()
        {
            InitializeComponent();
            dataSet11.Clear();
        }

        private void modificarTipo_Load(object sender, EventArgs e)
        {
            
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
                    
                    txtnomTipo.Text = dato[0]["nombreTipo"].ToString();
                    txtDexcTipo.Text = dato[0]["descripcionTipo"].ToString();
                    txtcodTipo.Clear();
                    txtnomTipo.Focus();
                    groupBox1.Enabled = true;
                    tipo = txtnomTipo.Text;
                }
                else
                {
                    txtcodTipo.Focus();
                    txtcodTipo.Clear();
                    MessageBox.Show("El tipo de producto no existe");
                }
            }
            else
            {
                MessageBox.Show("Aún no ha ingresado el código del tipo de producto a buscar");
            }
        }

        private void txtnomTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtnomTipo.Text == "")
                {
                    MessageBox.Show("No deje en blanco el nombre del tipo de producto");
                }
                else
                {
                    txtDexcTipo.Focus();
                }
                
            }
        }
        private void Limpiar_Click(object sender, EventArgs e)
        {
            txtnomTipo.Clear();
            txtDexcTipo.Clear();
            txtcodTipo.Focus();
            groupBox2.Enabled = false;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (txtnomTipo.Text != "" && txtDexcTipo.Text != "")
            {
                dato[0]["nombreTipo"] = txtnomTipo.Text;
                dato[0]["descripcionTipo"] = txtDexcTipo.Text;
                dato[0].AcceptChanges();
                //dataSet11.WriteXml("d:\\ArchTipo.xml");
                dataSet11.WriteXml(Application.StartupPath + "\\ArchTipo.xml");
                dataSet11.Clear();


                Actulaizacion oa = new Actulaizacion();
                oa.ShowDialog();
                System.Data.DataRow[] dato1;
                if (oa.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    dataSet11.Clear();
                    //dataSet11.ReadXml("d:\\ArchProductos.xml");
                    dataSet11.ReadXml(Application.StartupPath + "\\ArchProductos.xml");
                    for (int i = 0; i < dataSet11.tblProducto.Rows.Count; i++)
                    {
                        if (dataSet11.tblProducto.Rows[i]["tipoProducto"].ToString() == tipo)
                        {
                            dataSet11.tblProducto.Rows[i]["tipoProducto"] = txtnomTipo.Text;
                            dataSet11.tblProducto.Rows[i].AcceptChanges();
                            //dataSet11.WriteXml("d:\\ArchProductos.xml");
                            dataSet11.WriteXml(Application.StartupPath + "\\ArchProductos.xml");
                            dataSet11.Clear();
                        }
                        dataSet11.Clear();
                        //dataSet11.ReadXml("d:\\ArchProductos.xml");
                        dataSet11.ReadXml(Application.StartupPath + "\\ArchProductos.xml");
                    }
                    dataSet11.Clear();
                    MessageBox.Show("Se ha modificado los datos del tipo de producto y los datos del producto correctamente");
                }
                else
                {
                    MessageBox.Show("Se ha modificado los datos del tipo de producto correctamente");
                }

                txtnomTipo.Clear();
                txtDexcTipo.Clear();
                groupBox1.Enabled = false;

            }
            else
            {
                MessageBox.Show("Algunos datos no están completos");
            }
        }

        private void txtcodTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtcodTipo.Text == "")
                {
                    MessageBox.Show("Por favor no deje en blanco el código a buscar");
                }
                else
                {
                    if (txtcodTipo.Text.Length == 4)
                    {
                        iconButton2.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El código debe tener 4 caracteres. Ejemplo: A001");
                    }
                }
            }
        }

        private void txtDexcTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtDexcTipo.Text == "")
                {
                    MessageBox.Show("Por favor no deje en blanco la descripción del tipo de producto");
                }
                else
                {
                    guardar.Focus();
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

        private void txtcodTipo_MouseClick(object sender, MouseEventArgs e)
        {
            txtnomTipo.Clear();
            txtDexcTipo.Clear();
            txtcodTipo.Focus();
            groupBox1.Enabled = false;
        }
    }
}
