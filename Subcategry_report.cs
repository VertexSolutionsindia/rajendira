using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1
{
    public partial class Subcategry_report : Form
    {
        public Subcategry_report()
        {
            InitializeComponent();
        }

        private void Subcategry_report_Load(object sender, EventArgs e)
        {
            Getproductid1();
        }
        private void Getproductid1()
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  Style_id,category_name,Style_name from Product_style where category_name='" + comboBox2.Text + "' order by  Style_id asc "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "Style ID";
                            dataGridView1.Columns[0].HeaderText = "Style ID";
                            dataGridView1.Columns[0].DataPropertyName = "Style_id";


                            dataGridView1.Columns[1].Name = "Category Name";
                            dataGridView1.Columns[1].HeaderText = "Category Name";
                            dataGridView1.Columns[1].DataPropertyName = "category_name";


                            dataGridView1.Columns[2].Name = "Style Name";
                            dataGridView1.Columns[2].HeaderText = "Style Name";
                            dataGridView1.Columns[2].DataPropertyName = "Style_name";




                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings["connection"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  Style_id,category_name,Style_name from Product_style   order by Style_id asc"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.Columns[0].Name = "Style ID";
                            dataGridView1.Columns[0].HeaderText = "Style ID";
                            dataGridView1.Columns[0].DataPropertyName = "Style_id";


                            dataGridView1.Columns[1].Name = "Category Name";
                            dataGridView1.Columns[1].HeaderText = "Category Name";
                            dataGridView1.Columns[1].DataPropertyName = "category_name";


                            dataGridView1.Columns[2].Name = "Style Name";
                            dataGridView1.Columns[2].HeaderText = "Style Name";
                            dataGridView1.Columns[2].DataPropertyName = "Style_name";




                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
