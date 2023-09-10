using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppCafeteria
{
    public partial class IngresarVentaCliente : Form
    {
        public Random ob = new Random();
        string correo;
        bool t = false;
        public IngresarVentaCliente()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                            dataSet11.Clear();
                            dataSet11.ReadXml("d:\\ArchCliente.xml");
                            System.Data.DataRow[] dato;
                            dato = dataSet11.tblCliente.Select("cedula='" + txtCedula.Text + "'");

                            if (dato.Length > 0)
                            {
                                MessageBox.Show("El cliente con cédula " + txtCedula.Text + " ya existe");
                                txtCedula.Clear();
                            }
                            else
                            {
                                txtNombre.Focus();
                                Limpiar.Enabled = true;
                            }

                        }
                        else
                        {
                            MessageBox.Show(texto);
                            txtCedula.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cédula del cliente no esta completa");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un número de cédula");
                }
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtNombre.Text != "")
                {
                    txtedad.Focus();
                }
                else
                {
                    MessageBox.Show("Por favor ingrese el nombre del cliente");
                }
            }
        }

        private void txtedad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("En este campo, se coloca la edad");
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtedad.Text == "")
                {
                    MessageBox.Show("Por favor ingrese la edad del cliente");
                }
                else
                {
                    int x = int.Parse(txtedad.Text);
                    if (x >= 10 && x <= 100)
                    {
                        genero.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese una edad en rango de 10 a 100");
                        txtedad.Text = "";
                    }
                }

            }
        }

        private void genero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (genero.Text != "")
                {
                    if (genero.Text == "Masculino" || genero.Text == "Femenino")
                    {
                        txtemail.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Por favor escoja un género válido");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese el género del cliente");
                }
            }
        }

        private void txtemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtemail.Text == "")
                    txtemail.Focus();
                else
                {
                    string mailBody = "";
                    correo = txtemail.Text;
                    CCorreo objCor = new CCorreo();
                    if (objCor.validar(correo))
                    {
                        try
                        {
                            int random = ob.Next(1000, 10000);
                            MailMessage mensaje = new MailMessage();
                            mensaje.To.Add(correo);
                            mensaje.Subject = "Registro en el sistema de la cafeteria Café Molido";
                            mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
                            mailBody += "<center><h2 style=background-color:#231C1D;color:#E8DDB5>" + "CAFÉ MOLIDO " + "</h2></center>";
                            mailBody += "<center><h4 style=background-color:#E8DDB5;color:#231C1D>" + "Código de confirmación" + "</h4>";
                            mailBody += "<center><p style=color:#231C1D>" + "Su código de confirmación es:" + "</p>";
                            mailBody += "<center><h4 style=color:#231C1D>" + random.ToString() + "</h4>";
                            mensaje.Body = mailBody;
                            mensaje.BodyEncoding = System.Text.Encoding.UTF8;
                            mensaje.IsBodyHtml = true;
                            mensaje.From = new MailAddress("cafemolinocafeteria@gmail.com");
                            SmtpClient cliente = new SmtpClient();
                            cliente.Credentials = new NetworkCredential("cafemolinocafeteria@gmail.com", "123456 MOLINO CAFE.");
                            cliente.Port = 587;
                            cliente.EnableSsl = true;
                            cliente.Host = "smtp.gmail.com";
                            cliente.Send(mensaje);
                            ConfirmacionCorreo oc = new ConfirmacionCorreo(random.ToString());
                            oc.ShowDialog();
                            if (oc.DialogResult == System.Windows.Forms.DialogResult.OK)
                            {
                                label2.ForeColor = Color.Green;
                                label2.Text = "Correo electrónico válido";
                                t = true;
                                txtCidudad.Focus();
                            }
                            else
                            {
                                label2.ForeColor = Color.Red;
                                label2.Text = "Correo electrónico no fue confirmado";
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error al enviar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                    }
                    else
                    {
                        label2.ForeColor = Color.Red;
                        label2.Text = "Correo electrónico no válido";
                        MessageBox.Show("Ingrese un correo electrónico válido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtCidudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCidudad.Text == "")
                {
                    MessageBox.Show("Por favor ingrese la ciudad del cliente");
                }
                else
                {
                    guardar.Focus();
                }
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            txtCedula.Clear();
            txtCidudad.Clear();
            genero.Text = "";
            txtedad.Text = "";
            txtemail.Clear();
            txtNombre.Clear();
            Limpiar.Enabled = false;
            txtCedula.Focus();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            string s;
            if (txtCedula.Text != "" && txtNombre.Text != "" && txtedad.Text != "" && genero.Text != "" && txtemail.Text != "" && txtCidudad.Text != "")
            {
                if (t == true)
                {

                    dataSet11.Clear();
                    //dataSet11.ReadXml("d:\\ArchCliente.xml");
                    dataSet11.ReadXml(Application.StartupPath + "\\ArchCliente.xml");
                    System.Data.DataRow[] dato;
                    dato = dataSet11.tblCliente.Select("cedula='" + txtCedula.Text + "'");

                    if (dato.Length > 0)
                    {
                        MessageBox.Show("El cliente con cédula " + txtCedula.Text + " ya existe");
                        txtCedula.Clear();
                    }
                    else
                    {
                        dataSet11.Clear();
                        //dataSet11.ReadXml("d:\\ArchCliente.xml");
                        dataSet11.ReadXml(Application.StartupPath + "\\ArchCliente.xml");
                        string ced = txtCedula.Text;
                        s = ced;
                        string nom = txtNombre.Text;
                        string ed = txtedad.Text;
                        string gen = genero.Text;
                        string email = txtemail.Text;
                        string dir = txtCidudad.Text;
                        object[] dato1 = new object[6];
                        dato1[0] = ced;
                        dato1[1] = nom;
                        dato1[2] = ed;
                        dato1[3] = gen;
                        dato1[4] = email;
                        dato1[5] = dir;
                        dataSet11.tblCliente.Rows.Add(dato1);
                        //dataSet11.WriteXml("d:\\ArchCliente.xml");
                        dataSet11.WriteXml(Application.StartupPath + "\\ArchCliente.xml");
                        dataSet11.Clear();
                        txtCedula.Clear();
                        txtNombre.Clear();
                        txtedad.Text = "";
                        genero.Text = "";
                        txtemail.Text = "";
                        Limpiar.Enabled = false;
                        txtCidudad.Clear();
                        label2.Visible = false;
                        MessageBox.Show("Se ha ingresado correctamente los datos del cliente");

                        VentaProductos ov = new VentaProductos(s);
                        ov.ShowDialog();
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("El correo aun no ha sido verificado");
                }

            }
            else
            {
                MessageBox.Show("Algunos datos no están completos");
            }
        }
    }
}
