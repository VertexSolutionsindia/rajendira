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
    public partial class Condition : Form
    {
        public Condition()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM condition WHERE no =@no", con10);
            check_User_Name.Parameters.AddWithValue("@no", label3.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("The condition already exist");
            }
            else
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("insert into condition values(@condition)", con);
                cmd.Parameters.AddWithValue("@condition",richTextBox1.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Condition created successfully");
                richTextBox1.Text = "";
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cd = new SqlCommand("update condition set condition=@condition where no='" + label3.Text + "'", con);
            cd.Parameters.AddWithValue("@condition",richTextBox1.Text);
            con.Open();
            cd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated successfully");
            richTextBox1.Text = "";
          
        }

        private void Condition_Load(object sender, EventArgs e)
        {

           SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            con11.Open();
            string query1 = "Select * from condition where no=1 ";
            SqlCommand cmd11 = new SqlCommand(query1, con11);
            SqlDataReader dr1 = cmd11.ExecuteReader();
            if (dr1.Read())
            {
                label3.Text = dr1["NO"].ToString();
                richTextBox1.Text = dr1["condition"].ToString();
                
            }

          

           
        }
    }
}
