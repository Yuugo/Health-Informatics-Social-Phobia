using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.View.Overview;
using NijnCoach.View.Main;

namespace NijnCoach.View.Exposure
{
    public partial class ExposurePanel : Panel
    {
        private Boolean _loadAvatar = true;
        System.Windows.Forms.Timer t;
        public ExposurePanel(Boolean _loadAvatar = true)
        {
            this._loadAvatar = _loadAvatar;
            InitializeComponent();
            /*
             * Do the complete exposure
             * Not included in this project
             */
            t = new System.Windows.Forms.Timer();
            t.Interval = 3000;
            t.Tick += new EventHandler(exposureFinishedEventHandler);
            t.Enabled = true;

            
        }

        private void exposureFinishedEventHandler(object sender, EventArgs e)
        {
            t.Enabled = false;
            //Load the overview of this exposure session
            //Load the correct data from the database
            try
            {
                MainForm.mainForm.replacePanel(new OverviewPanel(_loadAvatar));
            }
            catch (ArgumentException)
            {
                MainForm.mainForm.replacePanel(new NijnCoach.View.Home.HomePanel(_loadAvatar));
            }
        }

    }
}
