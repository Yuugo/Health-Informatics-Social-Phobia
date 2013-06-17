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
            int y = 100;
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            System.Windows.Forms.Button[] buttons = {button1, button2, button3, button4,button5};
            System.EventHandler[] eventHandlers = { questionnaireEventHandler, overviewEventHandler, exposureEventHandler, exitEventHandler ,button5_Click};
            string[] buttonText = {"Fill in Questionnaire","View progress","Start Exposure","Exit","Log out"};
            for(int i = 0; i < buttons.Length; i++)
            {
                System.Windows.Forms.Button b = buttons[i];
                GUIHelper.setElement(ref b, new System.Drawing.Point(left, y + i * 50), "button" + (i + 1), new System.Drawing.Size(300, 40), i, buttonText[i]);
                b.UseVisualStyleBackColor = true;
                b.Click += new System.EventHandler(eventHandlers[i]);
            }
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(750, 38);
            this.button5.Size = new System.Drawing.Size(100, 36);

            this.Controls.AddRange(buttons);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button button1, button2, button3, button4,button5;

    }
}
