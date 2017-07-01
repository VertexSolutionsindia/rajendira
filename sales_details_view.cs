using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class sales_details_view : Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string name = "";
        public sales_details_view()
        {
            InitializeComponent();
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
                string sql = "SELECT DISTINCT [name1] FROM [sales]";
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
                string sql = "SELECT DISTINCT [gstin1] FROM [sales]";
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
        private void sales_details_view_Load(object sender, EventArgs e)
        {

            this.KeyPreview = true;


            textBox7.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            textBox7.AutoCompleteCustomSource = DataCollection;


            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection1 = new AutoCompleteStringCollection();
            getData1(DataCollection1);
            textBox1.AutoCompleteCustomSource = DataCollection1;


            int value = 1;
            SqlConnection con112 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name1 = new SqlCommand("select * from currentfinancialyear WHERE no =@no", con112);
            check_User_Name1.Parameters.AddWithValue("@no", value);
            con112.Open();
            SqlDataReader reader1 = check_User_Name1.ExecuteReader();
            if (reader1.Read())
            {
                string financial = reader1["financial_year"].ToString();
                label8.Text = financial;
            }
            con112.Close();


            getdata();
        }

        private void getdata()
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT invoice_no,date,name1,address1,taxable_total,t_cgst,t_sgst,t_igst,gst_total,grand_total  from sales where  financial_year='" + label8.Text + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);



                            dataGridView1.Columns[0].Name = "Bill No";
                            dataGridView1.Columns[0].HeaderText = "Bill No";
                            dataGridView1.Columns[0].DataPropertyName = "invoice_no";


                            dataGridView1.Columns[1].Name = "Date ";
                            dataGridView1.Columns[1].HeaderText = "Date ";
                            dataGridView1.Columns[1].DataPropertyName = "date";


                            dataGridView1.Columns[2].Name = "Receiver Name";
                            dataGridView1.Columns[2].HeaderText = "Receiver Name";
                            dataGridView1.Columns[2].DataPropertyName = "name1";

                            dataGridView1.Columns[3].Name = "Address";
                            dataGridView1.Columns[3].HeaderText = "Address";
                            dataGridView1.Columns[3].DataPropertyName = "address1";

                            dataGridView1.Columns[4].Name = "Before tax";
                            dataGridView1.Columns[4].HeaderText = "Before tax";
                            dataGridView1.Columns[4].DataPropertyName = "taxable_total";

                            dataGridView1.Columns[5].Name = "Total CGST";
                            dataGridView1.Columns[5].HeaderText = "Total CGST";
                            dataGridView1.Columns[5].DataPropertyName = "t_cgst";

                            dataGridView1.Columns[6].Name = "Total SGST";
                            dataGridView1.Columns[6].HeaderText = "Total SGST";
                            dataGridView1.Columns[6].DataPropertyName = "t_sgst";


                            dataGridView1.Columns[7].Name = "Total IGST";
                            dataGridView1.Columns[7].HeaderText = "Total IGST";
                            dataGridView1.Columns[7].DataPropertyName = "t_igst";

                            dataGridView1.Columns[8].Name = "Total GST";
                            dataGridView1.Columns[8].HeaderText = "Total GST";
                            dataGridView1.Columns[8].DataPropertyName = "gst_total";

                            dataGridView1.Columns[9].Name = "Grand Total";
                            dataGridView1.Columns[9].HeaderText = "Grand Total";
                            dataGridView1.Columns[9].DataPropertyName = "grand_total";




                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {





                    name = row.Cells[0].Value.ToString();

                    Sales_report sr1 = new Sales_report();
                    sr1.Show();
                }
            }
            catch (Exception rt)
            { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {




                    SetValueForText1 = row.Cells[0].Value.ToString();
                   
                   
                    this.Close();
                }
            }
            catch (Exception rt)
            { }
        }

        private void sales_details_view_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sales_invoice sa = new Sales_invoice();
            sa.Show();
        }

        private void sales_details_view_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
                if (MessageBox.Show("Invoice will be deleted.", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
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
                            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cd = new SqlCommand("delete from sales where invoice_no='" + row.Cells[0].Value.ToString() + "' AND financial_year='" + financial + "' ", con);
                            con.Open();
                            cd.ExecuteNonQuery();
                            con.Close();
                            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cd1 = new SqlCommand("delete from sales_product_table where invoice_no='" + row.Cells[0].Value.ToString() + "' AND financial_year='" + financial + "'", con1);
                            con1.Open();
                            cd1.ExecuteNonQuery();
                            con1.Close();

                            SqlConnection con111 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cd111 = new SqlCommand("delete from sales_product_table_final where invoice_no='" + row.Cells[0].Value.ToString() + "' AND financial_year='" + financial + "'", con111);
                            con111.Open();
                            cd111.ExecuteNonQuery();
                            con111.Close();
                        }

                    }
                    MessageBox.Show("Invoice deleted successfully");
                    getdata();
                }
          
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT invoice_no,date,name1,address1,taxable_total,t_cgst,t_sgst,t_igst,gst_total,grand_total  from sales where name1='"+textBox7.Text+"' and  financial_year='" + label8.Text + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);



                            dataGridView1.Columns[0].Name = "Bill No";
                            dataGridView1.Columns[0].HeaderText = "Bill No";
                            dataGridView1.Columns[0].DataPropertyName = "invoice_no";


                            dataGridView1.Columns[1].Name = "Date ";
                            dataGridView1.Columns[1].HeaderText = "Date ";
                            dataGridView1.Columns[1].DataPropertyName = "date";


                            dataGridView1.Columns[2].Name = "Receiver Name";
                            dataGridView1.Columns[2].HeaderText = "Receiver Name";
                            dataGridView1.Columns[2].DataPropertyName = "name1";

                            dataGridView1.Columns[3].Name = "Address";
                            dataGridView1.Columns[3].HeaderText = "Address";
                            dataGridView1.Columns[3].DataPropertyName = "address1";

                            dataGridView1.Columns[4].Name = "Before tax";
                            dataGridView1.Columns[4].HeaderText = "Before tax";
                            dataGridView1.Columns[4].DataPropertyName = "taxable_total";

                            dataGridView1.Columns[5].Name = "Total CGST";
                            dataGridView1.Columns[5].HeaderText = "Total CGST";
                            dataGridView1.Columns[5].DataPropertyName = "t_cgst";

                            dataGridView1.Columns[6].Name = "Total SGST";
                            dataGridView1.Columns[6].HeaderText = "Total SGST";
                            dataGridView1.Columns[6].DataPropertyName = "t_sgst";


                            dataGridView1.Columns[7].Name = "Total IGST";
                            dataGridView1.Columns[7].HeaderText = "Total IGST";
                            dataGridView1.Columns[7].DataPropertyName = "t_igst";

                            dataGridView1.Columns[8].Name = "Total GST";
                            dataGridView1.Columns[8].HeaderText = "Total GST";
                            dataGridView1.Columns[8].DataPropertyName = "gst_total";

                            dataGridView1.Columns[9].Name = "Grand Total";
                            dataGridView1.Columns[9].HeaderText = "Grand Total";
                            dataGridView1.Columns[9].DataPropertyName = "grand_total";




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
                using (SqlCommand cmd = new SqlCommand("SELECT invoice_no,date,name1,address1,taxable_total,t_cgst,t_sgst,t_igst,gst_total,grand_total  from sales where gstin1='" + textBox1.Text + "' and  financial_year='" + label8.Text + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);



                            dataGridView1.Columns[0].Name = "Bill No";
                            dataGridView1.Columns[0].HeaderText = "Bill No";
                            dataGridView1.Columns[0].DataPropertyName = "invoice_no";


                            dataGridView1.Columns[1].Name = "Date ";
                            dataGridView1.Columns[1].HeaderText = "Date ";
                            dataGridView1.Columns[1].DataPropertyName = "date";


                            dataGridView1.Columns[2].Name = "Receiver Name";
                            dataGridView1.Columns[2].HeaderText = "Receiver Name";
                            dataGridView1.Columns[2].DataPropertyName = "name1";

                            dataGridView1.Columns[3].Name = "Address";
                            dataGridView1.Columns[3].HeaderText = "Address";
                            dataGridView1.Columns[3].DataPropertyName = "address1";

                            dataGridView1.Columns[4].Name = "Before tax";
                            dataGridView1.Columns[4].HeaderText = "Before tax";
                            dataGridView1.Columns[4].DataPropertyName = "taxable_total";

                            dataGridView1.Columns[5].Name = "Total CGST";
                            dataGridView1.Columns[5].HeaderText = "Total CGST";
                            dataGridView1.Columns[5].DataPropertyName = "t_cgst";

                            dataGridView1.Columns[6].Name = "Total SGST";
                            dataGridView1.Columns[6].HeaderText = "Total SGST";
                            dataGridView1.Columns[6].DataPropertyName = "t_sgst";


                            dataGridView1.Columns[7].Name = "Total IGST";
                            dataGridView1.Columns[7].HeaderText = "Total IGST";
                            dataGridView1.Columns[7].DataPropertyName = "t_igst";

                            dataGridView1.Columns[8].Name = "Total GST";
                            dataGridView1.Columns[8].HeaderText = "Total GST";
                            dataGridView1.Columns[8].DataPropertyName = "gst_total";

                            dataGridView1.Columns[9].Name = "Grand Total";
                            dataGridView1.Columns[9].HeaderText = "Grand Total";
                            dataGridView1.Columns[9].DataPropertyName = "grand_total";




                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }
    }
}
