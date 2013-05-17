using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NijnCoach.Exposure_data
{
    class ExposureSession
    {
        DateTime startTime  { get; set; }
        DateTime date       { get; set; }
        List<ExpTimestamp> data;
        int index = 0;

        public ExposureSession()
        {
            data = new List<ExpTimestamp>();
        }

        public ExposureSession(DateTime date)
        {
            this.date = date;
            data = new List<ExpTimestamp>();
        }

        public ExposureSession(DateTime date, DateTime st)
        {
            this.date = date;
            this.startTime = st;
            data = new List<ExpTimestamp>();
        }

        public DateTime getDate()
        {
            return date;
        }

        public ExpTimestamp nextTimeStamp()
        {
            if (data.Count > index && data[index] != null)
            {
                index++;
                return data[index];
            }
            else
            {
                index = 0;
                return null;
            }
        }




        public static ExposureSession ReadExposureSession(StreamReader reader, DateTime dt)
        {
            // Read the first data line to extract the begin time of the session
            ExpTimestamp firstStamp = ExpTimestamp.ReadExpTimestamp(reader.ReadLine());
            ExposureSession session = new ExposureSession(dt, firstStamp.getTime());
            // Reset time of the first stamp to the time relative to starting time
            DateTime tzero = new DateTime();
            tzero.AddHours(00); tzero.AddMinutes(00); tzero.AddSeconds(00);
            firstStamp.setTime(tzero);
            // Add the first time stamp to the list
            session.data.Add(firstStamp);
            

            while (reader.Peek() != -1)
            {
                
                //Console.WriteLine("Reading line...");//debug
                
                string line = reader.ReadLine();
                
                //Console.WriteLine(line);//debug

                ExpTimestamp stamp = ExpTimestamp.ReadExpTimestamp(line, session.startTime);

                session.data.Add(stamp);
            }
            return session;
        }

    }
}
