using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach;
using NijnCoach.Database;


namespace NijnCoach.View.Main
{
    public partial class LoginMenu : Form
    {
        public LoginMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SByte userNo = DBConnect.getUser(textBox1.Text, textBox2.Text);
                if (userNo >= 0)
                {
                    if (DBConnect.getType(userNo))
                    {
                        MessageBox.Show("trapist");
                        MainClass.userNo = userNo;
                    }
                    else
                    {
                        MessageBox.Show("patient");
                        MainClass.userNo = userNo;
                    }

                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
            }

            
        }
    }
}
