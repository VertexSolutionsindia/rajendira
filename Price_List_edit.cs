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
    public partial class Price_List_edit : Form
    {
        DataTable dt2;
        public Price_List_edit()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getpricelist();
        }

        private void getpricelist()
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Sno,Product_category,Product_Style,size,Box_pcs,Box_rate,box_per_rate from priceList where Name='" + comboBox1.Text + "' order by Sno asc"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dt2 = new DataTable())
                        {
                            sda.Fill(dt2);
                            dataGridView1.Columns[0].Name = "S.No";
                            dataGridView1.Columns[0].HeaderText = "S.No";
                            dataGridView1.Columns[0].DataPropertyName = "Sno";

                            dataGridView1.Columns[1].Name = "Product Category";
                            dataGridView1.Columns[1].HeaderText = "Product Category";
                            dataGridView1.Columns[1].DataPropertyName = "Product_Category";


                            dataGridView1.Columns[2].Name = "Style";
                            dataGridView1.Columns[2].HeaderText = "Style";
                            dataGridView1.Columns[2].DataPropertyName = "Product_Style";

                            dataGridView1.Columns[3].Name = "Size";
                            dataGridView1.Columns[3].HeaderText = "Size";
                            dataGridView1.Columns[3].DataPropertyName = "size";

                            dataGridView1.Columns[4].Name = "Pcs/ Box";
                            dataGridView1.Columns[4].HeaderText = "Pcs/ Box";
                            dataGridView1.Columns[4].DataPropertyName = "Box_pcs";


                            dataGridView1.Columns[5].Name = "Box Rate";
                            dataGridView1.Columns[5].HeaderText = "Box Rate";
                            dataGridView1.Columns[5].DataPropertyName = "Box_rate";

                            dataGridView1.Columns[6].Name = "Rate Per Pcs";
                            dataGridView1.Columns[6].HeaderText = "Rate Per Pcs";
                            dataGridView1.Columns[6].DataPropertyName = "box_per_rate";

                         


                            dataGridView1.DataSource = dt2;
                        }
                    }
                }
            }
        }
        bool notlastColumn = true;

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
        private void Price_List_edit_Load(object sender, EventArgs e)
        {
            getid();
            GETVALUE();
            Getproductidfor3();


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
        private void GETVALUE()
        {

           
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
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Category_name";
            comboBox2.ValueMember = "Category_id";


            con.Close();
        }

        private void getid()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select distinct  Name from priceList", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { "-Select item" };
            dt.Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";


            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int category_id = 0;
                int style_id = 0;
                int no = 0;
                DateTime date;

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    SqlConnection con14 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand check_User_Name4 = new SqlCommand("SELECT * FROM priceList WHERE Name = @Name and Sno=@Sno", con14);
                    check_User_Name4.Parameters.AddWithValue("@Name", comboBox1.Text);
                    check_User_Name4.Parameters.AddWithValue("@Sno", dataGridView1.Rows[i].Cells[0].Value);
                    con14.Open();
                    SqlDataReader reader4 = check_User_Name4.ExecuteReader();
                    if (reader4.HasRows)
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





                            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd = new SqlCommand("update priceList set Product_category=@Product_category,Product_Style=@Product_Style,size=@size,Box_pcs=@Box_pcs,Box_rate=@Box_rate,box_per_rate=@box_per_rate,Category_id=@Category_id,Style_id=@Style_id where Name='" + comboBox1.Text + "' and  Sno='" + dataGridView1.Rows[i].Cells[0].Value + "'", con);

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

                        }
                        con1.Close();

                    }
                    else
                    {
                        SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd11 = new SqlCommand("select * from priceList where Name='" + comboBox1.Text + "'", con11);
                        con11.Open();
                        SqlDataReader dr11;
                        dr11 = cmd11.ExecuteReader();
                        if (dr11.Read())
                        {
                            no = Convert.ToInt32(dr11["No"].ToString());
                            date = Convert.ToDateTime(dr11["Date"].ToString());






                            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd = new SqlCommand("insert into priceList values(@No,@Date,@Name,@Sno,@Product_category,@Product_Style,@size,@Box_pcs,@Box_rate,@box_per_rate,@Category_id,@Style_id)", con);
                            cmd.Parameters.AddWithValue("@No", no);
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@Name", comboBox1.Text);
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


                        }
                        con11.Close();



                    }
                    con14.Close();




                }
                MessageBox.Show("Price list updated sucessfully");
            }
            catch (Exception RT)
            { }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cd = new SqlCommand("delete from priceList where  Name='" + comboBox1.Text + "' and Sno='" + row.Cells[0].Value.ToString() + "'", con);
                    con.Open();
                    cd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Price list deleted sucessfully");
                getpricelist();
            }
            catch (Exception ER)
            { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
       
    

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
        }

       

        

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Price list will be deleted.", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand cd = new SqlCommand("delete from priceList where  Name='" + comboBox1.Text + "'", con);
                con.Open();
                cd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("The price List deleted successfully");
            }
            
         
            getid();
        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select  Style_id,Style_name from Product_style where category_name='" + comboBox2.Text.Trim() + "'", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "-Select item" };
            dt.Rows.InsertAt(dr, 0);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "Style_name";
            comboBox3.ValueMember = "Style_id";


            con.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  Product_Category,Product_Style,size from product_entry where Product_Category='" + comboBox2.Text + "' and Product_Style='" + comboBox3.Text + "' order by ID asc    "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt1 = new DataTable())
                        {
                            sda.Fill(dt1);



                            dataGridView2.Columns[0].Name = "Product Category";
                            dataGridView2.Columns[0].HeaderText = "Product Category";
                            dataGridView2.Columns[0].DataPropertyName = "Product_Category";


                            dataGridView2.Columns[1].Name = "Style";
                            dataGridView2.Columns[1].HeaderText = "Style";
                            dataGridView2.Columns[1].DataPropertyName = "Product_Style";

                            dataGridView2.Columns[2].Name = "Size";
                            dataGridView2.Columns[2].HeaderText = "Size";
                            dataGridView2.Columns[2].DataPropertyName = "size";


                            dataGridView2.DataSource = dt1;
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    DataRow dr = dt2.NewRow();
                    dr[0] = (Convert.ToInt32(dataGridView1.Rows.Count-1) + 1).ToString();
                    dr[1] = dataGridView2.Rows[i].Cells[0].Value;
                    dr[2] = dataGridView2.Rows[i].Cells[1].Value;
                    dr[3] = dataGridView2.Rows[i].Cells[2].Value;
                   
                    dt2.Rows.Add(dr);
                    
                    dataGridView1.DataSource = dt2;

                }
            }
            catch (Exception ER)
            { }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
                {
                    dataGridView2.Rows.RemoveAt(item.Index);
                }
            }
            catch (Exception WE)
            { }
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
                    cmd.CommandText = "Select size  from product_entry where Product_Category='" + name + "' and Product_Style='" + name1 + "'";
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
                    cmd.CommandText = "Select size from product_entry where Product_Category='" + name + "' and Product_Style='" + name1 + "'";
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
                if (dataGridView1.CurrentCell.ColumnIndex == 6)
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
                    cmd.CommandText = "Select Name from product_entry where Product_Category='" + name + "' and Product_Style='" + name1 + "'";
                    conn.Open();
                    dreader = cmd.ExecuteReader();
                    if (dreader.HasRows == true)
                    {
                        while (dreader.Read())
                            acBusIDSorce.Add(dreader["Name"].ToString());
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
            catch (Exception WE)
            { }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
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

                if (dataGridView1.CurrentCell.ColumnIndex == 3)
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
                    SqlCommand check_User_Name1 = new SqlCommand("select * from priceList WHERE size =@size", con11);
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

        private void dataGridView1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
            }
            catch (Exception WE)
            { }
        }

       

        

       

      
    }
}
