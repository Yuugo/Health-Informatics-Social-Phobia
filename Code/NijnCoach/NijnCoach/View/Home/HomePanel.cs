﻿using System;
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
        private Boolean _loadAvatar = true;
        public HomePanel(Boolean _loadAvatar = true)
        {
            this._loadAvatar = _loadAvatar;
            InitializeComponent();
        }

        private void questionnaireEventHandler(object sender, EventArgs e)
        {
            //Fetch correct questionnaire from database
            MainForm.mainForm.replacePanel(new QuestionnaireForm(_loadAvatar));
        }

        private void overviewEventHandler(object sender, EventArgs e)
        {
            MainForm.mainForm.replacePanel(new OverviewPanel(_loadAvatar));
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
