using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Threading;
using NijnCoach.View.Questionnaire;
using System;
namespace NijnCoach.View.Overview
{
    partial class OverviewPanel
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
        protected override void InitializeComponent()
        {
            base.InitializeComponent();
            this.buttonHome = new System.Windows.Forms.Button();
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
            // buttonHome
            // 
            System.Windows.Forms.Control[] controls = {buttonHome, previousSessionChart, chartTabs, previousSessionTab, groupBoxRadiobuttonsPreviousSession, gsrRadiobuttonPreviousSession,
                hrRadiobuttonPreviousSession, sudRadiobuttonPreviousSession, overviewTab, groupBoxRadiobuttonsOverview, gsrRadiobuttonOverview, hrRadiobuttonOverview, sudRadiobuttonOverview,
                overviewChart, commentPanel, PreviousSessionSelectBox};
            System.Drawing.Point[] locations = {new System.Drawing.Point(6, 12), new System.Drawing.Point(0, 0), new System.Drawing.Point(12, 45), new System.Drawing.Point(4, 22), 
                                               new System.Drawing.Point(450, 6), new System.Drawing.Point(6, 41), new System.Drawing.Point(6, 64), new System.Drawing.Point(6, 18), 
											   new System.Drawing.Point(4, 22), new System.Drawing.Point(450, 6), new System.Drawing.Point(6, 41), new System.Drawing.Point(6, 64),
											   new System.Drawing.Point(6, 18), new System.Drawing.Point(-4, 0), new System.Drawing.Point(12, 380), new System.Drawing.Point(292, 17) };
            String[] names = { "buttonHome", "previousSessionChart", "chartTabs", "previousSessionTab", "groupBoxRadiobuttonsPreviousSession", "gsrRadiobuttonPreviousSession",
								"hrRadiobuttonPreviousSession", "sudRadiobuttonPreviousSession", "overviewTab", "groupBoxRadiobuttonsOverview", "gsrRadiobuttonOverview",
								"overviewChart", "commentPanel", "PreviousSessionSelectBox"};
            System.Drawing.Size[] sizes = { new System.Drawing.Size(75, 23), new System.Drawing.Size(550, 300), new System.Drawing.Size(560, 330), new System.Drawing.Size(560, 330),
											new System.Drawing.Size(97, 84), new System.Drawing.Size(48, 17), new System.Drawing.Size(69, 17), new System.Drawing.Size(48, 17),
											new System.Drawing.Size(560, 330), new System.Drawing.Size(97, 84), new System.Drawing.Size(48, 17), new System.Drawing.Size(69, 17), 
											new System.Drawing.Size(48, 17), new System.Drawing.Size(550, 300), new System.Drawing.Size(960, 100), new System.Drawing.Size(125, 21)};
			int[] tabIndeces = {4, 3, 4, 0, 7, 5, 6, 4, 1, 8, 5, 0, 6};
			String[] texts = {"Home",  "Previous Session", null, "Previous Session", "Show", "GSR", "Heartrate", "SUD", "Overview Progress", "Show", "GSR", "Heartrate", "SUD", "Overview", 
						null, null};
			System.EventHandler[] eventHandlers = {this.homeEventHandler, null, chartTabs_SelectedIndexChanged, null, null, this.gsrRadiobuttonPreviousSession_CheckedChanged, this.hrRadiobuttonPreviousSession_CheckedChanged,
								this.sudRadiobuttonPreviousSession_CheckedChanged, null, this.gsrRadiobuttonOverview_CheckedChanged, this.gsrRadiobuttonOverview_CheckedChanged, 
								this.hrRadiobuttonOverview_CheckedChanged, null, null, PreviousSessionSelectBox_SelectedIndexChanged};
			for(int i=0; i<controls.Length;i++)
			{
				GUIHelper.setElement(ref controls[i], locations[i], names[i], sizes[i], tabIndeces[i], texts[i]);
				if(eventHandlers[i] != null)
				{
					if(controls[i] is System.Windows.Forms.RadioButton)
					{
						(controls[i] as System.Windows.Forms.RadioButton).CheckedChanged += new System.EventHandler(eventHandlers[i]);
					}
					if(controls[i] is System.Windows.Forms.Button)
					{
						controls[i].Click += new System.EventHandler(eventHandlers[i]);
					}
				}
				if(controls[i] is System.Windows.Forms.RadioButton)
				{
					controls[i].AutoSize = true;
					(controls[i] as System.Windows.Forms.RadioButton).UseVisualStyleBackColor = true;
				}
			}
            
            initPreviousSessionChart();
            initChartTabs();
            initPreviousSessionTab();
            initGroupBoxRadiobuttonsPreviousSession();
            initSudRadiobuttonPreviousSession();
            initOverviewTab();
            initGroupBoxRadiobuttonsOverview();
            initSudRadiobuttonOverview();
            initOverviewChart();
            initCommentPanel();
            initPreviousSessionSelectBox();
            // 
            // ExposureChartsForm
            // 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.PreviousSessionSelectBox, this.commentPanel, this._avatarPanel, this.chartTabs, this.buttonHome});
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
        #region
        private void initPreviousSessionChart()
		{
            System.Windows.Forms.DataVisualization.Charting.ChartArea previousSessionChartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			previousSessionChartArea.AxisX.Interval = 3D;
            previousSessionChartArea.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            previousSessionChartArea.AxisX.LabelStyle.Format = "mm:ss";
            previousSessionChartArea.AxisX.MajorGrid.Enabled = false;
            previousSessionChartArea.AxisY.MajorGrid.Enabled = false;
            previousSessionChartArea.Name = "previousSessionChartArea";
            this.previousSessionChart.ChartAreas.Add(previousSessionChartArea);
            this.previousSessionTitle.Name = "previousSessionTitle";
            this.previousSessionTitle.Text = "Previous Session";
            this.previousSessionChart.Titles.Add(previousSessionTitle);
		}
		
		private void initChartTabs()
		{
			this.chartTabs.Controls.Add(this.previousSessionTab);
            this.chartTabs.Controls.Add(this.overviewTab);
            this.chartTabs.SelectedIndex = 0;
            this.chartTabs.SelectedIndexChanged += new System.EventHandler(chartTabs_SelectedIndexChanged);
		}
		
		private void initPreviousSessionTab()
		{
			this.previousSessionTab.BackColor = System.Drawing.Color.White;
            this.previousSessionTab.Controls.Add(this.groupBoxRadiobuttonsPreviousSession);
            this.previousSessionTab.Controls.Add(this.previousSessionChart);
            this.previousSessionTab.Padding = new System.Windows.Forms.Padding(3);
		}

        private void initGroupBoxRadiobuttonsPreviousSession()
        {
            this.groupBoxRadiobuttonsPreviousSession.Controls.Add(this.gsrRadiobuttonPreviousSession);
            this.groupBoxRadiobuttonsPreviousSession.Controls.Add(this.hrRadiobuttonPreviousSession);
            this.groupBoxRadiobuttonsPreviousSession.Controls.Add(this.sudRadiobuttonPreviousSession);
            this.groupBoxRadiobuttonsPreviousSession.TabStop = false;
        }

        private void initSudRadiobuttonPreviousSession()
        {
            this.sudRadiobuttonPreviousSession.Checked = true;
            this.sudRadiobuttonPreviousSession.TabStop = true;
        }

        private void initOverviewTab()
        {
            this.overviewTab.BackColor = System.Drawing.Color.White;
            this.overviewTab.Controls.Add(this.groupBoxRadiobuttonsOverview);
            this.overviewTab.Controls.Add(this.overviewChart);
            this.overviewTab.Padding = new System.Windows.Forms.Padding(3);
        }

        private void initGroupBoxRadiobuttonsOverview()
        {
            this.groupBoxRadiobuttonsOverview.Controls.Add(this.gsrRadiobuttonOverview);
            this.groupBoxRadiobuttonsOverview.Controls.Add(this.hrRadiobuttonOverview);
            this.groupBoxRadiobuttonsOverview.Controls.Add(this.sudRadiobuttonOverview);
            this.groupBoxRadiobuttonsOverview.TabStop = false;
        }

        private void initSudRadiobuttonOverview()
        {
            this.sudRadiobuttonOverview.AutoSize = true;
            this.sudRadiobuttonOverview.TabStop = true;
        }

        private void initOverviewChart()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea overviewChartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Title overviewTitle = new System.Windows.Forms.DataVisualization.Charting.Title();
            overviewChartArea.AxisX.MajorGrid.Enabled = false;
            overviewChartArea.AxisY.MajorGrid.Enabled = false;
            overviewChartArea.Name = "overviewChartArea";
            this.overviewChart.ChartAreas.Add(overviewChartArea);
            overviewTitle.Name = "overviewTitle";
            overviewTitle.Text = "Overview Progress";
            this.overviewChart.Titles.Add(overviewTitle);
        }

        private void initCommentPanel()
        {
            this.commentPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.commentPanelIntern = new CommentPanel(commentPanel.Width, commentPanel.Height);
            this.commentPanel.Controls.Add(commentPanelIntern);

        }

        private void initPreviousSessionSelectBox()
        {
            this.PreviousSessionSelectBox.FormattingEnabled = true;
            this.PreviousSessionSelectBox.SelectedIndexChanged += new System.EventHandler(PreviousSessionSelectBox_SelectedIndexChanged);
        }
        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart previousSessionChart;
        private System.Windows.Forms.DataVisualization.Charting.Title previousSessionTitle;
        private System.Windows.Forms.TabControl chartTabs;
        private System.Windows.Forms.TabPage previousSessionTab;
        private System.Windows.Forms.TabPage overviewTab;
        private Chart overviewChart;
        private System.Windows.Forms.Panel _avatarPanel;
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
        private System.Windows.Forms.Control buttonHome;

        protected override System.Windows.Forms.Panel panelAvatar
        {
            get
            {
                if (this._avatarPanel == null)
                {
                    _avatarPanel = new System.Windows.Forms.Panel();
                    this._avatarPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
					GUIHelper.setElement(ref this._avatarPanel, new System.Drawing.Point(575, 12), "avatarPanel",
									new System.Drawing.Size(400, 360), 5, null);
                }
                return this._avatarPanel;
            }
        }
    }
}