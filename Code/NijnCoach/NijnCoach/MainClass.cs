using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NijnCoach.XMLclasses;
using NijnCoach.Database;
using System.Windows.Forms;
using NijnCoach.View.Main;
using NijnCoach.View.TherapistGUI;
using NijnCoach.View.PatientFiles;

namespace NijnCoach
{
    class MainClass
    {
        public static void InactiveMain(String[] args)
        {
            //XMLParser parser = new XMLParser();
             Questionnaire q = DBConnect.getQuestionnaireByPatient(12);
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

            //Application.Run(new NijnCoach.View.PatientFiles.PatientFiles());
            //Application.Run(new saveFileDialog());
            Application.Run(new NijnCoach.View.Main.LoginMenu());
        }
    }
}
