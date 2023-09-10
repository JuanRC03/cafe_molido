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
    public partial class FrmReporte1 : Form
    {
        public FrmReporte1()
        {
            InitializeComponent();
            //dataSet11.ReadXml("d:\\ArchCliente.xml");
            dataSet11.ReadXml(Application.StartupPath + "\\ArchCliente.xml");
        }

        private void FrmReporte1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
