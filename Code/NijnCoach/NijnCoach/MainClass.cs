using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NijnCoach.XMLclasses;
using NijnCoach.Database;
using System.Windows.Forms;

namespace NijnCoach
{
    class MainClass
    {
        public static void InactiveMain(String[] args)
        {
            XMLParser parser = new XMLParser();
            Questionnaire q = parser.readXMLFromFile("ziejewelwillem.xml");
            DBConnect.InsertQuestionnairre("codeQuest", q);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new QuestionnaireForm());

            Application.Run(new NijnCoach.View.TherapistGUI.TherapistGUI());
            
            //questionnaire = parser.readXMLFromFile("answers.xml");
            //Application.Run(new TherapistQuestionnaire(questionnaire));
            
        }
    }
}
