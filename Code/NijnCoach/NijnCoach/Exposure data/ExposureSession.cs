using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NijnCoach.XMLclasses;

namespace NijnCoach.Model
{
    public class ExposureSession
    {
        private DateTime date;
        private List<ExpTimestamp> data;
        public Comment comment { get; set; }
        private int index = 0;
        public string Date
        {
            get
            {
                return date.ToShortDateString();
            }
        }

        public ExposureSession(DateTime date)
        {
            this.date = date;
            this.data = new List<ExpTimestamp>();
        }

        public ExposureSession(DateTime date, Comment c)
        {
            this.date = date;
            this.comment = c;
            this.data = new List<ExpTimestamp>();
        }

        public DateTime getDate()
        {
            return date;
        }

        public void addTimeStamp(ExpTimestamp st)
        {
            this.data.Add(st);
        }

        public ExpTimestamp nextTimeStamp()
        {
            if (data.Count > index && data[index] != null)
            {
                return data[index++];
            }
            else
            {
                index = 0;
                return null;
            }
        }

        internal int CompareTo(ExposureSession e)
        {
            return DateTime.Compare(this.date, e.date);
        }

        public ExpTimestamp meanScore()
        {
            int maxSUD = 0, maxGSR = 0, maxHR = 0;
            foreach (ExpTimestamp e in data)
            {
                maxSUD = e.getSUD() >= maxSUD ? e.getSUD() : maxSUD;
                maxGSR = e.getGSR() >= maxGSR ? e.getGSR() : maxGSR;
                maxHR = e.getHR() >= maxHR ? e.getHR() : maxHR;
            }
            return new ExpTimestamp(new DateTime(), maxHR, maxGSR, maxSUD);
        }

        public static ExposureSession ReadExposureSession(StreamReader reader, DateTime dt)
        {
            ExposureSession session = new ExposureSession(dt);

            while (reader.Peek() != -1)
            {
                ExpTimestamp stamp = ExpTimestamp.ReadExpTimestamp(reader.ReadLine(), dt);

                session.data.Add(stamp);
            }
            return session;
        }


    }
}
