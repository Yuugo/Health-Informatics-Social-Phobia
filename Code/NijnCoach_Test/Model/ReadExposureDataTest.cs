using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NijnCoach.Model;
using System.IO;
using NijnCoach;
//using Moq;

namespace NijnCoach_Test.Model
{
    [TestFixture]
    class ReadExposureDataTest
    {
        [Test]
        public void extractDateFromNameTest1()
        {
            string name = "02-05-2013_1500";
            DateTime expected = new DateTime(2013,05,02,15,00,00);
            DateTime actual = ReadExposureData.ExtractDateFromFilename(name);
            Assert.AreEqual(expected, actual, "Wrong date:");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void extractDateFromNameTest2()
        {
            string name = "wrong02-05-2013_1500";

            ReadExposureData.ExtractDateFromFilename(name);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void extractDateFromNameTest3()
        {
            string name = "02-05-2013_2500";

            ReadExposureData.ExtractDateFromFilename(name);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void extractDateFromNameTest4()
        {
            string name = "02-25-2013_1500";

            ReadExposureData.ExtractDateFromFilename(name);
        }
    }
}
