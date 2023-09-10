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
    public partial class FrmReporte4 : Form
    {
        public FrmReporte4()
        {
            InitializeComponent();
            //DataSet1.ReadXml("d:\\ArchUsuarios.xml");
            DataSet1.ReadXml(Application.StartupPath + "\\ArchUsuarios.xml");
        }

        private void FrmReporte4_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
