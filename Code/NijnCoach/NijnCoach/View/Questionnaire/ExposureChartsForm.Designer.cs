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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.home = new System.Windows.Forms.Button();
            this.lastSessionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTabs = new System.Windows.Forms.TabControl();
            this.lastSessionTab = new System.Windows.Forms.TabPage();
            this.overviewTab = new System.Windows.Forms.TabPage();
            this.overviewChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.avatarPanel = new System.Windows.Forms.Panel();
            this.commentPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lastSessionChart)).BeginInit();
            this.chartTabs.SuspendLayout();
            this.lastSessionTab.SuspendLayout();
            this.overviewTab.SuspendLayout();
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
            // lastSessionChart
            // 
            chartArea3.AxisX.Interval = 3D;
            chartArea3.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea3.AxisX.LabelStyle.Format = "mm:ss";
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisY.LabelStyle.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.Name = "ChartArea1";
            this.lastSessionChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.lastSessionChart.Legends.Add(legend3);
            this.lastSessionChart.Location = new System.Drawing.Point(0, 0);
            this.lastSessionChart.Name = "lastSessionChart";
            this.lastSessionChart.Size = new System.Drawing.Size(597, 361);
            this.lastSessionChart.TabIndex = 3;
            this.lastSessionChart.Text = "Last Session";
            title3.Name = "title1";
            title3.Text = "Last session";
            this.lastSessionChart.Titles.Add(title3);
            // 
            // chartTabs
            // 
            this.chartTabs.Controls.Add(this.lastSessionTab);
            this.chartTabs.Controls.Add(this.overviewTab);
            this.chartTabs.Location = new System.Drawing.Point(12, 65);
            this.chartTabs.Name = "chartTabs";
            this.chartTabs.SelectedIndex = 0;
            this.chartTabs.Size = new System.Drawing.Size(605, 387);
            this.chartTabs.TabIndex = 4;
            // 
            // lastSessionTab
            // 
            this.lastSessionTab.BackColor = System.Drawing.SystemColors.Control;
            this.lastSessionTab.Controls.Add(this.lastSessionChart);
            this.lastSessionTab.Location = new System.Drawing.Point(4, 22);
            this.lastSessionTab.Name = "lastSessionTab";
            this.lastSessionTab.Padding = new System.Windows.Forms.Padding(3);
            this.lastSessionTab.Size = new System.Drawing.Size(597, 361);
            this.lastSessionTab.TabIndex = 0;
            this.lastSessionTab.Text = "Last Session";
            // 
            // overviewTab
            // 
            this.overviewTab.BackColor = System.Drawing.SystemColors.Control;
            this.overviewTab.Controls.Add(this.overviewChart);
            this.overviewTab.Location = new System.Drawing.Point(4, 22);
            this.overviewTab.Name = "overviewTab";
            this.overviewTab.Padding = new System.Windows.Forms.Padding(3);
            this.overviewTab.Size = new System.Drawing.Size(597, 361);
            this.overviewTab.TabIndex = 1;
            this.overviewTab.Text = "Overview Progress";
            // 
            // overviewChart
            // 
            chartArea4.Name = "ChartArea2";
            this.overviewChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend2";
            this.overviewChart.Legends.Add(legend4);
            this.overviewChart.Location = new System.Drawing.Point(-4, 0);
            this.overviewChart.Name = "overviewChart";
            this.overviewChart.Size = new System.Drawing.Size(601, 361);
            this.overviewChart.TabIndex = 0;
            this.overviewChart.Text = "Overview";
            title4.Name = "title2";
            title4.Text = "Overview Progress";
            this.overviewChart.Titles.Add(title4);
            // 
            // avatarPanel
            // 
            this.avatarPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.avatarPanel.Location = new System.Drawing.Point(623, 12);
            this.avatarPanel.Name = "avatarPanel";
            this.avatarPanel.Size = new System.Drawing.Size(655, 646);
            this.avatarPanel.TabIndex = 5;
            // 
            // commentPanel
            // 
            this.commentPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.commentPanel.Location = new System.Drawing.Point(12, 458);
            this.commentPanel.Name = "commentPanel";
            this.commentPanel.Size = new System.Drawing.Size(600, 200);
            this.commentPanel.TabIndex = 6;
            // 
            // ExposureChartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 670);
            this.Controls.Add(this.commentPanel);
            this.Controls.Add(this.avatarPanel);
            this.Controls.Add(this.chartTabs);
            this.Controls.Add(this.home);
            this.Name = "ExposureChartsForm";
            this.Text = "ExposureChartsForm";
            ((System.ComponentModel.ISupportInitialize)(this.lastSessionChart)).EndInit();
            this.chartTabs.ResumeLayout(false);
            this.lastSessionTab.ResumeLayout(false);
            this.overviewTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overviewChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button home;
        private System.Windows.Forms.DataVisualization.Charting.Chart lastSessionChart;
        private System.Windows.Forms.TabControl chartTabs;
        private System.Windows.Forms.TabPage lastSessionTab;
        private System.Windows.Forms.TabPage overviewTab;
        private Chart overviewChart;
        private System.Windows.Forms.Panel avatarPanel;
        private System.Windows.Forms.Panel commentPanel;
    }
}