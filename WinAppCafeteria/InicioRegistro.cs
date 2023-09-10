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
    public partial class InicioRegistro : Form
    {
        public Random ob = new Random();
        string correo;
        bool t = false;
        bool temail = false;
        int cont = 0;
        string s;
        public InicioRegistro()
        {
            InitializeComponent();
            dataSet11.Clear();
            try
            {
                dataSet11.Clear();
                //dataSet11.ReadXml("d:\\ArchUsuarios.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchUsuarios.xml");
                for (int i = 0; i < dataSet11.tblUsuario.Rows.Count; i++)
                {
                    cont++;
                }
                if (cont != 0)
                {
                    login ol = new login();
                    ol.ShowDialog();
                }
                dataSet11.Clear();
            }
            catch
            {
                //dataSet11.WriteXml("d:\\ArchUsuarios.xml");
                dataSet11.WriteXml(Application.StartupPath + "\\ArchUsuarios.xml");
            }
            dataSet11.Clear();
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
                        try
                        {
                            ValidarCedula ov = new ValidarCedula();
                            texto = ov.validar(txtCedula.Text);
                            if (texto == "V")
                            {
                                txtNombre.Focus();
                            }
                            else
                            {
                                MessageBox.Show(texto);
                                txtCedula.Clear();
                            }
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("La cédula del cliente no está completa");
                    }
                }
                else
                {

                    MessageBox.Show("Por favor ingrese un número de cedula "+txtCedula.Text);
                }
            }
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

        private void iconButton2_Click(object sender, EventArgs e)
        {

            txtContrasenia.UseSystemPasswordChar = false;

        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            txtContrasenia.UseSystemPasswordChar = true;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            dataSet11.Clear();
            if (txtCedula.Text != "" && txtNombre.Text != "" && txtedad.Text != "" && genero.Text != "" && txtemail.Text != "" && txtCidudad.Text != "" && txtusuario.Text != "" && txtconfirContra.Text != "" && txtContrasenia.Text != "" && txtContrasenia.Text == txtconfirContra.Text)
            { 
                if (t == true)
                {

                    dataSet11.Clear();
                    //dataSet11.ReadXml("d:\\ArchUsuarios.xml");
                    dataSet11.ReadXml(Application.StartupPath + "\\ArchUsuarios.xml");
                    System.Data.DataRow[] dato;
                    dato = dataSet11.tblUsuario.Select("cedula='" + txtCedula.Text + "'");

                    if (dato.Length > 0)
                    {
                        MessageBox.Show("El usuario con cédula " + txtCedula.Text + " ya existe");
                        txtCedula.Clear();
                    }
                    else
                    {
                        dataSet11.Clear();
                        dato = dataSet11.tblUsuario.Select("usuario='" + txtusuario.Text + "'");
                        if (dato.Length > 0)
                        {
                            MessageBox.Show("El usuario con nombre " + txtusuario.Text + " ya existe");
                            txtusuario.Clear();
                        }
                        else
                        {
                            dataSet11.Clear();
                            //dataSet11.ReadXml("d:\\ArchUsuarios.xml");
                            dataSet11.ReadXml(Application.StartupPath + "\\ArchUsuarios.xml");
                            string ced = txtCedula.Text;
                            string nom = txtNombre.Text;
                            string ed = txtedad.Text;
                            string gen = genero.Text;
                            string email = txtemail.Text;
                            string dir = txtCidudad.Text;
                            string us = txtusuario.Text;
                            string con = txtContrasenia.Text;
                            object[] dato1 = new object[8];
                            dato1[0] = ced;
                            dato1[1] = nom;
                            dato1[2] = ed;
                            dato1[3] = gen;
                            dato1[4] = email;
                            dato1[5] = dir;
                            dato1[6] = us;
                            dato1[7] = con;
                            dataSet11.tblUsuario.Rows.Add(dato1);
                            //dataSet11.WriteXml("d:\\ArchUsuarios.xml");
                            dataSet11.WriteXml(Application.StartupPath + "\\ArchUsuarios.xml");
                            dataSet11.Clear();
                            txtCedula.Clear();
                            txtNombre.Clear();
                            txtedad.Text = "";
                            genero.Text = "";
                            txtemail.Text = "";
                            txtusuario.Clear();
                            txtContrasenia.Clear();
                            txtconfirContra.Clear();
                            txtCidudad.Clear();
                            label2.Visible = false;
                            t = false;
                            MessageBox.Show("Se ha ingresado correctamente los datos del usuario");
                            temail = false;
                            this.Visible = false;
                            login ol = new login();
                            ol.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El correo aún no ha sido verificado");
                } 
            }
            else
            {
                MessageBox.Show("Algunos datos no están completos");
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

        private void txtedad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

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
                            mensaje.Subject = "Registro en el sistema de la cafeteria Café Molino";
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
                                label2.Text = "Correo electrónico no confirmado";
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
                if (txtCidudad.Text == "")
                {
                    MessageBox.Show("Por favor ingrese la ciudad del cliente");
                }
                else
                {
                    txtusuario.Focus();
                }
                txtusuario.Text = (Regex.Replace(txtNombre.Text, @"\s", "")).ToLower() + "@cafemolino.com";
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
            dataSet11.Clear();
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
    }
}
