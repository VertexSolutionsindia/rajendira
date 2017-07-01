using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1
{
    public partial class Sales_report : Form
    {
        public Sales_report()
        {
            InitializeComponent();
        }

        private void Sales_report_Load(object sender, EventArgs e)
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
                if (Sales_invoice.SETVALUE!= "")
                {
                    name = Sales_invoice.SETVALUE;
                }
                else if (sales_details_view.name!= "")
                {
                    name = sales_details_view.name;
                }


                textBox1.Text = name.ToString();
                CrystalReport6 report = new CrystalReport6();
              

                DataSet4TableAdapters.DataTable1TableAdapter ta = new DataSet4TableAdapters.DataTable1TableAdapter();
                DataSet4.DataTable1DataTable table = ta.GetData(Convert.ToInt32(name));
                report.SetDataSource(table.DefaultView);
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ExportReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrystalReport1 report = new CrystalReport1();
            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
            report.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;


            //Start the printing process.  Provide details of the print job
            //using the arguments.
            report.PrintToPrinter(1, true, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
