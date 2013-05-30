using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NijnCoach.Exposure_data;
using System.Diagnostics;
using System.Threading;
using System.Globalization;


namespace NijnCoach.View.Questionnaire
{
    public partial class ExposureChartsForm : Form
    {
        private ExposureSession[] exposureSessions;

        public ExposureChartsForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ExposureSessions_Load);
        }

        private void ExposureSessions_Load(object sender, EventArgs e)
        {
            this.exposureSessions = getAllSessionsFromDatabase();
            this.PreviousSessionSelectBox.DataSource = this.exposureSessions;
            this.PreviousSessionSelectBox.DisplayMember = "Date";
            this.PreviousSessionSelectBox.SelectedIndex = this.exposureSessions.Length-1;
            this.PreviousSessionChart_Load();
            this.ProgressOverviewChart_Load();
        }

        //dummy function, has to call a database function to retrieve the sessions, 
        //maybe sort them and save them in an object.
        private ExposureSession[] getAllSessionsFromDatabase()
        {
            ExposureSession[] sessions = new ExposureSession[3];
            string file = "Z://git//Health-Informatics-Social-Phobia//Code//NijnCoach//NijnCoach//04-05-2013_1500.txt";
            ExposureSession session = ReadExposureData.ReadFile(file);
            sessions[0] = session;
            file = "Z://git//Health-Informatics-Social-Phobia//Code//NijnCoach//NijnCoach//05-05-2013_1500.txt";
            session = ReadExposureData.ReadFile(file);
            sessions[1] = session;
            file = "Z://git//Health-Informatics-Social-Phobia//Code//NijnCoach//NijnCoach//06-05-2013_1501.txt";
            session = ReadExposureData.ReadFile(file);
            sessions[2] = session;
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
            if ((serie == "GSR" || serie == "SUD" || serie == "HR") && chart != null)
            {
                var maxValue = double.MinValue;
                var margin = 1.2;

                foreach (var pt in chart.Series[serie].Points) 
                {
                    if (maxValue < pt.YValues[0]) maxValue = pt.YValues[0];
                }

                chart.ChartAreas[0].AxisY.Maximum = maxValue * margin;
            }
            else
            {
                Console.WriteLine("Unvalid chart or serie to rescale");
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

        private void PreviousSessionSelectBox_SelectedIndexChanged(Object sender, EventArgs e)
        {

            sudRadiobuttonPreviousSession.Checked = true;
            PreviousSessionChart_Load();
        }
    }
}
