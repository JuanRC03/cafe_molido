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
    public partial class modificarCliente : Form
    {
        System.Data.DataRow[] dato;
        public Random ob = new Random();
        string correo;
        bool t = false;
        string cc;
        public modificarCliente()
        {
            InitializeComponent();
            dataSet11.Clear();
            txtCedula.MaxLength = 10;
            txtedad.MaxLength = 3;
        }

        private void modificarCliente_Load(object sender, EventArgs e)
        {
            
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "")
            {
                dataSet11.Clear();
                //dataSet11.ReadXml("d:\\ArchCliente.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchCliente.xml");

                dato = dataSet11.tblCliente.Select("cedula='" + txtCedula.Text + "'");

                if (dato.Length > 0)
                {
                    txtNombre.Text = dato[0]["nombre"].ToString();
                    
                    txtedad.Text = dato[0]["edad"].ToString();
                    genero.Text = dato[0]["genero"].ToString();
                    txtemail.Text = dato[0]["email"].ToString();
                    cc = txtemail.Text;
                    txtCidudad.Text = dato[0]["ciudad"].ToString();
                    groupBox2.Enabled = true;
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
                MessageBox.Show("Aún no ha ingresado la cédula del cliente a buscar");
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtedad.Focus();
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
                            mensaje.Subject = "Usted realizó una compra";
                            mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
                            mailBody += "<center><h2 style=background-color:#231C1D;color:#E8DDB5>" + "CAFÉ MOLINO " + "</h2></center>";
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

        private void guardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtedad.Text != "" && genero.Text != "" && txtemail.Text != "" && txtCidudad.Text != "")
            {
                if (cc != txtemail.Text)
                {
                    if (t == true)
                    {
                        dato[0]["nombre"] = txtNombre.Text;
                        dato[0]["edad"] = txtedad.Text;
                        dato[0]["genero"] = genero.Text;
                        dato[0]["email"] = txtemail.Text;
                        dato[0]["ciudad"] = txtCidudad.Text;
                        dato[0].AcceptChanges();
                        //dataSet11.WriteXml("d:\\ArchCliente.xml");
                        dataSet11.WriteXml(Application.StartupPath + "\\ArchCliente.xml");
                        dataSet11.Clear();
                        MessageBox.Show("Se ha modificado los datos del cliente correctamente");
                        txtNombre.Text = "";
                        txtedad.Text = "";
                        genero.Text = "";
                        txtemail.Text = "";
                        txtCidudad.Text = "";
                        label2.Visible = false;
                        groupBox2.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("El correo aun no ha sido confirmado");
                    }
                }
                else
                {
                    dato[0]["nombre"] = txtNombre.Text;
                    dato[0]["edad"] = txtedad.Text;
                    dato[0]["genero"] = genero.Text;
                    dato[0]["email"] = txtemail.Text;
                    dato[0]["ciudad"] = txtCidudad.Text;
                    dato[0].AcceptChanges();
                    //dataSet11.WriteXml("d:\\ArchCliente.xml");
                    dataSet11.WriteXml(Application.StartupPath + "\\ArchCliente.xml");
                    dataSet11.Clear();
                    MessageBox.Show("Se ha modificado los datos del cliente correctamente");
                    txtNombre.Text = "";
                    txtedad.Text = "";
                    genero.Text = "";
                    txtemail.Text = "";
                    txtCidudad.Text = "";
                    label2.Visible = false;
                    groupBox2.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Algunos datos no están completos");
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
                    MessageBox.Show("Por favor ingrese un número de cedula");
                }
            }
        }

        private void txtNombre_KeyPress_1(object sender, KeyPressEventArgs e)
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
                    MessageBox.Show("Por favor ingrese el genero del cliente");
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
            txtNombre.Text = "";
            txtedad.Text = "";
            genero.Text = "";
            txtemail.Text = "";
            txtCidudad.Text = "";
            groupBox2.Enabled = false;
            dataSet11.Clear();
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
            txtNombre.Text = "";
            txtedad.Text = "";
            genero.Text = "";
            txtemail.Text = "";
            txtCidudad.Text = "";
            groupBox2.Enabled = false;
            dataSet11.Clear();
        }
    }
}
