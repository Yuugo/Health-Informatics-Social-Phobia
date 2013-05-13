using System.Collections.Generic;
namespace NijnCoach.View.Questionnaire
{
    partial class CommentPanel : IQuestionPanel
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
            this.labelComment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(10, 30);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(35, 13);
            this.labelComment.TabIndex = 0;
            this.labelComment.Text = "label1";
            // 
            // CommentPanel
            // 
            this.Controls.Add(labelComment);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelComment;

    }
}
