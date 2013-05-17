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
            this.Load += new System.EventHandler(this.ExposureChartsForm_Load);
        }

        private double f(int i)
        {
            var f1 = 59894 - (8128 * i) + (262 * i * i) - (1.6 * i * i * i);
            return f1;
        }


        private void ExposureChartsForm_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            var series2 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series2",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };
            series2.XValueType = ChartValueType.Auto;

            string file = "Z://git//Health-Informatics-Social-Phobia//Code//NijnCoach//NijnCoach//06-05-2013_1500.txt";
            ExposureSession session = ReadExposureData.ReadFile(file);

            Console.WriteLine(session);


            chart1.Series.Add(series2);

            ExpTimestamp data = session.nextTimeStamp();
            series2.Points.AddXY(data.getTime(), data.getScore());
            while (data != null)
            {
                data = session.nextTimeStamp();
                series2.Points.AddXY(data.getTime(), data.getScore());
            }


            // set date format to dutch representation
            Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");
            chart1.Legends.Add(new Legend(session.getDate().ToShortDateString()));

            // show an X label every 3 Minute
            chart1.ChartAreas[0].AxisX.Interval = 3.0;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            
            
            chart1.Invalidate();
        }

    }
}
