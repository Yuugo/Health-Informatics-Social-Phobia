<<<<<<< HEAD
﻿using System;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new QuestionnaireForm());

            Application.Run(new NijnCoach.View.TherapistGUI.TherapistGUI());
            
            //questionnaire = parser.readXMLFromFile("answers.xml");
            //Application.Run(new TherapistQuestionnaire(questionnaire));
            
        }
    }
}
=======
﻿using System;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QuestionnaireForm());

            //Application.Run(new NijnCoach.View.TherapistGUI.TherapistGUI());
            
            //questionnaire = parser.readXMLFromFile("answers.xml");
            //Application.Run(new TherapistQuestionnaire(questionnaire));
            
        }
    }
}
>>>>>>> test
