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
    public partial class frmCategory : Form
    {
        private int rowIndex = 0;
        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            getid();
            getcategorydetails();
            this.KeyPreview = true;
            btnSave.Enabled = false;
           
            btnClose.Enabled = false;
        }

        private void getcategorydetails()
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  Category_id,Category_name from Product_category order by Category_id asc "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "Category ID";
                            dataGridView1.Columns[0].HeaderText = "Category ID";
                            dataGridView1.Columns[0].DataPropertyName = "Category_id";
                            dataGridView1.Columns[1].Name = "Category Name";
                            dataGridView1.Columns[1].HeaderText = "Category Name";
                            dataGridView1.Columns[1].DataPropertyName = "Category_name";



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
            string query = "Select max(Category_id) from Product_category ";
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtCategoryName.Text=="")
            {
                MessageBox.Show("Please Enter valid category");
            }
            else
            {


                SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Product_category WHERE Category_id = @Category_id", con10);
                check_User_Name.Parameters.AddWithValue("@Category_id", label2.Text);
                con10.Open();
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("The product category already exist");
                }
                else
                {
                    SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand("insert into Product_category values(@Category_id,@Category_name)", con1);
                    cmd.Parameters.AddWithValue("@Category_id", label2.Text);
                    cmd.Parameters.AddWithValue("@Category_name", txtCategoryName.Text);
                    con1.Open();
                    cmd.ExecuteNonQuery();
                    con1.Close();
                    MessageBox.Show("Product category added successfully");
                    txtCategoryName.Text = "";
                    getid();
                    getcategorydetails();
                }
                con10.Close();

                SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name1 = new SqlCommand("SELECT * FROM Product_category WHERE Category_id != @Category_id", con11);
                check_User_Name1.Parameters.AddWithValue("@Category_id", label2.Text);
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
            txtCategoryName.Text = "";
        
            btnSave.Enabled = false;
            btnClose.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
           



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
             
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Product_category WHERE Category_id = @Category_id", con10);
            check_User_Name.Parameters.AddWithValue("@Category_id", label2.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
            
                btnClose.Enabled = true;
              
            }
            else
            {
                btnSave.Enabled = true;
                btnClose.Enabled = true;
                btnNew.Enabled = false;
               
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            txtCategoryName.Text = "";
            getid();
        }

        private void txtCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Product_category WHERE Category_id = @Category_id", con10);
            check_User_Name.Parameters.AddWithValue("@Category_id", label2.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
              
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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                e.Handled = true;
            }

            }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
                DateTime today = DateTime.Today;
                if (MessageBox.Show("Product category will be deleted.", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cd = new SqlCommand("delete from Product_category where Category_id='" + row.Cells[0].Value.ToString() + "'", con);
                        con.Open();
                        cd.ExecuteNonQuery();
                        con.Close();



                        SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd1 = new SqlCommand("delete from Product_style where Category_id='" + row.Cells[0].Value.ToString() + "'", con1);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();



                        SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd2 = new SqlCommand("delete from product_entry where category_id='" + row.Cells[0].Value.ToString() + "'", con2);
                        con2.Open();
                        cmd2.ExecuteNonQuery();
                        con2.Close();


                        SqlConnection con3 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd3 = new SqlCommand("delete from priceList where Category_id='" + row.Cells[0].Value.ToString() + "'", con3);
                        con3.Open();
                        cmd3.ExecuteNonQuery();
                        con3.Close();



                    }
                    MessageBox.Show("Product category deleted successfully");
                    getcategorydetails();
                    getid();
                }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    SqlConnection con14 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand check_User_Name4 = new SqlCommand("SELECT * FROM Product_category WHERE Category_id = @Category_id", con14);
                    check_User_Name4.Parameters.AddWithValue("@Category_id", dataGridView1.Rows[i].Cells[0].Value);
                    con14.Open();
                    SqlDataReader reader4 = check_User_Name4.ExecuteReader();
                    if (reader4.HasRows)
                    {
                        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cd = new SqlCommand("update Product_category set Category_name=@Category_name where Category_id='" + dataGridView1.Rows[i].Cells[0].Value + "'", con);
                        cd.Parameters.AddWithValue("@Category_name", dataGridView1.Rows[i].Cells[1].Value);
                        con.Open();
                        cd.ExecuteNonQuery();
                        con.Close();

                    }
                    con14.Close();

                }
               
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    SqlConnection con14 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand check_User_Name4 = new SqlCommand("SELECT * FROM Product_style WHERE Category_id = @Category_id", con14);
                    check_User_Name4.Parameters.AddWithValue("@Category_id", dataGridView1.Rows[i].Cells[0].Value);
                    con14.Open();
                    SqlDataReader reader4 = check_User_Name4.ExecuteReader();
                    if (reader4.HasRows)
                    {
                        SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd1 = new SqlCommand("update Product_style set category_name=@category_name where Category_id='" + dataGridView1.Rows[i].Cells[0].Value + "'", con1);
                        cmd1.Parameters.AddWithValue("@category_name", dataGridView1.Rows[i].Cells[1].Value);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                    }
                    con14.Close();

                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    SqlConnection con14 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand check_User_Name4 = new SqlCommand("SELECT * FROM  product_entry WHERE  category_id = @category_id", con14);
                    check_User_Name4.Parameters.AddWithValue("@category_id", dataGridView1.Rows[i].Cells[0].Value);
                    con14.Open();
                    SqlDataReader reader4 = check_User_Name4.ExecuteReader();
                    if (reader4.HasRows)
                    {
                        SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd2 = new SqlCommand("update product_entry set Product_Category=@Product_Category where category_id='" + dataGridView1.Rows[i].Cells[0].Value + "'", con2);
                        cmd2.Parameters.AddWithValue("@Product_Category", dataGridView1.Rows[i].Cells[1].Value);
                        con2.Open();
                        cmd2.ExecuteNonQuery();
                        con2.Close();

                    }

                    con14.Close();
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    SqlConnection con14 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand check_User_Name4 = new SqlCommand("SELECT * FROM  priceList WHERE  Category_id = @Category_id", con14);
                    check_User_Name4.Parameters.AddWithValue("@Category_id", dataGridView1.Rows[i].Cells[0].Value);
                    con14.Open();
                    SqlDataReader reader4 = check_User_Name4.ExecuteReader();
                    if (reader4.HasRows)
                    {
                        SqlConnection con3 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd3 = new SqlCommand("update priceList set Product_Category=@Product_Category where Category_id='" + dataGridView1.Rows[i].Cells[0].Value + "'", con3);
                        cmd3.Parameters.AddWithValue("@Product_category", dataGridView1.Rows[i].Cells[1].Value);
                        con3.Open();
                        cmd3.ExecuteNonQuery();
                        con3.Close();

                    }
                    con14.Close();

                }



              
                MessageBox.Show("Product category updated successfully");
               
             
                getid();
            }
            catch (Exception we)
            { }
        }

        private void frmCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                button1.PerformClick();
            }

            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Product_category WHERE Category_id = @Category_id", con10);
            check_User_Name.Parameters.AddWithValue("@Category_id", label2.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
              
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
            {
                this.dataGridView1.Rows.RemoveAt(this.rowIndex);
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        }
    }

