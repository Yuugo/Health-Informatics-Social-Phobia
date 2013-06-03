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
            
        }

    }
}
