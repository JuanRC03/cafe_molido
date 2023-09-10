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
    public partial class FrmReporte5 : Form
    {
        public FrmReporte5()
        {
            InitializeComponent();
            //DataSet1.ReadXml("d:\\ArchFactura.xml");
            DataSet1.ReadXml(Application.StartupPath + "\\ArchFactura.xml");
        }

        private void FrmReporte5_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
