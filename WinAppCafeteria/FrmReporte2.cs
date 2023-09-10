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
    public partial class FrmReporte2 : Form
    {
        public FrmReporte2()
        {
            InitializeComponent();
            //dataSet11.ReadXml("d:\\ArchTipo.xml");
            dataSet11.ReadXml(Application.StartupPath + "\\ArchTipo.xml");
        }

        private void FrmReporte2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
