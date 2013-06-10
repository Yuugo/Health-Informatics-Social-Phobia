using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.View.Home;

namespace NijnCoach.View.TherapistGUI
{
    public partial class TherapistMain : Form
    {

        private static TherapistMain _main;

        private TherapistMain()
        {
            InitializeComponent();
            replacePanel(new HomePanel());
        }

        public static TherapistMain main
        {
            get
            {
                if (_main == null)
                {
                    _main = new TherapistMain();
                }
                return _main;
            }
        }

        public void replacePanel(Panel panel)
        {
            if (innerPanel != null)
            {
                outerPanel.Controls.Remove(innerPanel);
                innerPanel.Dispose();
            }
            innerPanel = panel;
            if (innerPanel != null)
            {
                innerPanel.SuspendLayout();
                innerPanel.Size = new System.Drawing.Size(outerPanel.Size.Width, outerPanel.Size.Height);
                innerPanel.ResumeLayout();
                outerPanel.Controls.Add(innerPanel);
            }
        }

    }
}
