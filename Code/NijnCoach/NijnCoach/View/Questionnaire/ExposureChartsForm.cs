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
        
        public ExposureChartsForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.LastExposureSessionChart_Load);
            this.Load += new System.EventHandler(this.ProgressOverviewChart_Load);
        }

        //dummy function, has to be replaced by database function
        private ExposureSession[] getAllSessionsFromDatabase()
        {
            ExposureSession[] sessions = new ExposureSession[3];
            string file = "Z://git//Health-Informatics-Social-Phobia//Code//NijnCoach//NijnCoach//06-05-2013_1501.txt";
            ExposureSession session = ReadExposureData.ReadFile(file);
            sessions[0] = session;
            file = "Z://git//Health-Informatics-Social-Phobia//Code//NijnCoach//NijnCoach//07-05-2013_1500.txt";
            session = ReadExposureData.ReadFile(file);
            sessions[1] = session;
            file = "Z://git//Health-Informatics-Social-Phobia//Code//NijnCoach//NijnCoach//08-05-2013_1500.txt";
            session = ReadExposureData.ReadFile(file);
            sessions[2] = session;
            return sessions;
        }

        //dummy function, has to be replaced by database function
        private ExposureSession getLatestSessionFromDatabase()
        {
            string file = "Z://git//Health-Informatics-Social-Phobia//Code//NijnCoach//NijnCoach//06-05-2013_1501.txt";
            return ReadExposureData.ReadFile(file);
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

        private void ProgressOverviewChart_Load(object sender, EventArgs e)
        {
            this.overviewChart.Series.Clear();

            initializeChartSeries(this.overviewChart);

            // Fill the series with all the mean scores from the exposure sessions
            var sessions = getAllSessionsFromDatabase();
            foreach (ExposureSession s in sessions)
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

        private void LastExposureSessionChart_Load(object sender, EventArgs e)
        {
            this.lastSessionChart.Series.Clear();

            initializeChartSeries(this.lastSessionChart);

            // Fill all the series with the data from the previous session
            var session = getLatestSessionFromDatabase();
            int sud = 0;
            ExpTimestamp data = session.nextTimeStamp();
            do
            {
                this.lastSessionChart.Series["GSR"].Points.AddXY(data.getTime(), data.getGSR());
                this.lastSessionChart.Series["HR"].Points.AddXY(data.getTime(), data.getHR());
                if (data.getSUD() >= 0)
                    sud = data.getSUD();
                this.lastSessionChart.Series["SUD"].Points.AddXY(data.getTime(), sud);
                data = session.nextTimeStamp();
            } while (data != null);

            // rescale to SUD scale so the other two don't show
            rescaleChart(this.lastSessionChart, "SUD");

            this.lastSessionChart.Invalidate();
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

        private void gsrRadiobuttonLastSession_CheckedChanged(Object sender, EventArgs e)
        {
            if (gsrRadiobuttonLastSession.Checked)
            {
                this.lastSessionChart.Series["GSR"].Enabled = true;
                this.lastSessionChart.Series["SUD"].Enabled = false;
                this.lastSessionChart.Series["HR"].Enabled = false;
                rescaleChart(this.lastSessionChart, "GSR");
            } 
            else
            {
                this.lastSessionChart.Series["GSR"].Enabled = false;
            }
        }

        private void sudRadiobuttonLastSession_CheckedChanged(Object sender, EventArgs e)
        {
            if (sudRadiobuttonLastSession.Checked)
            {
                this.lastSessionChart.Series["GSR"].Enabled = false;
                this.lastSessionChart.Series["SUD"].Enabled = true;
                this.lastSessionChart.Series["HR"].Enabled = false;
                rescaleChart(this.lastSessionChart, "SUD");
            }
            else
            {
                this.lastSessionChart.Series["SUD"].Enabled = false;
            }
        }

        private void hrRadiobuttonLastSession_CheckedChanged(Object sender, EventArgs e)
        {
            if (hrRadiobuttonLastSession.Checked)
            {
                this.lastSessionChart.Series["GSR"].Enabled = false;
                this.lastSessionChart.Series["SUD"].Enabled = false;
                this.lastSessionChart.Series["HR"].Enabled = true;
                rescaleChart(this.lastSessionChart, "HR");
            }
            else
            {
                this.lastSessionChart.Series["HR"].Enabled = false;
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
    }
}
