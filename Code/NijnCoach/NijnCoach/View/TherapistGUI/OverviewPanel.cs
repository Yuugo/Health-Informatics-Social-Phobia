using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NijnCoach.XMLclasses;
using NijnCoach.View.Questionnaire;

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
            commentPanel.Dispose();
            commentPanel = new OpenQuestionPanel(550, 100);
            commentPanel.Size = new System.Drawing.Size(550, 100);
            OpenQuestion oq = new OpenQuestion();
            oq.question = "What comment do you want to give to this patient?";
            (commentPanel as OpenQuestionPanel).entry = oq;
        }
        
        protected override void homeEventHandler(object sender, EventArgs e)
        {
            TherapistGUI.TherapistMain.main.replacePanel(new TherapistGUI.HomePanel());
        }
    }
}
