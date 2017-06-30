using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class Send_sms : Form
    {
        public Send_sms()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=nazeer.sheik@vertexsolution.co.in:vertex&senderID=TEST SMS&receipientno=" + textBox1.Text + "&dcs=0&msgtxt=" + richTextBox1.Text + "&state=4 ";
            // Create a request object  
            WebRequest request = HttpWebRequest.Create(strUrl);
            // Get the response back  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            response.Close();
            s.Close();
            readStream.Close();
            MessageBox.Show("Message sent successfully");
        }
    }
}
