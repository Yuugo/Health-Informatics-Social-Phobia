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
        }

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

            ExpTimestamp data; int sud = 0;
            do
            {
                data = session.nextTimeStamp();
                gsrserie.Points.AddXY(data.getTime(), data.getGSR());
                hrserie.Points.AddXY(data.getTime(), data.getHR());
                if (data.getSUD() >= 0)
                    sud = data.getSUD();
                sudserie.Points.AddXY(data.getTime(), sud);
            } while (data != null);


            this.lastSessionChart.Invalidate();
        }

    }
}
