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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            label3.Text = Login.username1.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand cmd=new SqlCommand("update login set username=@username,password=@password where id='"+label3.Text+"'",con);
            cmd.Parameters.AddWithValue("@username", textBox3.Text);
            cmd.Parameters.AddWithValue("@password", textBox4.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully");
            textBox3.Text = "";
            textBox4.Text = "";
            Login L = new Login();
            L.Show();
            this.Close();

           
        }
    }
}
