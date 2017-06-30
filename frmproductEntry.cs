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
    public partial class frmproductEntry : Form
    {
        public frmproductEntry()
        {
            InitializeComponent();
        }

        private void frmproductEntry_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Select item";
            comboBox2.Text = "Select item";
            Getproductid();
            Getproductidfor3();
            getid();
            getdetails1();
            this.KeyPreview = true;
        }

        private void getid()
        {
            int a;
            DateTime today = DateTime.Today;
            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            con1.Open();
            string query = "Select  max(convert(int,SubString(product_id,PATINDEX('%[0-9]%',product_id),Len(product_id)))) from id";
            SqlCommand cmd1 = new SqlCommand(query, con1);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    label5.Text = "TP" + "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    label5.Text = "TP" + a.ToString();
                }
            }
        }
        private void Getproductid()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select  * from Product_category", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "-Select item" };
            dt.Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Category_name";
            comboBox1.ValueMember = "Category_id";


            con.Close();
        }
        private void Getproductidfor3()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select  * from Product_category", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "-Select item" };
            dt.Rows.InsertAt(dr, 0);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "Category_name";
            comboBox3.ValueMember = "Category_id";


            con.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select  Style_id,Style_name from Product_style where category_name='" + comboBox1.Text.Trim() + "'", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "-Select item" };
            dt.Rows.InsertAt(dr, 0);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Style_name";
            comboBox2.ValueMember = "Style_id";


            con.Close();

               
         
          
              
         
              
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }
        private void getdetails1()
        {
            textBox2.Text = "";
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  Product_code,Product_Category,Product_Style,size from product_entry order by ID asc    "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "Product Code";
                            dataGridView1.Columns[0].HeaderText = "Product Code";
                            dataGridView1.Columns[0].DataPropertyName = "Product_code";


                            dataGridView1.Columns[1].Name = "Product Category";
                            dataGridView1.Columns[1].HeaderText = "Product Category";
                            dataGridView1.Columns[1].DataPropertyName = "Product_Category";


                            dataGridView1.Columns[2].Name = "Style";
                            dataGridView1.Columns[2].HeaderText = "Style";
                            dataGridView1.Columns[2].DataPropertyName = "Product_Style";

                            dataGridView1.Columns[3].Name = "Size";
                            dataGridView1.Columns[3].HeaderText = "Size";
                            dataGridView1.Columns[3].DataPropertyName = "size";


                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void getdetails()
        {
            textBox2.Text = "";
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  Product_code,Product_Category,Product_Style,size from product_entry where Product_Category='" + comboBox1.Text + "' and Product_Style='" + comboBox2.Text + "' order by Product_code asc    "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "Product Code";
                            dataGridView1.Columns[0].HeaderText = "Product Code";
                            dataGridView1.Columns[0].DataPropertyName = "Product_code";


                            dataGridView1.Columns[1].Name = "Product Category";
                            dataGridView1.Columns[1].HeaderText = "Product Category";
                            dataGridView1.Columns[1].DataPropertyName = "Product_Category";


                            dataGridView1.Columns[2].Name = "Style";
                            dataGridView1.Columns[2].HeaderText = "Style";
                            dataGridView1.Columns[2].DataPropertyName = "Product_Style";

                            dataGridView1.Columns[3].Name = "Size";
                            dataGridView1.Columns[3].HeaderText = "Size";
                            dataGridView1.Columns[3].DataPropertyName = "size";


                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "-Select item")
            {
                MessageBox.Show("Please select valid category");

            }
            else if (comboBox2.Text == "-Select item")
            {
                MessageBox.Show("Please select valid style");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("please provice valid size");

            }
            else
            {


                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView2, label5.Text, comboBox1.Text, comboBox2.Text, textBox2.Text, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString());
                this.dataGridView2.Rows.Add(row);
                textBox2.Text = "";



                int a;

                SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand cmd11 = new SqlCommand("insert into id values(@product_id)", con11);
                cmd11.Parameters.AddWithValue("@product_id", label5.Text);
                con11.Open();
                cmd11.ExecuteNonQuery();
                con11.Close();

                getid();
            }
           


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {

                    SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd11 = new SqlCommand("insert into product_entry values(@Product_code,@Product_Category,@Product_Style,@size,@category_id,@style_id)", con11);
                    cmd11.Parameters.AddWithValue("@Product_code", dataGridView2.Rows[i].Cells[0].Value);
                    cmd11.Parameters.AddWithValue("@Product_Category", dataGridView2.Rows[i].Cells[1].Value);
                    cmd11.Parameters.AddWithValue("@Product_Style", dataGridView2.Rows[i].Cells[2].Value);
                    cmd11.Parameters.AddWithValue("@size", dataGridView2.Rows[i].Cells[3].Value);
                    cmd11.Parameters.AddWithValue("@category_id", dataGridView2.Rows[i].Cells[4].Value);
                    cmd11.Parameters.AddWithValue("@style_id", dataGridView2.Rows[i].Cells[5].Value);
                    con11.Open();
                    cmd11.ExecuteNonQuery();
                    con11.Close();

                }
                MessageBox.Show("The product size saved successfully");
                dataGridView2.Rows.Clear();
                Getproductidfor3();
                Getproductid();
                getid();
                getdetails();
                getdetails1();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                SqlConnection con14 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name4 = new SqlCommand("SELECT * FROM product_entry WHERE Product_code = @Product_code", con14);
                check_User_Name4.Parameters.AddWithValue("@Product_code", dataGridView1.Rows[i].Cells[0].Value);
                con14.Open();
                SqlDataReader reader4 = check_User_Name4.ExecuteReader();
                if (reader4.HasRows)
                {
                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand("update product_entry set Product_Category=@Product_Category,Product_Style=@Product_Style,size=@size  where Product_code='" + dataGridView1.Rows[i].Cells[0].Value + "'", con);

                    cmd.Parameters.AddWithValue("@Product_Category", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@Product_Style", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@size", dataGridView1.Rows[i].Cells[3].Value);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                con14.Close();
            }





         
            MessageBox.Show("The product size updated sucessfully");
            getdetails();
            getdubdetails();
            getid();
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("delete from product_entry  where Product_code='" + row.Cells[0].Value.ToString() + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
              
                
            }
            MessageBox.Show("The product size deleted successfully");
            getdetails();
            getid();
            getdetails1();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(item.Index);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select  Style_id,Style_name from Product_style where category_name='" + comboBox3.Text.Trim() + "'", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "-Select item" };
            dt.Rows.InsertAt(dr, 0);
            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "Style_name";
            comboBox4.ValueMember = "Style_id";


            con.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdubdetails();
        }

        private void getdubdetails()
        {
            textBox2.Text = "";
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  Product_code,Product_Category,Product_Style,size from product_entry where Product_Category='" + comboBox3.Text + "' and Product_Style='" + comboBox4.Text + "' order by Product_code asc    "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "Product Code";
                            dataGridView1.Columns[0].HeaderText = "Product Code";
                            dataGridView1.Columns[0].DataPropertyName = "Product_code";


                            dataGridView1.Columns[1].Name = "Product Category";
                            dataGridView1.Columns[1].HeaderText = "Product Category";
                            dataGridView1.Columns[1].DataPropertyName = "Product_Category";


                            dataGridView1.Columns[2].Name = "Style";
                            dataGridView1.Columns[2].HeaderText = "Style";
                            dataGridView1.Columns[2].DataPropertyName = "Product_Style";

                            dataGridView1.Columns[3].Name = "Size";
                            dataGridView1.Columns[3].HeaderText = "Size";
                            dataGridView1.Columns[3].DataPropertyName = "size";


                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Getproductid();
            dataGridView2.Rows.Clear();
            Getproductidfor3();
            Getproductid();
            getid();
            getdetails();
            getdetails1();
            textBox2.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
                e.Handled = true;
            }
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            textBox2.Focus();
        }

        private void frmproductEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                btnClose.PerformClick();
            }
        }
    }
}
