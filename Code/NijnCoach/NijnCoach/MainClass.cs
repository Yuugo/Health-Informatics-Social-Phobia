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
        public static void Main(String[] args)
        {
            Questionnaire q = new Questionnaire();
            DBConnect.InsertQuestionnairre("firstQuest", q);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void InactiveMain()
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
