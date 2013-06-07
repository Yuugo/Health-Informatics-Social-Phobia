using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NijnCoach.Model;
using System.IO;
using NijnCoach;
using Moq;

namespace NijnCoach_Test.Model
{
    [TestFixture]
    class ExpTimeStampTest
    {
        protected Boolean isRightTimeStamp(ExpTimestamp s, int sud, int gsr, int hr, DateTime time)
        {
            return s.getSUD() == sud &&
                    s.getGSR() == gsr &&
                    s.getHR() == hr &&
                    s.getTime() == time;
        }

        [Test]
        public void validStampRegularTimeNoSUDReadTest()
        {
            string stamp = "15:00:01  90  900";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);
            
            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);

            Assert.IsTrue(isRightTimeStamp(testOb, -1, 900, 90, new DateTime(2013,01,01,00,00,01)));
        }

        [Test]
        public void validStampOddTimeReadTest()
        {
            string stamp = "16:01:00  90  900";
            DateTime d = new DateTime(2013, 01, 01, 15, 59, 59);

            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);

            Assert.IsTrue(isRightTimeStamp(testOb, -1, 900, 90, new DateTime(2013, 01, 01, 00, 01, 01)));
        }

        [Test]
        public void validStampWithSUDReadTest()
        {
            string stamp = "15:00:01  90  900 3";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);

            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);

            Assert.IsTrue(isRightTimeStamp(testOb, 3, 900, 90, new DateTime(2013, 01, 01, 00, 00, 01)));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validStampFaultyTimeReadTest()
        {
            string stamp = "25:61:61  90  900";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);

            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);
        }
    }
}
