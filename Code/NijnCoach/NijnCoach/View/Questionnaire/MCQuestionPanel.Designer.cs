﻿using System.Collections.Generic;
namespace NijnCoach.View.Questionnaire
{
    partial class MCQuestionPanel : IQuestionPanel
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
            // 
            // MCQuestionPanel
            // 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion = new System.Windows.Forms.Label();
        private List<System.Windows.Forms.RadioButton> options = new List<System.Windows.Forms.RadioButton>();

    }
}
