using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
namespace program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string host = textBox1.Text;
            int port = System.Convert.ToInt16(numericUpDown1.Value);
            try
            {
                UdpClient klient = new UdpClient(host, port);
                Byte[] dane = Encoding.ASCII.GetBytes(textBox2.Text);
                klient.Send(dane, dane.Length);
                listBox1.Items.Add("Wysłano do" + host + ";" + port);
            }
            catch(Exception ex)
            {
                listBox1.Items.Add("Błąd nie udało się");
                MessageBox.Show(ex.ToString(), "Błąd");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int port = System.Convert.ToInt16(numericUpDown1.Value);
            IPEndPoint zdalnyIP = new IPEndPoint(IPAddress.Any, 0);
            try
            {
                UdpClient serwer = new UdpClient(port);
                Byte[] odczyt = serwer.Receive(ref zdalnyIP);
                string dane = Encoding.ASCII.GetString(odczyt);
                listBox1.Items.Add(dane);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Błąd");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
      
    }
}
