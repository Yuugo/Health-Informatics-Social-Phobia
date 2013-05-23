using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NijnCoach.Exposure_data
{
    class ExposureSession
    {
        DateTime date;
        List<ExpTimestamp> data;
        int index = 0;

        public ExposureSession(DateTime date)
        {
            this.date = date;
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
                return data[index++];
            }
            else
            {
                index = 0;
                return null;
            }
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
