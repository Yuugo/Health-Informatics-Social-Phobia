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

namespace NijnCoach.View.AvatarDir
{
    public abstract partial class AvatarContainer : Panel
    {
        protected System.Windows.Forms.Timer t;

        public AvatarContainer(Boolean _loadAvatar = true)
        {
            InitializeComponent();
            t = new System.Windows.Forms.Timer();
            if (_loadAvatar)
            {
                loadAvatar();
                t.Interval = 500;
                t.Tick += new EventHandler(waitForAvatar);
               
            }
            else
            {
                t.Interval = 1;
                t.Tick += new EventHandler(waitForNothing);
            }
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
                avatarLoaded();
            }            
        }

        private void waitForNothing(object sender, EventArgs e)
        {
            t.Enabled = false;
            avatarLoaded();
        }

        protected abstract void avatarLoaded();
    }
}
