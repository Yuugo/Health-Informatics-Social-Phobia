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
            chart2.Series.Clear();
            var series2 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series1",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };

            string file = "Z://git//Health-Informatics-Social-Phobia//Code//NijnCoach//NijnCoach//06-05-2013_1500.txt";
            ExposureSession session = ReadExposureData.ReadFile(file);

            Console.WriteLine(session);

            this.chart2.Series.Add(series2);

            for (int i = 0; i < 100; i++)
            {
                series2.Points.AddXY(i, f(i));
            }
            chart2.Invalidate();
        }

    }
}
