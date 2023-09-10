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
    public partial class BuscarModificar : Form
    {
        public string cod_aux,aux2;
        System.Data.DataRow[] dato;

        public BuscarModificar()
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

        private void BuscarModificar_Load(object sender, EventArgs e)
        {
            
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            dataSet12.Clear();
            //dataSet12.ReadXml("d:\\ArchTipo.xml");
            dataSet12.ReadXml(Application.StartupPath + "\\ArchTipo.xml");
            System.Data.DataRow[] dato1;
            dato1 = dataSet12.tblTipoProducto.Select("nombreTipo='" + txttipo.Text + "'");
            if (dato1.Length > 0)
            {
                cod_aux = dato1[0]["codigoTipo"].ToString()+"-";
                clVerifiacarCodigoProducto ov = new clVerifiacarCodigoProducto(txtcod1.Text, cod_aux);

                if (ov.validar() == true)
                {
                    float x = float.Parse(txtpre.Text);
                    if (x > 0 && x <= 1000)
                    {
                        if (txtcod1.Text != "" && txtnom.Text != "" && txtpre.Text != "" && txttipo.Text != "" && txtdescrip.Text != "" && txtPresentacion.Text != "")
                        {
                            dato[0]["codigoProducto"] = txtcod1.Text;
                            dato[0]["nombreProducto"] = txtnom.Text;
                            dato[0]["tipoProducto"] = txttipo.Text;
                            dato[0]["presentacionProducto"] = txtPresentacion.Text;
                            dato[0]["precioProducto"] = txtpre.Text;
                            dato[0]["DescripcionProducto"] = txtdescrip.Text;
                            dato[0].AcceptChanges();
                            //dataSet11.WriteXml("d:\\ArchProductos.xml");
                            dataSet11.WriteXml(Application.StartupPath + "\\ArchProductos.xml");
                            dataSet11.Clear();
                            MessageBox.Show("Se ha modificado los datos del producto correctamente");
                            txtnom.Clear();
                            txtdescrip.Clear();
                            txtpre.Clear();
                            txtcod1.Clear();
                            txttipo.Text = "";
                            txtPresentacion.Text = "";
                            groupBox2.Enabled = false;
                            txtcod1.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Algunos datos no están completos");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un precio mayor que 0 y menor o igual que 1000");
                    }
                }
                else
                {
                    MessageBox.Show("Se ha modificado el codigo ya que los "+txttipo.Text+" empiezan con el código " + cod_aux);
                    IdenitificadorTIpoProducto oi = new IdenitificadorTIpoProducto(txtcod1.Text, cod_aux);
                    txtcod1.Text = oi.retornarIdentificador();
                }
            }
            else
            {
                txtcod.Clear();
                MessageBox.Show("Por favor ingrese un tipo de producto que exista");
            }   
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
                        txtcod1.Text = dato[0]["codigoProducto"].ToString();
                        txtnom.Text = dato[0]["nombreProducto"].ToString();
                        txttipo.Text = dato[0]["tipoProducto"].ToString();
                        txtPresentacion.Text = dato[0]["presentacionProducto"].ToString();
                        txtpre.Text = dato[0]["precioProducto"].ToString();
                        txtdescrip.Text = dato[0]["DescripcionProducto"].ToString();
                        txtcod.Clear();
                        groupBox2.Enabled = true;
                        txttipo.Focus();
                        
                    }
                    else
                    {
                        txtcod.Clear();
                        MessageBox.Show("El producto no existe");
                    }
                }
                else
                {
                    MessageBox.Show("El código no está completo. Ejemplo: A001-0001");
                }  
            }
            else
            {
                MessageBox.Show("Aún no ha ingresado el código de producto a buscar");
            }


        }

        private void txtnom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtnom.Text != "")
                {
                    txtpre.Focus();
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco el nombre");
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
                        txttipo.Focus();
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
                    dataSet12.Clear();
                    //dataSet12.ReadXml("d:\\ArchTipo.xml");
                    dataSet12.ReadXml(Application.StartupPath + "\\ArchTipo.xml");
                    System.Data.DataRow[] dato;
                    aux2 = txtcod.Text;
                    dato = dataSet12.tblTipoProducto.Select("nombreTipo='" + txttipo.Text + "'");

                    if (dato.Length > 0)
                    {
                        cod_aux = dato[0]["codigoTipo"].ToString();
                        IdenitificadorTIpoProducto oi = new IdenitificadorTIpoProducto(txtcod1.Text, cod_aux);
                        txtcod1.Text = oi.retornarIdentificador();
                        txtcod1.Focus();
                    }
                    else
                    {
                        txtcod.Clear();
                        MessageBox.Show("Por favor ingrese un tipo de producto que exista");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco el texto");
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtcod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtcod.Text == "")
                {
                    MessageBox.Show("Por favor ingrese un códido de producto para buscar");
                }
                else
                {
                    if (txtcod.Text.Length == 9)
                    {
                        buscar.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El código no está completo. Ejemplo: A001-0001");
                    }
                }
            }
        }

        private void txtcod1_KeyPress(object sender, KeyPressEventArgs e)
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
                        clVerifiacarCodigoProducto ov = new clVerifiacarCodigoProducto(txtcod.Text, cod_aux);

                        if (ov.validar() == true)
                        {
                            txtnom.Focus();
                        }
                        else
                        {
                            MessageBox.Show("El código de producto no es válido ya que debe iniciar con " + cod_aux);
                            txtcod1.Text = cod_aux;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco el casillero");
                }

            }
        }

        private void txtPresentacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtPresentacion.Text != "")
                {
                    if(txtPresentacion.Text=="Lata de aluminio"|| txtPresentacion.Text == "Lata de hojalata"|| txtPresentacion.Text == "Lata de chapa"|| txtPresentacion.Text == "Botella de vidrio"|| txtPresentacion.Text == "Botella de plástico"|| txtPresentacion.Text == "Tarro"|| txtPresentacion.Text == "Frasco" ||txtPresentacion.Text == "Envase de pape")
                    {
                        txtdescrip.Focus();
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

        private void txtdescrip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtdescrip.Text != "")
                {
                    guardar.Focus();
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco la descripción");
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

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtcod_MouseClick(object sender, MouseEventArgs e)
        {
            txtnom.Clear();
            txtcod1.Clear();
            txttipo.Text = "";
            txtPresentacion.Text = "";
            txtpre.Clear();
            txtdescrip.Clear();
            txtcod.Focus();
            groupBox2.Enabled = false;
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            txtnom.Clear();
            txttipo.Text = "";
            txtPresentacion.Text = "";
            txtpre.Clear();
            txtdescrip.Clear();
            txtcod1.Clear();
            txtcod.Focus();
            groupBox2.Enabled = false;
            MessageBox.Show("No se ha modificado los datos");
        }
    }
}
