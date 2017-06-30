using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToString();
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void wordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
           frm.Show();
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubCategory sd = new frmSubCategory();
            sd.Show();
        }

        private void registrationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCustomerDetails fc = new frmCustomerDetails();
            fc.Show();
        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmproductEntry fp = new frmproductEntry();
            fp.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
            
            
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void stockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PriceList p = new PriceList();
            p.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void productsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmsalesinvoice fm = new frmsalesinvoice();
            fm.Show();
        }

        private void estimateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category_report r = new Category_report();
            r.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmproductEntry fp = new frmproductEntry();
            fp.Show();
        }

        private void priceListEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Price_List_edit p = new Price_List_edit();
            p.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
          
        }

        private void menuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip3_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dgfdgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory f = new frmCategory();
            f.Show();
        }

        private void productStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubCategory s = new frmSubCategory();
            s.Show();

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmproductEntry fp = new frmproductEntry();
            fp.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            frmCustomerDetails f = new frmCustomerDetails();
            f.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            PriceList p = new PriceList();
            p.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            frmsalesinvoice si = new frmsalesinvoice();
            si.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void customerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void customerDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void categoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void subCategoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void recordsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            frmsalesinvoice d = new frmsalesinvoice();
            d.Show();
        }

        private void subcategoryReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Subcategry_report s = new Subcategry_report();
            s.Show();
        }

        private void customerDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Report_Details c = new Customer_Report_Details();
            c.Show();
        }

        private void toolStripMenuItem6_Click_1(object sender, EventArgs e)
        {
            
        }

        private void productEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_entry_report p = new Product_entry_report();
            p.Show();
        }

        private void priceListReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Price_List_report p = new Price_List_report();
            p.Show();
        }

        private void invoiceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invoice_report_details i = new invoice_report_details();
            i.Show();
        }

        private void estimateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {

        }

        private void sendSmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Send_sms s = new Send_sms();
            s.Show();
        }

        private void estimateStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void conditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Condition c = new Condition();
            c.Show();
        }

        private void toolStripMenuItem10_Click_1(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem6_Click_2(object sender, EventArgs e)
        {
           
        }

        private void estimateReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }

        private void estimateStatusToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }

        private void financialYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Financial_year f = new Financial_year();
            f.Show();
           
        }

        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database_backup db = new Database_backup();
            db.Show();
        }

        private void gstInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales_invoice s = new Sales_invoice();
            s.Show();
        }

       
    }
}
