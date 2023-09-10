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
    public partial class FrmReporte3 : Form
    {
        public FrmReporte3()
        {
            InitializeComponent();
            //dataSet11.ReadXml("d:\\ArchProductos.xml");
            dataSet11.ReadXml(Application.StartupPath + "\\ArchProductos.xml");
        }

        private void FrmReporte3_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
