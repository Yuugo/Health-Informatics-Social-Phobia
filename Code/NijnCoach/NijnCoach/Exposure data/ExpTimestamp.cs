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

        public static ExpTimestamp ReadExpTimestamp(string stamp, DateTime dt)
        {
            string[] line = stamp.Split(null);
            //debug
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i] + "_");
            }
            Console.WriteLine();
            //debug

            string[] ts = line[0].Split(':');
            dt.AddHours(Convert.ToInt32(ts[0])); dt.AddMinutes(Convert.ToInt32(ts[1])); dt.AddSeconds(Convert.ToInt32(ts[2]));
            Console.WriteLine(ts[0] + ts[1] + ts[2]); //debug

            int hr = Convert.ToInt32(line[1]);
            Console.WriteLine(hr);
            int gsr = Convert.ToInt32(line[2]);
            Console.WriteLine(gsr);
            int sud;
            if (line.Length > 3 )
            {
                Console.WriteLine(line[3]);
                sud = Convert.ToInt32(line[3]);
            }
            else
            {
                Console.WriteLine("no SUD");
                sud = -1;
            }
            

            return new ExpTimestamp(dt, hr, gsr, sud);
        }
    }
}
