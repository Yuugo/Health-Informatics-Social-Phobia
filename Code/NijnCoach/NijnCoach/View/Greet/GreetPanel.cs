using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using NijnCoach.View.Main;
using NijnCoach.View.Questionnaire;
using NijnCoach.View.AvatarDir;
using NijnCoach.View.Home;

namespace NijnCoach.View.Greet
{
    public partial class GreetPanel : AvatarContainer
    {
        private Boolean _loadAvatar = true;
        public GreetPanel(Boolean _loadAvatar = true) : base(_loadAvatar)
        {
			this._loadAvatar = _loadAvatar;
        }

        protected override void avatarLoaded()
        {
            //TODO: play sound "Welcome!"
            buttonContinue.Enabled = true;
            buttonHome.Enabled = true;
        }

        private void continueEventHandler(object sender, EventArgs e)
        {
            //TODO: Fetch questionnaire from database
            //XMLParser parser = new XMLParser();
            //MainForm.mainForm.replacePanel(new QuestionnaireForm(parser.readXMLFromFile("writeTest.xml")));
            MainForm.mainForm.replacePanel(new QuestionnaireForm(_loadAvatar));
        }

        private void homeEventHandler(object sender, EventArgs e)
        {
            MainForm.mainForm.replacePanel(new HomePanel(_loadAvatar));
        }
    }
}
