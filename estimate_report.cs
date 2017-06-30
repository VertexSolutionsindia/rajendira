using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class estimate_report : Form
    {
        public estimate_report()
        {
            InitializeComponent();
        }

        private void estimate_report_Load(object sender, EventArgs e)
        {
            string name = frmsalesinvoice.SETVALUE;
            textBox1.Text = name.ToString();
            CrystalReport2 report = new CrystalReport2();
            DataSet1TableAdapters.DataTable1TableAdapter ta = new DataSet1TableAdapters.DataTable1TableAdapter();
            DataSet1.DataTable1DataTable table = ta.GetData(name);

            report.SetDataSource(table.DefaultView);
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
