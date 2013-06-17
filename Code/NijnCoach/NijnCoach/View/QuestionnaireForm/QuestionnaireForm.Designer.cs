using NijnCoach.XMLclasses;
using NijnCoach.View.Questionnaire;
using NijnCoach.View.AvatarDir;

namespace NijnCoach.View.Questionnaire
{
    partial class QuestionnaireForm
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
        protected override void InitializeComponent()
        {
            base.InitializeComponent();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(775, 20);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.TabIndex = 4;
            // 
            // panelQuestion
            // 
            this.panelQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelQuestion.Location = new System.Drawing.Point(116, 380);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(744, 95);
            this.panelQuestion.TabIndex = 1;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Enabled = false;
            this.buttonPrevious.Location = new System.Drawing.Point(35, 421);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevious.TabIndex = 2;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.previousEventHandler);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(866, 421);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.nextEventHandler);
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(6, 12);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(75, 23);
            this.buttonHome.TabIndex = 4;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.homeEventHandler);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(6, 41);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.saveEventHandler);
            
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "";
            this.openFileDialog.Filter = "XML Files(*.xml)|*.xml";
            // 
            // QuestionnaireForm
            
            this.ClientSize = new System.Drawing.Size(982, 487);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.panelQuestion);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.progressBar);
            this.progressBar.BringToFront();
            this.Name = "QuestionnaireForm";
            this.Text = "Questionnaire";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelQuestion;
        private IQuestionPanel panelQuestionIntern;
        private System.Windows.Forms.Button buttonPrevious, buttonNext, buttonHome, buttonSave;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

