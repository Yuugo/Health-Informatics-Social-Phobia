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
using NijnCoach.View.TherapistGUI;


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

            if (!(textBox1.Text == String.Empty || textBox2.Text == String.Empty))
            {
                SByte userNo = DBConnect.getUser(textBox1.Text, textBox2.Text);
                if (userNo >= 0)
                {
                    if (DBConnect.getType(userNo))
                    {
                        reset();
                        this.Hide();
                        TherapistMain.main.Show();
                    }
                    else
                    {
                        reset();
                        this.Hide();
                        NijnCoach.MainClass.userNo = userNo;
                        MainForm.mainForm.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
            }
        }

        private void formClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reset()
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
        }
    }
}
