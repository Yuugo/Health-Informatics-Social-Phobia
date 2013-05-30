using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.Database;
using System.Security.Cryptography;
namespace NijnCoach.View.PatientFiles
{
    public partial class CreateUser : Form
    {
        Patient pat = new Patient();

        public CreateUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] encode = Encoding.ASCII.GetBytes(textBox2.Text);
                encode = md5.ComputeHash(encode);
                String pass = Encoding.ASCII.GetString(encode);
                if (radioButton2.Checked == true)
                {
                    DBConnect.InsertUser("Therapist", textBox1.Text, pass);
                    MessageBox.Show("User has been created");
                    reset();
                }
                else
                {

                    PatientFiles dialog = new PatientFiles();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        List<TextBox> texts = new List<TextBox>() { dialog.textBox1, dialog.textBox2, dialog.textBox3, dialog.textBox4, dialog.textBox5, dialog.textBox6, dialog.textBox7, dialog.textBox8, dialog.textBox9 };

                        bool check = true;
                        bool numbers = true;
                        for (int i = 0; i < 9; i++)
                        {
                            if (texts[i].Text == "")
                            {
                                check = false;
                            };
                        }

                        try
                        {
                            Convert.ToSByte(texts[2].Text);
                            Convert.ToSByte(texts[4].Text);
                            Convert.ToInt64(texts[7].Text);
                        }
                        catch (Exception)
                        {
                            numbers = false;
                        }

                        if (check == true && numbers == true)
                        {
                            DBConnect.InsertUser("Patient", textBox1.Text, pass);
                            pat.Fname = texts[0].Text;
                            pat.Lname = texts[1].Text;
                            pat.Age = Convert.ToSByte(texts[2].Text);
                            pat.Street = texts[3].Text;
                            pat.HouseNo = Convert.ToSByte(texts[4].Text);
                            pat.Postal = texts[5].Text;
                            pat.City = texts[6].Text;
                            pat.PhoneNo = Convert.ToInt64(texts[7].Text);
                            pat.Email = texts[8].Text;
                            pat.PatientNo = DBConnect.getUserNo(textBox1.Text);
                            DBConnect.insertPatient(pat);
                            MessageBox.Show("Patient has been saved");
                            reset();
                        }
                        if (check == false)
                        {
                            MessageBox.Show("Empty field(s)");
                            dialog.Visible = true;
                        }
                        else
                        {
                            if (numbers == false)
                            {
                                MessageBox.Show("Not all number fields are filled in correctly");
                                dialog.Visible = true;
                            }
                        }
                    }
                }
                
            }
        }

        public void reset()
        {
            radioButton1.Checked = true;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
