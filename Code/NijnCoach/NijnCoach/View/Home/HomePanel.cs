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
using NijnCoach.View.Greet;
//using NijnCoach.View.questionnaireForm;

namespace NijnCoach.View.Home
{
    public partial class HomePanel : Panel
    {
        private Boolean _loadAvatar = false;
        public HomePanel(Boolean _loadAvatar = true)
        {
            this._loadAvatar = _loadAvatar;
            InitializeComponent();
        }

        private void questionnaireEventHandler(object sender, EventArgs e)
        {
            //Fetch correct questionnaire from database
            try
            {
                MainForm.mainForm.replacePanel(new QuestionnaireForm(_loadAvatar));
            }
            catch (NoQuestionnaireAvailableException)
            {
                MessageBox.Show("No Questionnaires are available for you.");
            }
        }

        private void overviewEventHandler(object sender, EventArgs e)
        {
            try
            {
                MainForm.mainForm.replacePanel(new OverviewPanel(_loadAvatar));
            }
            catch (ArgumentException){ }
        }

        private void exposureEventHandler(object sender, EventArgs e)
        {
            //StartExposure();
            //Fetch correct questionnaire from database
            MainForm.mainForm.replacePanel(new ExposurePanel(_loadAvatar));
        }

        private void exitEventHandler(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}