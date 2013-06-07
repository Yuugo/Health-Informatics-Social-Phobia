using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace NijnCoach.Model
{
    public class ExpTimestamp
    {
        private DateTime time;
        private int hr;
        private int gsr;
        private int sud;

        private static Regex regexNoSUD = new Regex(@"^(?<hour>[0-9]{2}):(?<min>[0-9]{2}):(?<sec>[0-9]{2})\s+(?<hr>[0-9]*)\s+(?<gsr>[0-9]*).*$");
        private static Regex regexSUD = new Regex(@"^[0-9]{2}:[0-9]{2}:[0-9]{2}\s+[0-9]+\s+[0-9]+\s+(?<sud>[0-9])\s*$");

        public ExpTimestamp(DateTime time, int hr, int gsr)
            : this(time, hr, gsr, -1) { }

        public ExpTimestamp(DateTime time, int hr, int gsr, int sud)
        {
            this.time = time;
            this.hr = hr;
            this.gsr = gsr;
            this.sud = sud;
        }

        public int getHR()
        {
            return hr;
        }

        public int getGSR()
        {
            return gsr;
        }

        public int getSUD()
        {
            return sud;
        }

        public DateTime getTime()
        {
            return time;
        }

        public void setTime(DateTime newTime)
        {
            Debug.Assert(newTime != null);
            time = newTime;
        }

        
        public static ExpTimestamp ReadExpTimestamp(string stamp, DateTime dt)
        {
            Match match = regexNoSUD.Match(stamp);

            if (!match.Success)
            {
                throw new System.ArgumentException("File is not in proper format", "stamp");
            }

            int hour = Convert.ToInt32(match.Groups["hour"].Value) - dt.Hour;
            int min = Convert.ToInt32(match.Groups["min"].Value) - dt.Minute;
            int sec = Convert.ToInt32(match.Groups["sec"].Value) - dt.Second;
            DateTime time = new DateTime(dt.Year, dt.Month, dt.Day, hour, min, sec);

            int hr = Convert.ToInt32(match.Groups["hr"].Value);
            int gsr = Convert.ToInt32(match.Groups["gsr"].Value);

            int sud;
            match = regexSUD.Match(stamp);

            if (match.Success)
                sud = Convert.ToInt32(match.Groups["sud"].Value);
            else
                sud = -1;

            return new ExpTimestamp(time, hr, gsr, sud);
        }
    }
}
