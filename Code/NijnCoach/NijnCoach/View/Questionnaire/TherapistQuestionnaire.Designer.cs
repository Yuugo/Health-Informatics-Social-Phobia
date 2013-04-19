using NijnCoach.XMLclasses;
using System.Diagnostics;
namespace NijnCoach.View.Questionnaire
{
    partial class TherapistQuestionnaire
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(XMLclasses.Questionnaire questionnaire)
        {
            this.SuspendLayout();
            // 
            // TherapistQuestionnaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.ClientSize = new System.Drawing.Size(938, 460);
            this.Name = "TherapistQuestionnaire";
            this.Text = "TherapistQuestionnaire";

            panelMainContent.Width = this.Width - 10;
            panelMainContent.Height = this.Height;
            panelMainContent.AutoScroll = true;
            foreach (IEntry entry in questionnaire.entries)
            {
                IQuestionPanel panel = null;
                if (entry is Comment)
                {
                    panel = new CommentPanel(panelMainContent.Width - 20, 100);
                }
                else if (entry is MCQuestion)
                {
                    panel = new MCQuestionPanel(panelMainContent.Width - 20, 100);
                }
                else if (entry is OpenQuestion)
                {
                    panel = new OpenQuestionPanel(panelMainContent.Width - 20, 100);
                }
                Debug.Assert(panel != null);
                panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                panel.entry = entry;
                panelMainContent.Controls.Add(panel);
                panelMainContent.SetFlowBreak(panel, true);
            }
            this.Controls.Add(panelMainContent);
            this.ResumeLayout(false);


        }

        #endregion

        System.Windows.Forms.FlowLayoutPanel panelMainContent = new System.Windows.Forms.FlowLayoutPanel();
    }
}