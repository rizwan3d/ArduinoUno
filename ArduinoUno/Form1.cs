using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
namespace ArduinoUno
{
    public partial class Form1 : Form
    {

        SerialPort port;

        int a = 90;

        public Form1()
        {
            InitializeComponent();

            port = new SerialPort("COM5", 9600);
            port.Open();

            this.FormClosed += Form1_FormClosed;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            port.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Text.Equals("On"))
            {
                b.Text = "Off";
                port.Write("200");
            }
            else
            {
                b.Text = "On";
                port.Write("250");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a += 10;
            if (a > 180)
                a = 180;
            port.Write(a.ToString());
            label1.Text = a.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a -= 10;
            if (a < 0)
                a = 0;
            port.Write(a.ToString());
            label1.Text = a.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
