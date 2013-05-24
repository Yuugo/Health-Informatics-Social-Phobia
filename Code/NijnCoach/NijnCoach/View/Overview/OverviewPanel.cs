using System;
using NijnCoach.View.Main;
using NijnCoach.View.Questionnaire;
using NijnCoach.View.AvatarDir;
using NijnCoach.View.Home;

namespace NijnCoach.View.Overview
{
    public partial class OverviewPanel : AvatarContainer
    {
        public OverviewPanel(Boolean _loadAvatar = true) : base(_loadAvatar)
        {
        }

        protected override void avatarLoaded()
        {

        }

        private void continueEventHandler(object sender, EventArgs e)
        {
            //TODO: Fetch briefing questionnaire from database
            MainForm.mainForm.replacePanel(new QuestionnaireForm());
        }

        private void homeEventHandler(object sender, EventArgs e)
        {
            MainForm.mainForm.replacePanel(new HomePanel());
        }
    }
}
