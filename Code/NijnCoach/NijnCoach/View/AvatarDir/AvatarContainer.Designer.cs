namespace NijnCoach.View.AvatarDir
{
    abstract partial class AvatarContainer
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
            if (disposing)
            {
                AvatarPanel.unParentAvatar();
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        protected virtual void InitializeComponent()
        {
            
            this.SuspendLayout();
            // 
            // AvatarContainer
            // 
            this.Controls.Add(this.panelAvatar);
            this.ResumeLayout(false);
        }

        #endregion
        private AvatarDir.AvatarPanel panelAvatarIntern;
        private System.Windows.Forms.Panel _panelAvatar = null;

        protected virtual System.Windows.Forms.Panel panelAvatar
        {
            get
            {
                if (_panelAvatar == null)
                {
                    _panelAvatar = new System.Windows.Forms.Panel();
                    _panelAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    _panelAvatar.Location = new System.Drawing.Point(87, 12);
                    _panelAvatar.Name = "panelAvatar";
                    _panelAvatar.Size = new System.Drawing.Size(797, 365);
                    _panelAvatar.TabIndex = 0;
                }
                return _panelAvatar;
            }
        }
    }
}
