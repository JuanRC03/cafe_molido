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
    public partial class RegistrarBuscarCliente : Form
    {
        public RegistrarBuscarCliente()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ingresar_Click(object sender, EventArgs e)
        {
            IngresarVentaCliente oi = new IngresarVentaCliente();
            oi.ShowDialog();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            BuscarVenta ob = new BuscarVenta();
            ob.ShowDialog();
        }
    }
}
