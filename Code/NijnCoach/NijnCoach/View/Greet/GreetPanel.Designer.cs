namespace NijnCoach.View.Greet
{
    partial class GreetPanel
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
        protected override void InitializeComponent()
        {
            base.InitializeComponent();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(370, 400);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(185, 30);
            this.buttonContinue.TabIndex = 0;
            this.buttonContinue.Text = "Continue to questionnaire -->";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Enabled = false;
            this.buttonContinue.Click += new System.EventHandler(continueEventHandler);
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(6, 12);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(75, 23);
            this.buttonHome.TabIndex = 4;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Enabled = false;
            this.buttonHome.Click += new System.EventHandler(this.homeEventHandler);
            // 
            // AvatarContainer
            // 
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonHome);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonHome;
    }
}
