using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.View.Questionnaire;
using NijnCoach.View.Main;
using NijnCoach.View.Overview;
using NijnCoach.View.Exposure;

namespace NijnCoach.View.Home
{
    public partial class HomePanel : Panel
    {
        public HomePanel()
        {
            InitializeComponent();
        }

        private void questionnaireEventHandler(object sender, EventArgs e)
        {
            //Fetch correct questionnaire from database
            MainForm.mainForm.replacePanel(new QuestionnaireForm());
        }

        private void overviewEventHandler(object sender, EventArgs e)
        {
            MainForm.mainForm.replacePanel(new OverviewPanel());
        }

        private void exposureEventHandler(object sender, EventArgs e)
        {
            //StartExposure();
            //Fetch correct questionnaire from database
            MainForm.mainForm.replacePanel(new ExposurePanel());
        }

        private void exitEventHandler(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
