namespace WindowsFormsApplication1
{
    partial class sales_details_view
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column10,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridView1.Location = new System.Drawing.Point(16, 97);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1328, 571);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Bill No";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Date";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Receiver Name";
            this.Column3.Name = "Column3";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Address";
            this.Column10.Name = "Column10";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Before Tax";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Total CGST";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Total SGST";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Total IGST";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Total GST";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Grand Total";
            this.Column9.Name = "Column9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 18);
            this.label8.TabIndex = 174;
            this.label8.Text = "label8";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1217, 55);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 35);
            this.button6.TabIndex = 177;
            this.button6.Text = "Delete";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1089, 55);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(122, 35);
            this.button5.TabIndex = 176;
            this.button5.Text = "View report";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1008, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 35);
            this.button4.TabIndex = 175;
            this.button4.Text = "Edit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1217, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 178;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(189, 18);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(217, 26);
            this.textBox7.TabIndex = 180;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(81, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 18);
            this.label11.TabIndex = 179;
            this.label11.Text = "Receiver Name";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(189, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 26);
            this.textBox1.TabIndex = 182;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 181;
            this.label1.Text = "GSTIN No";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(552, 9);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(211, 29);
            this.label30.TabIndex = 183;
            this.label30.Text = "GST Invoice Reports";
            // 
            // sales_details_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "sales_details_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Bill Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.sales_details_view_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.sales_details_view_FormClosed);
            this.Load += new System.EventHandler(this.sales_details_view_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label30;
    }
}