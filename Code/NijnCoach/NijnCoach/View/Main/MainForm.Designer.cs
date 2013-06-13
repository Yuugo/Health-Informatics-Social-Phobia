namespace NijnCoach.View.Main
{
    partial class MainForm
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
            int W = 982;
            int H = 487;
            this.outerPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(W, H);
            this.Controls.Add(this.outerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "NijnCoach";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formClosed);
            //this.TopMost = true;
            this.ResumeLayout(false);
            // 
            // outerPanel
            // 
            this.outerPanel.Location = new System.Drawing.Point(0, 0);
            this.outerPanel.Name = "outerPanel";
            this.outerPanel.Size = new System.Drawing.Size(W, H);
            this.outerPanel.TabIndex = 0;
        }

        #endregion

        private System.Windows.Forms.Panel outerPanel, innerPanel;

        private void formClosed(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}