using System.Windows.Forms;
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
            GUIHelper.setElement(ref this.buttonContinue, new System.Drawing.Point(370, 400), "buttonContinue", new System.Drawing.Size(185, 30),
                0, "Continue to questionnaire -->", false);
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(continueEventHandler);
            // 
            // buttonHome
            // 
            GUIHelper.setElement(ref this.buttonHome, new System.Drawing.Point(6, 12), "buttonHome", new System.Drawing.Size(75, 23),
                4, "Home", false);
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.homeEventHandler);
            // 
            // AvatarContainer
            // 
            this.Controls.AddRange(new Control[] { this.buttonContinue, this.buttonHome });
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonHome;
    }
}
