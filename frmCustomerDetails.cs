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
    public partial class frmCustomerDetails : Form
    {
        public frmCustomerDetails()
        {
            InitializeComponent();
        }

        private void frmCustomerDetails_Load(object sender, EventArgs e)
        {
            Getproductid();
            getid();
            Getproductid1();
            getcustomerdetails();
          
           
            
            btnSave.Enabled = false;
            
        }


        private void getcustomerdetails()
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT No,company_name,company_address,contact_person,nick_name,location,Mobile_no,Email,tin_no,cst_no,Remarks,invoice_price_list from customer_details order by No asc"))
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

                            dataGridView1.Columns[4].Name = "Nick Name";
                            dataGridView1.Columns[4].HeaderText = "Nick Name";
                            dataGridView1.Columns[4].DataPropertyName = "nick_name";


                            dataGridView1.Columns[5].Name = "Location";
                            dataGridView1.Columns[5].HeaderText = "Location";
                            dataGridView1.Columns[5].DataPropertyName = "location";

                            dataGridView1.Columns[6].Name = "Mobile No";
                            dataGridView1.Columns[6].HeaderText = "Mobile No";
                            dataGridView1.Columns[6].DataPropertyName = "Mobile_no";

                            dataGridView1.Columns[7].Name = "Email";
                            dataGridView1.Columns[7].HeaderText = "Email";
                            dataGridView1.Columns[7].DataPropertyName = "Email";


                            dataGridView1.Columns[8].Name = "Tin No";
                            dataGridView1.Columns[8].HeaderText = "Tin No";
                            dataGridView1.Columns[8].DataPropertyName = "tin_no";


                            dataGridView1.Columns[9].Name = "Cst No";
                            dataGridView1.Columns[9].HeaderText = "Cst No";
                            dataGridView1.Columns[9].DataPropertyName = "cst_no";


                            dataGridView1.Columns[10].Name = "Remarks";
                            dataGridView1.Columns[10].HeaderText = "Remarks";
                            dataGridView1.Columns[10].DataPropertyName = "Remarks";

                            dataGridView1.Columns[11].Name = "Invoice PriceList";
                            dataGridView1.Columns[11].HeaderText = "Invoice PriceList";
                            dataGridView1.Columns[11].DataPropertyName = "invoice_price_list";


                            

                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }
        private void getid()
        {
            int a;



            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            con1.Open();
            string query = "Select max(No) from customer_details ";
            SqlCommand cmd1 = new SqlCommand(query, con1);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {

                    label13.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    label13.Text = a.ToString();
                }
            }
        }
        private void Getproductid()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select  distinct Name from priceList  ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { "--Select item--" };
            dt.Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
          

            con.Close();
         

        }
        private void Getproductid1()
        {
           


        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            getid();
            textBox1.Text = "";
            richTextBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            richTextBox2.Text = "";
            Getproductid();
            btnSave.Enabled = false;
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text=="")
            {
                MessageBox.Show("Please enter company name");
            }
            else if (richTextBox1.Text == "")
            {
                MessageBox.Show("Please enter company address");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter contact person");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please enter mobile number");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Please enter location");
            }
            else if (comboBox1.Text == "--Select item--") 
            {
                 MessageBox.Show("Please add price list"); 
            }
            else
            {


                SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name = new SqlCommand("SELECT * FROM customer_details WHERE No = @No", con10);
                check_User_Name.Parameters.AddWithValue("@No", label13.Text);
                con10.Open();
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("The customer no already exist");
                }
                else
                {

                    SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand("insert into customer_details values(@No,@company_name,@company_address,@contact_person,@location,@Mobile_no,@Email,@tin_no,@cst_no,@Remarks,@invoice_price_list,@nick_name)", con1);

                    cmd.Parameters.AddWithValue("@No", label13.Text);
                    cmd.Parameters.AddWithValue("@company_name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@company_address", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@contact_person", textBox2.Text);
                    cmd.Parameters.AddWithValue("@location", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Mobile_no", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@tin_no", textBox5.Text);
                    cmd.Parameters.AddWithValue("@cst_no", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Remarks", richTextBox2.Text);
                    cmd.Parameters.AddWithValue("@invoice_price_list", comboBox1.Text);
              
                    cmd.Parameters.AddWithValue("@nick_name", textBox8.Text);

                    con1.Open();
                    cmd.ExecuteNonQuery();
                    con1.Close();
                    MessageBox.Show("Customer details added successfully");

                    textBox1.Text = "";
                    richTextBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox7.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox8.Text = "";
                    richTextBox2.Text = "";
                    Getproductid();
                    getid();
                    Getproductid();
                    getcustomerdetails();
                }
                con10.Close();
                SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name1 = new SqlCommand("SELECT * FROM customer_details WHERE No != @No", con11);
                check_User_Name1.Parameters.AddWithValue("@No", label13.Text);
                con11.Open();
                SqlDataReader reader1 = check_User_Name1.ExecuteReader();
                if (reader1.HasRows)
                {
                 
                    btnSave.Enabled = false;

                    btnNew.Enabled = true;

                }
                con11.Close();
            
        }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM customer_details WHERE No = @No", con10);
            check_User_Name.Parameters.AddWithValue("@No", label13.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
              
                btnSave.Enabled = false;

            }
            else
            {
                btnSave.Enabled = true;
                button1.Enabled = true;
                btnNew.Enabled = false;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {






                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("update customer_details set company_name=@company_name,company_address=@company_address,contact_person=@contact_person,location=@location,Mobile_no=@Mobile_no,Email=@Email,tin_no=@tin_no,cst_no=@cst_no,Remarks=@Remarks,invoice_price_list=@invoice_price_list,estimate_Price_list=@estimate_Price_list  where No='" + row.Cells[0].Value.ToString() + "'", con);

                cmd.Parameters.AddWithValue("@company_name", row.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@company_address", row.Cells[2].Value.ToString());
                cmd.Parameters.AddWithValue("@contact_person", row.Cells[3].Value.ToString());
                cmd.Parameters.AddWithValue("@location", row.Cells[4].Value.ToString());
                cmd.Parameters.AddWithValue("@Mobile_no", row.Cells[5].Value.ToString());
                cmd.Parameters.AddWithValue("@Email", row.Cells[6].Value.ToString());
                cmd.Parameters.AddWithValue("@tin_no", row.Cells[7].Value.ToString());
                cmd.Parameters.AddWithValue("@cst_no", row.Cells[8].Value.ToString());
                cmd.Parameters.AddWithValue("@Remarks", row.Cells[9].Value.ToString());
                cmd.Parameters.AddWithValue("@invoice_price_list", row.Cells[10].Value.ToString());
                cmd.Parameters.AddWithValue("@estimate_Price_list", row.Cells[11].Value.ToString());


                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                

            }
            MessageBox.Show("The customer details updated successfully");
            textBox1.Text = "";
            richTextBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            richTextBox2.Text = "";
            Getproductid();
            getid();
            Getproductid();
            getcustomerdetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            richTextBox2.Text = "";
            Getproductid();
            getid();
            Getproductid();
            getcustomerdetails();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM customer_details WHERE No = @No", con10);
            check_User_Name.Parameters.AddWithValue("@No", label13.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
             
                btnSave.Enabled = false;

            }
            else
            {
                btnSave.Enabled = true;

                btnNew.Enabled = false;

            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM customer_details WHERE No = @No", con10);
            check_User_Name.Parameters.AddWithValue("@No", label13.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
             
                btnSave.Enabled = false;

            }
            else
            {
                btnSave.Enabled = true;

                btnNew.Enabled = false;

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM customer_details WHERE No = @No", con10);
            check_User_Name.Parameters.AddWithValue("@No", label13.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
             
                btnSave.Enabled = false;

            }
            else
            {
                btnSave.Enabled = true;

                btnNew.Enabled = false;

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM customer_details WHERE No = @No", con10);
            check_User_Name.Parameters.AddWithValue("@No", label13.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
             
                btnSave.Enabled = false;

            }
            else
            {
                btnSave.Enabled = true;

                btnNew.Enabled = false;

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM customer_details WHERE No = @No", con10);
            check_User_Name.Parameters.AddWithValue("@No", label13.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
              
                btnSave.Enabled = false;

            }
            else
            {
                btnSave.Enabled = true;

                btnNew.Enabled = false;

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM customer_details WHERE No = @No", con10);
            check_User_Name.Parameters.AddWithValue("@No", label13.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
               
                btnSave.Enabled = false;

            }
            else
            {
                btnSave.Enabled = true;

                btnNew.Enabled = false;

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM customer_details WHERE No = @No", con10);
            check_User_Name.Parameters.AddWithValue("@No", label13.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
              
                btnSave.Enabled = false;

            }
            else
            {
                btnSave.Enabled = true;

                btnNew.Enabled = false;

            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM customer_details WHERE No = @No", con10);
            check_User_Name.Parameters.AddWithValue("@No", label13.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
             
                btnSave.Enabled = false;

            }
            else
            {
                btnSave.Enabled = true;

                btnNew.Enabled = false;

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextBox1.Focus();
                e.Handled = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
                e.Handled = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
                e.Handled = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
                e.Handled = true;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
                e.Handled = true;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
                e.Handled = true;
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextBox2.Focus();
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Customer details will be deleted.", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand("delete from customer_details where No='" + row.Cells[0].Value.ToString() + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Customer deleted successfully");
                textBox1.Text = "";
                richTextBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox7.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                richTextBox2.Text = "";
                Getproductid();
                getid();
                Getproductid();
                getcustomerdetails();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                SqlConnection con14 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand check_User_Name4 = new SqlCommand("SELECT * FROM customer_details WHERE No = @No", con14);
                    check_User_Name4.Parameters.AddWithValue("@No", dataGridView1.Rows[i].Cells[0].Value);
                    con14.Open();
                    SqlDataReader reader4 = check_User_Name4.ExecuteReader();
                    if (reader4.HasRows)
                    {
                        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd = new SqlCommand("update customer_details set company_name=@company_name,company_address=@company_address,contact_person=@contact_person,location=@location,Mobile_no=@Mobile_no,Email=@Email,tin_no=@tin_no,cst_no=@cst_no,Remarks=@Remarks,invoice_price_list=@invoice_price_list,nick_name=@nick_name  where No='" + dataGridView1.Rows[i].Cells[0].Value + "'", con);

                        cmd.Parameters.AddWithValue("@company_name", dataGridView1.Rows[i].Cells[1].Value);
                        cmd.Parameters.AddWithValue("@company_address", dataGridView1.Rows[i].Cells[2].Value);
                        cmd.Parameters.AddWithValue("@contact_person", dataGridView1.Rows[i].Cells[3].Value);
                        cmd.Parameters.AddWithValue("@nick_name", dataGridView1.Rows[i].Cells[4].Value);
                        cmd.Parameters.AddWithValue("@location", dataGridView1.Rows[i].Cells[5].Value);
                        cmd.Parameters.AddWithValue("@Mobile_no", dataGridView1.Rows[i].Cells[6].Value);
                        cmd.Parameters.AddWithValue("@Email", dataGridView1.Rows[i].Cells[7].Value);
                        cmd.Parameters.AddWithValue("@tin_no", dataGridView1.Rows[i].Cells[8].Value);
                        cmd.Parameters.AddWithValue("@cst_no", dataGridView1.Rows[i].Cells[9].Value);
                        cmd.Parameters.AddWithValue("@Remarks", dataGridView1.Rows[i].Cells[10].Value);
                        cmd.Parameters.AddWithValue("@invoice_price_list", dataGridView1.Rows[i].Cells[11].Value);
                     
                      

                        con.Open();
                        cmd.ExecuteNonQuery();

                        con.Close();

                    }
                    con14.Close();

            }


          
            MessageBox.Show("The customer details updated successfully");
         
            Getproductid();
            getid();
            Getproductid();
            getcustomerdetails();
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.Handled = true;
            }
        }
    }
}
