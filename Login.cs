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
    public partial class Login : Form
    {
        public static int username1 =0;
        public static string password = "";
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("select * from login", con);
                SqlDataReader dr;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    string username = dr["username"].ToString();
                    string password = dr["password"].ToString();

                    if (username == textBox1.Text && password == textBox2.Text)
                    {

                        Form1 f = new Form1();
                        f.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("username and password entered wrong");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }

            }
            catch (Exception er)
            { }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand cmd = new SqlCommand("select * from login", con);
                SqlDataReader dr;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                     id = Convert.ToInt32(dr["id"].ToString());
                    string username = dr["username"].ToString();
                    string password = dr["password"].ToString();

                    if (username == textBox1.Text && password == textBox2.Text)
                    {
                        username1 = id;
                        Form2 f = new Form2();
                        f.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("username and password entered wrong");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }

            }
            catch (Exception er)
            { }

         
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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
                button1.PerformClick();
            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



          
        

       
    }
}
