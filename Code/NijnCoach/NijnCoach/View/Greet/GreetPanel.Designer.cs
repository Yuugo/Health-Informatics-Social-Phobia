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
        private void InitializeComponent()
        {
            this.panelAvatar = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelAvatar
            // 
            this.panelAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAvatar.Location = new System.Drawing.Point(87, 12);
            this.panelAvatar.Name = "panelAvatar";
            this.panelAvatar.Size = new System.Drawing.Size(797, 365);
            this.panelAvatar.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Continue to questionnaire -->";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Enabled = false;
            this.button1.Click += new System.EventHandler(continueEventHandler);
            // 
            // AvatarContainer
            // 
            this.Controls.Add(this.panelAvatar);
            this.Controls.Add(this.button1);
            this.ResumeLayout(false);

        }

        #endregion
        private AvatarDir.AvatarPanel panelAvatarIntern;
        private System.Windows.Forms.Panel panelAvatar;
        private System.Windows.Forms.Button button1;
    }
}
