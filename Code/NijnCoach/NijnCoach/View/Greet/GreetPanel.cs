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

namespace NijnCoach.View.Greet
{
    public partial class GreetPanel : AvatarContainer
    {
        private System.Windows.Forms.Timer t;

        public GreetPanel(Boolean _loadAvatar = true) : base(_loadAvatar)
        {
        }

        protected override void avatarLoaded()
        {
            //TODO: play sound "Welcome!"
            buttonContinue.Enabled = true;
        }

        private void continueEventHandler(object sender, EventArgs e)
        {
            //TODO: Fetch questionnaire from database
            MainForm.mainForm.replacePanel(new QuestionnaireForm());
        }
    }
}
