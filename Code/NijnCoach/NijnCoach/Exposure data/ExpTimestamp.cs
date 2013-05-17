using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NijnCoach.Exposure_data
{
    class ExpTimestamp
    {
        DateTime time;
        int hr;
        int gsr;
        int sud;

        public ExpTimestamp(DateTime time, int hr, int gsr)
            : this(time, hr, gsr, -1) { }

        public ExpTimestamp(DateTime time, int hr, int gsr, int sud)
        {
            this.time = time;
            this.hr = hr;
            this.gsr = gsr;
            this.sud = sud;
        }

        public int getScore()
        {
            return hr;
        }

        public DateTime getTime()
        {
            return time;
        }

        public void setTime(DateTime newTime)
        {
            time = newTime;
        }





        public static ExpTimestamp ReadExpTimestamp(string stamp)
        {
            DateTime start = new DateTime();
            return ReadExpTimestamp(stamp, start);
        }

        public static ExpTimestamp ReadExpTimestamp(string stamp, DateTime dt)
        {
            string[] line = stamp.Split(null);
            
            /*debug
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i] + "_");
            }
            Console.WriteLine();
            /*///debug

            // Read the line with the time, and convert it to the time relative to the start time
            string[] ts = line[0].Split(':');
            DateTime time = new DateTime();
            int hour = Convert.ToInt32(ts[0]) - dt.Hour;
            int min = Convert.ToInt32(ts[1]) - dt.Minute;
            int sec = Convert.ToInt32(ts[2]) - dt.Second;
            time.AddHours(hour); time.AddMinutes(min); time.AddSeconds(sec);
            
            //Console.WriteLine(ts[0] + ts[1] + ts[2]); //debug

            int hr = Convert.ToInt32(line[1]);
            //Console.WriteLine(hr); //debug
            int gsr = Convert.ToInt32(line[2]);
            //Console.WriteLine(gsr);//debug
            int sud;
            if (line.Length > 3 )
            {
                //Console.WriteLine(line[3]);//debug
                sud = Convert.ToInt32(line[3]);
            }
            else
            {
                //Console.WriteLine("no SUD");//debug
                sud = -1;
            }
            

            return new ExpTimestamp(time, hr, gsr, sud);
        }
    }
}
