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
    public partial class Financial_year : Form
    {
        public Financial_year()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("insert into financial_year values(@no,@financial_year)", con10);
            check_User_Name.Parameters.AddWithValue("@no", label4.Text);
            check_User_Name.Parameters.AddWithValue("@financial_year", textBox1.Text);
            con10.Open();
            check_User_Name.ExecuteNonQuery();
            con10.Close();
            MessageBox.Show("Financial year added Successfully");
            textBox1.Text = "";
            getcurent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Financial_year_Load(object sender, EventArgs e)
        {
            getid();
            getcurent();
            getcurrentfinancial();
           
        }

        private void getcurent()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd = new SqlCommand("select no,financial_year from financial_year", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            listBox1.DataSource = ds.Tables[0];
            listBox1.DisplayMember = "financial_year";
            listBox1.ValueMember = "no";
        }

        private void   getcurrentfinancial()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd = new SqlCommand("select no,financial_year from currentfinancialyear", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            listBox2.DataSource = ds.Tables[0];
            listBox2.DisplayMember = "financial_year";
            listBox2.ValueMember = "no";
        }
        private void getid()
        {
            int a;



            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            con1.Open();
            string query = "Select max(no) from financial_year ";
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

        private void button1_Click(object sender, EventArgs e)
        {
            int value = 1;
            SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name1 = new SqlCommand("select * from currentfinancialyear WHERE no =@no", con11);
                    check_User_Name1.Parameters.AddWithValue("@no", value);
                    con11.Open();
                    SqlDataReader reader1 = check_User_Name1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand cmd10 = new SqlCommand("update currentfinancialyear set financial_year=@financial_year where no='" + value + "'", con10);
                        cmd10.Parameters.AddWithValue("@financial_year", listBox1.Text);
                        con10.Open();
                        cmd10.ExecuteNonQuery();
                        con10.Close();
                        MessageBox.Show("Current Financial year changed successfully");
                        getcurrentfinancial();
                    }
                    else
                    {
                        int value1 = 1;
                        SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                        SqlCommand check_User_Name = new SqlCommand("insert into currentfinancialyear values(@no,@financial_year)", con10);
                        check_User_Name.Parameters.AddWithValue("@no", value1);
                        check_User_Name.Parameters.AddWithValue("@financial_year", listBox1.Text);
                        con10.Open();
                        check_User_Name.ExecuteNonQuery();
                        con10.Close();
                        MessageBox.Show("Current Financial year created successfully");
                        getcurrentfinancial();
                    }
           
        }
    }
}
