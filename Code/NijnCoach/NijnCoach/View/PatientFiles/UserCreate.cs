using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.Database;
using System.Security.Cryptography;
using NijnCoach.View.TherapistGUI;
using NijnCoach.View.Home;

namespace NijnCoach.View.PatientFiles
{
    public partial class UserCreate : Panel
    {
        Sickpeople pat = new Sickpeople();

        public UserCreate()
        {
            InitializeComponent();
            //TherapistMain.main.replacePanel(new HomePanel());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text == String.Empty || textBox2.Text == String.Empty))
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] encode = Encoding.ASCII.GetBytes(textBox2.Text);
                encode = md5.ComputeHash(encode);
                String pass = Encoding.ASCII.GetString(encode);
                if (!textBox2.Text.Equals(confirmPassBox.Text))
                {
                    MessageBox.Show("Passwords do not match");
                    textBox2.Clear();
                    confirmPassBox.Clear();
                }
                else
                {
                    if (radioButton2.Checked)
                    {
                        DBConnect.InsertUser("Therapist", textBox1.Text, pass);
                        MessageBox.Show("User has been created");
                        reset();
                    }
                    else
                    {
                        PatientFiles dialog = new PatientFiles();
                        insertPatientFiles(dialog, pass);
                    }
                }

            }
        }

        public void insertPatientFiles(PatientFiles dialog, String pass)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<TextBox> texts = new List<TextBox>() { dialog.textBox1, dialog.textBox2, dialog.textBox3, dialog.textBox4, dialog.textBox5, dialog.textBox6, dialog.textBox7, dialog.textBox8, dialog.textBox9 };

                bool check = true;
                bool numbers = true;
                for (int i = 0; i < 9; i++)
                {
                    if (texts[i].Text == String.Empty)
                    {
                        check = false;
                    };
                }

                try
                {
                    Convert.ToInt32(texts[2].Text);
                    Convert.ToInt32(texts[4].Text);
                    Convert.ToInt64(texts[7].Text);
                }
                catch (Exception)
                {
                    numbers = false;
                }

                if (check && numbers)
                {
                    DBConnect.InsertUser("Patient", textBox1.Text, pass);
                    pat.Fname = texts[0].Text;
                    pat.Lname = texts[1].Text;
                    pat.Age = Convert.ToInt32(texts[2].Text);
                    pat.Street = texts[3].Text;
                    pat.HouseNo = Convert.ToInt32(texts[4].Text);
                    pat.Postal = texts[5].Text;
                    pat.City = texts[6].Text;
                    pat.PhoneNo = Convert.ToInt32(texts[7].Text);
                    pat.Email = texts[8].Text;
                    pat.PatientNo = DBConnect.getUserNo(textBox1.Text);
                    DBConnect.insertPatient(pat);
                    MessageBox.Show("Patient has been saved");
                    reset();
                }
                if (!check)
                {
                    MessageBox.Show("Empty field(s)");
                    insertPatientFiles(dialog, pass);
                }
                else
                {
                    if (!numbers)
                    {
                        MessageBox.Show("Not all number fields are filled in correctly");
                        insertPatientFiles(dialog, pass);
                    }
                }
            }

        }

        public void reset()
        {
            radioButton1.Checked = true;
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            confirmPassBox.Text = String.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TherapistMain.main.replacePanel(new NijnCoach.View.Home.HomePanel());
        }
    }
}


