using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class frmsalesinvoice : Form
    {
        public static string company_name = "";
        public static string address = "";
        public static string SETVALUE = "";
        public frmsalesinvoice()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

               
            }
            catch (Exception we)
            { }
        }

        private void frmsalesinvoice_Load(object sender, EventArgs e)
        {
            int value = 1;
            SqlConnection con112 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name1 = new SqlCommand("select * from currentfinancialyear WHERE no =@no", con112);
            check_User_Name1.Parameters.AddWithValue("@no", value);
            con112.Open();
            SqlDataReader reader1 = check_User_Name1.ExecuteReader();
            if (reader1.Read())
            {
                string financial = reader1["financial_year"].ToString();
                label17.Text = financial;
            }
            con112.Close();
            SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            con11.Open();
            string query1 = "Select * from condition where no=1 ";
            SqlCommand cmd11 = new SqlCommand(query1, con11);
            SqlDataReader dr11 = cmd11.ExecuteReader();
            if (dr11.Read())
            {
               
                richTextBox1.Text = dr11["condition"].ToString();

            }

            label15.Enabled = false;
            textBox9.Enabled = false;
            if (invoice_report_details.SetValueForText1 != "")
            {
                int value1 = 1;
                SqlConnection con111 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name11 = new SqlCommand("select * from currentfinancialyear WHERE no =@no", con111);
                check_User_Name11.Parameters.AddWithValue("@no", value1);
                con111.Open();
                SqlDataReader reader11 = check_User_Name11.ExecuteReader();
                if (reader11.Read())
                {
                    string financial = reader11["financial_year"].ToString();
                    SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd1 = new SqlCommand("Select * from invoice where invoice_no='" + invoice_report_details.SetValueForText1 + "' and financial_year='" + financial + "'", con1);
                    SqlDataReader dr1;
                    con1.Open();
                    dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {


                        SqlConnection con1111 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        con1111.Open();
                        string query111 = "Select *  from customer_details where company_name='" + invoice_report_details.SetValueForText2 + "'  ";
                        SqlCommand cmd111 = new SqlCommand(query111, con1111);
                        SqlDataReader dr111 = cmd111.ExecuteReader();
                        if (dr111.Read())
                        {



                            textBox2.Text = dr111["nick_name"].ToString();

                        }

                        label5.Text = dr1["Invoice_no"].ToString();
                        dateTimePicker2.Text = dr1["Date"].ToString();

                        textBox6.Text = dr1["Goods_to"].ToString();
                        textBox4.Text = dr1["No_of_Bdl"].ToString();
                        comboBox1.Text = dr1["Transport"].ToString();
                        comboBox2.Text = dr1["PriceList"].ToString();
                        comboBox5.Text = dr1["Document_Through"].ToString();
                        textBox9.Text = dr1["Wright"].ToString();
                        textBox10.Text = dr1["Lr_No"].ToString();
                        dateTimePicker3.Text = dr1["Lr_date"].ToString();
                        textBox3.Text = dr1["Other_charge_name"].ToString();
                        textBox11.Text = dr1["Other_charge_percentage"].ToString();
                        textBox7.Text = dr1["Total_Pcs"].ToString();
                        textBox8.Text = dr1["Total_amount"].ToString();
                        textBox12.Text = dr1["Other_charge_amount"].ToString();
                        comboBox4.Text = dr1["Tax_percentage"].ToString();
                        textBox14.Text = dr1["Tax_amount"].ToString();
                        textBox15.Text = dr1["Sub_tatal"].ToString();
                        textBox16.Text = dr1["Round_off"].ToString();
                        textBox17.Text = dr1["grand_total"].ToString();
                        textBox1.Text = dr1["tin_no"].ToString();
                        comboBox3.Text = dr1["Tax_percentage"].ToString();
                        con1111.Close();




                        GETEDITPRODUCT();

                    }
                    con1.Close();
                }
                con11.Close();

                }
                else
                {
                    getlink();

                }
          




            this.KeyPreview = true;
          

            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            textBox2.AutoCompleteCustomSource = DataCollection;

            comboBox3.Text = "Select tax type";

        }

        private void GETEDITPRODUCT()
        {
             int value1 = 1;
            SqlConnection con111 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name11 = new SqlCommand("select * from currentfinancialyear WHERE no =@no", con111);
                    check_User_Name11.Parameters.AddWithValue("@no", value1);
                    con111.Open();
                    SqlDataReader reader11 = check_User_Name11.ExecuteReader();
                    if (reader11.Read())
                    {
                        string financial = reader11["financial_year"].ToString();

                        string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT Product_category,style,Size,pcs,Per_pcs_rate,Amount  from invoice_product_table_final where invoice_no='" + invoice_report_details.SetValueForText1 + "' and financial_year='" + financial + "'"))
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {
                                    cmd.Connection = con;
                                    sda.SelectCommand = cmd;
                                    using (DataTable dt = new DataTable())
                                    {
                                        sda.Fill(dt);



                                        dataGridView1.Columns[1].Name = "Product group";
                                        dataGridView1.Columns[1].HeaderText = "Product group";
                                        dataGridView1.Columns[1].DataPropertyName = "Product_category";


                                        dataGridView1.Columns[2].Name = "product style ";
                                        dataGridView1.Columns[2].HeaderText = "product style ";
                                        dataGridView1.Columns[2].DataPropertyName = "style";


                                        dataGridView1.Columns[3].Name = "Size";
                                        dataGridView1.Columns[3].HeaderText = "Size";
                                        dataGridView1.Columns[3].DataPropertyName = "Size";

                                        dataGridView1.Columns[4].Name = "Pcs";
                                        dataGridView1.Columns[4].HeaderText = "Pcs";
                                        dataGridView1.Columns[4].DataPropertyName = "pcs";

                                        dataGridView1.Columns[5].Name = "Rate";
                                        dataGridView1.Columns[5].HeaderText = "Rate";
                                        dataGridView1.Columns[5].DataPropertyName = "Per_pcs_rate";


                                        dataGridView1.Columns[6].Name = "Amount";
                                        dataGridView1.Columns[6].HeaderText = "Amount";
                                        dataGridView1.Columns[6].DataPropertyName = "Amount";




                                        dataGridView1.DataSource = dt;
                                    }
                                }
                            }
                        }
                    }
                    con111.Close();
        }

        public void getlink()
        {
           
            gettransport();
            getprice();
            getid();
        }

        private void getprice()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);

            comboBox4.Text = "select";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select distinct  Name from priceList", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { "-Select item" };
            dt.Rows.InsertAt(dr, 0);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Name";


            con.Close();
        }
        public void gettransport()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select  * from transport", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "-Select item" };
            dt.Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "transport_name";
            comboBox1.ValueMember = "ID";

            con.Close();
        }
        private void getid()
        {
            int a;

             int value = 1;
            SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name1 = new SqlCommand("select * from currentfinancialyear WHERE no =@no", con11);
                    check_User_Name1.Parameters.AddWithValue("@no", value);
                    con11.Open();
                    SqlDataReader reader1 = check_User_Name1.ExecuteReader();
                    if (reader1.Read())
                    {

                        string financial = reader1["financial_year"].ToString();

                        SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        con1.Open();
                        string query = "Select max(Invoice_no) from invoice where financial_year='" + financial + "' ";
                        SqlCommand cmd1 = new SqlCommand(query, con1);
                        SqlDataReader dr = cmd1.ExecuteReader();
                        if (dr.Read())
                        {
                            string val = dr[0].ToString();
                            if (val == "")
                            {

                                label5.Text = "1";
                            }
                            else
                            {
                                a = Convert.ToInt32(dr[0].ToString());
                                a = a + 1;
                                label5.Text = a.ToString();
                            }
                        }
                    }
                    con11.Close();
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
                string sql = "SELECT DISTINCT [nick_name] FROM [customer_details]";
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
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
                if (comboBox2.Text == "-Select item")
                {
                    MessageBox.Show("Please select price list");
                }
                else
                {
                    if (dataGridView1.CurrentCell.ColumnIndex == 1)
                    {


                        SqlDataReader dreader;
                        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        AutoCompleteStringCollection acBusIDSorce = new AutoCompleteStringCollection();
                        cmd.CommandText = "Select DISTINCT Product_category  from priceList where Name='" + comboBox2.Text + "'";
                        conn.Open();
                        dreader = cmd.ExecuteReader();
                        if (dreader.HasRows == true)
                        {
                            while (dreader.Read())
                                acBusIDSorce.Add(dreader["Product_category"].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Data not Found");
                        }
                        dreader.Close();


                        //ComboBox txtBusID = e.Control as ComboBox;
                        TextBox Column2 = e.Control as TextBox;

                        if (Column2 != null)
                        {
                            Column2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            Column2.AutoCompleteCustomSource = acBusIDSorce;
                            Column2.AutoCompleteSource = AutoCompleteSource.CustomSource;

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
                        AutoCompleteStringCollection acBusIDSorce2 = new AutoCompleteStringCollection();
                        cmd.CommandText = "Select DISTINCT Product_Style from priceList where Name='" + comboBox2.Text + "' and Product_category='" + name + "'";
                        conn.Open();
                        dreader = cmd.ExecuteReader();
                        if (dreader.HasRows == true)
                        {
                            while (dreader.Read())
                                acBusIDSorce2.Add(dreader["Product_Style"].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Data not Found");
                        }
                        dreader.Close();


                        //ComboBox txtBusID = e.Control as ComboBox;
                        TextBox Column3 = e.Control as TextBox;

                        if (Column3 != null)
                        {
                            Column3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            Column3.AutoCompleteCustomSource = acBusIDSorce2;
                            Column3.AutoCompleteSource = AutoCompleteSource.CustomSource;

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
                        AutoCompleteStringCollection acBusIDSorce1 = new AutoCompleteStringCollection();
                        cmd.CommandText = "Select size from priceList where Name='" + comboBox2.Text + "' and Product_category='" + name + "' and Product_Style='" + name1 + "'";
                        conn.Open();
                        dreader = cmd.ExecuteReader();
                        if (dreader.HasRows == true)
                        {
                            while (dreader.Read())
                                acBusIDSorce1.Add(dreader["size"].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Data not Found");
                        }
                        dreader.Close();


                        //ComboBox txtBusID = e.Control as ComboBox;
                        TextBox Column4 = e.Control as TextBox;

                        if (Column4 != null)
                        {
                            Column4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            Column4.AutoCompleteCustomSource = acBusIDSorce1;
                            Column4.AutoCompleteSource = AutoCompleteSource.CustomSource;

                        }
                    }
                    if (dataGridView1.CurrentCell.ColumnIndex == 4)
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
                        AutoCompleteStringCollection acBusIDSorce1 = new AutoCompleteStringCollection();
                        cmd.CommandText = "Select Name from priceList where Name!='" + comboBox2.Text + "' and Product_category!='" + name + "' and Product_Style!='" + name1 + "'";
                        conn.Open();
                        dreader = cmd.ExecuteReader();
                        if (dreader.HasRows == true)
                        {
                            while (dreader.Read())
                                acBusIDSorce1.Add(dreader["Name"].ToString());
                        }

                        dreader.Close();


                        //ComboBox txtBusID = e.Control as ComboBox;
                        TextBox Column4 = e.Control as TextBox;

                        if (Column4 != null)
                        {
                            Column4.AutoCompleteMode = AutoCompleteMode.Suggest;
                            Column4.AutoCompleteCustomSource = acBusIDSorce1;
                            Column4.AutoCompleteSource = AutoCompleteSource.CustomSource;

                        }
                    }
                    if (dataGridView1.CurrentCell.ColumnIndex == 5)
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
                        AutoCompleteStringCollection acBusIDSorce1 = new AutoCompleteStringCollection();
                        cmd.CommandText = "Select Name from priceList where Name!='" + comboBox2.Text + "' and Product_category!='" + name + "' and Product_Style!='" + name1 + "'";
                        conn.Open();
                        dreader = cmd.ExecuteReader();
                        if (dreader.HasRows == true)
                        {
                            while (dreader.Read())
                                acBusIDSorce1.Add(dreader["Name"].ToString());
                        }

                        dreader.Close();


                        //ComboBox txtBusID = e.Control as ComboBox;
                        TextBox Column4 = e.Control as TextBox;

                        if (Column4 != null)
                        {
                            Column4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            Column4.AutoCompleteCustomSource = acBusIDSorce1;
                            Column4.AutoCompleteSource = AutoCompleteSource.CustomSource;

                        }
                    }




                }
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    SqlCommand check_User_Name = new SqlCommand("select * from priceList WHERE Product_category =@Product_category", con10);
                    check_User_Name.Parameters.AddWithValue("@Product_category", dataGridView1.Rows[j].Cells[1].Value.ToString());
                    con10.Open();
                    SqlDataReader reader = check_User_Name.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dataGridView1.Rows[j].Cells[1].Value = reader["Product_category"].ToString();

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
                    SqlCommand check_User_Name1 = new SqlCommand("select * from priceList WHERE Product_Style =@Product_Style", con11);
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


                string name = "";
                string name1 = "";
                string size = "";
                int i;
                i = dataGridView1.SelectedCells[0].RowIndex;
                name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                name1 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                size = dataGridView1.Rows[i].Cells[3].Value.ToString();
                SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                con1.Open();
                string query = "Select *  from priceList where Name='" + comboBox2.Text + "' and Product_category='" + name + "' and Product_Style='" + name1 + "' and size='" + size + "' ";
                SqlCommand cmd1 = new SqlCommand(query, con1);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {


                    dataGridView1.Rows[i].Cells[5].Value = dr["box_per_rate"].ToString();
                  

                }

              


              


              



               

            }
            catch (Exception er)
            { }
            
           
            

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
          
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

            getprocedurevalue();
        }

        private void getprocedurevalue()
        {
            try
            {
                float DIS = 0;

                float total = 0;
                if (textBox11.Text == "")
                {
                    DIS = 0;
                }
                else
                {
                    DIS = float.Parse(textBox11.Text);
                }


                total = float.Parse(textBox8.Text);
                float S = float.Parse(string.Format("{0:0.00}", (total + DIS)).ToString());

                textBox12.Text = string.Format("{0:0.00}", (S)).ToString();


                if (textBox11.Text == "")
                {
                    textBox12.Text = "";

                }
            }
            catch (Exception rt)
            { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            con1.Open();
            string query = "Select *  from customer_details where nick_name='" + textBox2.Text + "'  ";
            SqlCommand cmd1 = new SqlCommand(query, con1);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {


                comboBox2.Text = dr["invoice_price_list"].ToString();
                textBox6.Text = dr["location"].ToString();
                textBox1.Text = dr["tin_no"].ToString();
                company_name = dr["company_name"].ToString();
                address = dr["company_address"].ToString();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            gettax();
          
        }

        private void gettax()
        {
            try
            {


                float tax = float.Parse(comboBox4.Text);
                float total = float.Parse(textBox12.Text);
                float A = float.Parse(string.Format("{0:0.00}", (total * tax / 100)).ToString());

                textBox14.Text = string.Format("{0:0.00}", (A)).ToString();
                textBox15.Text = string.Format("{0:0.00}", (A + total)).ToString();
                textBox17.Text = string.Format("{0:0.00}",Math.Round( (A + total))).ToString();

                float value1 = float.Parse(textBox15.Text.ToString());
                float value2 = float.Parse(textBox17.Text.ToString());
                float value3 = float.Parse(string.Format("{0:0.00}", (value1 - value2)));
                textBox16.Text = string.Format("{0:0.00}", (value3)).ToString();

            }
            catch (Exception es)
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

             int a;
          
            string cst="";
            string tin="";
            string mobile_no = "";
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please provide valid buyer");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Please provide valid goods to");
            }
            else if (comboBox2.Text == "-Select item")
            {
                MessageBox.Show("Please select valid price list");
            }
            else if(comboBox1.Text=="-Select item")
            {
                MessageBox.Show("Please select valid transport");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Please enter valid no of bundles");
            }
            else if (comboBox4.Text == "select")
            {
                MessageBox.Show("Please select valid vat");
            }
            else
            {

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    int value12 = 1;
                    SqlConnection con111 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand check_User_Name1 = new SqlCommand("select * from currentfinancialyear WHERE no =@no", con111);
                    check_User_Name1.Parameters.AddWithValue("@no", value12);
                    con111.Open();
                    SqlDataReader reader1 = check_User_Name1.ExecuteReader();
                    if (reader1.Read())
                    {
                        string financial = reader1["financial_year"].ToString();


                        int a1 = 1;
                        SqlConnection con14 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand check_User_Name4 = new SqlCommand("SELECT * FROM invoice_product_table WHERE Invoice_no = @Invoice_no and S_no=@S_no and financial_year=@financial_year", con14);
                        check_User_Name4.Parameters.AddWithValue("@Invoice_no", label5.Text);
                        if (dataGridView1.Rows[i].Cells[0].Value == null)
                        {
                            check_User_Name4.Parameters.AddWithValue("@S_no", a1);
                        }
                        else
                        {
                            check_User_Name4.Parameters.AddWithValue("@S_no", dataGridView1.Rows[i].Cells[0].Value);
                        }
                        check_User_Name4.Parameters.AddWithValue("@financial_year", financial);




                        con14.Open();
                        SqlDataReader reader4 = check_User_Name4.ExecuteReader();
                        if (reader4.HasRows)
                        {



                            SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd11 = new SqlCommand("update sales_product_table set Product_category=@Product_category,style=@style,Size=@Size,pcs=@pcs,Per_pcs_rate=@Per_pcs_rate,Amount=@Amount where Invoice_no='" + label5.Text + "' and S_no='" + dataGridView1.Rows[i].Cells[0].Value + "' AND financial_year='"+label17.Text+"'", con11);

                            cmd11.Parameters.AddWithValue("@Product_category", dataGridView1.Rows[i].Cells[1].Value);
                            cmd11.Parameters.AddWithValue("@style", dataGridView1.Rows[i].Cells[2].Value);
                            string value = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            if (value == "Zero")
                            {
                                string size = "0";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "One")
                            {
                                string size = "1";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "Two")
                            {
                                string size = "2";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "Three")
                            {
                                string size = "3";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "Four")
                            {
                                string size = "4";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "Small")
                            {
                                string size = "S";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "Large")
                            {
                                string size = "L";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "Medium")
                            {
                                string size = "M";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "LL")
                            {
                                string size = "LL";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "XL")
                            {
                                string size = "XL";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "XXL")
                            {
                                string size = "XXL";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                           
                            cmd11.Parameters.AddWithValue("@pcs", dataGridView1.Rows[i].Cells[4].Value);
                            cmd11.Parameters.AddWithValue("@Per_pcs_rate", dataGridView1.Rows[i].Cells[5].Value);
                            cmd11.Parameters.AddWithValue("@Amount", dataGridView1.Rows[i].Cells[6].Value);
                            con11.Open();
                            cmd11.ExecuteNonQuery();
                            con11.Close();


                            SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd12 = new SqlCommand("update invoice_product_table_final set Product_category=@Product_category,style=@style,Size=@Size,pcs=@pcs,Per_pcs_rate=@Per_pcs_rate,Amount=@Amount where Invoice_no='" + label5.Text + "' and S_no='" + dataGridView1.Rows[i].Cells[0].Value + "'  and financial_year='" + label17.Text + "'", con12);

                            cmd12.Parameters.AddWithValue("@Product_category", dataGridView1.Rows[i].Cells[1].Value);
                            cmd12.Parameters.AddWithValue("@style", dataGridView1.Rows[i].Cells[2].Value);


                            cmd12.Parameters.AddWithValue("@Size", dataGridView1.Rows[i].Cells[3].Value);
                            cmd12.Parameters.AddWithValue("@pcs", dataGridView1.Rows[i].Cells[4].Value);
                            cmd12.Parameters.AddWithValue("@Per_pcs_rate", dataGridView1.Rows[i].Cells[5].Value);
                            cmd12.Parameters.AddWithValue("@Amount", dataGridView1.Rows[i].Cells[6].Value);
                            con12.Open();
                            cmd12.ExecuteNonQuery();
                            con12.Close();


                        }
                        else
                        {
                            SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd11 = new SqlCommand("insert into invoice_product_table values(@invoice_no,@S_no,@Product_category,@style,@Size,@pcs,@Per_pcs_rate,@Amount,@financial_year)", con11);
                            cmd11.Parameters.AddWithValue("@invoice_no", label5.Text);
                            cmd11.Parameters.AddWithValue("@S_no", dataGridView1.Rows[i].Cells[0].Value);
                            cmd11.Parameters.AddWithValue("@Product_category", dataGridView1.Rows[i].Cells[1].Value);
                            cmd11.Parameters.AddWithValue("@style", dataGridView1.Rows[i].Cells[2].Value);
                            string value = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            if (value == "Zero")
                            {
                                string size = "0";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "One")
                            {
                                string size = "1";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "Two")
                            {
                                string size = "2";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "Three")
                            {
                                string size = "3";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "Four")
                            {
                                string size = "4";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "Small")
                            {
                                string size = "S";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "Large")
                            {
                                string size = "L";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "Medium")
                            {
                                string size = "M";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "LL")
                            {
                                string size = "LL";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "XL")
                            {
                                string size = "XL";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }
                            if (value == "XXL")
                            {
                                string size = "XXL";
                                cmd11.Parameters.AddWithValue("@Size", size);
                            }

                            cmd11.Parameters.AddWithValue("@pcs", dataGridView1.Rows[i].Cells[4].Value);
                            cmd11.Parameters.AddWithValue("@Per_pcs_rate", dataGridView1.Rows[i].Cells[5].Value);
                            cmd11.Parameters.AddWithValue("@Amount", dataGridView1.Rows[i].Cells[6].Value);
                            cmd11.Parameters.AddWithValue("@financial_year", label17.Text);
                            con11.Open();
                            cmd11.ExecuteNonQuery();
                            con11.Close();


                            SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd12 = new SqlCommand("insert into invoice_product_table_final values(@invoice_no,@S_no,@Product_category,@style,@Size,@pcs,@Per_pcs_rate,@Amount,@financial_year)", con12);
                            cmd12.Parameters.AddWithValue("@invoice_no", label5.Text);
                            cmd12.Parameters.AddWithValue("@S_no", dataGridView1.Rows[i].Cells[0].Value);
                            cmd12.Parameters.AddWithValue("@Product_category", dataGridView1.Rows[i].Cells[1].Value);
                            cmd12.Parameters.AddWithValue("@style", dataGridView1.Rows[i].Cells[2].Value);


                            cmd12.Parameters.AddWithValue("@Size", dataGridView1.Rows[i].Cells[3].Value);

                            cmd12.Parameters.AddWithValue("@pcs", dataGridView1.Rows[i].Cells[4].Value);
                            cmd12.Parameters.AddWithValue("@Per_pcs_rate", dataGridView1.Rows[i].Cells[5].Value);
                            cmd12.Parameters.AddWithValue("@Amount", dataGridView1.Rows[i].Cells[6].Value);
                            cmd12.Parameters.AddWithValue("@financial_year", label17.Text);
                            con12.Open();
                            cmd12.ExecuteNonQuery();
                            con12.Close();

                        }
                        con14.Close();


                    }
                    con111.Close();

                }



                SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                con1.Open();
                string query = "Select * from customer_details where nick_name='" + textBox2.Text + "' ";
                SqlCommand cmd1 = new SqlCommand(query, con1);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {


                    address = dr["company_address"].ToString();
                    tin = dr["tin_no"].ToString();
                    cst = dr["cst_no"].ToString();
                    mobile_no = dr["Mobile_no"].ToString();

                }
                con1.Close();
                string VALUE1="";
                if (comboBox3.Text == "CST")
                {
                    if (comboBox4.Text == "1" || comboBox4.Text == "5")
                    {
                        VALUE1 = "CST@ " + comboBox4.Text + "%";
                    }
                }

                if (comboBox3.Text == "VAT")
                {
                    if (comboBox4.Text == "5")
                    {
                        VALUE1 = "VAT@ " + comboBox4.Text + "%";
                    }
                }


                int value121 = 1;
                    SqlConnection con1111 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand check_User_Name11= new SqlCommand("select * from currentfinancialyear WHERE no =@no", con1111);
                    check_User_Name11.Parameters.AddWithValue("@no", value121);
                    con1111.Open();
                    SqlDataReader reader11 = check_User_Name11.ExecuteReader();
                    if (reader11.Read())
                    {
                        string financial = reader11["financial_year"].ToString();
                        SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand check_User_Name = new SqlCommand("SELECT * FROM invoice WHERE Invoice_no = @Invoice_no AND financial_year=@financial_year", con10);
                        check_User_Name.Parameters.AddWithValue("@Invoice_no", label5.Text);
                        check_User_Name.Parameters.AddWithValue("@financial_year", financial);
                        con10.Open();
                        SqlDataReader reader = check_User_Name.ExecuteReader();
                        if (reader.HasRows)
                        {
                            if (comboBox3.Text == "Select tax type")
                            {
                                MessageBox.Show("Please select valid vat");
                            }
                            else
                            {

                                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                                SqlCommand cmd = new SqlCommand("update invoice set Date=@Date,Buyer=@Buyer,Address=@Address,tin_no=@tin_no,cst_no=@cst_no,Goods_to=@Goods_to,No_of_Bdl=@No_of_Bdl,Transport=@Transport,PriceList=@PriceList,Document_Through=@Document_Through,Wright=@Wright,Lr_No=@Lr_No,Lr_date=@Lr_date,Total_Pcs=@Total_Pcs,Total_amount=@Total_amount,Other_charge_name=@Other_charge_name,Other_charge_percentage=@Other_charge_percentage,Other_charge_amount=@Other_charge_amount,Tax_percentage=@Tax_percentage,Tax_amount=@Tax_amount,Sub_tatal=@Sub_tatal,Round_off=@Round_off,grand_total=@grand_total,comment=@comment where Invoice_no='" + label5.Text + "' and financial_year='" + label17.Text + "' ", con);

                                cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(dateTimePicker2.Value.Date));
                                cmd.Parameters.AddWithValue("@Buyer", company_name);
                                cmd.Parameters.AddWithValue("@Address", address);
                                cmd.Parameters.AddWithValue("@tin_no", textBox1.Text);
                                cmd.Parameters.AddWithValue("@cst_no", cst);
                                cmd.Parameters.AddWithValue("@Goods_to", textBox6.Text);
                                cmd.Parameters.AddWithValue("@No_of_Bdl", textBox4.Text);

                                cmd.Parameters.AddWithValue("@Transport", comboBox1.Text);
                                cmd.Parameters.AddWithValue("@PriceList", comboBox2.Text);
                                cmd.Parameters.AddWithValue("@Document_Through", comboBox5.Text);
                                cmd.Parameters.AddWithValue("@Wright", textBox9.Text);
                                cmd.Parameters.AddWithValue("@Lr_No", textBox10.Text);
                                cmd.Parameters.AddWithValue("@Lr_date", Convert.ToDateTime(dateTimePicker3.Value.Date));
                                cmd.Parameters.AddWithValue("@Total_Pcs", textBox7.Text);
                                cmd.Parameters.AddWithValue("@Total_amount", textBox8.Text);
                                cmd.Parameters.AddWithValue("@Other_charge_name", textBox3.Text);
                                cmd.Parameters.AddWithValue("@Other_charge_percentage", textBox11.Text);
                                cmd.Parameters.AddWithValue("@Other_charge_amount", textBox12.Text);

                                cmd.Parameters.AddWithValue("@Tax_percentage", VALUE1);

                                cmd.Parameters.AddWithValue("@Tax_amount", textBox14.Text);
                                cmd.Parameters.AddWithValue("@Sub_tatal", textBox15.Text);
                                cmd.Parameters.AddWithValue("@Round_off", textBox16.Text);
                                cmd.Parameters.AddWithValue("@grand_total", textBox17.Text);
                                cmd.Parameters.AddWithValue("@comment", richTextBox1.Text);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Invoice updated successfully");
                                SETVALUE = label5.Text;
                                Invoice_report I = new Invoice_report();
                                I.Show();

                                comboBox2.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                DataTable dt = (DataTable)dataGridView1.DataSource;
                                if (dt != null)
                                    dt.Clear();




                                textBox6.Text = "";
                                textBox7.Text = "";
                                textBox8.Text = "";
                                textBox9.Text = "";
                                textBox10.Text = "";
                                textBox11.Text = "";
                                textBox12.Text = "";

                                textBox14.Text = "";
                                textBox15.Text = "";
                                textBox16.Text = "";
                                comboBox1.Text = "";


                                comboBox4.Text = "";
                                comboBox5.Text = "";

                                getid();
                                gettransport();
                                getprice();

                                invoice_report_details.SetValueForText1 = "";
                            }


                        }
                        else
                        {





                            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd = new SqlCommand("insert into invoice values(@Invoice_no,@Date,@Buyer,@Address,@tin_no,@cst_no,@Goods_to,@No_of_Bdl,@Transport,@PriceList,@Document_Through,@Wright,@Lr_No,@Lr_date,@Total_Pcs,@Total_amount,@Other_charge_name,@Other_charge_percentage,@Other_charge_amount,@Tax_percentage,@Tax_amount,@Sub_tatal,@Round_off,@grand_total,@comment,@financial_year)", con);
                            cmd.Parameters.AddWithValue("@Invoice_no", label5.Text);
                            cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(dateTimePicker2.Value.Date));
                            cmd.Parameters.AddWithValue("@Buyer", company_name);
                            cmd.Parameters.AddWithValue("@Address", address);
                            cmd.Parameters.AddWithValue("@tin_no", textBox1.Text);
                            cmd.Parameters.AddWithValue("@cst_no", cst);
                            cmd.Parameters.AddWithValue("@Goods_to", textBox6.Text);
                            cmd.Parameters.AddWithValue("@No_of_Bdl", textBox4.Text);

                            cmd.Parameters.AddWithValue("@Transport", comboBox1.Text);
                            cmd.Parameters.AddWithValue("@PriceList", comboBox2.Text);
                            cmd.Parameters.AddWithValue("@Document_Through", comboBox5.Text);
                            cmd.Parameters.AddWithValue("@Wright", textBox9.Text);
                            cmd.Parameters.AddWithValue("@Lr_No", textBox10.Text);
                            cmd.Parameters.AddWithValue("@Lr_date", Convert.ToDateTime(dateTimePicker3.Value.Date));
                            cmd.Parameters.AddWithValue("@Total_Pcs", textBox7.Text);
                            cmd.Parameters.AddWithValue("@Total_amount", textBox8.Text);
                            cmd.Parameters.AddWithValue("@Other_charge_name", textBox3.Text);
                            cmd.Parameters.AddWithValue("@Other_charge_percentage", textBox11.Text);
                            cmd.Parameters.AddWithValue("@Other_charge_amount", textBox12.Text);
                            cmd.Parameters.AddWithValue("@Tax_percentage", VALUE1);
                            cmd.Parameters.AddWithValue("@Tax_amount", textBox14.Text);
                            cmd.Parameters.AddWithValue("@Sub_tatal", textBox15.Text);
                            cmd.Parameters.AddWithValue("@Round_off", textBox16.Text);
                            cmd.Parameters.AddWithValue("@grand_total", textBox17.Text);
                            cmd.Parameters.AddWithValue("@comment", richTextBox1.Text);
                            cmd.Parameters.AddWithValue("@financial_year", label17.Text);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Invoice created successfully");
                            comboBox2.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            dataGridView1.Rows.Clear();


                            textBox6.Text = "";
                            textBox7.Text = "";
                            textBox8.Text = "";
                            textBox9.Text = "";
                            textBox10.Text = "";
                            textBox11.Text = "";
                            textBox12.Text = "";

                            textBox14.Text = "";
                            textBox15.Text = "";
                            textBox16.Text = "";
                            comboBox1.Text = "";

                            textBox1.Text = "";
                            comboBox4.Text = "";
                            comboBox5.Text = "";
                            SETVALUE = label5.Text;
                            Invoice_report I = new Invoice_report();
                            I.Show();
                            getid();
                            gettransport();
                            getprice();



                        }

                        con10.Close();
                    }
                    con1111.Close();
               





            }

           
           

       
           
          

           
            
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            transport t = new transport();
            t.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            invoice_report_details.SetValueForText1 = "";
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int i;
                i = dataGridView1.SelectedCells[0].RowIndex;
                float qty = float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                float price = float.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                float total = price * qty;
                dataGridView1.Rows[i].Cells[6].Value = String.Format("{0:0.00}", total);




           



            decimal sum = 0;
            for (int j = 0; j < dataGridView1.Rows.Count; ++j)
            {

                sum += Convert.ToDecimal(dataGridView1.Rows[j].Cells[4].Value);
            }




            textBox7.Text = sum.ToString();

            decimal sum1 = 0;
            for (int j = 0; j < dataGridView1.Rows.Count; ++j)
            {

                sum1 += Convert.ToDecimal(dataGridView1.Rows[j].Cells[6].Value);
            }




            textBox8.Text = sum1.ToString();
            textBox12.Text = sum1.ToString();
            gettax();
          
            }
            catch (Exception er)
            { }

        }

        private void frmsalesinvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                button5.PerformClick();
            }

            if (e.KeyCode == Keys.F1)
            {
                button4.PerformClick();
            }
        }

        private void button4_Click_3(object sender, EventArgs e)
        {
            invoice_report_details i = new invoice_report_details();
            i.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            DataTable dt = (DataTable)dataGridView1.DataSource;
            if (dt != null)
                dt.Clear();




            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            comboBox1.Text = "";


            comboBox4.Text = "";
            comboBox5.Text = "";

            getid();
            gettransport();
            getprice();
            
            invoice_report_details.SetValueForText1 = "";

        }

        private void frmsalesinvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            invoice_report_details.SetValueForText1 = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Invoice product will be deleted.", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cd = new SqlCommand("delete from invoice_product_table where invoice_no='" + label5.Text + "' and  S_no='" + row.Cells[0].Value.ToString() + "'", con);
                        con.Open();
                        cd.ExecuteNonQuery();
                        con.Close();


                        SqlConnection con13 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cd13 = new SqlCommand("delete from invoice_product_table_final where invoice_no='" + label5.Text + "' and  S_no='" + row.Cells[0].Value.ToString() + "'", con13);
                        con13.Open();
                        cd13.ExecuteNonQuery();
                        con13.Close();

                    }
                    MessageBox.Show("Invoice product deleted successfully");
                    GETEDITPRODUCT();

                }














                decimal sum = 0;
                for (int j = 0; j < dataGridView1.Rows.Count; ++j)
                {

                    sum += Convert.ToDecimal(dataGridView1.Rows[j].Cells[4].Value);

                }




                textBox7.Text = sum.ToString();

                decimal sum1 = 0;
                for (int j = 0; j < dataGridView1.Rows.Count; ++j)
                {

                    sum1 += Convert.ToDecimal(dataGridView1.Rows[j].Cells[6].Value);
                }




                textBox8.Text = sum1.ToString();
                textBox12.Text = sum1.ToString();










            }
            catch (Exception WE)
            { }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            gettransport();
            getprice();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
            }
            catch (Exception ER)
            { }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    textBox4.Text = "";
                    textBox4.Text.Remove(textBox4.Text.Length - 1);
                }





            }
            catch (Exception fr)
            { }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(comboBox3.Text=="CST")
            {
                comboBox4.Items.Clear();
              
                comboBox4.Items.Add("1");
                comboBox4.Items.Add("5");
               
            }
            if (comboBox3.Text == "Select tax type")
            {
                comboBox4.Items.Clear();
                comboBox3.Text = "";
               
            }
            if (comboBox3.Text == "VAT")
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add("5");
              
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
                e.Handled = true;
            }
        }
    }
}
