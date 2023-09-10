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
    public partial class BusquedaUsuario : Form
    {
        string codigo;
        public BusquedaUsuario()
        {
            InitializeComponent();
            dataSet11.Clear();
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
                        codigo=dato[0]["contrasenia"].ToString();
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
            if(contra1.Text!="" && usua1.Text != "")
            {
                dataSet11.Clear();
                //dataSet11.ReadXml("d:\\ArchUsuarios.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchUsuarios.xml");
                System.Data.DataRow[] dato;
                dato = dataSet11.tblUsuario.Select("usuario='" + usua1.Text + "'");

                if (dato.Length > 0)
                {
                    if (contra1.Text == codigo)
                    {
                        lc.Text = dato[0]["cedula"].ToString();
                        ln.Text = dato[0]["nombre"].ToString();
                        le.Text = dato[0]["edad"].ToString();
                        lg.Text = dato[0]["genero"].ToString();
                        lem.Text = dato[0]["email"].ToString();
                        lciu.Text = dato[0]["ciudad"].ToString();
                        lu.Text = dato[0]["usuario"].ToString();
                        contra1.Clear();
                        usua1.Clear();
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            contra1.UseSystemPasswordChar = false;

        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            contra1.UseSystemPasswordChar = true;

        }

        private void usua1_MouseClick(object sender, MouseEventArgs e)
        {
            lc.Text = "";
            ln.Text = "";
            le.Text = "";
            lg.Text = "";
            lem.Text = "";
            lciu.Text = "";
            lu.Text = "";

        }

        private void usua1_TextChanged(object sender, EventArgs e)
        {

        }

        private void contra1_MouseClick(object sender, MouseEventArgs e)
        {
            lc.Text = "";
            ln.Text = "";
            le.Text = "";
            lg.Text = "";
            lem.Text = "";
            lciu.Text = "";
            lu.Text = "";
        }
    }
}
