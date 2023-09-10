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
    public partial class WinAppIngreso : Form
    {
        string cod_aux;
        public string[] nomTipo;
        public WinAppIngreso()
        {
            
            InitializeComponent();
            txttipo.Items.Clear();
            dataSet11.Clear();
            //dataSet11.ReadXml("d:\\ArchTipo.xml");
            dataSet11.ReadXml(Application.StartupPath + "\\ArchTipo.xml");
            for (int i = 0; i < dataSet11.tblTipoProducto.Rows.Count; i++)
            {
                txttipo.Items.Add(dataSet11.tblTipoProducto.Rows[i]["nombreTipo"].ToString());
            }
            dataSet11.Clear();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (txtcod.Text != "" && txtnom.Text != "" && txtpre.Text != "" && txttipo.Text != "" && txtdescrip.Text != "" && txtPresentacion.Text!="")
            {
                dataSet11.Clear();
                //dataSet11.ReadXml("d:\\ArchProductos.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchProductos.xml");
                System.Data.DataRow[] dato;
                dato = dataSet11.tblProducto.Select("codigoProducto='" + txtcod.Text + "'");

                if (dato.Length > 0)
                {
                    MessageBox.Show("El producto con código " + txtcod.Text + " ya existe");
                }
                else 
                { 
                    dataSet11.Clear();
                    //dataSet11.ReadXml("d:\\ArchProductos.xml");
                    dataSet11.ReadXml(Application.StartupPath + "\\ArchProductos.xml");
                    string cod = txtcod.Text;
                    string nom = txtnom.Text;
                    string pre = txtpre.Text;
                    string pres = txtPresentacion.Text;
                    string tip = txttipo.Text;
                    string desc = txtdescrip.Text;
                    object[] dato1 = new object[6];
                    dato1[0] = cod;
                    dato1[1] = nom;
                    dato1[2] = tip;
                    dato1[3] = pres;
                    dato1[4] = pre;
                    dato1[5] = desc;
                    dataSet11.tblProducto.Rows.Add(dato1);
                    //dataSet11.WriteXml("d:\\ArchProductos.xml");
                    dataSet11.WriteXml(Application.StartupPath + "\\ArchProductos.xml");
                    dataSet11.Clear();
                    txtcod.Clear();
                    txtnom.Clear();
                    txtPresentacion.Text = "";
                    txtpre.Clear();
                    txttipo.Text = "";
                    txtdescrip.Clear();
                    MessageBox.Show("Se ha ingresado correctamente los datos del producto");
                    Limpiar.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("Algunos datos no están completos");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void WinAppIngreso_Load(object sender, EventArgs e)
        {
            txtcod.Focus();
            
        }

        private void txtcod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtcod.Text != "")
                {
                    if (txtcod.Text == cod_aux)
                    {
                        MessageBox.Show("Por favor ingrese más caracteres al código");
                    }
                    else
                    {
                        if (txtcod.Text.Length == 9)
                        {
                            clVerifiacarCodigoProducto ov = new clVerifiacarCodigoProducto(txtcod.Text, cod_aux);

                            if (ov.validar() == true)
                            {
                                txtnom.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El codigo de producto no es válido ya que debe iniciar con " + cod_aux);
                                txtcod.Text = cod_aux;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor ingrese un código válido, con 9 caracteres. Ejemplo A001-0001");
                        }
                    }  
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco el casillero");
                }
                
            }
        }

        private void txtnom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtnom.Text != "")
                {
                    txtPresentacion.Focus();
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco el casillero");
                }
            }
        }

        private void txtpre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtpre.Text != "")
                {
                    double x = double.Parse(txtpre.Text);
                    if (x > 0 && x <= 1000)
                    {
                        txtdescrip.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un valor mayor que 0 y menor o igual que 1000");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco el casillero");
                }
            }
        }

        private void txttipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txttipo.Text != "")
                {
                    dataSet11.Clear();
                    //dataSet11.ReadXml("d:\\ArchTipo.xml");
                    dataSet11.ReadXml(Application.StartupPath + "\\ArchTipo.xml");
                    System.Data.DataRow[] dato;
                    dato = dataSet11.tblTipoProducto.Select("nombreTipo='" + txttipo.Text + "'");

                    if (dato.Length > 0)
                    {
                        txtcod.Text = dato[0]["codigoTipo"].ToString()+"-";
                        cod_aux = txtcod.Text;
                        txtcod.Focus();
                        Limpiar.Enabled = true;
                    }
                    else
                    {
                        txtcod.Clear();
                        MessageBox.Show("Por favor ingrese un tipo de producto que exista");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco los texto");
                }
            }
        }

        private void txtdescrip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtPresentacion.Text != "")
                {

                    guardar.Focus();
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco la descripción del producto");
                }
            }
        }

        private void txtPresentacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtPresentacion.Text != "")
                {
                    if (txtPresentacion.Text == "Lata de aluminio" || txtPresentacion.Text == "Lata de hojalata" || txtPresentacion.Text == "Lata de chapa" || txtPresentacion.Text == "Botella de vidrio" || txtPresentacion.Text == "Botella de plástico" || txtPresentacion.Text == "Tarro" || txtPresentacion.Text == "Frasco" || txtPresentacion.Text == "Envase de pape")
                    {
                        txtpre.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Por favor escoja un tipo de presentación");
                        txtPresentacion.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco el tipo de presentación del producto");
                }
            }
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            txtcod.Clear();
            txtnom.Clear();
            txtPresentacion.Text = "";
            txtpre.Clear();
            txttipo.Text = "";
            txtdescrip.Clear();
            txtcod.Focus();
            Limpiar.Enabled = false;
        }

        private void txtcod_MouseHover(object sender, EventArgs e)
        {
            if (txttipo.Text != "")
            {
                dataSet11.Clear();
                //dataSet11.ReadXml("d:\\ArchTipo.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchTipo.xml");
                System.Data.DataRow[] dato;
                dato = dataSet11.tblTipoProducto.Select("nombreTipo='" + txttipo.Text + "'");

                if (dato.Length > 0)
                {
                    txtcod.Text = dato[0]["codigoTipo"].ToString() + "-";
                    cod_aux = txtcod.Text;
                    txtcod.Focus();
                    Limpiar.Enabled = true;
                }
                else
                {
                    txtcod.Clear();
                    MessageBox.Show("Por favor ingrese un tipo de producto que exista");
                }
            }
            else
            {
                MessageBox.Show("Por favor no deje en blanco los texto");
            }
        }
    }
}
