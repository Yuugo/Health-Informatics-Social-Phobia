namespace NijnCoach.View.Home
{
    partial class HomePanel
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
            int left = 370;
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(left, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Fill in Questionnaire";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(questionnaireEventHandler);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(left, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(300, 40);
            this.button2.TabIndex = 0;
            this.button2.Text = "View progress";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(overviewEventHandler);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(left, 200);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(300, 40);
            this.button3.TabIndex = 0;
            this.button3.Text = "Start Exposure";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(exposureEventHandler);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(left, 250);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(300, 40);
            this.button4.TabIndex = 0;
            this.button4.Text = "Exit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(exitEventHandler);

            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(button3);
            this.Controls.Add(button4);
            
            this.ResumeLayout(false);


        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}
