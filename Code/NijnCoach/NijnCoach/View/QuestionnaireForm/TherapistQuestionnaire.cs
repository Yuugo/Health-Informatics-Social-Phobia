using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.XMLclasses;
using System.Diagnostics;

namespace NijnCoach.View.Questionnaire
{
    public partial class TherapistQuestionnaire : Form
    {
        private XMLclasses.Questionnaire questionnaire;
        public TherapistQuestionnaire(XMLclasses.Questionnaire questionnaire)
        {
            this.questionnaire = questionnaire;
            Debug.Assert(questionnaire.entries != null);
            InitializeComponent(questionnaire);
            
        }
    }
}
