namespace NijnCoach.View.TherapistGUI
{
    partial class saveFileDialog
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
        private void InitializeComponent()
        {
            this.saveFileCancel = new System.Windows.Forms.Button();
            this.saveFileConfirm = new System.Windows.Forms.Button();
            this.SaveFileLabel = new System.Windows.Forms.Label();
            this.saveFileTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveFileCancel
            // 
            this.saveFileCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.saveFileCancel.Location = new System.Drawing.Point(12, 112);
            this.saveFileCancel.Name = "saveFileCancel";
            this.saveFileCancel.Size = new System.Drawing.Size(92, 36);
            this.saveFileCancel.TabIndex = 4;
            this.saveFileCancel.Text = "Cancel";
            this.saveFileCancel.UseVisualStyleBackColor = true;
            // 
            // saveFileConfirm
            // 
            this.saveFileConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveFileConfirm.Location = new System.Drawing.Point(188, 112);
            this.saveFileConfirm.Name = "saveFileConfirm";
            this.saveFileConfirm.Size = new System.Drawing.Size(92, 36);
            this.saveFileConfirm.TabIndex = 5;
            this.saveFileConfirm.Text = "Save";
            this.saveFileConfirm.UseVisualStyleBackColor = true;
            // 
            // SaveFileLabel
            // 
            this.SaveFileLabel.AutoSize = true;
            this.SaveFileLabel.Location = new System.Drawing.Point(12, 9);
            this.SaveFileLabel.Name = "SaveFileLabel";
            this.SaveFileLabel.Size = new System.Drawing.Size(103, 13);
            this.SaveFileLabel.TabIndex = 6;
            this.SaveFileLabel.Text = "Questionnaire Name";
            // 
            // saveFileTextBox
            // 
            this.saveFileTextBox.Location = new System.Drawing.Point(15, 37);
            this.saveFileTextBox.Name = "saveFileTextBox";
            this.saveFileTextBox.Size = new System.Drawing.Size(265, 20);
            this.saveFileTextBox.TabIndex = 7;
            // 
            // saveFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 160);
            this.Controls.Add(this.saveFileTextBox);
            this.Controls.Add(this.SaveFileLabel);
            this.Controls.Add(this.saveFileConfirm);
            this.Controls.Add(this.saveFileCancel);
            this.Name = "saveFileDialog";
            this.Text = "saveFileDialog";
            this.Location = new System.Drawing.Point(152, 452);
            this.ResumeLayout(false);
            this.PerformLayout();
            

        }

        #endregion

        private System.Windows.Forms.Button saveFileCancel;
        private System.Windows.Forms.Button saveFileConfirm;
        private System.Windows.Forms.Label SaveFileLabel;
        public System.Windows.Forms.TextBox saveFileTextBox;
    }
}