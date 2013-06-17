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
using NijnCoach.View.Questionnaire;
using System.Diagnostics;

namespace NijnCoach.View.TherapistGUI
{
    public partial class qResult : Panel
    {
        int userNo = NijnCoach.MainClass.userNo;
        private XMLclasses.Questionnaire questionnaire;
        private int currentQuestion = 0;

        public qResult(XMLclasses.Questionnaire q)
        {
            questionnaire = q;
            InitializeComponent();
            string naam = DBConnect.getName(userNo);
            label2.Text = "Result of " + naam;
            if (questionnaire.entries.Count() == 1) buttonNext.Enabled = false;
            updatePanel(questionnaire.entries[currentQuestion]);
        }

        private void updatePanel(IEntry entry)
        {
            label1.Text = (currentQuestion + 1).ToString() + ".";
            panelMainContent.Controls.Clear();
            IQuestionPanel panel = null;
            if (entry is Comment)
            {
                panel = new CommentPanel(panelMainContent.Width - 20, 100);
            }
            else if (entry is MCQuestion)
            {
                panel = new MCQuestionPanel(panelMainContent.Width - 20, 100);
            }
            else if (entry is OpenQuestion)
            {
                panel = new OpenQuestionPanel(panelMainContent.Width - 20, 100);
            }
            Debug.Assert(panel != null);
            panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel.entry = entry;
            panel.partlyDisabled = true;
            panelMainContent.Controls.Add(panel);
            panelMainContent.SetFlowBreak(panel, true);
        }

        private void nextEventHandler(object sender, EventArgs e)
        {

            currentQuestion++;
            if (currentQuestion == questionnaire.entries.Count - 1)
            {
                buttonNext.Enabled = false;
            }
            buttonPrevious.Enabled = true;
            updatePanel(questionnaire.entries[currentQuestion]);
        }

        private void previousEventHandler(object sender, EventArgs e)
        {
            Debug.Assert(currentQuestion - 1 >= 0, "Array out of bounds: IEntry does not exist");
            currentQuestion--;
            //updatePanelQuestion(questionnaire.entries[currentQuestion]);
            if (currentQuestion == 0)
            {
                buttonPrevious.Enabled = false;
            }
            buttonNext.Enabled = true;
            updatePanel(questionnaire.entries[currentQuestion]);
        }



        private void homeEventHandler(object sender, EventArgs e)
        {
            TherapistMain.main.replacePanel(new View.TherapistGUI.PatientOverview());
        }
    }
}
