using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NijnCoach.XMLclasses;
using NijnCoach.View.Questionnaire;

namespace NijnCoach
{
    static class TestQuestionnaireForm
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XMLParser parser = new XMLParser();
            Questionnaire questionnaire = parser.readXMLFromFile("writeTest.xml");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QuestionnaireForm(questionnaire));
            questionnaire = parser.readXMLFromFile("answers.xml");
            Application.Run(new TherapistQuestionnaire(questionnaire));
            
        }
    }
}
