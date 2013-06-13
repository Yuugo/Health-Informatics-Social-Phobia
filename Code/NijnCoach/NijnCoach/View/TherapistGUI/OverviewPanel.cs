using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NijnCoach.View.TherapistGUI
{
    class OverviewPanel : NijnCoach.View.Overview.OverviewPanel
    {
        public OverviewPanel() : base(false)
        {

        }

        protected override void InitializeComponent()
        {
            base.InitializeComponent();
            //TODO: Resize some of the components
        }
        
        protected override void homeEventHandler(object sender, EventArgs e)
        {
            TherapistGUI.TherapistMain.main.replacePanel(new TherapistGUI.HomePanel());
        }
    }
}
