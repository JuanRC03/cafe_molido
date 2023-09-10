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
    public partial class ConfirmacionCorreo : Form
    {
        string s;
        public ConfirmacionCorreo(string c)
        {
            InitializeComponent();
            s = c;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Por favor no deje en blanco el recuadro");
                }
                else
                {
                    if (s == textBox1.Text)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El código de confirmación no coincide. Por favor intente de nuevo");
                        textBox1.Clear();
                    }
                }
            }
        }

        private void ConfirmacionCorreo_Load(object sender, EventArgs e)
        {

        }
    }
}
