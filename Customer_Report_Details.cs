using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Customer_Report_Details : Form
    {
        public Customer_Report_Details()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

      

        private void Customer_Report_Details_Load(object sender, EventArgs e)
        {
            getcustomerdetails();
            this.KeyPreview = true;
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            textBox1.AutoCompleteCustomSource = DataCollection;

            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection1 = new AutoCompleteStringCollection();
            getData1(DataCollection1);
            textBox2.AutoCompleteCustomSource = DataCollection1;

        }
        private void getData(AutoCompleteStringCollection dataCollection)
        {

            try
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                connetionString = System.Configuration.ConfigurationSettings.AppSettings["connection"];
                string sql = "SELECT DISTINCT [company_name] FROM [customer_details]";
                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    adapter.Dispose();
                    command.Dispose();
                    connection.Close();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataCollection.Add(row[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not open connection ! ");
                }
            }
            catch (Exception rt)
            { }
        }
        private void getData1(AutoCompleteStringCollection dataCollection)
        {

            try
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                connetionString = System.Configuration.ConfigurationSettings.AppSettings["connection"];
                string sql = "SELECT DISTINCT [Mobile_no] FROM [customer_details]";
                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    adapter.Dispose();
                    command.Dispose();
                    connection.Close();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataCollection.Add(row[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not open connection ! ");
                }
            }
            catch (Exception rt)
            { }
        }
        private void getcustomerdetails()
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT No,company_name,company_address,contact_person,location,Mobile_no,Email,tin_no,cst_no,Remarks,invoice_price_list,estimate_Price_list from customer_details"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "No";
                            dataGridView1.Columns[0].HeaderText = "No";
                            dataGridView1.Columns[0].DataPropertyName = "No";


                            dataGridView1.Columns[1].Name = "Company Name";
                            dataGridView1.Columns[1].HeaderText = "Company Name";
                            dataGridView1.Columns[1].DataPropertyName = "company_name";


                            dataGridView1.Columns[2].Name = "Customer Address";
                            dataGridView1.Columns[2].HeaderText = "Customer Address";
                            dataGridView1.Columns[2].DataPropertyName = "company_address";


                            dataGridView1.Columns[3].Name = "Contact Person";
                            dataGridView1.Columns[3].HeaderText = "Contact Person";
                            dataGridView1.Columns[3].DataPropertyName = "contact_person";

                            dataGridView1.Columns[4].Name = "Location";
                            dataGridView1.Columns[4].HeaderText = "Location";
                            dataGridView1.Columns[4].DataPropertyName = "location";

                            dataGridView1.Columns[5].Name = "Mobile No";
                            dataGridView1.Columns[5].HeaderText = "Mobile No";
                            dataGridView1.Columns[5].DataPropertyName = "Mobile_no";

                            dataGridView1.Columns[6].Name = "Email";
                            dataGridView1.Columns[6].HeaderText = "Email";
                            dataGridView1.Columns[6].DataPropertyName = "Email";


                            dataGridView1.Columns[7].Name = "Tin No";
                            dataGridView1.Columns[7].HeaderText = "Tin No";
                            dataGridView1.Columns[7].DataPropertyName = "tin_no";


                            dataGridView1.Columns[8].Name = "Cst No";
                            dataGridView1.Columns[8].HeaderText = "Cst No";
                            dataGridView1.Columns[8].DataPropertyName = "cst_no";


                            dataGridView1.Columns[9].Name = "Remarks";
                            dataGridView1.Columns[9].HeaderText = "Remarks";
                            dataGridView1.Columns[9].DataPropertyName = "Remarks";

                            dataGridView1.Columns[10].Name = "Invoice PriceList";
                            dataGridView1.Columns[10].HeaderText = "Invoice PriceList";
                            dataGridView1.Columns[10].DataPropertyName = "invoice_price_list";


                            dataGridView1.Columns[11].Name = "Estimate PriceList";
                            dataGridView1.Columns[11].HeaderText = "Estimate PriceList";
                            dataGridView1.Columns[11].DataPropertyName = "estimate_Price_list";


                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select *  from customer_details where company_name='" + textBox1.Text + "' "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "No";
                            dataGridView1.Columns[0].HeaderText = "No";
                            dataGridView1.Columns[0].DataPropertyName = "No";


                            dataGridView1.Columns[1].Name = "Company Name";
                            dataGridView1.Columns[1].HeaderText = "Company Name";
                            dataGridView1.Columns[1].DataPropertyName = "company_name";


                            dataGridView1.Columns[2].Name = "Customer Address";
                            dataGridView1.Columns[2].HeaderText = "Customer Address";
                            dataGridView1.Columns[2].DataPropertyName = "company_address";


                            dataGridView1.Columns[3].Name = "Contact Person";
                            dataGridView1.Columns[3].HeaderText = "Contact Person";
                            dataGridView1.Columns[3].DataPropertyName = "contact_person";

                            dataGridView1.Columns[4].Name = "Location";
                            dataGridView1.Columns[4].HeaderText = "Location";
                            dataGridView1.Columns[4].DataPropertyName = "location";

                            dataGridView1.Columns[5].Name = "Mobile No";
                            dataGridView1.Columns[5].HeaderText = "Mobile No";
                            dataGridView1.Columns[5].DataPropertyName = "Mobile_no";

                            dataGridView1.Columns[6].Name = "Email";
                            dataGridView1.Columns[6].HeaderText = "Email";
                            dataGridView1.Columns[6].DataPropertyName = "Email";


                            dataGridView1.Columns[7].Name = "Tin No";
                            dataGridView1.Columns[7].HeaderText = "Tin No";
                            dataGridView1.Columns[7].DataPropertyName = "tin_no";


                            dataGridView1.Columns[8].Name = "Cst No";
                            dataGridView1.Columns[8].HeaderText = "Cst No";
                            dataGridView1.Columns[8].DataPropertyName = "cst_no";


                            dataGridView1.Columns[9].Name = "Remarks";
                            dataGridView1.Columns[9].HeaderText = "Remarks";
                            dataGridView1.Columns[9].DataPropertyName = "Remarks";

                            dataGridView1.Columns[10].Name = "Invoice PriceList";
                            dataGridView1.Columns[10].HeaderText = "Invoice PriceList";
                            dataGridView1.Columns[10].DataPropertyName = "invoice_price_list";


                            dataGridView1.Columns[11].Name = "Estimate PriceList";
                            dataGridView1.Columns[11].HeaderText = "Estimate PriceList";
                            dataGridView1.Columns[11].DataPropertyName = "estimate_Price_list";


                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select *  from customer_details where Mobile_no='" + textBox2.Text + "' "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "No";
                            dataGridView1.Columns[0].HeaderText = "No";
                            dataGridView1.Columns[0].DataPropertyName = "No";


                            dataGridView1.Columns[1].Name = "Company Name";
                            dataGridView1.Columns[1].HeaderText = "Company Name";
                            dataGridView1.Columns[1].DataPropertyName = "company_name";


                            dataGridView1.Columns[2].Name = "Customer Address";
                            dataGridView1.Columns[2].HeaderText = "Customer Address";
                            dataGridView1.Columns[2].DataPropertyName = "company_address";


                            dataGridView1.Columns[3].Name = "Contact Person";
                            dataGridView1.Columns[3].HeaderText = "Contact Person";
                            dataGridView1.Columns[3].DataPropertyName = "contact_person";

                            dataGridView1.Columns[4].Name = "Location";
                            dataGridView1.Columns[4].HeaderText = "Location";
                            dataGridView1.Columns[4].DataPropertyName = "location";

                            dataGridView1.Columns[5].Name = "Mobile No";
                            dataGridView1.Columns[5].HeaderText = "Mobile No";
                            dataGridView1.Columns[5].DataPropertyName = "Mobile_no";

                            dataGridView1.Columns[6].Name = "Email";
                            dataGridView1.Columns[6].HeaderText = "Email";
                            dataGridView1.Columns[6].DataPropertyName = "Email";


                            dataGridView1.Columns[7].Name = "Tin No";
                            dataGridView1.Columns[7].HeaderText = "Tin No";
                            dataGridView1.Columns[7].DataPropertyName = "tin_no";


                            dataGridView1.Columns[8].Name = "Cst No";
                            dataGridView1.Columns[8].HeaderText = "Cst No";
                            dataGridView1.Columns[8].DataPropertyName = "cst_no";


                            dataGridView1.Columns[9].Name = "Remarks";
                            dataGridView1.Columns[9].HeaderText = "Remarks";
                            dataGridView1.Columns[9].DataPropertyName = "Remarks";

                            dataGridView1.Columns[10].Name = "Invoice PriceList";
                            dataGridView1.Columns[10].HeaderText = "Invoice PriceList";
                            dataGridView1.Columns[10].DataPropertyName = "invoice_price_list";


                            dataGridView1.Columns[11].Name = "Estimate PriceList";
                            dataGridView1.Columns[11].HeaderText = "Estimate PriceList";
                            dataGridView1.Columns[11].DataPropertyName = "estimate_Price_list";


                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void Customer_Report_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                button2.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
