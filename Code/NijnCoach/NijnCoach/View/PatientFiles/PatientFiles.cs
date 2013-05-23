﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using NijnCoach.XMLclasses;
using NijnCoach;
using NijnCoach.Database;

namespace NijnCoach.View.PatientFiles
{
    public partial class PatientFiles : Form
    {

        List<TextBox> texts = new List<TextBox>();
        Patient pat = new Patient();

        public PatientFiles()
        {
            InitializeComponent();
            //Lijsten met de benodigde form items daarin opgeslagen
            texts = new List<TextBox>() { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9 };
         
        }

        private void PatientFiles_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool check = true;
            bool numbers = true;
            for (int i = 0; i < 9; i++) {
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
                pat.Fname = texts[0].Text;
                pat.Lname = texts[1].Text;
                pat.Age = Convert.ToSByte(texts[2].Text);
                pat.Street = texts[3].Text;
                pat.HouseNo = Convert.ToSByte(texts[4].Text);
                pat.Postal = texts[5].Text;
                pat.City = texts[6].Text;
                pat.PhoneNo = Convert.ToInt64(texts[7].Text);
                pat.Email = texts[8].Text;


            }
            if(check == false){
                MessageBox.Show("Empty field(s)");
            }else { 
                if(numbers == false){
                    MessageBox.Show("Not all number fields are filled in correctly");
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("wat?");
            }
        }

    }
}
