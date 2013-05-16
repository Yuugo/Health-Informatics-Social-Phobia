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

        public ExposureSession(DateTime date)
        {
            this.date = date;
            data = new List<ExpTimestamp>();
        }

        public static ExposureSession ReadExposureSession(StreamReader reader, DateTime dt)
        {
            ExposureSession session = new ExposureSession(dt);

            while (reader.Peek() != -1)
            {
                //debug
                Console.WriteLine("Reading line...");
                string line = reader.ReadLine();
                Console.WriteLine(line);
                ExpTimestamp stamp = ExpTimestamp.ReadExpTimestamp(line, dt);
                //debug

                //ExpTimestamp stamp = ExpTimestamp.ReadExpTimestamp(reader.ReadLine(), dt);
                session.data.Add(stamp);
            }
            return session;
        }


    }
}
