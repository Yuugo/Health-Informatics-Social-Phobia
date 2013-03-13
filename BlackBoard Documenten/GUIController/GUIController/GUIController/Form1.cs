using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Net;
using CookComputing.XmlRpc;

namespace GUIController
{
    /* proxy interface */
    [XmlRpcUrl("http://localhost:8008")]
    public interface IStateName : IXmlRpcProxy
    {
                
        [XmlRpcMethod("surprisex")]
        string surprisex(double aValue);

        [XmlRpcMethod("happyx")]
        string happyx(double aValue);

        [XmlRpcMethod("sadx")]
        string sadx(double aValue);

        [XmlRpcMethod("angryx")]
        string angryx(double aValue);

        [XmlRpcMethod("disgustx")]
        string disgustx(double aValue);

        [XmlRpcMethod("fearx")]
        string fearx(double aValue);

        // Mixed

        [XmlRpcMethod("mixed0")]
        string mixed0(double aValue, double bValue);

        [XmlRpcMethod("mixed1")]
        string mixed1(double aValue, double bValue);

        [XmlRpcMethod("mixed2")]
        string mixed2(double aValue, double bValue);

        [XmlRpcMethod("mixed3")]
        string mixed3(double aValue, double bValue);

        [XmlRpcMethod("mixed4")]
        string mixed4(double aValue, double bValue);

        [XmlRpcMethod("myspeakx")]
        string myspeakx(string filename, int duration);

        //animation here
        [XmlRpcMethod("myanimation0")]
        string myanimation0();

        [XmlRpcMethod("myanimation1")]
        string myanimation1();

        [XmlRpcMethod("myanimation2")]
        string myanimation2();
    }

    
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* implement section */
            double aValue;
            aValue = double.Parse(textBox1.Text);
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.surprisex(aValue);
            //string message = proxy.result();
            //MessageBox.Show(message);

        }

        private void button25_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* implement section */
            double aValue;
            aValue = double.Parse(textBox1.Text);
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.happyx(aValue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /* implement section */
            double aValue;
            aValue = double.Parse(textBox1.Text);
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.sadx(aValue);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /* implement section */
            double aValue;
            aValue = double.Parse(textBox1.Text);
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.angryx(aValue);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /* implement section */
            double aValue;
            aValue = double.Parse(textBox1.Text);
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.disgustx(aValue);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /* implement section */
            double aValue;
            aValue = double.Parse(textBox1.Text);
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.fearx(aValue);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            /* implement section */
            double aValue, bValue;
            aValue = double.Parse(textBox2.Text);
            bValue = double.Parse(textBox3.Text);
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.mixed4(aValue, bValue);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            /* implement section */
            double aValue, bValue;
            aValue = double.Parse(textBox2.Text);
            bValue = double.Parse(textBox3.Text);
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.mixed0(aValue, bValue);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            /* implement section */
            double aValue, bValue;
            aValue = double.Parse(textBox2.Text);
            bValue = double.Parse(textBox3.Text);
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.mixed1(aValue, bValue);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            /* implement section */
            double aValue, bValue;
            aValue = double.Parse(textBox2.Text);
            bValue = double.Parse(textBox3.Text);
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.mixed2(aValue, bValue);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /* implement section */
            double aValue, bValue;
            aValue = double.Parse(textBox2.Text);
            bValue = double.Parse(textBox3.Text);
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.mixed3(aValue, bValue);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            /* implement section */
            string filename;
            int duration;
            filename = textBox4.Text + ".wav";
            duration = int.Parse(textBox5.Text);
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.myspeakx(filename, duration);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            /* implement section */
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.myanimation0();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            /* implement section */
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.myanimation1();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            /* implement section */
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.myanimation2();
        }
    }
}
