using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1
{
    
    public partial class Sales_invoice : Form
    {
        public static string company_name = "";
        public static string address = "";
        public static string SETVALUE = "";
        public Sales_invoice()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
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
                string query = "Select *  from priceList where Name='" + comboBox1.Text + "' and Product_category='" + name + "' and Product_Style='" + name1 + "' and size='" + size + "' ";
                SqlCommand cmd1 = new SqlCommand(query, con1);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {


                    dataGridView1.Rows[i].Cells[6].Value = dr["box_per_rate"].ToString();


                }


               







               


            }
            catch (Exception er)
            { }
            
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (comboBox1.Text == "-Select item")
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
                    cmd.CommandText = "Select DISTINCT Product_category  from priceList where Name='" + comboBox1.Text + "'";
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
                    cmd.CommandText = "Select DISTINCT Product_Style from priceList where Name='" + comboBox1.Text + "' and Product_category='" + name + "'";
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
                    cmd.CommandText = "Select size from priceList where Name='" + comboBox1.Text + "' and Product_category='" + name + "' and Product_Style='" + name1 + "'";
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
                    cmd.CommandText = "Select Name from priceList where Name!='" + comboBox1.Text + "' and Product_category!='" + name + "' and Product_Style!='" + name1 + "'";
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
                    cmd.CommandText = "Select Name from priceList where Name!='" + comboBox1.Text + "' and Product_category!='" + name + "' and Product_Style!='" + name1 + "'";
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
        private void getprice()
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
        private void Sales_invoice_Load(object sender, EventArgs e)
        {

            this.KeyPreview = true;


            textBox7.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            textBox7.AutoCompleteCustomSource = DataCollection;
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
            SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            con11.Open();
            string query1 = "Select * from condition where no=1 ";
            SqlCommand cmd11 = new SqlCommand(query1, con11);
            SqlDataReader dr11 = cmd11.ExecuteReader();
            if (dr11.Read())
            {

                richTextBox3.Text = dr11["condition"].ToString();

            }
            con11.Close();




            if (Customer_reports.SetValueForText1 != "")
            {
                string name11 = Customer_reports.SetValueForText1;
                SqlConnection con21 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand cmd21 = new SqlCommand("select * from customer where name1='" + name11 + "' ", con21);
                SqlDataReader dr21;
                con21.Open();
                dr21 = cmd21.ExecuteReader();
                if (dr21.Read())
                {
                    textBox7.Text = dr21["name1"].ToString();
                    richTextBox1.Text = dr21["address1"].ToString();
                    textBox9.Text = dr21["state1"].ToString();
                    textBox10.Text = dr21["state_code1"].ToString();
                    textBox11.Text = dr21["gstin1"].ToString();

                    textBox16.Text = dr21["name2"].ToString();
                    richTextBox2.Text = dr21["address2"].ToString();
                    textBox14.Text = dr21["state2"].ToString();
                    textBox13.Text = dr21["state_code3"].ToString();
                    textBox12.Text = dr21["gstin2"].ToString();
                }
                con21.Close();
            }

            if (sales_details_view.SetValueForText1 != "")
            {
                int invoice = Convert.ToInt32(sales_details_view.SetValueForText1);
                SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand cmd2 = new SqlCommand("select * from  sales where invoice_no='" + invoice + "' and financial_year='" + label8.Text + "'", con2);
                SqlDataReader dr2;
                con2.Open();
                dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    label5.Text = dr2["invoice_no"].ToString();
                    dateTimePicker1.Text = dr2["date"].ToString();
                    textBox1.Text = dr2["reverse_charge"].ToString();
                    comboBox1.Text = dr2["price_list"].ToString();
                    textBox2.Text = dr2["transpost"].ToString();
                    textBox4.Text = dr2["vehicle_no"].ToString();
                    dateTimePicker1.Text = dr2["date_supply"].ToString();
                    textBox6.Text = dr2["place_supply"].ToString();
                    comboBox5.Text = dr2["DT"].ToString();
                    textBox8.Text = dr2["no_of_bdl"].ToString();
                    textBox15.Text = dr2["lr_no"].ToString();
                    dateTimePicker3.Text = dr2["lr_date"].ToString();
                    textBox7.Text = dr2["name1"].ToString();
                    richTextBox1.Text = dr2["address1"].ToString();
                    textBox9.Text = dr2["state1"].ToString();
                    textBox10.Text = dr2["state_code1"].ToString();
                    textBox11.Text = dr2["gstin1"].ToString();

                    textBox16.Text = dr2["name2"].ToString();
                    richTextBox2.Text = dr2["address2"].ToString();
                    textBox14.Text = dr2["state2"].ToString();
                    textBox13.Text = dr2["state_code2"].ToString();
                    textBox12.Text = dr2["gstin2"].ToString();
                    textBox5.Text = dr2["total_qty"].ToString();
                    textBox17.Text = dr2["taxable_total"].ToString();
                    textBox18.Text = dr2["t_cgst"].ToString();
                    textBox19.Text = dr2["t_sgst"].ToString();
                    textBox20.Text = dr2["t_igst"].ToString();
                    textBox21.Text = dr2["gst_total"].ToString();
                    textBox22.Text = dr2["grand_total"].ToString();
                    textBox23.Text = dr2["account_number"].ToString();
                    textBox24.Text = dr2["ifsc"].ToString();
                    textBox25.Text = dr2["account_name"].ToString();
                }
                con2.Close();

                string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Product_category,style,Size,pcs,unit,Per_pcs_rate,Amount,discount,taxable_amount,cgst_rate,cgst_amount,sgst_rate,sgst_amount,igst_rate,igst_amount,total  from sales_product_table_final where invoice_no='" + invoice + "' and financial_year='" + label8.Text + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);



                                dataGridView1.Columns[1].Name = "Product Catgeory";
                                dataGridView1.Columns[1].HeaderText = "Product Category";
                                dataGridView1.Columns[1].DataPropertyName = "Product_category";


                                dataGridView1.Columns[2].Name = "Product Style ";
                                dataGridView1.Columns[2].HeaderText = "Product Style ";
                                dataGridView1.Columns[2].DataPropertyName = "style";


                                dataGridView1.Columns[3].Name = "Size";
                                dataGridView1.Columns[3].HeaderText = "Size";
                                dataGridView1.Columns[3].DataPropertyName = "Size";

                                dataGridView1.Columns[4].Name = "Qty";
                                dataGridView1.Columns[4].HeaderText = "Qty";
                                dataGridView1.Columns[4].DataPropertyName = "pcs";

                                dataGridView1.Columns[5].Name = "Unit";
                                dataGridView1.Columns[5].HeaderText = "Unit";
                                dataGridView1.Columns[5].DataPropertyName = "unit";

                                dataGridView1.Columns[6].Name = "Rate";
                                dataGridView1.Columns[6].HeaderText = "Rate";
                                dataGridView1.Columns[6].DataPropertyName = "Per_pcs_rate";


                                dataGridView1.Columns[7].Name = "Amount";
                                dataGridView1.Columns[7].HeaderText = "Amount";
                                dataGridView1.Columns[7].DataPropertyName = "Amount";

                                dataGridView1.Columns[8].Name = "Discount";
                                dataGridView1.Columns[8].HeaderText = "Discount";
                                dataGridView1.Columns[8].DataPropertyName = "discount";

                                dataGridView1.Columns[9].Name = "Taxable Amount";
                                dataGridView1.Columns[9].HeaderText = "Taxable Amount";
                                dataGridView1.Columns[9].DataPropertyName = "taxable_amount";

                                dataGridView1.Columns[10].Name = "CGST Rate";
                                dataGridView1.Columns[10].HeaderText = "CGST Rate";
                                dataGridView1.Columns[10].DataPropertyName = "cgst_rate";

                                dataGridView1.Columns[11].Name = "Amount";
                                dataGridView1.Columns[11].HeaderText = "Amount";
                                dataGridView1.Columns[11].DataPropertyName = "cgst_amount";


                                dataGridView1.Columns[12].Name = "SGST Rate";
                                dataGridView1.Columns[12].HeaderText = "SGST Rate";
                                dataGridView1.Columns[12].DataPropertyName = "sgst_rate";

                                dataGridView1.Columns[13].Name = "Amount";
                                dataGridView1.Columns[13].HeaderText = "Amount";
                                dataGridView1.Columns[13].DataPropertyName = "sgst_amount";

                                dataGridView1.Columns[14].Name = "IGST Rate";
                                dataGridView1.Columns[14].HeaderText = "IGST Rate";
                                dataGridView1.Columns[14].DataPropertyName = "igst_rate";

                                dataGridView1.Columns[15].Name = "Amount";
                                dataGridView1.Columns[15].HeaderText = "Amount";
                                dataGridView1.Columns[15].DataPropertyName = "igst_amount";

                                dataGridView1.Columns[16].Name = "Total";
                                dataGridView1.Columns[16].HeaderText = "Total";
                                dataGridView1.Columns[16].DataPropertyName = "total";


                                dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }


            }
            else
            {
                getprice();
                getid();
                

               
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
                string sql = "SELECT DISTINCT [name1] FROM [customer]";
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
                string query = "Select max(Invoice_no) from sales";
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
                        textBox3.Text = a.ToString();
                        a = a + 1;
                        label5.Text = a.ToString();
                    }
                }
            }
            con11.Close();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dataGridView1.SelectedCells[0].RowIndex;
                float qty = float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                float price = float.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                float total = price * qty;
                dataGridView1.Rows[i].Cells[7].Value = String.Format("{0:0.00}", total);

                decimal sum = 0;
                for (int j = 0; j < dataGridView1.Rows.Count; ++j)
                {

                    sum += Convert.ToDecimal(dataGridView1.Rows[j].Cells[4].Value);
                }




                textBox5.Text = sum.ToString();


                float amount = float.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                float discount = float.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                float discount_amount = amount * discount / 100;
                float taxable_amount = amount - discount_amount;
                dataGridView1.Rows[i].Cells[9].Value = String.Format("{0:0.00}", taxable_amount);

                decimal sum1 = 0;
                for (int j = 0; j < dataGridView1.Rows.Count; ++j)
                {

                    sum1 += Convert.ToDecimal(dataGridView1.Rows[j].Cells[9].Value);
                }




                textBox17.Text = sum1.ToString();


                float amount1 = float.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                float cgst_rate = float.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString());
                float cgst_amount = amount1 * cgst_rate / 100;

                dataGridView1.Rows[i].Cells[11].Value = String.Format("{0:0.00}", cgst_amount);

                decimal sum10 = 0;
                for (int j = 0; j < dataGridView1.Rows.Count; ++j)
                {

                    sum10 += Convert.ToDecimal(dataGridView1.Rows[j].Cells[11].Value);
                }




                textBox18.Text = sum10.ToString();


                float amount2 = float.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                float sgst_rate = float.Parse(dataGridView1.Rows[i].Cells[12].Value.ToString());
                float sgst_amount = amount2 * sgst_rate / 100;

                dataGridView1.Rows[i].Cells[13].Value = String.Format("{0:0.00}", sgst_amount);


                decimal sum11 = 0;
                for (int j = 0; j < dataGridView1.Rows.Count; ++j)
                {

                    sum11 += Convert.ToDecimal(dataGridView1.Rows[j].Cells[13].Value);
                }




                textBox19.Text = sum11.ToString();

                float amount3 = float.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                float igst_rate = float.Parse(dataGridView1.Rows[i].Cells[14].Value.ToString());
                float igst_amount = amount2 * igst_rate / 100;

                dataGridView1.Rows[i].Cells[15].Value = String.Format("{0:0.00}", igst_amount);


                decimal sum12 = 0;
                for (int j = 0; j < dataGridView1.Rows.Count; ++j)
                {

                    sum12 += Convert.ToDecimal(dataGridView1.Rows[j].Cells[15].Value);
                }




                textBox20.Text = sum12.ToString();

                float s0 = float.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                float s1 = float.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString());
                float s2 = float.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                float s3 = float.Parse(dataGridView1.Rows[i].Cells[15].Value.ToString());
               
                float s5=s0 + s1 + s2 + s3;
                dataGridView1.Rows[i].Cells[16].Value = String.Format("{0:0.00}", s5);


                float cgst =float.Parse( textBox18.Text);
                float sgst = float.Parse(textBox19.Text);
                float Igst = float.Parse(textBox20.Text);
              float total_gst=cgst+sgst+igst_amount;
              textBox21.Text =String.Format("{0:0.00}", total_gst).ToString();


              float before_tax = float.Parse(textBox17.Text);
              float total_gst1 = float.Parse(textBox21.Text);
                textBox22.Text=String.Format("{0:0.00}",Math.Round(before_tax+total_gst1)).ToString();
            }
            catch (Exception er)
            { }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("Please enter Receiver Name");
            }
            else  if (textBox16.Text == "")
            {
                MessageBox.Show("Please enter Consignee Name");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Please Add Product details");
            }
            else
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





                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {

                        int a1 = 1;
                        SqlConnection con14 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand check_User_Name4 = new SqlCommand("SELECT * FROM sales_product_table WHERE invoice_no = @invoice_no and S_no=@S_no and financial_year=@financial_year", con14);
                        check_User_Name4.Parameters.AddWithValue("@invoice_no", label5.Text);
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
                            SqlCommand cmd11 = new SqlCommand("update sales_product_table set Product_Category=@Product_category,style=@style,Size=@Size,pcs=@pcs,unit=@unit,Per_pcs_rate=@Per_pcs_rate,Amount=@Amount,discount=@discount,taxable_amount=@taxable_amount,cgst_rate=@cgst_rate,cgst_amount=@cgst_amount,sgst_rate=@sgst_rate,sgst_amount=@sgst_amount,igst_rate=@igst_rate,igst_amount=@igst_amount,total=@total where invoice_no=@invoice_no and S_no=@S_no and financial_year=@financial_year ", con11);
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
                            if (dataGridView1.Rows[i].Cells[5].Value != null)
                            {
                                cmd11.Parameters.AddWithValue("@unit", dataGridView1.Rows[i].Cells[5].Value);
                            }
                            else
                            {
                                cmd11.Parameters.AddWithValue("@unit", DBNull.Value);
                            }


                            cmd11.Parameters.AddWithValue("@Per_pcs_rate", dataGridView1.Rows[i].Cells[6].Value);
                            cmd11.Parameters.AddWithValue("@Amount", dataGridView1.Rows[i].Cells[7].Value);
                            cmd11.Parameters.AddWithValue("@discount", dataGridView1.Rows[i].Cells[8].Value);
                            cmd11.Parameters.AddWithValue("@taxable_amount", dataGridView1.Rows[i].Cells[9].Value);
                            cmd11.Parameters.AddWithValue("@cgst_rate", dataGridView1.Rows[i].Cells[10].Value);
                            cmd11.Parameters.AddWithValue("@cgst_amount", dataGridView1.Rows[i].Cells[11].Value);
                            cmd11.Parameters.AddWithValue("@sgst_rate", dataGridView1.Rows[i].Cells[12].Value);
                            cmd11.Parameters.AddWithValue("@sgst_amount", dataGridView1.Rows[i].Cells[13].Value);
                            cmd11.Parameters.AddWithValue("@igst_rate", dataGridView1.Rows[i].Cells[14].Value);
                            cmd11.Parameters.AddWithValue("@igst_amount", dataGridView1.Rows[i].Cells[15].Value);
                            cmd11.Parameters.AddWithValue("@total", dataGridView1.Rows[i].Cells[16].Value);
                            cmd11.Parameters.AddWithValue("@financial_year", label8.Text);
                            con11.Open();
                            cmd11.ExecuteNonQuery();
                            con11.Close();


                            SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd12 = new SqlCommand("update sales_product_table_final set Product_Category=@Product_category,style=@style,Size=@Size,pcs=@pcs,unit=@unit,Per_pcs_rate=@Per_pcs_rate,Amount=@Amount,discount=@discount,taxable_amount=@taxable_amount,cgst_rate=@cgst_rate,cgst_amount=@cgst_amount,sgst_rate=@sgst_rate,sgst_amount=@sgst_amount,igst_rate=@igst_rate,igst_amount=@igst_amount,total=@total where invoice_no=@invoice_no and S_no=@S_no and financial_year=@financial_year ", con12);
                            cmd12.Parameters.AddWithValue("@invoice_no", label5.Text);
                            cmd12.Parameters.AddWithValue("@S_no", dataGridView1.Rows[i].Cells[0].Value);
                            cmd12.Parameters.AddWithValue("@Product_category", dataGridView1.Rows[i].Cells[1].Value);
                            cmd12.Parameters.AddWithValue("@style", dataGridView1.Rows[i].Cells[2].Value);


                            cmd12.Parameters.AddWithValue("@Size", dataGridView1.Rows[i].Cells[3].Value);

                            cmd12.Parameters.AddWithValue("@pcs", dataGridView1.Rows[i].Cells[4].Value);
                            if (dataGridView1.Rows[i].Cells[5].Value != null)
                            {
                                cmd12.Parameters.AddWithValue("@unit", dataGridView1.Rows[i].Cells[5].Value);
                            }
                            else
                            {
                                cmd12.Parameters.AddWithValue("@unit", DBNull.Value);
                            }
                            cmd12.Parameters.AddWithValue("@Per_pcs_rate", dataGridView1.Rows[i].Cells[6].Value);
                            cmd12.Parameters.AddWithValue("@Amount", dataGridView1.Rows[i].Cells[7].Value);
                            cmd12.Parameters.AddWithValue("@discount", dataGridView1.Rows[i].Cells[8].Value);
                            cmd12.Parameters.AddWithValue("@taxable_amount", dataGridView1.Rows[i].Cells[9].Value);
                            cmd12.Parameters.AddWithValue("@cgst_rate", dataGridView1.Rows[i].Cells[10].Value);
                            cmd12.Parameters.AddWithValue("@cgst_amount", dataGridView1.Rows[i].Cells[11].Value);
                            cmd12.Parameters.AddWithValue("@sgst_rate", dataGridView1.Rows[i].Cells[12].Value);
                            cmd12.Parameters.AddWithValue("@sgst_amount", dataGridView1.Rows[i].Cells[13].Value);
                            cmd12.Parameters.AddWithValue("@igst_rate", dataGridView1.Rows[i].Cells[14].Value);
                            cmd12.Parameters.AddWithValue("@igst_amount", dataGridView1.Rows[i].Cells[15].Value);
                            cmd12.Parameters.AddWithValue("@total", dataGridView1.Rows[i].Cells[16].Value);
                            cmd12.Parameters.AddWithValue("@financial_year", label8.Text);

                            con12.Open();
                            cmd12.ExecuteNonQuery();
                            con12.Close();




                        }
                        else
                        {









                            SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd11 = new SqlCommand("insert into sales_product_table values(@invoice_no,@S_no,@Product_category,@style,@Size,@pcs,@unit,@Per_pcs_rate,@Amount,@discount,@taxable_amount,@cgst_rate,@cgst_amount,@sgst_rate,@sgst_amount,@igst_rate,@igst_amount,@total,@financial_year)", con11);
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
                            if (dataGridView1.Rows[i].Cells[5].Value != null)
                            {
                                cmd11.Parameters.AddWithValue("@unit", dataGridView1.Rows[i].Cells[5].Value);
                            }
                            else
                            {
                                cmd11.Parameters.AddWithValue("@unit", DBNull.Value);
                            }


                            cmd11.Parameters.AddWithValue("@Per_pcs_rate", dataGridView1.Rows[i].Cells[6].Value);
                            cmd11.Parameters.AddWithValue("@Amount", dataGridView1.Rows[i].Cells[7].Value);
                            cmd11.Parameters.AddWithValue("@discount", dataGridView1.Rows[i].Cells[8].Value);
                            cmd11.Parameters.AddWithValue("@taxable_amount", dataGridView1.Rows[i].Cells[9].Value);
                            cmd11.Parameters.AddWithValue("@cgst_rate", dataGridView1.Rows[i].Cells[10].Value);
                            cmd11.Parameters.AddWithValue("@cgst_amount", dataGridView1.Rows[i].Cells[11].Value);
                            cmd11.Parameters.AddWithValue("@sgst_rate", dataGridView1.Rows[i].Cells[12].Value);
                            cmd11.Parameters.AddWithValue("@sgst_amount", dataGridView1.Rows[i].Cells[13].Value);
                            cmd11.Parameters.AddWithValue("@igst_rate", dataGridView1.Rows[i].Cells[14].Value);
                            cmd11.Parameters.AddWithValue("@igst_amount", dataGridView1.Rows[i].Cells[15].Value);
                            cmd11.Parameters.AddWithValue("@total", dataGridView1.Rows[i].Cells[16].Value);
                            cmd11.Parameters.AddWithValue("@financial_year", label8.Text);
                            con11.Open();
                            cmd11.ExecuteNonQuery();
                            con11.Close();


                            SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd12 = new SqlCommand("insert into sales_product_table_final values(@invoice_no,@S_no,@Product_category,@style,@Size,@pcs,@unit,@Per_pcs_rate,@Amount,@discount,@taxable_amount,@cgst_rate,@cgst_amount,@sgst_rate,@sgst_amount,@igst_rate,@igst_amount,@total,@financial_year)", con12);
                            cmd12.Parameters.AddWithValue("@invoice_no", label5.Text);
                            cmd12.Parameters.AddWithValue("@S_no", dataGridView1.Rows[i].Cells[0].Value);
                            cmd12.Parameters.AddWithValue("@Product_category", dataGridView1.Rows[i].Cells[1].Value);
                            cmd12.Parameters.AddWithValue("@style", dataGridView1.Rows[i].Cells[2].Value);


                            cmd12.Parameters.AddWithValue("@Size", dataGridView1.Rows[i].Cells[3].Value);

                            cmd12.Parameters.AddWithValue("@pcs", dataGridView1.Rows[i].Cells[4].Value);
                            if (dataGridView1.Rows[i].Cells[5].Value != null)
                            {
                                cmd12.Parameters.AddWithValue("@unit", dataGridView1.Rows[i].Cells[5].Value);
                            }
                            else
                            {
                                cmd12.Parameters.AddWithValue("@unit", DBNull.Value);
                            }
                            cmd12.Parameters.AddWithValue("@Per_pcs_rate", dataGridView1.Rows[i].Cells[6].Value);
                            cmd12.Parameters.AddWithValue("@Amount", dataGridView1.Rows[i].Cells[7].Value);
                            cmd12.Parameters.AddWithValue("@discount", dataGridView1.Rows[i].Cells[8].Value);
                            cmd12.Parameters.AddWithValue("@taxable_amount", dataGridView1.Rows[i].Cells[9].Value);
                            cmd12.Parameters.AddWithValue("@cgst_rate", dataGridView1.Rows[i].Cells[10].Value);
                            cmd12.Parameters.AddWithValue("@cgst_amount", dataGridView1.Rows[i].Cells[11].Value);
                            cmd12.Parameters.AddWithValue("@sgst_rate", dataGridView1.Rows[i].Cells[12].Value);
                            cmd12.Parameters.AddWithValue("@sgst_amount", dataGridView1.Rows[i].Cells[13].Value);
                            cmd12.Parameters.AddWithValue("@igst_rate", dataGridView1.Rows[i].Cells[14].Value);
                            cmd12.Parameters.AddWithValue("@igst_amount", dataGridView1.Rows[i].Cells[15].Value);
                            cmd12.Parameters.AddWithValue("@total", dataGridView1.Rows[i].Cells[16].Value);
                            cmd12.Parameters.AddWithValue("@financial_year", label8.Text);

                            con12.Open();
                            cmd12.ExecuteNonQuery();
                            con12.Close();
                        }
                    }








                    SqlConnection con21 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd21 = new SqlCommand("select * from sales where invoice_no='" + label5.Text + "' and  financial_year='" + financial + "' ", con21);
                    SqlDataReader dr21;
                    con21.Open();
                    dr21 = cmd21.ExecuteReader();
                    if (dr21.HasRows)
                    {
                        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd = new SqlCommand("update sales set date=@date,reverse_charge=@reverse_charge,price_list=@price_list,transpost=@transpost,vehicle_no=@vehicle_no,date_supply=@date_supply,place_supply=@place_supply,DT=@DT,no_of_bdl=@no_of_bdl,lr_no=@lr_no,lr_date=@lr_date,name1=@name1,address1=@address1,state1=@state1,state_code1=@state_code1,gstin1=@gstin1,name2=@name2,address2=@address2,state2=@state2,state_code2=@state_code2,gstin2=@gstin2,total_qty=@total_qty,taxable_total=@taxable_total,t_cgst=@t_cgst,t_sgst=@t_sgst,t_igst=@t_igst,gst_total=@gst_total,grand_total=@grand_total,condition=@condition,account_number=@account_number,ifsc=@ifsc,account_name=@account_name where invoice_no=@invoice_no and financial_year=@financial_year", con);
                        cmd.Parameters.AddWithValue("@Invoice_no", label5.Text);
                        cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dateTimePicker1.Value.Date));
                        cmd.Parameters.AddWithValue("@reverse_charge", textBox1.Text);
                        cmd.Parameters.AddWithValue("@price_list", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@transpost", textBox2.Text);
                        cmd.Parameters.AddWithValue("@vehicle_no", textBox4.Text);
                        cmd.Parameters.AddWithValue("@date_supply", Convert.ToDateTime(dateTimePicker2.Value.Date));
                        cmd.Parameters.AddWithValue("@place_supply", textBox6.Text);

                        cmd.Parameters.AddWithValue("@DT", comboBox5.Text);
                        cmd.Parameters.AddWithValue("@no_of_bdl", textBox8.Text);
                        cmd.Parameters.AddWithValue("@lr_no", textBox15.Text);
                        cmd.Parameters.AddWithValue("@lr_date", Convert.ToDateTime(dateTimePicker3.Value.Date));
                        cmd.Parameters.AddWithValue("@name1", textBox7.Text);
                        cmd.Parameters.AddWithValue("@address1", richTextBox1.Text);
                        cmd.Parameters.AddWithValue("@state1", textBox9.Text);
                        cmd.Parameters.AddWithValue("@state_code1", textBox10.Text);
                        cmd.Parameters.AddWithValue("@gstin1", textBox11.Text);
                        cmd.Parameters.AddWithValue("@name2", textBox16.Text);
                        cmd.Parameters.AddWithValue("@address2", richTextBox2.Text);
                        cmd.Parameters.AddWithValue("@state2", textBox14.Text);
                        cmd.Parameters.AddWithValue("@state_code2", textBox13.Text);
                        cmd.Parameters.AddWithValue("@gstin2", textBox12.Text);
                        cmd.Parameters.AddWithValue("@total_qty", textBox5.Text);
                        cmd.Parameters.AddWithValue("@taxable_total", textBox17.Text);
                        cmd.Parameters.AddWithValue("@t_cgst", textBox18.Text);
                        cmd.Parameters.AddWithValue("@t_sgst", textBox19.Text);
                        cmd.Parameters.AddWithValue("@t_igst", textBox20.Text);
                        cmd.Parameters.AddWithValue("@gst_total", textBox21.Text);
                        cmd.Parameters.AddWithValue("@grand_total", textBox22.Text);
                        cmd.Parameters.AddWithValue("@financial_year", label8.Text);
                        cmd.Parameters.AddWithValue("@condition", richTextBox3.Text);
                        cmd.Parameters.AddWithValue("@account_number", textBox23.Text);
                        cmd.Parameters.AddWithValue("@ifsc", textBox24.Text);
                        cmd.Parameters.AddWithValue("@account_name", textBox25.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        SqlConnection con213 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd213 = new SqlCommand("select * from customer where name1!='" + textBox7.Text + "' and gstin1!='" + textBox11.Text + "' ", con213);
                        SqlDataReader dr213;
                        con213.Open();
                        dr213 = cmd213.ExecuteReader();
                        if (dr213.HasRows)
                        {
                            SqlConnection con200 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd200 = new SqlCommand("insert into customer values(@name1,@address1,@state1,@state_code1,@gstin1,@name2,@address2,@state2,@state_code3,@gstin2)", con200);
                            cmd200.Parameters.AddWithValue("@name1", textBox7.Text);
                            cmd200.Parameters.AddWithValue("@address1", richTextBox1.Text);
                            cmd200.Parameters.AddWithValue("@state1", textBox9.Text);
                            cmd200.Parameters.AddWithValue("@state_code1", textBox10.Text);
                            cmd200.Parameters.AddWithValue("@gstin1", textBox11.Text);
                            cmd200.Parameters.AddWithValue("@name2", textBox16.Text);
                            cmd200.Parameters.AddWithValue("@address2", richTextBox2.Text);
                            cmd200.Parameters.AddWithValue("@state2", textBox14.Text);
                            cmd200.Parameters.AddWithValue("@state_code3", textBox13.Text);
                            cmd200.Parameters.AddWithValue("@gstin2", textBox12.Text);
                            con200.Open();
                            cmd200.ExecuteNonQuery();
                            con200.Close();
                        }
                        con213.Close();

                        MessageBox.Show("Invoice updated successfully");

                        textBox1.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                        textBox12.Text = "";
                        textBox13.Text = "";
                        textBox14.Text = "";
                        textBox15.Text = "";
                        textBox16.Text = "";
                        textBox17.Text = "";
                        textBox18.Text = "";
                        textBox19.Text = "";
                        textBox20.Text = "";
                        textBox21.Text = "";
                        textBox22.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        richTextBox1.Text = "";
                        richTextBox2.Text = "";
                        textBox25.Text = "";
                        textBox23.Text = "";
                        textBox24.Text = "";
                        richTextBox3.Text = "";
                        DataTable dt = (DataTable)dataGridView1.DataSource;
                        if (dt != null)
                            dt.Clear();
                        getid();
                        getprice();
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd = new SqlCommand("insert into sales values(@invoice_no,@date,@reverse_charge,@price_list,@transpost,@vehicle_no,@date_supply,@place_supply,@DT,@no_of_bdl,@lr_no,@lr_date,@name1,@address1,@state1,@state_code1,@gstin1,@name2,@address2,@state2,@state_code2,@gstin2,@total_qty,@taxable_total,@t_cgst,@t_sgst,@t_igst,@gst_total,@grand_total,@financial_year,@condition,@account_number,@ifsc,@account_name)", con);
                        cmd.Parameters.AddWithValue("@Invoice_no", label5.Text);
                        cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dateTimePicker1.Value.Date));
                        cmd.Parameters.AddWithValue("@reverse_charge", textBox1.Text);
                        cmd.Parameters.AddWithValue("@price_list", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@transpost", textBox2.Text);
                        cmd.Parameters.AddWithValue("@vehicle_no", textBox4.Text);
                        cmd.Parameters.AddWithValue("@date_supply", Convert.ToDateTime(dateTimePicker2.Value.Date));
                        cmd.Parameters.AddWithValue("@place_supply", textBox6.Text);

                        cmd.Parameters.AddWithValue("@DT", comboBox5.Text);
                        cmd.Parameters.AddWithValue("@no_of_bdl", textBox8.Text);
                        cmd.Parameters.AddWithValue("@lr_no", textBox15.Text);
                        cmd.Parameters.AddWithValue("@lr_date", Convert.ToDateTime(dateTimePicker3.Value.Date));
                        cmd.Parameters.AddWithValue("@name1", textBox7.Text);
                        cmd.Parameters.AddWithValue("@address1", richTextBox1.Text);
                        cmd.Parameters.AddWithValue("@state1", textBox9.Text);
                        cmd.Parameters.AddWithValue("@state_code1", textBox10.Text);
                        cmd.Parameters.AddWithValue("@gstin1", textBox11.Text);
                        cmd.Parameters.AddWithValue("@name2", textBox16.Text);
                        cmd.Parameters.AddWithValue("@address2", richTextBox2.Text);
                        cmd.Parameters.AddWithValue("@state2", textBox14.Text);
                        cmd.Parameters.AddWithValue("@state_code2", textBox13.Text);
                        cmd.Parameters.AddWithValue("@gstin2", textBox12.Text);
                        cmd.Parameters.AddWithValue("@total_qty", textBox5.Text);
                        cmd.Parameters.AddWithValue("@taxable_total", textBox17.Text);
                        cmd.Parameters.AddWithValue("@t_cgst", textBox18.Text);
                        cmd.Parameters.AddWithValue("@t_sgst", textBox19.Text);
                        cmd.Parameters.AddWithValue("@t_igst", textBox20.Text);
                        cmd.Parameters.AddWithValue("@gst_total", textBox21.Text);
                        cmd.Parameters.AddWithValue("@grand_total", textBox22.Text);
                        cmd.Parameters.AddWithValue("@financial_year", label8.Text);
                        cmd.Parameters.AddWithValue("@condition", richTextBox3.Text);
                        cmd.Parameters.AddWithValue("@account_number", textBox23.Text);
                        cmd.Parameters.AddWithValue("@ifsc", textBox24.Text);
                        cmd.Parameters.AddWithValue("@account_name", textBox25.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        SqlConnection con213 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd213 = new SqlCommand("select * from customer where name1='" + textBox7.Text + "' and gstin1='" + textBox11.Text + "' ", con213);
                        SqlDataReader dr213;
                        con213.Open();
                        dr213 = cmd213.ExecuteReader();
                        if (dr213.HasRows)
                        {

                        }
                        else
                        {
                            SqlConnection con200 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd200 = new SqlCommand("insert into customer values(@name1,@address1,@state1,@state_code1,@gstin1,@name2,@address2,@state2,@state_code3,@gstin2)", con200);
                            cmd200.Parameters.AddWithValue("@name1", textBox7.Text);
                            cmd200.Parameters.AddWithValue("@address1", richTextBox1.Text);
                            cmd200.Parameters.AddWithValue("@state1", textBox9.Text);
                            cmd200.Parameters.AddWithValue("@state_code1", textBox10.Text);
                            cmd200.Parameters.AddWithValue("@gstin1", textBox11.Text);
                            cmd200.Parameters.AddWithValue("@name2", textBox16.Text);
                            cmd200.Parameters.AddWithValue("@address2", richTextBox2.Text);
                            cmd200.Parameters.AddWithValue("@state2", textBox14.Text);
                            cmd200.Parameters.AddWithValue("@state_code3", textBox13.Text);
                            cmd200.Parameters.AddWithValue("@gstin2", textBox12.Text);
                            con200.Open();
                            cmd200.ExecuteNonQuery();
                            con200.Close();
                        }
                    con213.Close();
                        MessageBox.Show("Invoice created successfully");
                        dataGridView1.Rows.Clear();
                        textBox1.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                        textBox12.Text = "";
                        textBox13.Text = "";
                        textBox14.Text = "";
                        textBox15.Text = "";
                        textBox16.Text = "";
                        textBox17.Text = "";
                        textBox18.Text = "";
                        textBox19.Text = "";
                        textBox20.Text = "";
                        textBox21.Text = "";
                        textBox22.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        richTextBox1.Text = "";
                        richTextBox2.Text = "";
                        textBox25.Text = "";
                        textBox23.Text = "";
                        textBox24.Text = "";
                        richTextBox3.Text = "";

                        getid();
                        getprice();
                       



                    }

                }
                con111.Close();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox25.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            richTextBox3.Text = "";
            comboBox5.Text = "";

            SqlConnection con21 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd21 = new SqlCommand("select max(invoice_no) from sales where invoice_no='"+label5.Text+"' and  financial_year='" + label8.Text + "' ", con21);
            SqlDataReader dr21;
            con21.Open();
            dr21 = cmd21.ExecuteReader();
            if (dr21.HasRows)
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                if (dt != null)
                    dt.Clear();
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
            con21.Close();

            SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            con11.Open();
            string query1 = "Select * from condition where no=1 ";
            SqlCommand cmd11 = new SqlCommand(query1, con11);
            SqlDataReader dr11 = cmd11.ExecuteReader();
            if (dr11.Read())
            {

                richTextBox3.Text = dr11["condition"].ToString();

            }
            con11.Close();


            richTextBox1.Text = "";
            richTextBox2.Text = "";
            getid();
            getprice();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox5.Text = "";
            textBox25.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            richTextBox3.Text = "";
            SqlConnection con21 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd21 = new SqlCommand("select max(invoice_no) from sales where invoice_no='" + label5.Text + "' and  financial_year='" + label8.Text + "' ", con21);
            SqlDataReader dr21;
            con21.Open();
            dr21 = cmd21.ExecuteReader();
            if (dr21.HasRows)
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                if (dt != null)
                    dt.Clear();
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
            con21.Close();
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            getid();
            getprice();
            SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            con11.Open();
            string query1 = "Select * from condition where no=1 ";
            SqlCommand cmd11 = new SqlCommand(query1, con11);
            SqlDataReader dr11 = cmd11.ExecuteReader();
            if (dr11.Read())
            {

                richTextBox3.Text = dr11["condition"].ToString();

            }
            con11.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection con21 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd21 = new SqlCommand("select max(invoice_no) from sales where invoice_no='" + label5.Text + "' and  financial_year='" + label8.Text + "' ", con21);
            SqlDataReader dr21;
            con21.Open();
            dr21 = cmd21.ExecuteReader();
            if (dr21.HasRows)
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                if (dt != null)
                    dt.Clear();
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
            con21.Close();
            if (Convert.ToInt32(label5.Text) > Convert.ToInt32(1))
            {
                label5.Text = (Convert.ToInt32(label5.Text) - 1).ToString();
            }

            SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd2 = new SqlCommand("select * from  sales where invoice_no='" + label5.Text + "' and financial_year='" + label8.Text + "'", con2);
            SqlDataReader dr2;
            con2.Open();
            dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                dateTimePicker1.Text = dr2["date"].ToString();
                textBox1.Text = dr2["reverse_charge"].ToString();
                comboBox1.Text = dr2["price_list"].ToString();
                textBox2.Text = dr2["transpost"].ToString();
                textBox4.Text = dr2["vehicle_no"].ToString();
                dateTimePicker1.Text = dr2["date_supply"].ToString();
                textBox6.Text = dr2["place_supply"].ToString();
                comboBox5.Text = dr2["DT"].ToString();
                textBox8.Text = dr2["no_of_bdl"].ToString();
                textBox15.Text = dr2["lr_no"].ToString();
                dateTimePicker3.Text = dr2["lr_date"].ToString();
                textBox7.Text = dr2["name1"].ToString();
                richTextBox1.Text = dr2["address1"].ToString();
                textBox9.Text = dr2["state1"].ToString();
                textBox10.Text = dr2["state_code1"].ToString();
                textBox11.Text = dr2["gstin1"].ToString();

                textBox16.Text = dr2["name2"].ToString();
                richTextBox2.Text = dr2["address2"].ToString();
                textBox14.Text = dr2["state2"].ToString();
                textBox13.Text = dr2["state_code2"].ToString();
                textBox12.Text = dr2["gstin2"].ToString();
                textBox5.Text = dr2["total_qty"].ToString();
                textBox17.Text = dr2["taxable_total"].ToString();
                textBox18.Text = dr2["t_cgst"].ToString();
                textBox19.Text = dr2["t_sgst"].ToString();
                textBox20.Text = dr2["t_igst"].ToString();
                textBox21.Text = dr2["gst_total"].ToString();
                textBox22.Text = dr2["grand_total"].ToString();
                textBox23.Text = dr2["account_number"].ToString();
                textBox24.Text = dr2["ifsc"].ToString();
                textBox25.Text = dr2["account_name"].ToString();
            }
            con2.Close();

            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Product_category,style,Size,pcs,unit,Per_pcs_rate,Amount,discount,taxable_amount,cgst_rate,cgst_amount,sgst_rate,sgst_amount,igst_rate,igst_amount,total  from sales_product_table_final where invoice_no='" + label5.Text + "' and financial_year='" + label8.Text + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);



                            dataGridView1.Columns[1].Name = "Product Catgeory";
                            dataGridView1.Columns[1].HeaderText = "Product Category";
                            dataGridView1.Columns[1].DataPropertyName = "Product_category";


                            dataGridView1.Columns[2].Name = "Product Style ";
                            dataGridView1.Columns[2].HeaderText = "Product Style ";
                            dataGridView1.Columns[2].DataPropertyName = "style";


                            dataGridView1.Columns[3].Name = "Size";
                            dataGridView1.Columns[3].HeaderText = "Size";
                            dataGridView1.Columns[3].DataPropertyName = "Size";

                            dataGridView1.Columns[4].Name = "Qty";
                            dataGridView1.Columns[4].HeaderText = "Qty";
                            dataGridView1.Columns[4].DataPropertyName = "pcs";

                            dataGridView1.Columns[5].Name = "Unit";
                            dataGridView1.Columns[5].HeaderText = "Unit";
                            dataGridView1.Columns[5].DataPropertyName = "unit";

                            dataGridView1.Columns[6].Name = "Rate";
                            dataGridView1.Columns[6].HeaderText = "Rate";
                            dataGridView1.Columns[6].DataPropertyName = "Per_pcs_rate";


                            dataGridView1.Columns[7].Name = "Amount";
                            dataGridView1.Columns[7].HeaderText = "Amount";
                            dataGridView1.Columns[7].DataPropertyName = "Amount";

                            dataGridView1.Columns[8].Name = "Discount";
                            dataGridView1.Columns[8].HeaderText = "Discount";
                            dataGridView1.Columns[8].DataPropertyName = "discount";

                            dataGridView1.Columns[9].Name = "Taxable Amount";
                            dataGridView1.Columns[9].HeaderText = "Taxable Amount";
                            dataGridView1.Columns[9].DataPropertyName = "taxable_amount";

                            dataGridView1.Columns[10].Name = "CGST Rate";
                            dataGridView1.Columns[10].HeaderText = "CGST Rate";
                            dataGridView1.Columns[10].DataPropertyName = "cgst_rate";

                            dataGridView1.Columns[11].Name = "Amount";
                            dataGridView1.Columns[11].HeaderText = "Amount";
                            dataGridView1.Columns[11].DataPropertyName = "cgst_amount";


                            dataGridView1.Columns[12].Name = "SGST Rate";
                            dataGridView1.Columns[12].HeaderText = "SGST Rate";
                            dataGridView1.Columns[12].DataPropertyName = "sgst_rate";

                            dataGridView1.Columns[13].Name = "Amount";
                            dataGridView1.Columns[13].HeaderText = "Amount";
                            dataGridView1.Columns[13].DataPropertyName = "sgst_amount";

                            dataGridView1.Columns[14].Name = "IGST Rate";
                            dataGridView1.Columns[14].HeaderText = "IGST Rate";
                            dataGridView1.Columns[14].DataPropertyName = "igst_rate";

                            dataGridView1.Columns[15].Name = "Amount";
                            dataGridView1.Columns[15].HeaderText = "Amount";
                            dataGridView1.Columns[15].DataPropertyName = "igst_amount";

                            dataGridView1.Columns[16].Name = "Total";
                            dataGridView1.Columns[16].HeaderText = "Total";
                            dataGridView1.Columns[16].DataPropertyName = "total";


                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }



        }

        private void button5_Click(object sender, EventArgs e)
        {


            SqlConnection con213 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd213 = new SqlCommand("select max(invoice_no) from sales where invoice_no='" + label5.Text + "' and  financial_year='" + label8.Text + "' ", con213);
            SqlDataReader dr213;
            con213.Open();
            dr213 = cmd213.ExecuteReader();
            if (dr213.HasRows)
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                if (dt != null)
                    dt.Clear();
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
            con213.Close();
            SqlConnection con21 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd21 = new SqlCommand("select max(invoice_no) from sales where financial_year='" + label8.Text + "' ", con21);
            SqlDataReader dr21;
            con21.Open();
            dr21 = cmd21.ExecuteReader();
            if (dr21.Read())
            {
                int value = Convert.ToInt32(dr21[0].ToString());
                if (Convert.ToInt32(label5.Text) < Convert.ToInt32(value + 1))
                {
                   label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                }
            }
            con21.Close();

            SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd2 = new SqlCommand("select * from  sales where invoice_no='" + label5.Text + "' and financial_year='" + label8.Text + "'", con2);
            SqlDataReader dr2;
            con2.Open();
            dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                dateTimePicker1.Text = dr2["date"].ToString();
                textBox1.Text = dr2["reverse_charge"].ToString();
                comboBox1.Text = dr2["price_list"].ToString();
                textBox2.Text = dr2["transpost"].ToString();
                textBox4.Text = dr2["vehicle_no"].ToString();
                dateTimePicker1.Text = dr2["date_supply"].ToString();
                textBox6.Text = dr2["place_supply"].ToString();
                comboBox5.Text = dr2["DT"].ToString();
                textBox8.Text = dr2["no_of_bdl"].ToString();
                textBox15.Text = dr2["lr_no"].ToString();
                dateTimePicker3.Text = dr2["lr_date"].ToString();
                textBox7.Text = dr2["name1"].ToString();
                richTextBox1.Text = dr2["address1"].ToString();
                textBox9.Text = dr2["state1"].ToString();
                textBox10.Text = dr2["state_code1"].ToString();
                textBox11.Text = dr2["gstin1"].ToString();

                textBox16.Text = dr2["name2"].ToString();
                richTextBox2.Text = dr2["address2"].ToString();
                textBox14.Text = dr2["state2"].ToString();
                textBox13.Text = dr2["state_code2"].ToString();
                textBox12.Text = dr2["gstin2"].ToString();
                textBox5.Text = dr2["total_qty"].ToString();
                textBox17.Text = dr2["taxable_total"].ToString();
                textBox18.Text = dr2["t_cgst"].ToString();
                textBox19.Text = dr2["t_sgst"].ToString();
                textBox20.Text = dr2["t_igst"].ToString();
                textBox21.Text = dr2["gst_total"].ToString();
                textBox22.Text = dr2["grand_total"].ToString();
                textBox23.Text = dr2["account_number"].ToString();
                textBox24.Text = dr2["ifsc"].ToString();
                textBox25.Text = dr2["account_name"].ToString();
            }
            else
            {
                textBox1.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
                textBox21.Text = "";
                textBox22.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox25.Text = "";
                textBox23.Text = "";
                textBox24.Text = "";
               
                SqlConnection con212 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand cmd212 = new SqlCommand("select max(invoice_no) from sales where invoice_no='" + label5.Text + "' and  financial_year='" + label8.Text + "' ", con212);
                SqlDataReader dr212;
                con212.Open();
                dr212 = cmd212.ExecuteReader();
                if (dr212.HasRows)
                {
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    if (dt != null)
                        dt.Clear();
                }
                else
                {
                    dataGridView1.Rows.Clear();
                }
                con212.Close();




                richTextBox1.Text = "";
                richTextBox2.Text = "";
                getid();
                getprice();

            }
            con2.Close();

            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Product_category,style,Size,pcs,unit,Per_pcs_rate,Amount,discount,taxable_amount,cgst_rate,cgst_amount,sgst_rate,sgst_amount,igst_rate,igst_amount,total  from sales_product_table_final where invoice_no='" + label5.Text + "' and financial_year='" + label8.Text + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);



                            dataGridView1.Columns[1].Name = "Product Catgeory";
                            dataGridView1.Columns[1].HeaderText = "Product Category";
                            dataGridView1.Columns[1].DataPropertyName = "Product_category";


                            dataGridView1.Columns[2].Name = "Product Style ";
                            dataGridView1.Columns[2].HeaderText = "Product Style ";
                            dataGridView1.Columns[2].DataPropertyName = "style";


                            dataGridView1.Columns[3].Name = "Size";
                            dataGridView1.Columns[3].HeaderText = "Size";
                            dataGridView1.Columns[3].DataPropertyName = "Size";

                            dataGridView1.Columns[4].Name = "Qty";
                            dataGridView1.Columns[4].HeaderText = "Qty";
                            dataGridView1.Columns[4].DataPropertyName = "pcs";

                            dataGridView1.Columns[5].Name = "Unit";
                            dataGridView1.Columns[5].HeaderText = "Unit";
                            dataGridView1.Columns[5].DataPropertyName = "unit";

                            dataGridView1.Columns[6].Name = "Rate";
                            dataGridView1.Columns[6].HeaderText = "Rate";
                            dataGridView1.Columns[6].DataPropertyName = "Per_pcs_rate";


                            dataGridView1.Columns[7].Name = "Amount";
                            dataGridView1.Columns[7].HeaderText = "Amount";
                            dataGridView1.Columns[7].DataPropertyName = "Amount";

                            dataGridView1.Columns[8].Name = "Discount";
                            dataGridView1.Columns[8].HeaderText = "Discount";
                            dataGridView1.Columns[8].DataPropertyName = "discount";

                            dataGridView1.Columns[9].Name = "Taxable Amount";
                            dataGridView1.Columns[9].HeaderText = "Taxable Amount";
                            dataGridView1.Columns[9].DataPropertyName = "taxable_amount";

                            dataGridView1.Columns[10].Name = "CGST Rate";
                            dataGridView1.Columns[10].HeaderText = "CGST Rate";
                            dataGridView1.Columns[10].DataPropertyName = "cgst_rate";

                            dataGridView1.Columns[11].Name = "Amount";
                            dataGridView1.Columns[11].HeaderText = "Amount";
                            dataGridView1.Columns[11].DataPropertyName = "cgst_amount";


                            dataGridView1.Columns[12].Name = "SGST Rate";
                            dataGridView1.Columns[12].HeaderText = "SGST Rate";
                            dataGridView1.Columns[12].DataPropertyName = "sgst_rate";

                            dataGridView1.Columns[13].Name = "Amount";
                            dataGridView1.Columns[13].HeaderText = "Amount";
                            dataGridView1.Columns[13].DataPropertyName = "sgst_amount";

                            dataGridView1.Columns[14].Name = "IGST Rate";
                            dataGridView1.Columns[14].HeaderText = "IGST Rate";
                            dataGridView1.Columns[14].DataPropertyName = "igst_rate";

                            dataGridView1.Columns[15].Name = "Amount";
                            dataGridView1.Columns[15].HeaderText = "Amount";
                            dataGridView1.Columns[15].DataPropertyName = "igst_amount";

                            dataGridView1.Columns[16].Name = "Total";
                            dataGridView1.Columns[16].HeaderText = "Total";
                            dataGridView1.Columns[16].DataPropertyName = "total";


                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SETVALUE = textBox3.Text;
            Sales_report I = new Sales_report();
            I.Show();
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Sure shall i delete this invoice.", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                 SqlConnection con21 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd21 = new SqlCommand("select * from sales where invoice_no='" + label5.Text + "' and  financial_year='" + label8.Text + "' ", con21);
                    SqlDataReader dr21;
                    con21.Open();
                    dr21 = cmd21.ExecuteReader();
                    if (dr21.HasRows)
                    {

                        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cd = new SqlCommand("delete from sales where invoice_no='" + label5.Text + "' AND financial_year='" + label8.Text + "' ", con);
                        con.Open();
                        cd.ExecuteNonQuery();
                        con.Close();
                        SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cd1 = new SqlCommand("delete from sales_product_table where invoice_no='" + label5.Text + "' AND financial_year='" + label8.Text + "'", con1);
                        con1.Open();
                        cd1.ExecuteNonQuery();
                        con1.Close();

                        SqlConnection con111 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cd111 = new SqlCommand("delete from sales_product_table_final where invoice_no='" + label5.Text + "' AND financial_year='" + label8.Text + "'", con111);
                        con111.Open();
                        cd111.ExecuteNonQuery();
                        con111.Close();
                        MessageBox.Show("Invoice deleted successfully");

                        textBox1.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                        textBox12.Text = "";
                        textBox13.Text = "";
                        textBox14.Text = "";
                        textBox15.Text = "";
                        textBox16.Text = "";
                        textBox17.Text = "";
                        textBox18.Text = "";
                        textBox19.Text = "";
                        textBox20.Text = "";
                        textBox21.Text = "";
                        textBox22.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox25.Text = "";
                        textBox23.Text = "";
                        textBox24.Text = "";
                        richTextBox3.Text = "";
                        comboBox5.Text = "";

                        SqlConnection con212 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd212 = new SqlCommand("select max(invoice_no) from sales where invoice_no='" + label5.Text + "' and  financial_year='" + label8.Text + "' ", con212);
                        SqlDataReader dr212;
                        con212.Open();
                        dr212 = cmd212.ExecuteReader();
                        if (dr212.HasRows)
                        {
                            DataTable dt = (DataTable)dataGridView1.DataSource;
                            if (dt != null)
                                dt.Clear();
                        }
                        else
                        {
                            dataGridView1.Rows.Clear();
                        }
                        con212.Close();

                        SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        con11.Open();
                        string query1 = "Select * from condition where no=1 ";
                        SqlCommand cmd11 = new SqlCommand(query1, con11);
                        SqlDataReader dr11 = cmd11.ExecuteReader();
                        if (dr11.Read())
                        {

                            richTextBox3.Text = dr11["condition"].ToString();

                        }
                        con11.Close();


                        richTextBox1.Text = "";
                        richTextBox2.Text = "";
                        getid();
                        getprice();
                    }
                    else
                    {
                        MessageBox.Show("Invoice no is not available in database");
                    }
                    con21.Close();
            }
          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox3.Text) > Convert.ToInt32(1))
            {
                textBox3.Text = (Convert.ToInt32(textBox3.Text) - 1).ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con21 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd21 = new SqlCommand("select max(invoice_no) from sales where financial_year='" + label8.Text + "' ", con21);
            SqlDataReader dr21;
            con21.Open();
            dr21 = cmd21.ExecuteReader();
            if (dr21.Read())
            {
                int value = Convert.ToInt32(dr21[0].ToString());
                if (Convert.ToInt32(textBox3.Text) < Convert.ToInt32(value))
                {
                    textBox3.Text = (Convert.ToInt32(textBox3.Text) + 1).ToString();
                }
                else
                {
                    MessageBox.Show("Please create invoice "+" - " + label5.Text );
                }
            }
            con21.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox16.Text = textBox7.Text;
            richTextBox2.Text = richTextBox1.Text;
            textBox14.Text = textBox9.Text;
            textBox13.Text = textBox10.Text;
            textBox12.Text = textBox11.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con21 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd21 = new SqlCommand("select * from customer where name1='" + textBox7.Text+ "' ", con21);
            SqlDataReader dr21;
            con21.Open();
            dr21 = cmd21.ExecuteReader();
            if (dr21.Read())
            {
                richTextBox1.Text = dr21["address1"].ToString();
                textBox9.Text = dr21["state1"].ToString();
                textBox10.Text = dr21["state_code1"].ToString();
                textBox11.Text = dr21["gstin1"].ToString();

                textBox16.Text = dr21["name2"].ToString();
                richTextBox2.Text = dr21["address2"].ToString();
                textBox14.Text = dr21["state2"].ToString();
                textBox13.Text = dr21["state_code3"].ToString();
                textBox12.Text = dr21["gstin2"].ToString();
            }
            con21.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox16.Text = "";
            richTextBox2.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sales_details_view sa = new sales_details_view();
            sa.Show();
            this.Close();
        }

        private void Sales_invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            sales_details_view.SetValueForText1 = "";
            Customer_reports.SetValueForText1 = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
                e.Handled = true;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox8.Focus();
                e.Handled = true;
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.Handled = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
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
                textBox6.Focus();
                e.Handled = true;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox5.Focus();
                e.Handled = true;
            }
        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox15.Focus();
                e.Handled = true;
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
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
                richTextBox1.Focus();
                e.Handled = true;
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();
                e.Handled = true;
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox10.Focus();
                e.Handled = true;
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox11.Focus();
                e.Handled = true;
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox16.Focus();
                e.Handled = true;
            }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextBox2.Focus();
                e.Handled = true;
            }
        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox14.Focus();
                e.Handled = true;
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox13.Focus();
                e.Handled = true;
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox12.Focus();
                e.Handled = true;
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
                e.Handled = true;
            }
        }

        private void textBox25_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox23.Focus();
                e.Handled = true;
            }
        }

        private void textBox23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox24.Focus();
                e.Handled = true;
            }
        }

        private void textBox24_KeyDown(object sender, KeyEventArgs e)
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
                textBox17.Focus();
                e.Handled = true;
            }
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox18.Focus();
                e.Handled = true;
            }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox19.Focus();
                e.Handled = true;
            }
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox20.Focus();
                e.Handled = true;
            }
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox21.Focus();
                e.Handled = true;
            }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox22.Focus();
                e.Handled = true;
            }
        }

        private void textBox22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox25.Focus();
                e.Handled = true;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Customer_reports cr = new Customer_reports();
            cr.Show();
            this.Close();
        }
    }
}
