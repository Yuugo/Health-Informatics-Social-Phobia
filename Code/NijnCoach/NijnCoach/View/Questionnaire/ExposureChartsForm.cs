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
            //this.Load += new System.EventHandler(this.ProgressOverviewChart_Load);


            //this.Load += new System.EventHandler(this.ProgressOverviewChart_CheckedChanged);
            //this.Load += new System.EventHandler(this.ProgressOverviewChart_CheckedChanged);
            //this.Load += new System.EventHandler(this.ProgressOverviewChart_CheckedChanged);
        }

//        private void ProgressOverviewChart_Load(object sender, EventArgs e)
//        {
//            this.overviewChart.Series.Clear();
//
//            #region Initialize the series
//
//            var hrOverviewSerie = new Series
//            {
//                Name = "Heartrate",
//                Color = System.Drawing.Color.Red,
//                IsVisibleInLegend = true,
//                IsXValueIndexed = true,
//                ChartType = SeriesChartType.Line,
//                XValueType = ChartValueType.Auto
//            };
//            var gsrOverviewSerie = new Series
//            {
//                Name = "GSR",
//                Color = System.Drawing.Color.Green,
//                IsVisibleInLegend = true,
//                IsXValueIndexed = true,
//                ChartType = SeriesChartType.Line,
//                XValueType = ChartValueType.Auto
//            };
//            var sudOverviewSerie = new Series
//            {
//                Name = "SUD",
//                Color = System.Drawing.Color.Blue,
//                IsVisibleInLegend = true,
//                IsXValueIndexed = true,
//                ChartType = SeriesChartType.Line,
//                XValueType = ChartValueType.Auto
//            };
//
//            this.overviewChart.Series.Add(hrOverviewSerie);
//            this.overviewChart.Series.Add(gsrOverviewSerie);
//            this.overviewChart.Series.Add(sudOverviewSerie);
//
//            #endregion
//
//            // Fill the series with all the mean scores from the exposure sessions
//            var sessions = getAllSessionsFromDatabase();
//            foreach (ExposureSession s in sessions)
//            {
//                var e = s.meanScore();
//                hrOverviewSerie.Points.AddXY(s.getDate(), e.getHR());
//                gsrOverviewSerie.Points.AddXY(s.getDate(), e.getGSR());
//                sudOverviewSerie.Points.AddXY(s.getDate(), e.getSUD());
//            }
//
//            // Hide every serie except for the SUD score as a default serie
//            this.overviewChart.Series["hrOverviewSerie"].Enabled = false;
//            this.overviewChart.Series["gsrOverviewSerie"].Enabled = false;
//
//        }


        private void LastExposureSessionChart_Load(object sender, EventArgs e)
        {
            this.lastSessionChart.Series.Clear();

            string file = "Z://git//Health-Informatics-Social-Phobia//Code//NijnCoach//NijnCoach//06-05-2013_1501.txt";
            ExposureSession session = ReadExposureData.ReadFile(file);

            #region Initialize the series

            var hrserie = new Series
            {
                Name = "Heartrate",
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

            this.lastSessionChart.Series.Add(hrserie);
            this.lastSessionChart.Series.Add(gsrserie);
            this.lastSessionChart.Series.Add(sudserie);

            #endregion

            // Fill all the series with the data from the previous session
            int sud = 0;
            ExpTimestamp data = session.nextTimeStamp();
            do
            {
                gsrserie.Points.AddXY(data.getTime(), data.getGSR());
                hrserie.Points.AddXY(data.getTime(), data.getHR());
                if (data.getSUD() >= 0)
                    sud = data.getSUD();
                sudserie.Points.AddXY(data.getTime(), sud);
                data = session.nextTimeStamp();
            } while (data != null);

            // Hide every serie except for the SUD score as a default serie
            //this.lastSessionChart.Series["Heartrate"].Enabled = false;
            //this.lastSessionChart.Series["GSR"].Enabled = false;
            //this.lastSessionChart.Series["SUD"].Enabled = false;

            this.lastSessionChart.Invalidate();
        }

        private void rescaleChart(Chart chart, string serie)
        {
            if ((serie == "GSR" || serie == "SUD" || serie == "Heartrate") && chart != null)
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
                rescaleChart(this.lastSessionChart, "GSR");
                this.lastSessionChart.Invalidate();
                this.lastSessionChart.Update();
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
                this.lastSessionChart.Series["SUD"].Enabled = true;
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
                this.lastSessionChart.Series["Heartrate"].Enabled = true;
                rescaleChart(this.lastSessionChart, "Heartrate");
            }
            else
            {
                this.lastSessionChart.Series["Heartrate"].Enabled = false;
            }
        }


    }
}
