using System.Collections.Generic;
using System.Windows.Forms;
namespace NijnCoach.View.TherapistGUI
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
        public void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();

            System.Windows.Forms.Button[] buttons = { button1, button2, button3,button4 };
            System.EventHandler[] eventHandlers = { button1_Click, button2_Click, button3_Click,button4_Click};
            string[] buttonText = { "New questionnaire", "New user", "Patients overview" ,"Log out"};
            for (int i = 0;i<4;i++){
                GUIHelper.setElement<Button>(ref buttons[i],new System.Drawing.Point(244, 165 + 92*i),"button" + (1 + i).ToString(),new System.Drawing.Size(157, 51),i,buttonText[i]);
                buttons[i].Click += new System.EventHandler(eventHandlers[i]);
                buttons[i].UseVisualStyleBackColor = true;
            }
           
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 46);
            this.label1.TabIndex = 5;
            this.label1.Text = "Main Menu";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(557, 26);
            this.button4.Size = new System.Drawing.Size(105, 36);
            // 
            // TherapistMain
            // 
            this.Controls.AddRange(buttons);
            this.Controls.Add(this.label1);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1,button2,button3,button4;
        private System.Windows.Forms.Label label1;
    }
}
