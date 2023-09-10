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
    public partial class login : Form
    {
        string cc;
        public login()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            Form1 of = new Form1();

            of.ShowDialog();
            this.Close();
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
                        cc = dato[0]["contrasenia"].ToString();
                        txtContrasenia.Focus();

                    }
                    else
                    {
                        MessageBox.Show("El usuario con nombre " + txtusuario.Text + " no existe");
                        txtusuario.Clear();
                    }

                }
            }
        }

        private void txtContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtusuario.Text == "")
                {
                    MessageBox.Show("Por favor ingrese su contraseña");
                }
                else
                {
                    if (cc == txtContrasenia.Text)
                    {
                        guardar.Enabled = true;
                        guardar.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta");
                        txtContrasenia.Clear();
                    }

                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            txtContrasenia.UseSystemPasswordChar = false;
        }

        private void iconButton2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            txtContrasenia.UseSystemPasswordChar = true;
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
