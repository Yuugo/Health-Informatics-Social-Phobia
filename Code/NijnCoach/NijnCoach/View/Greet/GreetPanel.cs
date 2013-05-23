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

namespace NijnCoach.View.Greet
{
    public partial class GreetPanel : Panel
    {
        private System.Windows.Forms.Timer t;

        public GreetPanel(Boolean _loadAvatar = true)
        {
            InitializeComponent();
            if (_loadAvatar)
            {
                loadAvatar();
            }
            t = new System.Windows.Forms.Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(waitForAvatar);
            t.Enabled = true;
        }

        public void loadAvatar()
        {
            Debug.Assert(panelAvatarIntern == null);
            panelAvatarIntern = new NijnCoach.View.AvatarDir.AvatarPanel(100, 100);
            panelAvatarIntern.Width = panelAvatar.Width;
            panelAvatarIntern.Height = panelAvatar.Height;
            panelAvatar.Controls.Add(panelAvatarIntern);
        }

        private void waitForAvatar(object sender, EventArgs e)
        {
            if(panelAvatarIntern.fullyLoaded)
            {
                t.Enabled = false;
                //TODO: play sound "Welcome!"
                button1.Enabled = true;
            }            
        }

        private void continueEventHandler(object sender, EventArgs e)
        {
            //TODO: Fetch questionnaire from database
            MainForm.mainForm.replacePanel(new QuestionnaireForm());
        }
    }
}
