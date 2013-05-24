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
        public ExposurePanel()
        {
            InitializeComponent();
            /*
             * Do the complete exposure
             * Not included in this project
             */
            System.Threading.Thread.Sleep(3000);

            //Load the overview of this exposure session
            //Load the correct data from the database
            MainForm.mainForm.replacePanel(new OverviewPanel());
        }
    }
}
