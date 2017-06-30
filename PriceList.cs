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
    public partial class PriceList : Form
    {
        bool notlastColumn = true;
        public PriceList()
        {
            InitializeComponent();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 1)
                {

                    SqlDataReader dreader;
                    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    AutoCompleteStringCollection acBusIDSorce = new AutoCompleteStringCollection();
                    cmd.CommandText = "Select Category_name from Product_category";
                    conn.Open();
                    dreader = cmd.ExecuteReader();
                    if (dreader.HasRows == true)
                    {
                        while (dreader.Read())
                            acBusIDSorce.Add(dreader["Category_name"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Data not Found");
                    }
                    dreader.Close();


                    //ComboBox txtBusID = e.Control as ComboBox;
                    TextBox Column1 = e.Control as TextBox;

                    if (Column1 != null)
                    {
                        Column1.AutoCompleteMode = AutoCompleteMode.Suggest;
                        Column1.AutoCompleteCustomSource = acBusIDSorce;
                        Column1.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    }
                }



                if (dataGridView1.CurrentCell.ColumnIndex == 2)
                {
                    int i;
                    i = dataGridView1.SelectedCells[0].RowIndex;
                    string name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    SqlDataReader dreader;
                    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    AutoCompleteStringCollection acBusIDSorce = new AutoCompleteStringCollection();
                    cmd.CommandText = "Select Style_name from Product_style where category_name='" + name + "'";
                    conn.Open();
                    dreader = cmd.ExecuteReader();
                    if (dreader.HasRows == true)
                    {
                        while (dreader.Read())
                            acBusIDSorce.Add(dreader["Style_name"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Data not Found");
                    }
                    dreader.Close();


                    //ComboBox txtBusID = e.Control as ComboBox;
                    TextBox Column1 = e.Control as TextBox;

                    if (Column1 != null)
                    {
                        Column1.AutoCompleteMode = AutoCompleteMode.Suggest;
                        Column1.AutoCompleteCustomSource = acBusIDSorce;
                        Column1.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    }
                }

                if (dataGridView1.CurrentCell.ColumnIndex == 3)
                {
                    int i;
                    i = dataGridView1.SelectedCells[0].RowIndex;
                    string name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string name1 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    SqlDataReader dreader;
                    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    AutoCompleteStringCollection acBusIDSorce = new AutoCompleteStringCollection();
                    cmd.CommandText = "Select size from product_entry where Product_Category='" + name + "' and Product_Style='" + name1 + "'";
                    conn.Open();
                    dreader = cmd.ExecuteReader();
                    if (dreader.HasRows == true)
                    {
                        while (dreader.Read())
                            acBusIDSorce.Add(dreader["size"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Data not Found");
                    }
                    dreader.Close();


                    //ComboBox txtBusID = e.Control as ComboBox;
                    TextBox Column1 = e.Control as TextBox;

                    if (Column1 != null)
                    {
                        Column1.AutoCompleteMode = AutoCompleteMode.Suggest;
                        Column1.AutoCompleteCustomSource = acBusIDSorce;
                        Column1.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    }
                }
                
                if (dataGridView1.CurrentCell.ColumnIndex == 4)
                    {
                    int i;
                    i = dataGridView1.SelectedCells[0].RowIndex;
                    string name = "SARAN";
                    string name1 = "SARAN";
                    SqlDataReader dreader;
                    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    AutoCompleteStringCollection acBusIDSorce = new AutoCompleteStringCollection();
                    cmd.CommandText = "Select size from product_entry where Product_Category!='" + name + "' and Product_Style='" + name1 + "'";
                    conn.Open();
                    dreader = cmd.ExecuteReader();
                    if (dreader.HasRows == true)
                    {
                        while (dreader.Read())
                            acBusIDSorce.Add(dreader["size"].ToString());
                    }

                    dreader.Close();


                    //ComboBox txtBusID = e.Control as ComboBox;
                    TextBox Column1 = e.Control as TextBox;

                    if (Column1 != null)
                    {
                        Column1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        Column1.AutoCompleteCustomSource = acBusIDSorce;
                        Column1.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    }
                }
                if (dataGridView1.CurrentCell.ColumnIndex == 5)
                {
                    int i;
                    i = dataGridView1.SelectedCells[0].RowIndex;
                    string name = "SARAN";
                    string name1 = "SARAN";
                    SqlDataReader dreader;
                    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    AutoCompleteStringCollection acBusIDSorce = new AutoCompleteStringCollection();
                    cmd.CommandText = "Select size  from product_entry where Product_Category!='" + name + "' and Product_Style='" + name1 + "'";
                    conn.Open();
                    dreader = cmd.ExecuteReader();
                    if (dreader.HasRows == true)
                    {
                        while (dreader.Read())
                            acBusIDSorce.Add(dreader["size"].ToString());
                    }

                    dreader.Close();


                    //ComboBox txtBusID = e.Control as ComboBox;
                    TextBox Column1 = e.Control as TextBox;

                    if (Column1 != null)
                    {
                        Column1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        Column1.AutoCompleteCustomSource = acBusIDSorce;
                        Column1.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    }
                }
            }
            catch (Exception er)
            { }

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
       
        private void PriceList_Load(object sender, EventArgs e)
        {
            getid();
            Getproductidfor3();
            

            this.KeyPreview = true;
           
        }
        private void getdetails1()
        {
          
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Product_Category,Product_Style,size from product_entry order by ID asc    "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                           

                            dataGridView2.Columns[0].Name = "Product Category";
                            dataGridView2.Columns[0].HeaderText = "Product Category";
                            dataGridView2.Columns[0].DataPropertyName = "Product_Category";


                            dataGridView2.Columns[1].Name = "Style";
                            dataGridView2.Columns[1].HeaderText = "Style";
                            dataGridView2.Columns[1].DataPropertyName = "Product_Style";

                            dataGridView2.Columns[2].Name = "Size";
                            dataGridView2.Columns[2].HeaderText = "Size";
                            dataGridView2.Columns[2].DataPropertyName = "size";


                            dataGridView2.DataSource = dt;
                        }
                    }
                }
            }
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
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Category_name";
            comboBox1.ValueMember = "Category_id";


            con.Close();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
                {
            int icolumn = dataGridView1.CurrentCell.ColumnIndex;
            int irow = dataGridView1.CurrentCell.RowIndex;
            int i = irow;
            if (keyData == Keys.Enter)
            {
               
                    if (icolumn == dataGridView1.Columns.Count - 1)
                    {
                        //dataGridView1.Rows.Add();
                        if (notlastColumn == true)
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                        }

                        dataGridView1.CurrentCell = dataGridView1[0, irow + 1];
                    }
                    else
                    {
                        dataGridView1.CurrentCell = dataGridView1[icolumn + 1, irow];
                    }
                    return true;
              
            }
            else
                if (keyData == Keys.Escape)
                {
                    this.Close();
                    return true;
                }
                }
            catch (Exception we)
            { }
            //below is for escape key return
            return base.ProcessCmdKey(ref msg, keyData);
            //below is for enter key return 
            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void getid()
        {
            int a;



            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            con1.Open();
            string query = "Select max(No) from priceList ";
            SqlCommand cmd1 = new SqlCommand(query, con1);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {

                    label4.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    label4.Text = a.ToString();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            dateTimePicker1.Text = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            getid();
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            dateTimePicker1.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                int category_id = 0;
                int style_id = 0;

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please provide valid price list name");
                }
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {


                        SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd1 = new SqlCommand("select * from Product_style where category_name='" + dataGridView1.Rows[i].Cells[1].Value + "' and Style_name='" + dataGridView1.Rows[i].Cells[2].Value + "'", con1);
                        con1.Open();
                        SqlDataReader dr1;
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            category_id = Convert.ToInt32(dr1["Category_id"].ToString());
                            style_id = Convert.ToInt32(dr1["Style_id"].ToString());
                        }


                        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd = new SqlCommand("INSERT INTO  priceList values(@No,@Date,@Name,@Sno,@Product_category,@Product_Style,@size,@Box_pcs,@Box_rate,@box_per_rate,@Category_id,@style_id)", con);
                        cmd.Parameters.AddWithValue("@No", label4.Text);
                        cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Sno", dataGridView1.Rows[i].Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Product_category", dataGridView1.Rows[i].Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Product_Style", dataGridView1.Rows[i].Cells[2].Value);
                        cmd.Parameters.AddWithValue("@size", dataGridView1.Rows[i].Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Box_pcs", dataGridView1.Rows[i].Cells[4].Value);
                        cmd.Parameters.AddWithValue("@Box_rate", dataGridView1.Rows[i].Cells[5].Value);
                        cmd.Parameters.AddWithValue("@box_per_rate", dataGridView1.Rows[i].Cells[6].Value);
                        cmd.Parameters.AddWithValue("@Category_id", category_id);
                        cmd.Parameters.AddWithValue("@Style_id", style_id);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con1.Close();
                    }
                   
                 
                    MessageBox.Show("Price list saved successfully");
                    getid();
                    dataGridView1.Rows.Clear();
                    textBox1.Text = "";
                    dateTimePicker1.Text = "";
                    Getproductidfor3();
                    getdetails1();

                }
               
            }
            catch (Exception er)
            { }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int j;
                j = dataGridView1.SelectedCells[0].RowIndex;
                if (dataGridView1.CurrentCell.ColumnIndex == 1)
                {

                    SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand check_User_Name = new SqlCommand("select * from product_entry WHERE Product_Category =@Product_Category", con10);
                    check_User_Name.Parameters.AddWithValue("@Product_Category", dataGridView1.Rows[j].Cells[1].Value.ToString());
                    con10.Open();
                    SqlDataReader reader = check_User_Name.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dataGridView1.Rows[j].Cells[1].Value = reader["Product_Category"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("Please provide correct category");
                        dataGridView1.Rows[j].Cells[1].Value = "";
                    }
                }

                if (dataGridView1.CurrentCell.ColumnIndex == 2)
                {


                    SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand check_User_Name1 = new SqlCommand("select * from product_entry WHERE Product_Style =@Product_Style", con11);
                    check_User_Name1.Parameters.AddWithValue("@Product_Style", dataGridView1.Rows[j].Cells[2].Value.ToString());
                    con11.Open();
                    SqlDataReader reader1 = check_User_Name1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        dataGridView1.Rows[j].Cells[2].Value = reader1["Product_Style"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("Please provide correct style");
                        dataGridView1.Rows[j].Cells[2].Value = "";

                    }


                }
                if (dataGridView1.CurrentCell.ColumnIndex == 3)
                {


                    SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand check_User_Name1 = new SqlCommand("select * from product_entry WHERE size =@size", con11);
                    check_User_Name1.Parameters.AddWithValue("@size", dataGridView1.Rows[j].Cells[3].Value.ToString());
                    con11.Open();
                    SqlDataReader reader1 = check_User_Name1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        dataGridView1.Rows[j].Cells[3].Value = reader1["size"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("Please provide correct size");
                        dataGridView1.Rows[j].Cells[3].Value = "";

                    }


                }
            }
            catch (Exception er)
            { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dataGridView1.SelectedCells[0].RowIndex;
                float qty = float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                float price = float.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                float total = price / qty;
                dataGridView1.Rows[i].Cells[6].Value = string.Format("{0:0.00}", total);




            }
            catch (Exception er)
            { }
        }

        private void PriceList_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control == true && e.KeyCode == Keys.X)
            {
                button1.PerformClick();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  Product_Category,Product_Style,size from product_entry where Product_Category='" + comboBox1.Text + "' and Product_Style='" + comboBox2.Text + "' order by ID asc    "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                          


                            dataGridView2.Columns[0].Name = "Product Category";
                            dataGridView2.Columns[0].HeaderText = "Product Category";
                            dataGridView2.Columns[0].DataPropertyName = "Product_Category";


                            dataGridView2.Columns[1].Name = "Style";
                            dataGridView2.Columns[1].HeaderText = "Style";
                            dataGridView2.Columns[1].DataPropertyName = "Product_Style";

                            dataGridView2.Columns[2].Name = "Size";
                            dataGridView2.Columns[2].HeaderText = "Size";
                            dataGridView2.Columns[2].DataPropertyName = "size";


                            dataGridView2.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.dataGridView1, "", dataGridView2.Rows[i].Cells[0].Value, dataGridView2.Rows[i].Cells[1].Value, dataGridView2.Rows[i].Cells[2].Value, "", "", "", "");
                    this.dataGridView1.Rows.Add(row);
                }
            }
            catch (Exception ER)
            { }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
                {
                    dataGridView2.Rows.RemoveAt(item.Index);
                }
            }
            catch (Exception ER)
            { }
        }
    }
}
