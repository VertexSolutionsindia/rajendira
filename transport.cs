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
    public partial class transport : Form
    {
        public transport()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            getid();
            txtCategoryName.Text = "";
          
            frmsalesinvoice p = (frmsalesinvoice)Application.OpenForms[" frmsalesinvoice"];
            p.gettransport();
        }
        private void getid()
        {
            int a;



            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            con1.Open();
            string query = "Select max(ID) from transport ";
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

            try
            {
                SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name = new SqlCommand("SELECT * FROM transport WHERE ID= @ID", con10);
                check_User_Name.Parameters.AddWithValue("@ID", label2.Text);
                con10.Open();
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("The Product category already exist");
                }
                else
                {
                    SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cmd = new SqlCommand("insert into transport values(@ID,@transport_name)", con1);
                    cmd.Parameters.AddWithValue("@ID", label2.Text);
                    cmd.Parameters.AddWithValue("@transport_name", txtCategoryName.Text);
                    con1.Open();
                    cmd.ExecuteNonQuery();
                    con1.Close();
                    MessageBox.Show("Transport added successfully");
                    frmsalesinvoice F = (frmsalesinvoice)Application.OpenForms["frmsalesinvoice"];
                    F.gettransport();
                    txtCategoryName.Text = "";
                    getid();
                    getcategorydetails();

                }


                frmsalesinvoice i = (frmsalesinvoice)Application.OpenForms["frmsalesinvoice"];
                i.gettransport();
                SqlConnection con11 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand check_User_Name1 = new SqlCommand("SELECT * FROM transport WHERE ID != @ID", con11);
                check_User_Name1.Parameters.AddWithValue("@ID", label2.Text);
                con11.Open();
                SqlDataReader reader1 = check_User_Name1.ExecuteReader();
                if (reader1.HasRows)
                {

                    btnSave.Enabled = false;

                    btnNew.Enabled = true;

                }
                frmsalesinvoice p = (frmsalesinvoice)Application.OpenForms[" frmsalesinvoice"];
                p.gettransport();
            }
            catch (Exception rt)
            { }
           
        }

        private void transport_Load(object sender, EventArgs e)
        {
            getid();
            getcategorydetails();
           
            btnSave.Enabled = false;
           
        }
        private void getcategorydetails()
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  ID,transport_name from transport"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "ID";
                            dataGridView1.Columns[0].HeaderText = "ID";
                            dataGridView1.Columns[0].DataPropertyName = "ID";
                            dataGridView1.Columns[1].Name = "Transport Name";
                            dataGridView1.Columns[1].HeaderText = "Transport Name";
                            dataGridView1.Columns[1].DataPropertyName = "transport_name";



                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
         
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtCategoryName.Text = "";
            getid();
            frmsalesinvoice F = (frmsalesinvoice)Application.OpenForms["frmsalesinvoice"];
            F.gettransport();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmsalesinvoice i = (frmsalesinvoice)Application.OpenForms["frmsalesinvoice"];
            i.gettransport();
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con10 = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM transport WHERE ID = @ID", con10);
            check_User_Name.Parameters.AddWithValue("@ID", label2.Text);
            con10.Open();
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
              

            }
            else
            {
                btnSave.Enabled = true;

                btnNew.Enabled = false;

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];
            dataGridView1.CurrentCell.Selected = true;
            dataGridView1.BeginEdit(true);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand cd = new SqlCommand("delete from transport where ID='" + row.Cells[0].Value.ToString() + "'", con);
                    con.Open();
                    cd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Deleted Successfully");
                frmsalesinvoice p1 = (frmsalesinvoice)Application.OpenForms["frmsalesinvoice"];
                p1.gettransport();

                txtCategoryName.Text = "";
                getid();
                getcategorydetails();
            }
            catch (Exception rt)
            { }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connection"]);
                SqlCommand cd = new SqlCommand("update transport set transport_name=@transport_name where ID='" + row.Cells[0].Value.ToString() + "'", con);
                cd.Parameters.AddWithValue("@transport_name", row.Cells[1].Value.ToString());
             
                con.Open();
                cd.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Updated Successfully");
            frmsalesinvoice p1 = (frmsalesinvoice)Application.OpenForms["frmsalesinvoice"];
            p1.gettransport();

          
            getid();
            getcategorydetails();
        }
    }
}
