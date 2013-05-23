﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NijnCoach.Exposure_data
{
    class ReadExposureData
    {
        static Regex regex = new Regex(@"^.*(?<day>[0-9]{2})-(?<month>[0-9]{2})-(?<year>[0-9]{4})_(?<hour>[0-9]{2})(?<min>[0-9]{2})\.txt$");

        public static string[] GetFiles()
        {
            throw new NotImplementedException();
        }

        public static ExposureSession ReadFile(string filename)
        {
            Console.WriteLine(filename);

            DateTime dt = ExtractDateFromFilename(filename);
            
            StreamReader reader = new StreamReader(filename);
            try
            {
                reader.ReadLine();
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

        public static DateTime ExtractDateFromFilename(string filename)
        {
            Match match = regex.Match(filename);
            if (match.Success)
            {
                int year =  Convert.ToInt32( match.Groups["year"].Value );
                int month = Convert.ToInt32(match.Groups["month"].Value);
                int day = Convert.ToInt32(match.Groups["day"].Value);
                int hour = Convert.ToInt32(match.Groups["hour"].Value);
                int min = Convert.ToInt32(match.Groups["min"].Value);
                return new DateTime(year, month, day, hour, min, 00);
            }
            else
            {
                return new DateTime();
            }
        }
    }
}
