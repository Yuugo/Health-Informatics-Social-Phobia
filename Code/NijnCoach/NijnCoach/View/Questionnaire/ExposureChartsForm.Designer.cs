using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Threading;
namespace NijnCoach.View.Questionnaire
{
    partial class ExposureChartsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea previousSessionChartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea overviewChartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Title overviewTitle = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.home = new System.Windows.Forms.Button();
            this.previousSessionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.previousSessionTitle = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartTabs = new System.Windows.Forms.TabControl();
            this.previousSessionTab = new System.Windows.Forms.TabPage();
            this.groupBoxRadiobuttonsPreviousSession = new System.Windows.Forms.GroupBox();
            this.gsrRadiobuttonPreviousSession = new System.Windows.Forms.RadioButton();
            this.hrRadiobuttonPreviousSession = new System.Windows.Forms.RadioButton();
            this.sudRadiobuttonPreviousSession = new System.Windows.Forms.RadioButton();
            this.overviewTab = new System.Windows.Forms.TabPage();
            this.groupBoxRadiobuttonsOverview = new System.Windows.Forms.GroupBox();
            this.gsrRadiobuttonOverview = new System.Windows.Forms.RadioButton();
            this.hrRadiobuttonOverview = new System.Windows.Forms.RadioButton();
            this.sudRadiobuttonOverview = new System.Windows.Forms.RadioButton();
            this.overviewChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.avatarPanel = new System.Windows.Forms.Panel();
            this.commentPanel = new System.Windows.Forms.Panel();
            this.PreviousSessionSelectBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.previousSessionChart)).BeginInit();
            this.chartTabs.SuspendLayout();
            this.previousSessionTab.SuspendLayout();
            this.groupBoxRadiobuttonsPreviousSession.SuspendLayout();
            this.overviewTab.SuspendLayout();
            this.groupBoxRadiobuttonsOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overviewChart)).BeginInit();
            this.SuspendLayout();
            // 
            // home
            // 
            this.home.Location = new System.Drawing.Point(12, 12);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(90, 29);
            this.home.TabIndex = 1;
            this.home.Text = "Home";
            this.home.UseVisualStyleBackColor = true;
            // 
            // previousSessionChart
            // 
            previousSessionChartArea.AxisX.Interval = 3D;
            previousSessionChartArea.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            previousSessionChartArea.AxisX.LabelStyle.Format = "mm:ss";
            previousSessionChartArea.AxisX.MajorGrid.Enabled = false;
            previousSessionChartArea.AxisY.MajorGrid.Enabled = false;
            previousSessionChartArea.Name = "previousSessionChartArea";
            this.previousSessionChart.ChartAreas.Add(previousSessionChartArea);
            this.previousSessionChart.Location = new System.Drawing.Point(0, 0);
            this.previousSessionChart.Name = "previousSessionChart";
            this.previousSessionChart.Size = new System.Drawing.Size(689, 406);
            this.previousSessionChart.TabIndex = 3;
            this.previousSessionChart.Text = "Previous Session";
            this.previousSessionTitle.Name = "previousSessionTitle";
            this.previousSessionTitle.Text = "Previous Session";
            this.previousSessionChart.Titles.Add(previousSessionTitle);
            // 
            // chartTabs
            // 
            this.chartTabs.Controls.Add(this.previousSessionTab);
            this.chartTabs.Controls.Add(this.overviewTab);
            this.chartTabs.Location = new System.Drawing.Point(12, 65);
            this.chartTabs.Name = "chartTabs";
            this.chartTabs.SelectedIndex = 0;
            this.chartTabs.Size = new System.Drawing.Size(693, 428);
            this.chartTabs.TabIndex = 4;
            // 
            // previousSessionTab
            // 
            this.previousSessionTab.BackColor = System.Drawing.Color.White;
            this.previousSessionTab.Controls.Add(this.groupBoxRadiobuttonsPreviousSession);
            this.previousSessionTab.Controls.Add(this.previousSessionChart);
            this.previousSessionTab.Location = new System.Drawing.Point(4, 22);
            this.previousSessionTab.Name = "previousSessionTab";
            this.previousSessionTab.Padding = new System.Windows.Forms.Padding(3);
            this.previousSessionTab.Size = new System.Drawing.Size(685, 402);
            this.previousSessionTab.TabIndex = 0;
            this.previousSessionTab.Text = "Previous Session";
            // 
            // groupBoxRadiobuttonsPreviousSession
            // 
            this.groupBoxRadiobuttonsPreviousSession.Controls.Add(this.gsrRadiobuttonPreviousSession);
            this.groupBoxRadiobuttonsPreviousSession.Controls.Add(this.hrRadiobuttonPreviousSession);
            this.groupBoxRadiobuttonsPreviousSession.Controls.Add(this.sudRadiobuttonPreviousSession);
            this.groupBoxRadiobuttonsPreviousSession.Location = new System.Drawing.Point(582, 6);
            this.groupBoxRadiobuttonsPreviousSession.Name = "groupBoxRadiobuttonsPreviousSession";
            this.groupBoxRadiobuttonsPreviousSession.Size = new System.Drawing.Size(97, 84);
            this.groupBoxRadiobuttonsPreviousSession.TabIndex = 7;
            this.groupBoxRadiobuttonsPreviousSession.TabStop = false;
            this.groupBoxRadiobuttonsPreviousSession.Text = "Show";
            // 
            // gsrRadiobuttonPreviousSession
            // 
            this.gsrRadiobuttonPreviousSession.AutoSize = true;
            this.gsrRadiobuttonPreviousSession.Location = new System.Drawing.Point(6, 41);
            this.gsrRadiobuttonPreviousSession.Name = "gsrRadiobuttonPreviousSession";
            this.gsrRadiobuttonPreviousSession.Size = new System.Drawing.Size(48, 17);
            this.gsrRadiobuttonPreviousSession.TabIndex = 5;
            this.gsrRadiobuttonPreviousSession.Text = "GSR";
            this.gsrRadiobuttonPreviousSession.UseVisualStyleBackColor = true;
            this.gsrRadiobuttonPreviousSession.CheckedChanged += new System.EventHandler(this.gsrRadiobuttonPreviousSession_CheckedChanged);
            // 
            // hrRadiobuttonPreviousSession
            // 
            this.hrRadiobuttonPreviousSession.AutoSize = true;
            this.hrRadiobuttonPreviousSession.Location = new System.Drawing.Point(6, 64);
            this.hrRadiobuttonPreviousSession.Name = "hrRadiobuttonPreviousSession";
            this.hrRadiobuttonPreviousSession.Size = new System.Drawing.Size(69, 17);
            this.hrRadiobuttonPreviousSession.TabIndex = 6;
            this.hrRadiobuttonPreviousSession.Text = "Heartrate";
            this.hrRadiobuttonPreviousSession.UseVisualStyleBackColor = true;
            this.hrRadiobuttonPreviousSession.CheckedChanged += new System.EventHandler(this.hrRadiobuttonPreviousSession_CheckedChanged);
            // 
            // sudRadiobuttonPreviousSession
            // 
            this.sudRadiobuttonPreviousSession.AutoSize = true;
            this.sudRadiobuttonPreviousSession.Checked = true;
            this.sudRadiobuttonPreviousSession.Location = new System.Drawing.Point(6, 18);
            this.sudRadiobuttonPreviousSession.Name = "sudRadiobuttonPreviousSession";
            this.sudRadiobuttonPreviousSession.Size = new System.Drawing.Size(48, 17);
            this.sudRadiobuttonPreviousSession.TabIndex = 4;
            this.sudRadiobuttonPreviousSession.TabStop = true;
            this.sudRadiobuttonPreviousSession.Text = "SUD";
            this.sudRadiobuttonPreviousSession.UseVisualStyleBackColor = true;
            this.sudRadiobuttonPreviousSession.CheckedChanged += new System.EventHandler(this.sudRadiobuttonPreviousSession_CheckedChanged);
            // 
            // overviewTab
            // 
            this.overviewTab.BackColor = System.Drawing.Color.White;
            this.overviewTab.Controls.Add(this.groupBoxRadiobuttonsOverview);
            this.overviewTab.Controls.Add(this.overviewChart);
            this.overviewTab.Location = new System.Drawing.Point(4, 22);
            this.overviewTab.Name = "overviewTab";
            this.overviewTab.Padding = new System.Windows.Forms.Padding(3);
            this.overviewTab.Size = new System.Drawing.Size(685, 402);
            this.overviewTab.TabIndex = 1;
            this.overviewTab.Text = "Overview Progress";
            // 
            // groupBoxRadiobuttonsOverview
            // 
            this.groupBoxRadiobuttonsOverview.Controls.Add(this.gsrRadiobuttonOverview);
            this.groupBoxRadiobuttonsOverview.Controls.Add(this.hrRadiobuttonOverview);
            this.groupBoxRadiobuttonsOverview.Controls.Add(this.sudRadiobuttonOverview);
            this.groupBoxRadiobuttonsOverview.Location = new System.Drawing.Point(582, 6);
            this.groupBoxRadiobuttonsOverview.Name = "groupBoxRadiobuttonsOverview";
            this.groupBoxRadiobuttonsOverview.Size = new System.Drawing.Size(97, 84);
            this.groupBoxRadiobuttonsOverview.TabIndex = 8;
            this.groupBoxRadiobuttonsOverview.TabStop = false;
            this.groupBoxRadiobuttonsOverview.Text = "Show";
            // 
            // gsrRadiobuttonOverview
            // 
            this.gsrRadiobuttonOverview.AutoSize = true;
            this.gsrRadiobuttonOverview.Location = new System.Drawing.Point(6, 41);
            this.gsrRadiobuttonOverview.Name = "gsrRadiobuttonOverview";
            this.gsrRadiobuttonOverview.Size = new System.Drawing.Size(48, 17);
            this.gsrRadiobuttonOverview.TabIndex = 5;
            this.gsrRadiobuttonOverview.Text = "GSR";
            this.gsrRadiobuttonOverview.UseVisualStyleBackColor = true;
            this.gsrRadiobuttonOverview.CheckedChanged += new System.EventHandler(this.gsrRadiobuttonOverview_CheckedChanged);
            // 
            // hrRadiobuttonOverview
            // 
            this.hrRadiobuttonOverview.AutoSize = true;
            this.hrRadiobuttonOverview.Location = new System.Drawing.Point(6, 64);
            this.hrRadiobuttonOverview.Name = "hrRadiobuttonOverview";
            this.hrRadiobuttonOverview.Size = new System.Drawing.Size(69, 17);
            this.hrRadiobuttonOverview.TabIndex = 6;
            this.hrRadiobuttonOverview.Text = "Heartrate";
            this.hrRadiobuttonOverview.UseVisualStyleBackColor = true;
            this.hrRadiobuttonOverview.CheckedChanged += new System.EventHandler(this.hrRadiobuttonOverview_CheckedChanged);
            // 
            // sudRadiobuttonOverview
            // 
            this.sudRadiobuttonOverview.AutoSize = true;
            this.sudRadiobuttonOverview.Checked = true;
            this.sudRadiobuttonOverview.Location = new System.Drawing.Point(6, 18);
            this.sudRadiobuttonOverview.Name = "sudRadiobuttonOverview";
            this.sudRadiobuttonOverview.Size = new System.Drawing.Size(48, 17);
            this.sudRadiobuttonOverview.TabIndex = 4;
            this.sudRadiobuttonOverview.TabStop = true;
            this.sudRadiobuttonOverview.Text = "SUD";
            this.sudRadiobuttonOverview.UseVisualStyleBackColor = true;
            this.sudRadiobuttonOverview.CheckedChanged += new System.EventHandler(this.sudRadiobuttonOverview_CheckedChanged);
            // 
            // overviewChart
            // 
            overviewChartArea.AxisX.MajorGrid.Enabled = false;
            overviewChartArea.AxisY.MajorGrid.Enabled = false;
            overviewChartArea.Name = "overviewChartArea";
            this.overviewChart.ChartAreas.Add(overviewChartArea);
            this.overviewChart.Location = new System.Drawing.Point(-4, 0);
            this.overviewChart.Name = "overviewChart";
            this.overviewChart.Size = new System.Drawing.Size(689, 406);
            this.overviewChart.TabIndex = 0;
            this.overviewChart.Text = "Overview";
            overviewTitle.Name = "overviewTitle";
            overviewTitle.Text = "Overview Progress";
            this.overviewChart.Titles.Add(overviewTitle);
            // 
            // avatarPanel
            // 
            this.avatarPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.avatarPanel.Location = new System.Drawing.Point(711, 12);
            this.avatarPanel.Name = "avatarPanel";
            this.avatarPanel.Size = new System.Drawing.Size(567, 646);
            this.avatarPanel.TabIndex = 5;
            // 
            // commentPanel
            // 
            this.commentPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.commentPanel.Location = new System.Drawing.Point(12, 499);
            this.commentPanel.Name = "commentPanel";
            this.commentPanel.Size = new System.Drawing.Size(693, 159);
            this.commentPanel.TabIndex = 6;
            this.commentPanelIntern = new CommentPanel(commentPanel.Width, commentPanel.Height);
            this.commentPanel.Controls.Add(commentPanelIntern);
            // 
            // PreviousSessionSelectBox
            // 
            this.PreviousSessionSelectBox.FormattingEnabled = true;
            this.PreviousSessionSelectBox.Location = new System.Drawing.Point(292, 17);
            this.PreviousSessionSelectBox.Name = "PreviousSessionSelectBox";
            this.PreviousSessionSelectBox.Size = new System.Drawing.Size(125, 21);
            this.PreviousSessionSelectBox.TabIndex = 7;
            this.PreviousSessionSelectBox.SelectedIndexChanged += new System.EventHandler(PreviousSessionSelectBox_SelectedIndexChanged);
            // 
            // ExposureChartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 670);
            this.Controls.Add(this.PreviousSessionSelectBox);
            this.Controls.Add(this.commentPanel);
            this.Controls.Add(this.avatarPanel);
            this.Controls.Add(this.chartTabs);
            this.Controls.Add(this.home);
            this.Name = "ExposureChartsForm";
            this.Text = "ExposureChartsForm";
            ((System.ComponentModel.ISupportInitialize)(this.previousSessionChart)).EndInit();
            this.chartTabs.ResumeLayout(false);
            this.previousSessionTab.ResumeLayout(false);
            this.groupBoxRadiobuttonsPreviousSession.ResumeLayout(false);
            this.groupBoxRadiobuttonsPreviousSession.PerformLayout();
            this.overviewTab.ResumeLayout(false);
            this.groupBoxRadiobuttonsOverview.ResumeLayout(false);
            this.groupBoxRadiobuttonsOverview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overviewChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button home;
        private System.Windows.Forms.DataVisualization.Charting.Chart previousSessionChart;
        private System.Windows.Forms.DataVisualization.Charting.Title previousSessionTitle;
        private System.Windows.Forms.TabControl chartTabs;
        private System.Windows.Forms.TabPage previousSessionTab;
        private System.Windows.Forms.TabPage overviewTab;
        private Chart overviewChart;
        private System.Windows.Forms.Panel avatarPanel;
        private System.Windows.Forms.Panel commentPanel;
        private IQuestionPanel commentPanelIntern;
        private System.Windows.Forms.GroupBox groupBoxRadiobuttonsPreviousSession;
        private System.Windows.Forms.RadioButton gsrRadiobuttonPreviousSession;
        private System.Windows.Forms.RadioButton hrRadiobuttonPreviousSession;
        private System.Windows.Forms.RadioButton sudRadiobuttonPreviousSession;
        private System.Windows.Forms.GroupBox groupBoxRadiobuttonsOverview;
        private System.Windows.Forms.RadioButton gsrRadiobuttonOverview;
        private System.Windows.Forms.RadioButton hrRadiobuttonOverview;
        private System.Windows.Forms.RadioButton sudRadiobuttonOverview;
        private System.Windows.Forms.ComboBox PreviousSessionSelectBox;
    }
}