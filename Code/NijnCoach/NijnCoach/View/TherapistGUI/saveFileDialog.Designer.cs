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
            this.patientNoBox = new System.Windows.Forms.TextBox();
            this.patientNoLabel = new System.Windows.Forms.Label();
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
            this.saveFileTextBox.Location = new System.Drawing.Point(12, 25);
            this.saveFileTextBox.Name = "saveFileTextBox";
            this.saveFileTextBox.Size = new System.Drawing.Size(265, 20);
            this.saveFileTextBox.TabIndex = 7;
            // 
            // patientNoBox
            // 
            this.patientNoBox.Location = new System.Drawing.Point(12, 86);
            this.patientNoBox.Name = "patientNoBox";
            this.patientNoBox.Size = new System.Drawing.Size(265, 20);
            this.patientNoBox.TabIndex = 8;
            this.patientNoBox.TextChanged += new System.EventHandler(this.va);
            // 
            // patientNoLabel
            // 
            this.patientNoLabel.AutoSize = true;
            this.patientNoLabel.Location = new System.Drawing.Point(12, 70);
            this.patientNoLabel.Name = "patientNoLabel";
            this.patientNoLabel.Size = new System.Drawing.Size(80, 13);
            this.patientNoLabel.TabIndex = 9;
            this.patientNoLabel.Text = "Patient Number";
            // 
            // saveFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 160);
            this.Controls.Add(this.patientNoLabel);
            this.Controls.Add(this.patientNoBox);
            this.Controls.Add(this.saveFileTextBox);
            this.Controls.Add(this.SaveFileLabel);
            this.Controls.Add(this.saveFileConfirm);
            this.Controls.Add(this.saveFileCancel);
            this.Location = new System.Drawing.Point(152, 452);
            this.Name = "saveFileDialog";
            this.Text = "saveFileDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveFileCancel;
        private System.Windows.Forms.Button saveFileConfirm;
        private System.Windows.Forms.Label SaveFileLabel;
        public System.Windows.Forms.TextBox saveFileTextBox;
        public System.Windows.Forms.TextBox patientNoBox;
        private System.Windows.Forms.Label patientNoLabel;
    }
}