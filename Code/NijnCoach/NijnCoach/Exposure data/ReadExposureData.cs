using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace NijnCoach.Exposure_data
{
    class ReadExposureData
    {
        static string winDir = System.Environment.GetEnvironmentVariable("windir");

        public static string[] GetFiles()
        {
            throw new NotImplementedException();
        }

        public static ExposureSession ReadFile(string filename)
        {
            //string date = "06-05-2013";
            //string time = "1500";
            DateTime dt = new DateTime(2013, 05, 06, 15, 00, 00);

            //string file = winDir + "\\" + date + "_" + time + ".txt";
            //string file = "Z://git//Health-Informatics-Social-Phobia//Code//NijnCoach//NijnCoach//06-05-2013_1500.txt";
            Console.WriteLine(filename);



            StreamReader reader = new StreamReader(filename);
            try
            {
                //debug
                Console.WriteLine("Reading file...");
                Console.WriteLine(reader.ReadLine()); // Header line
                //debug

                //reader.ReadLine();
                return ExposureSession.ReadExposureSession(reader, dt);
            }
            catch
            {
                Console.WriteLine("Error reading file: " + filename);
                return null;
            }
            finally
            {
                reader.Close();
            }
        }

    }
}
