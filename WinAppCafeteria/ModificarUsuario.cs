using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppCafeteria
{
    public partial class ModificarUsuario : Form
    {
        string s;
        public Random ob = new Random();
        string correo;
        bool t = false;
        bool temail = false;
        System.Data.DataRow[] dato;
        string codigo;
        public ModificarUsuario()
        {
            InitializeComponent();
            dataSet11.Clear();
            txtedad.MaxLength = 3;
        }

        private void usua1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (usua1.Text == "")
                {
                    MessageBox.Show("Por favor no deje en blanco el nombre del usuario");
                }
                else
                {
                    dataSet11.Clear();
                    //dataSet11.ReadXml("d:\\ArchUsuarios.xml");
                    dataSet11.ReadXml(Application.StartupPath + "\\ArchUsuarios.xml");
                    System.Data.DataRow[] dato;
                    dato = dataSet11.tblUsuario.Select("usuario='" + usua1.Text + "'");

                    if (dato.Length > 0)
                    {
                        codigo = dato[0]["contrasenia"].ToString();
                        contra1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No existe el usuario");
                        usua1.Clear();
                    }

                }
            }
        }

        private void contra1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (contra1.Text == "")
                {
                    MessageBox.Show("Por favor no deje en blanco el nombre del usuario");
                }
                else
                {
                    if (codigo == contra1.Text)
                    {
                        buscar.Focus();
                    }
                    else
                    {
                        MessageBox.Show("La contraseña ingresada no es correcta");
                        contra1.Clear();
                    }

                }
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (contra1.Text != "" && usua1.Text != "")
            {
                dataSet11.Clear();
                //dataSet11.ReadXml("d:\\ArchUsuarios.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchUsuarios.xml");
                dato = dataSet11.tblUsuario.Select("usuario='" + usua1.Text + "'");

                if (dato.Length > 0)
                {
                    if (contra1.Text == dato[0]["contrasenia"].ToString())
                    {
                        txtNombre.Text = dato[0]["nombre"].ToString();
                        txtedad.Text = dato[0]["edad"].ToString();
                        genero.Text = dato[0]["genero"].ToString();
                        txtemail.Text = dato[0]["email"].ToString();
                        txtCidudad.Text = dato[0]["ciudad"].ToString();
                        txtusuario.Text = dato[0]["usuario"].ToString();
                        txtContrasenia.Text = dato[0]["contrasenia"].ToString();
                        groupBox1.Enabled = true;
                        contra1.Clear();
                        usua1.Clear();
                        txtNombre.Focus();
                    }
                    else
                    {
                        MessageBox.Show("La contraseña es incorrecta");
                        contra1.Clear();

                    }
                }
                else
                {

                    MessageBox.Show("El usuario no existe");
                    usua1.Clear();
                }
            }
            else
            {
                MessageBox.Show("Ingrese todos los datos para realizar la búsqueda");
            }
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtedad.Text != "" && genero.Text != "" && txtemail.Text != "" && txtCidudad.Text != "" && txtusuario.Text!="" && txtContrasenia.Text!="" && txtconfirContra.Text!="")
            {
                dato[0]["nombre"] = txtNombre.Text;
                dato[0]["edad"] = txtedad.Text;
                dato[0]["genero"] = genero.Text;
                dato[0]["email"] = txtemail.Text;
                dato[0]["ciudad"] = txtCidudad.Text;
                dato[0]["usuario"] = txtusuario.Text;
                dato[0]["contrasenia"] = txtContrasenia.Text;
                dato[0].AcceptChanges();
                //dataSet11.WriteXml("d:\\ArchUsuarios.xml");
                dataSet11.WriteXml(Application.StartupPath + "\\ArchUsuarios.xml");
                dataSet11.Clear();
                MessageBox.Show("Se ha modificado los datos del cliente correctamente");
                txtNombre.Text = "";
                txtedad.Text = "";
                genero.Text = "";
                txtemail.Text = "";
                txtCidudad.Text = "";
                txtusuario.Clear();
                txtconfirContra.Clear();
                txtconfirContra.Clear();
                label2.Visible = false;
                groupBox1.Enabled = false;

            }
            else
            {
                MessageBox.Show("Algunos datos no están completos");
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            contra1.UseSystemPasswordChar = false;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            contra1.UseSystemPasswordChar = true;
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtedad.Text="";
            genero.Text="";
            txtemail.Clear();
            txtCidudad.Clear();
            txtusuario.Clear();
            txtContrasenia.Clear();
            txtconfirContra.Clear();
            groupBox1.Enabled = false;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            txtContrasenia.UseSystemPasswordChar = false;
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            txtContrasenia.UseSystemPasswordChar = true;
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
                    MessageBox.Show("Por favor ingrese el nombre del usuario");
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
                                label2.Visible = true;
                                txtCidudad.Focus();
                            }
                            else
                            {
                                label2.Visible = true;
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
                        label2.Visible = true;
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
                if (txtCidudad.Text != "")
                {
                    txtusuario.Focus();
                }
                else
                {
                    MessageBox.Show("Por favor no deje en blanco la ciudad");
                }
                txtusuario.Text = (Regex.Replace(txtNombre.Text, @"\s", "")).ToLower() + "@cafemolino.com";
            }
        }

        private void txtContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtusuario.Text == "")
                {
                    MessageBox.Show("Por favor no deje en blanco la contraseña");
                }
                else
                {
                    s = txtContrasenia.Text;
                    txtconfirContra.Focus();
                    txtContrasenia.UseSystemPasswordChar = true;
                }
            }
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtusuario.Text == "")
                {
                    MessageBox.Show("Por favor no deje en blanco el nombre del usuario");
                }
                else
                {
                    dataSet11.Clear();
                    //dataSet11.ReadXml("d:\\ArchUsuarios.xml");
                    dataSet11.ReadXml(Application.StartupPath + "\\ArchUsuarios.xml");
                    System.Data.DataRow[] dato;
                    dato = dataSet11.tblUsuario.Select("usuario='" + txtusuario.Text + "'");

                    if (dato.Length > 0)
                    {
                        MessageBox.Show("El usuario con nombre " + txtusuario.Text + " ya existe");
                        txtusuario.Clear();
                    }
                    else
                    {
                        txtContrasenia.Focus();
                    }

                }
            }
        }

        private void txtconfirContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtusuario.Text == "")
                {
                    MessageBox.Show("Por favor no deje en blanco la confirmación de la contraseña");
                }
                else
                {
                    if (s == txtconfirContra.Text)
                    {
                        guardar.Focus();
                    }
                    else
                    {
                        if (txtContrasenia.Text == txtconfirContra.Text)
                        {
                            guardar.Focus();
                        }
                        else
                        {
                            MessageBox.Show("La confirmación de la contraseña no coinside");
                            txtconfirContra.Clear();

                        }

                    }
                }
            }
        }

        private void usua1_MouseClick(object sender, MouseEventArgs e)
        {
            txtNombre.Clear();
            txtedad.Text = "";
            genero.Text = "";
            txtemail.Clear();
            txtCidudad.Clear();
            txtusuario.Clear();
            txtContrasenia.Clear();
            txtconfirContra.Clear();
            groupBox1.Enabled = false;
        }

        private void contra1_MouseClick(object sender, MouseEventArgs e)
        {
            txtNombre.Clear();
            txtedad.Text = "";
            genero.Text = "";
            txtemail.Clear();
            txtCidudad.Clear();
            txtusuario.Clear();
            txtContrasenia.Clear();
            txtconfirContra.Clear();
            groupBox1.Enabled = false;
        }

        private void txtusuario_MouseHover(object sender, EventArgs e)
        {
            txtusuario.Text = (Regex.Replace(txtNombre.Text, @"\s", "")).ToLower() + "@cafemolino.com";
        }
    }
}
