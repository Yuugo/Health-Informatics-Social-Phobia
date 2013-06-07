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
    public static class MainClass
    {
        public static int userNo { get; set; }

        public static void InactiveMain(String[] args)
        {
            //XMLParser parser = new XMLParser();
             Questionnaire q = DBConnect.getQuestionnaireByPatient(12);
        }

        /// <summary>
        /// The main entry point for the application.s
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new QuestionnaireForm());
            //Application.Run(new TherapistGUI());
            //Application.Run(new NijnCoach.View.PatientFiles.PatientFiles());
            //Application.Run(new saveFileDialog());
            //Application.Run(new PatientFiles());
            Application.Run(new LoginMenu());
            //userNo = 4;
            //Application.Run(MainForm.mainForm);
        }
    }
}
