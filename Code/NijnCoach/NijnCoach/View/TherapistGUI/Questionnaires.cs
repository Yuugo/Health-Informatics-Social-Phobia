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
    public partial class Questionnaires : Form
    {
        List<Questionnairre> qs = new List<Questionnairre>();

        public Questionnaires(int patientNo)
        {
            InitializeComponent();
            qs = DBConnect.getQuestionnairesByPatient(patientNo);
            List<string[]> data = new List<string[]>();
            for (int i = 0; i < qs.Count; i++)
            {
                data.Add(new string[] { qs.ElementAt(i).Id.ToString(),qs.ElementAt(i).Name.ToString()});
            }
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Name");
            for (int i = 0; i < qs.Count; i++)
            {
                table.Rows.Add(data.ElementAt(i));
            }
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellClick(object sender, EventArgs e)
        {
            int cell = dataGridView1.CurrentCell.RowIndex;
            if (cell < dataGridView1.Rows.Count - 1)
            {
                Open.Enabled = true;
            }
            else
            {
                Open.Enabled = false;
            }
        }


    }
}
