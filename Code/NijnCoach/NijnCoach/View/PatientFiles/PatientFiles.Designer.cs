namespace NijnCoach.View.PatientFiles
{

    partial class PatientFiles
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.labelH = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            System.Windows.Forms.Label[] labels = { label1, label2, label3, label4, label5, label6, label7, label8, label9, labelH };
            System.Windows.Forms.TextBox[] textBoxes = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9 };

            string[] labelText = { "First name", "Last name", "Age", "Street", "House number", "Postal code", "City", "Telephone number", "Email address" };
            int[] textSizes = { 222, 222, 58, 222, 58, 100, 222, 145, 222 };

            for (int i = 0; i < 9; i++)
            {
                GUIHelper.setElement(ref labels[i], new System.Drawing.Point(48, 96 + 29 * i), "label" + (i + 1).ToString(), new System.Drawing.Size(74, 17), i, labelText[i]);
                GUIHelper.setElement(ref textBoxes[i], new System.Drawing.Point(190, 96 + 29 * i), "textBox" + (i + 1).ToString(), new System.Drawing.Size(textSizes[i], 22), i + 9, "");
                labels[i].AutoSize = true;
            }

            // 
            // labelH
            // 
            this.labelH.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelH.Location = new System.Drawing.Point(12, 23);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(459, 42);
            this.labelH.TabIndex = 18;
            this.labelH.Text = "Personal data";
            this.labelH.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(291, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 45);
            this.button1.TabIndex = 19;
            this.button1.Text = "Save file";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // PatientFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 490);
            this.Controls.AddRange(textBoxes);
            this.Controls.AddRange(labels);
            this.Controls.Add(this.button1);
            this.Name = "PatientFiles";
            this.Text = "PatientFiles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1, label2, label3, label4, label5, label6, label7, label8, label9, labelH;
        public System.Windows.Forms.TextBox textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9;
        public System.Windows.Forms.Button button1;
    }
}
