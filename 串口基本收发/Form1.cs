using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口基本收发
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Microsoft.VisualBasic.Devices.Computer cmbCOM = new Microsoft.VisualBasic.Devices.Computer();

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.WriteTimeout = 1000;
            Control.CheckForIllegalCrossThreadCalls = false;

            foreach (string str in cmbCOM.Ports.SerialPortNames)
            {
                comboBox1.Items.Add(str);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;
            try
            {
                serialPort1.Open();
            }
            catch
            {
                MessageBox.Show("？？？");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "sdasf";
            byte[] buffer = Encoding.ASCII.GetBytes(str);
            serialPort1.Write(buffer,0,buffer.Length);
            serialPort1.DiscardOutBuffer();
        }
    }
}
