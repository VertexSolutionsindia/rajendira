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
    public partial class Customer_reports : Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string name = "";
        public Customer_reports()
        {
            InitializeComponent();
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
        private void getData1(AutoCompleteStringCollection dataCollection)
        {

            try
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                connetionString = System.Configuration.ConfigurationSettings.AppSettings["connection"];
                string sql = "SELECT DISTINCT [gstin1] FROM [customer]";
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
        private void Customer_reports_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;


            textBox7.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            textBox7.AutoCompleteCustomSource = DataCollection;


            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection1 = new AutoCompleteStringCollection();
            getData1(DataCollection1);
            textBox1.AutoCompleteCustomSource = DataCollection1;


            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT name1,address1,state1,state_code1,gstin1,name2,address2,state2,state_code3,gstin2  from customer"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);



                            dataGridView1.Columns[0].Name = "Receiver Name";
                            dataGridView1.Columns[0].HeaderText = "Receiver Name";
                            dataGridView1.Columns[0].DataPropertyName = "name1";


                            dataGridView1.Columns[1].Name = "Address";
                            dataGridView1.Columns[1].HeaderText = "Address";
                            dataGridView1.Columns[1].DataPropertyName = "address1";


                            dataGridView1.Columns[2].Name = "State";
                            dataGridView1.Columns[2].HeaderText = "State";
                            dataGridView1.Columns[2].DataPropertyName = "state1";

                            dataGridView1.Columns[3].Name = "State Code";
                            dataGridView1.Columns[3].HeaderText = "State Code";
                            dataGridView1.Columns[3].DataPropertyName = "state_code1";

                            dataGridView1.Columns[4].Name = "GSTIN";
                            dataGridView1.Columns[4].HeaderText = "GSTIN";
                            dataGridView1.Columns[4].DataPropertyName = "gstin1";

                              dataGridView1.Columns[5].Name = "Designee Name";
                            dataGridView1.Columns[5].HeaderText = "Designee Name";
                            dataGridView1.Columns[5].DataPropertyName = "name2";


                            dataGridView1.Columns[6].Name = "D Address";
                            dataGridView1.Columns[6].HeaderText = "D Address";
                            dataGridView1.Columns[6].DataPropertyName = "address2";


                            dataGridView1.Columns[7].Name = "D State";
                            dataGridView1.Columns[7].HeaderText = "D State";
                            dataGridView1.Columns[7].DataPropertyName = "state2";

                            dataGridView1.Columns[8].Name = "D State Code";
                            dataGridView1.Columns[8].HeaderText = "D State Code";
                            dataGridView1.Columns[8].DataPropertyName = "state_code3";

                            dataGridView1.Columns[9].Name = "D GSTIN";
                            dataGridView1.Columns[9].HeaderText = "D GSTIN";
                            dataGridView1.Columns[9].DataPropertyName = "gstin2";




                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void Customer_reports_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sales_invoice s = new Sales_invoice();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {




                    SetValueForText1 = row.Cells[0].Value.ToString();
                   

                    this.Close();
                }
            }
            catch (Exception rt)
            { }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT name1,address1,state1,state_code1,gstin1,name2,address2,state2,state_code3,gstin2  from customer where name1='"+textBox7.Text+"'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);



                            dataGridView1.Columns[0].Name = "Receiver Name";
                            dataGridView1.Columns[0].HeaderText = "Receiver Name";
                            dataGridView1.Columns[0].DataPropertyName = "name1";


                            dataGridView1.Columns[1].Name = "Address";
                            dataGridView1.Columns[1].HeaderText = "Address";
                            dataGridView1.Columns[1].DataPropertyName = "address1";


                            dataGridView1.Columns[2].Name = "State";
                            dataGridView1.Columns[2].HeaderText = "State";
                            dataGridView1.Columns[2].DataPropertyName = "state1";

                            dataGridView1.Columns[3].Name = "State Code";
                            dataGridView1.Columns[3].HeaderText = "State Code";
                            dataGridView1.Columns[3].DataPropertyName = "state_code1";

                            dataGridView1.Columns[4].Name = "GSTIN";
                            dataGridView1.Columns[4].HeaderText = "GSTIN";
                            dataGridView1.Columns[4].DataPropertyName = "gstin1";

                            dataGridView1.Columns[5].Name = "Designee Name";
                            dataGridView1.Columns[5].HeaderText = "Designee Name";
                            dataGridView1.Columns[5].DataPropertyName = "name2";


                            dataGridView1.Columns[6].Name = "D Address";
                            dataGridView1.Columns[6].HeaderText = "D Address";
                            dataGridView1.Columns[6].DataPropertyName = "address2";


                            dataGridView1.Columns[7].Name = "D State";
                            dataGridView1.Columns[7].HeaderText = "D State";
                            dataGridView1.Columns[7].DataPropertyName = "state2";

                            dataGridView1.Columns[8].Name = "D State Code";
                            dataGridView1.Columns[8].HeaderText = "D State Code";
                            dataGridView1.Columns[8].DataPropertyName = "state_code3";

                            dataGridView1.Columns[9].Name = "D GSTIN";
                            dataGridView1.Columns[9].HeaderText = "D GSTIN";
                            dataGridView1.Columns[9].DataPropertyName = "gstin2";




                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT name1,address1,state1,state_code1,gstin1,name2,address2,state2,state_code3,gstin2  from customer where gstin1='" + textBox1.Text + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);



                            dataGridView1.Columns[0].Name = "Receiver Name";
                            dataGridView1.Columns[0].HeaderText = "Receiver Name";
                            dataGridView1.Columns[0].DataPropertyName = "name1";


                            dataGridView1.Columns[1].Name = "Address";
                            dataGridView1.Columns[1].HeaderText = "Address";
                            dataGridView1.Columns[1].DataPropertyName = "address1";


                            dataGridView1.Columns[2].Name = "State";
                            dataGridView1.Columns[2].HeaderText = "State";
                            dataGridView1.Columns[2].DataPropertyName = "state1";

                            dataGridView1.Columns[3].Name = "State Code";
                            dataGridView1.Columns[3].HeaderText = "State Code";
                            dataGridView1.Columns[3].DataPropertyName = "state_code1";

                            dataGridView1.Columns[4].Name = "GSTIN";
                            dataGridView1.Columns[4].HeaderText = "GSTIN";
                            dataGridView1.Columns[4].DataPropertyName = "gstin1";

                            dataGridView1.Columns[5].Name = "Designee Name";
                            dataGridView1.Columns[5].HeaderText = "Designee Name";
                            dataGridView1.Columns[5].DataPropertyName = "name2";


                            dataGridView1.Columns[6].Name = "D Address";
                            dataGridView1.Columns[6].HeaderText = "D Address";
                            dataGridView1.Columns[6].DataPropertyName = "address2";


                            dataGridView1.Columns[7].Name = "D State";
                            dataGridView1.Columns[7].HeaderText = "D State";
                            dataGridView1.Columns[7].DataPropertyName = "state2";

                            dataGridView1.Columns[8].Name = "D State Code";
                            dataGridView1.Columns[8].HeaderText = "D State Code";
                            dataGridView1.Columns[8].DataPropertyName = "state_code3";

                            dataGridView1.Columns[9].Name = "D GSTIN";
                            dataGridView1.Columns[9].HeaderText = "D GSTIN";
                            dataGridView1.Columns[9].DataPropertyName = "gstin2";




                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }
    }
}
