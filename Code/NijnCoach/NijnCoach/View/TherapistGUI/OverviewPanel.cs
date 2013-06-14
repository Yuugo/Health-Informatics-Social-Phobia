using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NijnCoach.XMLclasses;
using NijnCoach.View.Questionnaire;
using System.Windows.Forms;
using NijnCoach.Model;

namespace NijnCoach.View.TherapistGUI
{
    class OverviewPanel : NijnCoach.View.Overview.OverviewPanel
    {
        private Panel emptyAvatarPanel;
        private Button buttonSend;
        private Label labelEmotion;
        private ComboBox comboBoxEmotion;
        private Boolean _overview = false;
        private OpenQuestion oq;
        public OverviewPanel() : base(false)
        {

        }

        protected override void InitializeComponent()
        {
            base.InitializeComponent();
            //TODO: Resize some of the components
            commentPanel.Dispose();
            commentPanel = new OpenQuestionPanel(560, 200);
            buttonSend = new Button();
            labelEmotion = new Label();
            comboBoxEmotion = new ComboBox();
            GUIHelper.setElement(ref commentPanel, new System.Drawing.Point(12, 380),"commentPanel", new System.Drawing.Size(560, 200), 4,"");
            this.commentPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            oq = new OpenQuestion();
            oq.question = "What comment do you want to give to this patient?";
            oq.theAnswer = selectedSession().comment.theAnswer;
            (commentPanel as OpenQuestionPanel).entry = oq;

            GUIHelper.setElement(ref buttonSend, new System.Drawing.Point(450, 585), "buttonSend", new System.Drawing.Size(75, 23), 5, "Send");
            buttonSend.Click += new System.EventHandler(buttonSendEventHandler);

            GUIHelper.setElement(ref labelEmotion, new System.Drawing.Point(12, 585), "labelEmotion", new System.Drawing.Size(94, 24), 8, "Emotion");
            this.labelEmotion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmotion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmotion.RightToLeft = System.Windows.Forms.RightToLeft.No;

            this.comboBoxEmotion.FormattingEnabled = true;
            this.comboBoxEmotion.Items.AddRange(new object[] {
            "",
            "Happy",
            "Sad",
            "Angry",
            "Run",
			"Sit",
			"Stand",
			"Surpise"});
            this.comboBoxEmotion.Location = new System.Drawing.Point(130, 585);
            this.comboBoxEmotion.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxEmotion.Name = "comboBoxEmotion";
            this.comboBoxEmotion.Size = new System.Drawing.Size(127, 25);
            this.comboBoxEmotion.TabIndex = 32;

            this.Controls.Add(commentPanel);
            this.Controls.Add(buttonSend);
            this.Controls.Add(labelEmotion);
            this.Controls.Add(comboBoxEmotion);
        }

        protected override System.Windows.Forms.Panel panelAvatar
        {
            get
            {
                if (this.emptyAvatarPanel == null)
                {
                    emptyAvatarPanel = new System.Windows.Forms.Panel();
                    GUIHelper.setElement(ref this.emptyAvatarPanel, new System.Drawing.Point(575, 12), "avatarPanel",
                                    new System.Drawing.Size(400, 360), 5, null);
                }
                return this.emptyAvatarPanel;
            }
        }
        
        protected override void homeEventHandler(object sender, EventArgs e)
        {
            TherapistGUI.TherapistMain.main.replacePanel(new TherapistGUI.HomePanel());
        }

        protected override void chartTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.chartTabs_SelectedIndexChanged(sender, e);
            _overview = !_overview;
        }

        private void buttonSendEventHandler(object sender, EventArgs e)
        {
            ExposureSession eSess = selectedSession();
            String name = eSess.getDate().Day.ToString("D2") + "-" + eSess.getDate().Month.ToString("D2") + "-" + eSess.getDate().Year.ToString("D2") +
                "_" + eSess.getDate().Hour.ToString("D2") + eSess.getDate().Minute.ToString("D2");
            NijnCoach.Database.DBConnect.setEvaluationCommentaryByPatientAndName(NijnCoach.MainClass.userNo, name, oq.theAnswer, comboBoxEmotion.Text);
        }
    }
}
