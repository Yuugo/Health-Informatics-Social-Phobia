using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NijnCoach.XMLclasses;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using NijnCoach.View.AvatarDir;
using NijnCoach.View.Main;
using NijnCoach.View.Questionnaire;
using NijnCoach.View.Home;
using NijnCoach.Model;
using NijnCoach.Database;


namespace NijnCoach.View.Overview
{
    public partial class OverviewPanel : AvatarContainer
    {
        private Boolean _loadAvatar = true;
        private List<ExposureSession> exposureSessions;

        public OverviewPanel(Boolean _loadAvatar = true) : base(_loadAvatar)
        {
            this._loadAvatar = _loadAvatar;
        }

        protected override void avatarLoaded()
        {
            
        }

        private void continueEventHandler(object sender, EventArgs e)
        {
            //TODO: Fetch briefing questionnaire from database
            MainForm.mainForm.replacePanel(new QuestionnaireForm(_loadAvatar));
        }

        private void homeEventHandler(object sender, EventArgs e)
        {
            MainForm.mainForm.replacePanel(new HomePanel(_loadAvatar));
        }

        private void ExposureSessions_Load()
        {
            // Retrieve all the session data from the database
            this.exposureSessions = getAllSessionsFromDatabase();
            if (this.exposureSessions.Count == 0)
            {
                MessageBox.Show("No exposure data available");
                throw new ArgumentException("No exposure data available");
            }
            // Make the sessions selectable in the selection box
            this.PreviousSessionSelectBox.BindingContext = new BindingContext();
            this.PreviousSessionSelectBox.DataSource = this.exposureSessions;
            this.PreviousSessionSelectBox.DisplayMember = "Date";
            // Set the initial selected session to be the last one
            this.PreviousSessionSelectBox.SelectedIndex = this.exposureSessions.Count() - 1;
            // Load the charts
            this.PreviousSessionChart_Load();
            this.ProgressOverviewChart_Load();
        }

        //dummy function, has to call a database function to retrieve the sessions, 
        //maybe sort them and save them in an object.
        private List<ExposureSession> getAllSessionsFromDatabase()
        {
            List<ProgressEval> dbsess = DBConnect.getProgressEvaluationByPatient(MainClass.userNo);

            List<ExposureSession> sessions = new List<ExposureSession>(dbsess.Count());

            foreach (ProgressEval dbs in dbsess)
            {
                var ses = ReadExposureData.CreateExposureSession(dbs.Name, dbs.Content);
                Comment com = new Comment { value = dbs.Commentary, emotion = ""/*dbs.Emotion*/ };
                ses.comment = com;
                sessions.Add(ses);
            }

            sessions.Sort((a, b) => a.CompareTo(b));

            return sessions;
        }

        private ExposureSession selectedSession(){
            return (ExposureSession)PreviousSessionSelectBox.SelectedItem;
        }

        private void initializeChartSeries(Chart chart)
        {
            var hrserie = new Series
            {
                Name = "HR",
                Color = System.Drawing.Color.Red,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Auto
            };
            var gsrserie = new Series
            {
                Name = "GSR",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Auto
            };
            var sudserie = new Series
            {
                Name = "SUD",
                Color = System.Drawing.Color.Blue,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Auto
            };

            chart.Series.Add(hrserie);
            chart.Series.Add(gsrserie);
            chart.Series.Add(sudserie);
        }

        private void ProgressOverviewChart_Load()
        {
            this.overviewChart.Series.Clear();

            initializeChartSeries(this.overviewChart);

            // Fill the series with all the mean scores from the exposure sessions
            foreach (ExposureSession s in exposureSessions)
            {
                var t = s.meanScore();
                this.overviewChart.Series["HR"].Points.AddXY(s.getDate(), t.getHR());
                this.overviewChart.Series["GSR"].Points.AddXY(s.getDate(), t.getGSR());
                this.overviewChart.Series["SUD"].Points.AddXY(s.getDate(), t.getSUD());
            }

            // rescale to SUD scale so the other two don't show
            rescaleChart(this.overviewChart, "SUD");

            this.overviewChart.Invalidate();
        }

        private void PreviousSessionChart_Load()
        {
            Debug.Assert(selectedSession() != null);

            this.previousSessionChart.Series.Clear();

            initializeChartSeries(this.previousSessionChart);

            ExposureSession previousSession = selectedSession();
            // Fill all the series with the data from the previous session
            int sud = 0;
            ExpTimestamp data = previousSession.nextTimeStamp();
            do
            {
                this.previousSessionChart.Series["GSR"].Points.AddXY(data.getTime(), data.getGSR());
                this.previousSessionChart.Series["HR"].Points.AddXY(data.getTime(), data.getHR());
                if (data.getSUD() >= 0)
                    sud = data.getSUD();
                this.previousSessionChart.Series["SUD"].Points.AddXY(data.getTime(), sud);
                data = previousSession.nextTimeStamp();
            } while (data != null);

            // rescale to SUD scale so the other two don't show
            rescaleChart(this.previousSessionChart, "SUD");

            // set the title of the chart to the date of the session
            this.previousSessionTitle.Text = previousSession.Date;

            this.previousSessionChart.Invalidate();
        }

        private void rescaleChart(Chart chart, string serie)
        {
            Debug.Assert((serie == "GSR" || serie == "SUD" || serie == "HR") && chart != null, "Unvalid chart or serie to rescale");

            if (serie == "SUD") // Resize chart different for SUD, because it looks better when the max is 10
            {
                chart.ChartAreas[0].AxisY.Maximum = 10;
            }
            else
            {
                var maxValue = double.MinValue;
                var margin = 1.3;

                foreach (var pt in chart.Series[serie].Points)
                {
                    if (maxValue < pt.YValues[0]) maxValue = pt.YValues[0];
                }

                chart.ChartAreas[0].AxisY.Maximum = maxValue * margin;
            }
        }

        private void gsrRadiobuttonPreviousSession_CheckedChanged(Object sender, EventArgs e)
        {
            if (gsrRadiobuttonPreviousSession.Checked)
            {
                this.previousSessionChart.Series["GSR"].Enabled = true;
                this.previousSessionChart.Series["SUD"].Enabled = false;
                this.previousSessionChart.Series["HR"].Enabled = false;
                rescaleChart(this.previousSessionChart, "GSR");
            } 
            else
            {
                this.previousSessionChart.Series["GSR"].Enabled = false;
            }
        }

        private void sudRadiobuttonPreviousSession_CheckedChanged(Object sender, EventArgs e)
        {
            if (sudRadiobuttonPreviousSession.Checked)
            {
                this.previousSessionChart.Series["GSR"].Enabled = false;
                this.previousSessionChart.Series["SUD"].Enabled = true;
                this.previousSessionChart.Series["HR"].Enabled = false;
                rescaleChart(this.previousSessionChart, "SUD");
            }
            else
            {
                this.previousSessionChart.Series["SUD"].Enabled = false;
            }
        }

        private void hrRadiobuttonPreviousSession_CheckedChanged(Object sender, EventArgs e)
        {
            if (hrRadiobuttonPreviousSession.Checked)
            {
                this.previousSessionChart.Series["GSR"].Enabled = false;
                this.previousSessionChart.Series["SUD"].Enabled = false;
                this.previousSessionChart.Series["HR"].Enabled = true;
                rescaleChart(this.previousSessionChart, "HR");
            }
            else
            {
                this.previousSessionChart.Series["HR"].Enabled = false;
            }
        }

        private void gsrRadiobuttonOverview_CheckedChanged(Object sender, EventArgs e)
        {
            if (gsrRadiobuttonOverview.Checked)
            {
                this.overviewChart.Series["GSR"].Enabled = true;
                this.overviewChart.Series["SUD"].Enabled = false;
                this.overviewChart.Series["HR"].Enabled = false;
                rescaleChart(this.overviewChart, "GSR");
            }
            else
            {
                this.overviewChart.Series["GSR"].Enabled = false;
            }
        }

        private void sudRadiobuttonOverview_CheckedChanged(Object sender, EventArgs e)
        {
            if (sudRadiobuttonOverview.Checked)
            {
                this.overviewChart.Series["GSR"].Enabled = false;
                this.overviewChart.Series["SUD"].Enabled = true;
                this.overviewChart.Series["HR"].Enabled = false;
                rescaleChart(this.overviewChart, "SUD");
            }
            else
            {
                this.overviewChart.Series["SUD"].Enabled = false;
            }
        }

        private void hrRadiobuttonOverview_CheckedChanged(Object sender, EventArgs e)
        {
            if (hrRadiobuttonOverview.Checked)
            {
                this.overviewChart.Series["GSR"].Enabled = false;
                this.overviewChart.Series["SUD"].Enabled = false;
                this.overviewChart.Series["HR"].Enabled = true;
                rescaleChart(this.overviewChart, "HR");
            }
            else
            {
                this.overviewChart.Series["HR"].Enabled = false;
            }
        }

        private void CommentPanel_Load()
        {
            commentPanel.SuspendLayout();
            Comment comment = selectedSession().comment;
            if (comment != null)
            {
                commentPanelIntern.entry = comment;
            }
            else
            {
                Comment empty = new Comment { value = String.Empty, emotion = String.Empty };
                commentPanelIntern.entry = empty;
            }
            commentPanel.ResumeLayout();
        }

        private void PreviousSessionSelectBox_SelectedIndexChanged(Object sender, EventArgs e)
        {
            sudRadiobuttonPreviousSession.Checked = true;
            PreviousSessionChart_Load();
            CommentPanel_Load();
        }

        // Function to hide the session selection box when looking at the overview chart
        private void chartTabs_SelectedIndexChanged(Object sender, EventArgs e)
        {
            this.PreviousSessionSelectBox.Enabled = this.chartTabs.SelectedTab == previousSessionTab;
        }
    }
}
