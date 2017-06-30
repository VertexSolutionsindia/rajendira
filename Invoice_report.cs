using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Invoice_report : Form
    {
        public Invoice_report()
        {
            InitializeComponent();
        }

        private void Invoice_report_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            int value = 1;
            SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name1 = new SqlCommand("select * from currentfinancialyear WHERE no =@no", con11);
            check_User_Name1.Parameters.AddWithValue("@no", value);
            con11.Open();
            SqlDataReader reader1 = check_User_Name1.ExecuteReader();
            if (reader1.Read())
            {
                string financial = reader1["financial_year"].ToString();


                this.KeyPreview = true;
                string name = "";
                if (frmsalesinvoice.SETVALUE != "")
                {
                    name = frmsalesinvoice.SETVALUE;
                }
                else if (invoice_report_details.name != "")
                {
                    name = invoice_report_details.name;
                }


                textBox1.Text = name.ToString();
                CrystalReport1 report = new CrystalReport1();
                DataSet1TableAdapters.DataTable1TableAdapter ta = new DataSet1TableAdapters.DataTable1TableAdapter();
                DataSet1.DataTable1DataTable table = ta.GetData(Convert.ToInt32(name), financial, financial);

                report.SetDataSource(table.DefaultView);
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
           
        }

        private void Invoice_report_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmsalesinvoice.SETVALUE = "";
            invoice_report_details.name = "";
        }

        private void Invoice_report_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmsalesinvoice.SETVALUE = "";
            invoice_report_details.name = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = 1;
            SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name1 = new SqlCommand("select * from currentfinancialyear WHERE no =@no", con11);
            check_User_Name1.Parameters.AddWithValue("@no", value);
            con11.Open();
            SqlDataReader reader1 = check_User_Name1.ExecuteReader();
            if (reader1.Read())
            {
                string financial = reader1["financial_year"].ToString();


                this.KeyPreview = true;
                string name = "";
                if (frmsalesinvoice.SETVALUE != "")
                {
                    name = frmsalesinvoice.SETVALUE;
                }
                else if (invoice_report_details.name != "")
                {
                    name = invoice_report_details.name;
                }


                textBox1.Text = name.ToString();
                CrystalReport1 report = new CrystalReport1();
                DataSet1TableAdapters.DataTable1TableAdapter ta = new DataSet1TableAdapters.DataTable1TableAdapter();
                DataSet1.DataTable1DataTable table = ta.GetData(Convert.ToInt32(name), financial, financial);

                report.SetDataSource(table.DefaultView);
                System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                report.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;


                //Start the printing process.  Provide details of the print job
                //using the arguments.
                report.PrintToPrinter(1, true, 0, 0);
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ExportReport();
        }

        private void Invoice_report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
            if (e.KeyCode == Keys.E)
            {
                button2.PerformClick();
            }
            if (e.KeyCode == Keys.C)
            {
                button3.PerformClick();
            }
        }
    }
}
