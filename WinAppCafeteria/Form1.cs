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
    public partial class Form1 : Form
    {
        public string [] codT = { "A001", "B001", "D001" };
        public string[] nombreT = { "Café", "Jugos", "Batidos" };
        public string[] descT = { "Bebidas que se obtiene a partir de los granos tostados y molidos de los frutos de la planta del café", "Sustancia líquida que se extrae de los vegetales o frutas, normalmente por presión", "Bebida elaborada a base de leche o helado, que puede llevar frutas, chocolate, turrón o también helado" };
        public Form1()
        {
            InitializeComponent();

            dataSet11.Clear();
            try
            {
               
                //dataSet11.ReadXml("d:\\ArchProductos.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchProductos.xml");
            }
            catch
            {
                //dataSet11.WriteXml("d:\\ArchProductos.xml");
                dataSet11.WriteXml(Application.StartupPath + "\\ArchProductos.xml");
            }
            dataSet11.Clear();
            try
            {
                //dataSet11.ReadXml("d:\\ArchTipo.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchTipo.xml");
            }
            catch
            {
                //dataSet11.WriteXml("d:\\ArchTipo.xml");
                dataSet11.WriteXml(Application.StartupPath + "\\ArchTipo.xml");
                for (int i = 0; i < 3; i++)
                {
                    dataSet11.Clear();
                    //dataSet11.ReadXml("d:\\ArchTipo.xml");
                    dataSet11.ReadXml(Application.StartupPath + "\\ArchTipo.xml");
                    object[] dato1 = new object[3];
                    dato1[0] = codT[i];
                    dato1[1] = nombreT[i];
                    dato1[2] = descT[i];
                    dataSet11.tblTipoProducto.Rows.Add(dato1);
                    //dataSet11.WriteXml("d:\\ArchTipo.xml");
                    dataSet11.WriteXml(Application.StartupPath + "\\ArchTipo.xml");
                    dataSet11.Clear();
                }
            }
            dataSet11.Clear();
            try
            {
                //dataSet11.ReadXml("d:\\ArchCliente.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchCliente.xml");
            }
            catch
            {
                //dataSet11.WriteXml("d:\\ArchCliente.xml");
                dataSet11.WriteXml(Application.StartupPath + "\\ArchCliente.xml");
            }
            dataSet11.Clear();
            try
            {
                //dataSet11.ReadXml("d:\\ArchFactura.xml");
                dataSet11.ReadXml(Application.StartupPath + "\\ArchFactura.xml");
            }
            catch
            {
                //dataSet11.WriteXml("d:\\ArchFactura.xml");
                dataSet11.WriteXml(Application.StartupPath + "\\ArchFactura.xml");
            }
            dataSet11.Clear();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void inicio_Click(object sender, EventArgs e)
        {
            //PictureBox1.Visible = false;
        }

        private void ingresar_Click(object sender, EventArgs e)
        {
            
            p1.Visible = false;
            p2.Visible = true;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            p7.Visible = false;
            pnlIngresar.Visible = true;
            pnlModificar.Visible = false;
            pnlBuscar.Visible = false;
            pnlEliminar.Visible = false;
            pnlReportes.Visible = false;
            pnlUsuario.Visible = false;


        }

        private void reportes_Click(object sender, EventArgs e)
        {
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = true;
            p7.Visible = false;
            pnlIngresar.Visible = false;
            pnlModificar.Visible = false;
            pnlBuscar.Visible = false;
            pnlEliminar.Visible = false;
            pnlUsuario.Visible = false;
            if (pnlReportes.Visible == true)
            {
                pnlReportes.Visible = false;
            }
            else
            {
                pnlReportes.Visible = true;
            }
        }

        private void inicio_Click_1(object sender, EventArgs e)
        {
            
            p1.Visible = true;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            p7.Visible = false;
            pnlIngresar.Visible = false;
            pnlModificar.Visible = false;
            pnlBuscar.Visible = false;
            pnlEliminar.Visible = false;
            pnlReportes.Visible = false;
            pnlUsuario.Visible = false ;

        }

        private void modificar_Click(object sender, EventArgs e)
        {
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = true;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            p7.Visible = false;
            pnlIngresar.Visible = false;
            pnlModificar.Visible = true;
            pnlBuscar.Visible = false;
            pnlEliminar.Visible = false;
            pnlReportes.Visible = false;
            pnlUsuario.Visible = false;

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = true;
            p5.Visible = false;
            p6.Visible = false;
            p7.Visible = false;
            pnlIngresar.Visible = false;
            pnlModificar.Visible = false;
            pnlBuscar.Visible = true;
            pnlEliminar.Visible = false;
            pnlReportes.Visible = false;
            pnlUsuario.Visible = false;

        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = true;
            p6.Visible = false;
            p7.Visible = false;
            pnlIngresar.Visible = false;
            pnlModificar.Visible = false;
            pnlBuscar.Visible = false;
            pnlEliminar.Visible = true;
            pnlReportes.Visible = false;
            pnlUsuario.Visible = false;

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        

        private void venta_Click(object sender, EventArgs e)
        {
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            p7.Visible = true;
            pnlIngresar.Visible = false;
            pnlModificar.Visible = false;
            pnlBuscar.Visible = false;
            pnlEliminar.Visible = false;
            pnlReportes.Visible = false;
            pnlUsuario.Visible = false;
            RegistrarBuscarCliente or = new RegistrarBuscarCliente();
            or.ShowDialog();
        }

        private void aP_Click(object sender, EventArgs e)
        {
            WinAppIngreso oi = new WinAppIngreso();
            oi.ShowDialog();
        }

        private void aT_Click(object sender, EventArgs e)
        {
            ingresarTipo ot = new ingresarTipo();
            ot.ShowDialog();
        }

        private void mP_Click(object sender, EventArgs e)
        {
            BuscarModificar om = new BuscarModificar();
            om.ShowDialog();

        }

        private void aC_Click(object sender, EventArgs e)
        {
            ingresoCliente oc = new ingresoCliente();
            oc.ShowDialog();
        }

        private void mT_Click(object sender, EventArgs e)
        {
            modificarTipo ot = new modificarTipo();
            ot.ShowDialog();
        }

        private void mC_Click(object sender, EventArgs e)
        {
            modificarCliente oc = new modificarCliente();
            oc.ShowDialog();
        }

        private void bP_Click(object sender, EventArgs e)
        {
            Buscar ob = new Buscar();
            ob.ShowDialog();
        }

        private void bT_Click(object sender, EventArgs e)
        {
            buscarTipo ot = new buscarTipo();
            ot.ShowDialog();
        }

        private void bC_Click(object sender, EventArgs e)
        {
            buscarCliente oc = new buscarCliente();
            oc.ShowDialog();
        }

        private void eP_Click(object sender, EventArgs e)
        {
            DuscarEliminar oe = new DuscarEliminar();
                oe.ShowDialog();
        }

        private void eT_Click(object sender, EventArgs e)
        {
            eliminarTipo ot = new eliminarTipo();
            ot.ShowDialog();

        }

        private void eC_Click(object sender, EventArgs e)
        {
            EliminarCliente oc = new EliminarCliente();
            oc.ShowDialog();
        }

        private void usuario_Click(object sender, EventArgs e)
        {
            pnlIngresar.Visible = false;
            pnlModificar.Visible = false;
            pnlBuscar.Visible = false;
            pnlEliminar.Visible = false;
            pnlReportes.Visible = false;
            pnlUsuario.Visible = true;
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            p7.Visible = false;
        }

        private void breg_Click(object sender, EventArgs e)
        {
            IngresarUsuario ou = new IngresarUsuario();
            ou.ShowDialog();
            pnlUsuario.Visible = false;

        }

        private void bbus_Click(object sender, EventArgs e)
        {
            BusquedaUsuario ou = new BusquedaUsuario();
            ou.ShowDialog();
        }

        private void bmod_Click(object sender, EventArgs e)
        {
            ModificarUsuario ou = new ModificarUsuario();
            ou.ShowDialog();
        }

        private void rep1_Click(object sender, EventArgs e)
        {
            FrmReporte1 objRep = new FrmReporte1();
            objRep.ShowDialog();
        }

        private void rep2_Click(object sender, EventArgs e)
        {
            FrmReporte2 objRep = new FrmReporte2();
            objRep.ShowDialog();
        }

        private void re3_Click(object sender, EventArgs e)
        {
            FrmReporte3 objRep = new FrmReporte3();
            objRep.ShowDialog();
        }

        private void rep4_Click(object sender, EventArgs e)
        {
            FrmReporte4 objRep = new FrmReporte4();
            objRep.ShowDialog();
        }

        private void rep5_Click(object sender, EventArgs e)
        {
            FrmReporte6 objRep = new FrmReporte6();
            objRep.ShowDialog();
        }

        private void rep6_Click(object sender, EventArgs e)
        {
            FrmReporte5 objRep = new FrmReporte5();
            objRep.ShowDialog();
        }

        private void beli_Click(object sender, EventArgs e)
        {
            EliminarUsuario oe = new EliminarUsuario();
            oe.ShowDialog();
        }
    }
}
