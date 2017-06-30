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
    public partial class invoice_report_details : Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string name = "";
        public invoice_report_details()
        {
            InitializeComponent();
        }

        private void invoice_report_details_Load(object sender, EventArgs e)
        {
            getcustomerdetails();
            this.KeyPreview = true;
            getdata();


            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            textBox1.AutoCompleteCustomSource = DataCollection;
        }

        private void getdata()
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


                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("select  distinct Invoice_no,Buyer from invoice WHERE financial_year='"+financial+"' ", con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DataRow dr;
                        dr = dt.NewRow();
                        dr.ItemArray = new object[] { 0, "--Select item--" };
                        dt.Rows.InsertAt(dr, 0);
                        comboBox1.DataSource = dt;
                        comboBox1.DisplayMember = "Invoice_no";
                        comboBox1.ValueMember = "Buyer";


                        con.Close();
                    }
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
                string sql = "SELECT DISTINCT [Buyer] FROM [invoice]";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "0")
            {
                MessageBox.Show("Please select valid valid number");
            }
            else
            {
                name = comboBox1.Text;
                Invoice_report i = new Invoice_report();
                i.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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


                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("select  distinct Invoice_no from invoice where Buyer='" + textBox1.Text + "' AND financial_year='"+financial+"' ", con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DataRow dr;
                        dr = dt.NewRow();
                        dr.ItemArray = new object[] { 0, };
                        dt.Rows.InsertAt(dr, 0);
                        comboBox1.DataSource = dt;
                        comboBox1.DisplayMember = "Invoice_no";


                        con.Close();
                    }
                    con11.Close();
        
        
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void invoice_report_details_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                button2.PerformClick();
            }
        }
        public void getcustomerdetails()
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
                        string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT Buyer,Invoice_no,No_of_Bdl,Total_Pcs,Date,Transport  from invoice where financial_year='" + financial + "' ORDER BY ID ASC"))
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    using (DataTable dt = new DataTable())
                                    {
                                        sda.Fill(dt);
                                        dataGridView1.Columns[0].Name = "Customaer Name";
                                        dataGridView1.Columns[0].HeaderText = "Customer Name";
                                        dataGridView1.Columns[0].DataPropertyName = "Buyer";


                                        dataGridView1.Columns[1].Name = "Invoice No";
                                        dataGridView1.Columns[1].HeaderText = "Invoice No";
                                        dataGridView1.Columns[1].DataPropertyName = "Invoice_no";


                                        dataGridView1.Columns[2].Name = "No of bundles";
                                        dataGridView1.Columns[2].HeaderText = "No of bundles";
                                        dataGridView1.Columns[2].DataPropertyName = "No_of_Bdl";


                                        dataGridView1.Columns[3].Name = "Total Pcs";
                                        dataGridView1.Columns[3].HeaderText = "Total pcs";
                                        dataGridView1.Columns[3].DataPropertyName = "Total_Pcs";

                                        dataGridView1.Columns[4].Name = "Date";
                                        dataGridView1.Columns[4].HeaderText = "Date";
                                        dataGridView1.Columns[4].DataPropertyName = "Date";

                                        dataGridView1.Columns[5].Name = "Carrier";
                                        dataGridView1.Columns[5].HeaderText = "Carrier";
                                        dataGridView1.Columns[5].DataPropertyName = "Transport";







                                        dataGridView1.DataSource = dt;
                                    }
                                }
                            }
                        }
                    }
                    con11.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            


                
            }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
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
                        SqlCommand cd = new SqlCommand("delete from invoice where invoice_no='" + row.Cells[1].Value.ToString() + "' AND financial_year='" + financial + "' ", con);
                        con.Open();
                        cd.ExecuteNonQuery();
                        con.Close();
                        SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cd1 = new SqlCommand("delete from invoice_product_table where invoice_no='" + row.Cells[1].Value.ToString() + "' AND financial_year='" + financial + "'", con1);
                        con1.Open();
                        cd1.ExecuteNonQuery();
                        con1.Close();

                        SqlConnection con111 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cd111 = new SqlCommand("delete from invoice_product_table_final where invoice_no='" + row.Cells[1].Value.ToString() + "' AND financial_year='" + financial + "'", con111);
                        con111.Open();
                        cd111.ExecuteNonQuery();
                        con111.Close();
                    }

                    }
                    MessageBox.Show("Invoice deleted successfully");
                    getcustomerdetails();
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




                SetValueForText1 = row.Cells[1].Value.ToString();
                SetValueForText2 = row.Cells[0].Value.ToString();
                frmsalesinvoice d = new frmsalesinvoice();
                d.Show();
            }
                 }
            catch (Exception rt)
            { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
             try
            {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {





                name = row.Cells[1].Value.ToString();

                Invoice_report i = new Invoice_report();
                i.Show();
            }
            }
             catch (Exception rt)
             { }
          
        }
        }
    }

