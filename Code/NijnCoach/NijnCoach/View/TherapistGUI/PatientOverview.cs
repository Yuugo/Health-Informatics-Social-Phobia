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

namespace NijnCoach.View.TherapistGUI
{
    public partial class PatientOverview : Panel
    {
        List<Sickpeople> patients= new List<Sickpeople>();

        public PatientOverview()
        {
            InitializeComponent();
            patients = DBConnect.getPatients();
            List<string[]> data = new List<string[]>();
            for (int i = 0;i<patients.Count;i++){
                data.Add(new string[]{patients.ElementAt(i).PatientNo.ToString(),patients.ElementAt(i).Fname,patients.ElementAt(i).Lname});
            }
            DataTable table = new DataTable();
            table.Columns.Add("PatientNo");
            table.Columns.Add("First name");
            table.Columns.Add("Last name");
            for (int i = 0; i < patients.Count; i++)
            {
                table.Rows.Add(data.ElementAt(i));
            }
            dataGridView1.DataSource = table;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TherapistMain.main.replacePanel(new NijnCoach.View.TherapistGUI.HomePanel());
        }

        private void dataGridView1_CellClick(object sender, EventArgs e)
        {
            int cell = dataGridView1.CurrentCell.RowIndex;
            if(cell < dataGridView1.Rows.Count -1){
                button1.Enabled = true;
                button2.Enabled = true;
                string no = dataGridView1.Rows[cell].Cells[0].Value.ToString();
                int patientNo = System.Convert.ToInt32(no);
                Sickpeople patient = DBConnect.getPatientByNumber(patientNo);
                textBox1.Text = patient.Fname;
                textBox2.Text = patient.Lname;
                textBox3.Text = patient.Age.ToString();
                textBox4.Text = patient.Street;
                textBox5.Text = patient.HouseNo.ToString();
                textBox6.Text = patient.Postal;
                textBox7.Text = patient.City;
                textBox8.Text = patient.PhoneNo.ToString();
                textBox9.Text = patient.Email;
                textBox0.Text = patient.PatientNo.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            NijnCoach.MainClass.userNo = System.Convert.ToInt32(textBox0.Text);
            if (DBConnect.getQuestionnaireByPatient(MainClass.userNo) != null)
            {
                TherapistMain.main.replacePanel(new NijnCoach.View.TherapistGUI.qResult());
            }
            else
            {
                MessageBox.Show("No questionnaire found");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            NijnCoach.MainClass.userNo = System.Convert.ToInt32(textBox0.Text);
            try
            {
                TherapistMain.main.replacePanel(new NijnCoach.View.TherapistGUI.OverviewPanel());
            }
            catch (ArgumentException){}
        }
    }
}
