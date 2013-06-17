using System.Windows.Forms;

namespace NijnCoach.View.TherapistGUI
{
    partial class Questionnaires
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
            this.Cancel = new System.Windows.Forms.Button();
            this.QuestionnaireLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Open = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(12, 327);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(123, 44);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // QuestionnaireLabel
            // 
            this.QuestionnaireLabel.AutoSize = true;
            this.QuestionnaireLabel.BackColor = System.Drawing.SystemColors.Control;
            this.QuestionnaireLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionnaireLabel.Location = new System.Drawing.Point(10, 9);
            this.QuestionnaireLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.QuestionnaireLabel.Name = "QuestionnaireLabel";
            this.QuestionnaireLabel.Size = new System.Drawing.Size(127, 20);
            this.QuestionnaireLabel.TabIndex = 6;
            this.QuestionnaireLabel.Text = "Questionnaires:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(278, 259);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Open
            // 
            this.Open.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Open.Location = new System.Drawing.Point(206, 327);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(125, 44);
            this.Open.TabIndex = 7;
            this.Open.Text = "Open";
            this.Open.UseVisualStyleBackColor = true;
            // 
            // Questionnaires
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 402);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.QuestionnaireLabel);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(152, 452);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Questionnaires";
            this.Text = "QuestionnaireDialog";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DataGridView dataGridView1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label QuestionnaireLabel;
        private Button Open;
    }
}