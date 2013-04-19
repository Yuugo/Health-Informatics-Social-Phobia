using System.Collections.Generic;
namespace NijnCoach.View.Questionnaire
{
    partial class OpenQuestionPanel : IQuestionPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            
            this.SuspendLayout();
            labelQuestion.AutoSize = true;
            Controls.Add(labelQuestion);
            this.SetFlowBreak(labelQuestion, true);
            textBoxAnswer.Width = this.Width - 10;
            textBoxAnswer.Height = this.Height - 10 - labelQuestion.Height;
            textBoxAnswer.Multiline = true;
            textBoxAnswer.TextChanged += new System.EventHandler(answerEventHandler);
            Controls.Add(textBoxAnswer);
            // 
            // OpenQuestionPanel
            // 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        System.Windows.Forms.Label labelQuestion = new System.Windows.Forms.Label();
        System.Windows.Forms.TextBox textBoxAnswer = new System.Windows.Forms.TextBox();

    }
}
