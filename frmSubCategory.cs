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
    public partial class frmSubCategory : Form
    {
        public frmSubCategory()
        {
            InitializeComponent();
        }

        private void frmSubCategory_Load(object sender, EventArgs e)
        {
            Getproductid();
            getid();
            Getproductid1();
            getsubcategorydetails();
            comboBox1.Focus();
            this.KeyPreview = true;
            btnSave.Enabled = false;
            btnNew.Enabled = true;


        }
        private void getsubcategorydetails()
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  Style_id,category_name,Style_name from Product_style   order by Style_id asc"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "Style ID";
                            dataGridView1.Columns[0].HeaderText = "Style ID";
                            dataGridView1.Columns[0].DataPropertyName = "Style_id";


                            dataGridView1.Columns[1].Name = "Category Name";
                            dataGridView1.Columns[1].HeaderText = "Category Name";
                            dataGridView1.Columns[1].DataPropertyName = "category_name";


                            dataGridView1.Columns[2].Name = "Style Name";
                            dataGridView1.Columns[2].HeaderText = "Style Name";
                            dataGridView1.Columns[2].DataPropertyName = "Style_name";




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
            string query = "Select max(Style_id) from Product_style ";
            SqlCommand cmd1 = new SqlCommand(query, con1);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {

                    label2.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    label2.Text = a.ToString();
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
        private void Getproductid1()
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
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Category_name";
            comboBox2.ValueMember = "Category_id";

            con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "-Select item")
            {
                MessageBox.Show("Please select valid category");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter product style");
            }
            else
            {


                SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Product_style WHERE Style_id = @Style_id", con10);
                check_User_Name.Parameters.AddWithValue("@Style_id", label2.Text);
                con10.Open();
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("The product style already exist");
                }
                else
                {

                    SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand("insert into Product_style values(@Style_id,@Style_name,@Category_id,@category_name)", con1);
                    cmd.Parameters.AddWithValue("@Style_id", label2.Text);
                    cmd.Parameters.AddWithValue("@Style_name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Category_id", comboBox1.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@category_name", comboBox1.Text);
                    con1.Open();
                    cmd.ExecuteNonQuery();
                    con1.Close();
                    MessageBox.Show("Product style added successfully");
                    textBox1.Text = "";
                    getid();
                    Getproductid();
                   
                    Getproductid1();
                    getsubcategorydetails();
                }
                con10.Close();
                SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name1 = new SqlCommand("SELECT * FROM Product_style WHERE Style_id != @Style_id", con11);
                check_User_Name1.Parameters.AddWithValue("@Style_id", label2.Text);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           


                


               

          
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            getid();
            textBox1.Text = "";
            btnSave.Enabled = false;
          
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Product_style WHERE Style_id = @Style_id", con10);
            check_User_Name.Parameters.AddWithValue("@Style_id", label2.Text);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Getproductid();
            textBox1.Text = "";
            getid();
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Product_style WHERE Style_id = @Style_id", con10);
            check_User_Name.Parameters.AddWithValue("@Style_id", label2.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
               
                btnSave.Enabled = false;
                if (e.KeyCode == Keys.Enter)
                {
                   
                    e.Handled = true;
                }

            }
            else
            {
                btnSave.Enabled = true;

                btnNew.Enabled = false;

                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                    e.Handled = true;
                }

            }
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
           
            
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              
                e.Handled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  Style_id,category_name,Style_name from Product_style where category_name='" + comboBox2.Text + "' order by  Style_id asc "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                             sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "Style ID";
                            dataGridView1.Columns[0].HeaderText = "Style ID";
                            dataGridView1.Columns[0].DataPropertyName = "Style_id";


                            dataGridView1.Columns[1].Name = "Category Name";
                            dataGridView1.Columns[1].HeaderText = "Category Name";
                            dataGridView1.Columns[1].DataPropertyName = "category_name";


                            dataGridView1.Columns[2].Name = "Style Name";
                            dataGridView1.Columns[2].HeaderText = "Style Name";
                            dataGridView1.Columns[2].DataPropertyName = "Style_name";




                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Product style will be deleted.", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand("delete from Product_style where Style_id='" + row.Cells[0].Value.ToString() + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd1 = new SqlCommand("delete from product_entry where style_id='" + row.Cells[0].Value.ToString() + "'", con1);
                    con1.Open();
                    cmd1.ExecuteNonQuery();
                    con1.Close();

                    SqlConnection con3 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd3 = new SqlCommand("delete from priceList where Style_id='" + row.Cells[0].Value.ToString() + "'", con3);
                    con3.Open();
                    cmd3.ExecuteNonQuery();
                    con3.Close();



                }
                MessageBox.Show("The product style deleted successfully");
                getsubcategorydetails();
                getid();
                textBox1.Text = "";
                Getproductid();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
            int category_id = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                SqlConnection con14 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name4 = new SqlCommand("SELECT * FROM Product_style WHERE Style_id = @Style_id", con14);
                check_User_Name4.Parameters.AddWithValue("@Style_id", dataGridView1.Rows[i].Cells[0].Value);
                con14.Open();
                SqlDataReader reader4 = check_User_Name4.ExecuteReader();
                if (reader4.HasRows)
                {

                    SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd10 = new SqlCommand("select * from Product_category where Category_name='" + dataGridView1.Rows[i].Cells[1].Value + "'", con10);
                    con10.Open();
                    SqlDataReader dr10;
                    dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                    {
                        category_id = Convert.ToInt32(dr10["Category_id"].ToString());

                    }
                    con10.Close();

                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand("update Product_style set Style_name=@Style_name,Category_id=@Category_id,category_name=@category_name where Style_id='" + dataGridView1.Rows[i].Cells[0].Value + "'", con);
                    cmd.Parameters.AddWithValue("@Style_name", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@Category_id", category_id);
                    cmd.Parameters.AddWithValue("@category_name", dataGridView1.Rows[i].Cells[1].Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                con14.Close();



            }

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                SqlConnection con14 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name4 = new SqlCommand("SELECT * FROM product_entry WHERE style_id = @style_id", con14);
                check_User_Name4.Parameters.AddWithValue("@style_id", dataGridView1.Rows[i].Cells[0].Value);
                con14.Open();
                SqlDataReader reader4 = check_User_Name4.ExecuteReader();
                if (reader4.HasRows)
                {

                    SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd10 = new SqlCommand("select * from Product_category where Category_name='" + dataGridView1.Rows[i].Cells[1].Value + "'", con10);
                    con10.Open();
                    SqlDataReader dr10;
                    dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                    {
                        category_id = Convert.ToInt32(dr10["Category_id"].ToString());

                    }
                    con10.Close();
                    SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd1 = new SqlCommand("update product_entry set Product_Style=@Product_Style,category_id=@category_id,Product_Category=@Product_Category where style_id='" + dataGridView1.Rows[i].Cells[0].Value + "'", con1);
                    cmd1.Parameters.AddWithValue("@Product_Style", dataGridView1.Rows[i].Cells[2].Value);
                    cmd1.Parameters.AddWithValue("@category_id", category_id);
                    cmd1.Parameters.AddWithValue("@Product_Category", dataGridView1.Rows[i].Cells[1].Value);
                    con1.Open();
                    cmd1.ExecuteNonQuery();

                    con1.Close();

                }

                con14.Close();


            }

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                SqlConnection con14 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name4 = new SqlCommand("SELECT * FROM priceList WHERE Style_id = @Style_id", con14);
                check_User_Name4.Parameters.AddWithValue("@Style_id", dataGridView1.Rows[i].Cells[0].Value);
                con14.Open();
                SqlDataReader reader4 = check_User_Name4.ExecuteReader();
                if (reader4.HasRows)
                {

                    SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd10 = new SqlCommand("select * from Product_category where Category_name='" + dataGridView1.Rows[i].Cells[1].Value + "'", con10);
                    con10.Open();
                    SqlDataReader dr10;
                    dr10 = cmd10.ExecuteReader();
                    if (dr10.Read())
                    {
                        category_id = Convert.ToInt32(dr10["Category_id"].ToString());

                    }
                    con10.Close();
                    SqlConnection con3 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd3 = new SqlCommand("update priceList set Product_Style=@Product_Style,Category_id=@Category_id,Product_category=@Product_category where Style_id='" + dataGridView1.Rows[i].Cells[0].Value + "'", con3);
                    cmd3.Parameters.AddWithValue("@Product_Style", dataGridView1.Rows[i].Cells[2].Value);
                    cmd3.Parameters.AddWithValue("@Category_id", category_id);
                    cmd3.Parameters.AddWithValue("@Product_category", dataGridView1.Rows[i].Cells[1].Value);
                    con3.Open();
                    cmd3.ExecuteNonQuery();
                    con3.Close();
                }

                con14.Close();


            }













          
                MessageBox.Show("The product style updated successfully");
                textBox1.Text = "";
                getid();
               
                Getproductid();
            }
            catch (Exception er)
            { }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  Style_id,category_name,Style_name from Product_style   order by Style_id asc"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "Style ID";
                            dataGridView1.Columns[0].HeaderText = "Style ID";
                            dataGridView1.Columns[0].DataPropertyName = "Style_id";


                            dataGridView1.Columns[1].Name = "Category Name";
                            dataGridView1.Columns[1].HeaderText = "Category Name";
                            dataGridView1.Columns[1].DataPropertyName = "category_name";


                            dataGridView1.Columns[2].Name = "Style Name";
                            dataGridView1.Columns[2].HeaderText = "Style Name";
                            dataGridView1.Columns[2].DataPropertyName = "Style_name";




                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void frmSubCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                button1.PerformClick();
            }
        }

       
    }
}
