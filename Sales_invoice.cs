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
            getprice();
            getid();
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









            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd = new SqlCommand("insert into sales values(@invoice_no,@date,@reverse_charge,@price_list,@transpost,@vehicle_no,@date_supply,@place_supply,@DT,@no_of_bdl,@lr_no,@lr_date,@name1,@address1,@state1,@state_code1,@gstin1,@name2,@address2,@state2,@state_code2,@gstin2,@total_qty,@taxable_total,@t_cgst,@t_sgst,@t_igst,@gst_total,@grand_total,@financial_year)", con);
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
            cmd.Parameters.AddWithValue("@financial_year", label17.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();



            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
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
                cmd11.Parameters.AddWithValue("@financial_year", label17.Text);
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
                cmd12.Parameters.AddWithValue("@financial_year", label17.Text);
           
                con12.Open();
                cmd12.ExecuteNonQuery();
                con12.Close();
            }

            MessageBox.Show("Invoice created successfully");

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
            dataGridView1.Rows.Clear();
            getid();
            getprice();

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
            dataGridView1.Rows.Clear();
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
            dataGridView1.Rows.Clear();
            getid();
            getprice();
        }
    }
}
