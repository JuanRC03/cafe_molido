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
    public partial class Cantidad : Form
    {
        public Cantidad()
        {
            InitializeComponent();
        }

        public int retornarNumero()
        {
            int x = int.Parse(textBox1.Text);
            return x;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("En este campo, se coloca la cantidad");
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Por favor no deje en blanco el recuadro");
                }
                else
                {
                    int x = int.Parse(textBox1.Text);
                    if (x > 0 && x <= 100)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un número en el rango de 1 a 100");
                        textBox1.Clear();
                    }
                }
            }
        }

        private void Cantidad_Load(object sender, EventArgs e)
        {

        }
    }
}
