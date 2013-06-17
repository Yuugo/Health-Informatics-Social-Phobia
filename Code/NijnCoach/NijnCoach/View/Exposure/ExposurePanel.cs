using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.View.Overview;
using NijnCoach.View.Main;

namespace NijnCoach.View.Exposure
{
    public partial class ExposurePanel : Panel
    {
        private Boolean _loadAvatar = false;
        System.Windows.Forms.Timer t;
        public ExposurePanel(Boolean _loadAvatar = true)
        {
            this._loadAvatar = _loadAvatar;
            InitializeComponent();
            /*
             * Do the complete exposure
             * Not included in this project
             */
            //Instead some dummy data will be generated
            generateDummyData();
            //End of dummy code
            t = new System.Windows.Forms.Timer();
            t.Interval = 3000;
            t.Tick += new EventHandler(exposureFinishedEventHandler);
            t.Enabled = true;

            
        }

        private void exposureFinishedEventHandler(object sender, EventArgs e)
        {
            t.Enabled = false;
            //Load the overview of this exposure session
            //Load the correct data from the database
            try
            {
                MainForm.mainForm.replacePanel(new OverviewPanel(_loadAvatar));
            }
            catch (ArgumentException)
            {
                MainForm.mainForm.replacePanel(new NijnCoach.View.Home.HomePanel(_loadAvatar));
            }
        }

        //Start of dummy code
        private static Random rnd = new Random(DateTime.Now.Millisecond);

        private void generateDummyData()
        {
            String sOut = "TimeStamp\tHeartRate\t\tGSR\t\tSUD\n";
            int hour = System.DateTime.Now.Hour;
            int beginMinute = System.DateTime.Now.Minute;
            int beginSecond = System.DateTime.Now.Second;
            string name = System.DateTime.Now.Day.ToString("D2") + "-" + System.DateTime.Now.Month.ToString("D2") + "-" + System.DateTime.Now.Year.ToString("D2") +
                "_" + hour.ToString("D2") + beginMinute.ToString("D2");
            double delta = ( (double)rnd.Next(100, 200) )/100.0;//Random
            int i;
            int minute = beginMinute;
            int second = beginSecond;
            for (i = 0; i < 1800; i++)
            {
                sOut += hour.ToString("D2") + ":" + minute.ToString("D2") + ":" + second.ToString("D2") + "\t";
                sOut += hr(i, delta).ToString() + "\t";//heartrate
                sOut += gsr(i, delta).ToString() + "\t";//GSR
                if (minute % 3 == beginMinute % 3 && second == beginSecond)
                {
                    sOut += sud(i, delta).ToString() + "\t";//SUD
                }
                sOut += "\n";
                second++;
                if (second >= 60)
                {
                    second = 0;
                    minute++;
                }
                if (minute >= 60)
                {
                    minute = 0;
                    hour++;
                }
                if (hour >= 24)
                {
                    hour = 0;
                }
            }
            NijnCoach.Database.DBConnect.InsertProgressEvaluation(name, MainClass.userNo, sOut);
        }


        private int sud(int x, double delta)
        {
            double a = rnd.Next() % 10 * 0.0000001 - 0.000005;
            double b = x - rnd.Next(880, 920);
            double c = 5 * delta;
            double r = a * b * b + c;
            return (int)r;
        }

        private int gsr(int x, double delta)
        {
            double a = rnd.Next() % 5 * 0.00001 - 0.0001;
            double b = x - rnd.Next(880, 920);
            double c = rnd.Next(540,550) * delta;
            double r = a * b * b + c;
            return (int)r;
        }

        private int hr(int x, double delta)
        {
            double a = rnd.Next()%20 * 0.000001 - 0.00004;
            double b = x - rnd.Next(850, 950);
            double c = rnd.Next(70, 80) * delta;
            double r = a * b * b + c;
            return (int)r;
        }
    }
}
