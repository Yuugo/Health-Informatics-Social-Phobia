using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NUnit.Framework;
using System.Threading;
using System.Drawing;


namespace NijnCoach_Test.View.Avatar
{
    [TestFixture]
    class MultipleAvatarTest
    {
        private Form theForm = null;
        private System.Windows.Forms.Timer t = null;
        private NijnCoach.View.AvatarPanel.AvatarPanel avatarPanel1;
        [Test]
        public void Test()
        {
            theForm = new Form();
            theForm.Size = new Size(600, 400);
            avatarPanel1 = new NijnCoach.View.AvatarPanel.AvatarPanel(600, 400);
            avatarPanel1.Size = new Size(600, 400);
            theForm.Controls.Add(avatarPanel1);
            theForm.Text = "avatarPanel 1";
            t = new System.Windows.Forms.Timer();
            t.Interval = 12000;
            t.Tick += new EventHandler(addAvatarPanel);
            t.Enabled = true;
            Application.Run(theForm);
            Assert.True(MessageBox.Show("Were the two avatars sequentually correctly displayed", "", MessageBoxButtons.YesNo) == DialogResult.Yes);
        }

        private void addAvatarPanel(object sender, EventArgs e)
        {
            t.Enabled = false;
            if (theForm != null && avatarPanel1 != null)
            {
                avatarPanel1.Dispose();
                theForm.Controls.Remove(avatarPanel1);
                theForm.Text = "avatarPanel 2";
                NijnCoach.View.AvatarPanel.AvatarPanel avatarPanel2 = new NijnCoach.View.AvatarPanel.AvatarPanel();
                avatarPanel2.Size = new Size(600, 400);
                theForm.Controls.Add(avatarPanel2);
            }
            t = new System.Windows.Forms.Timer();
            t.Interval = 6000;
            t.Tick += new EventHandler(closeForm);
            t.Enabled = true;
        }

        private void closeForm(object sender, EventArgs e)
        {
            if(theForm != null)
            {
                theForm.Close();
            }
            t.Enabled = false;
        }
    }
}
