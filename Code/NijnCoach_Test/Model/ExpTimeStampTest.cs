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
    class ExpTimeStampTest
    {
        protected void isRightTimeStamp(ExpTimestamp s, int sud, int gsr, int hr, DateTime time)
        {
            Assert.AreEqual(sud, s.getSUD(), "Wrong sud:" );
            Assert.AreEqual(gsr, s.getGSR(), "Wrong gsr:");
            Assert.AreEqual(hr, s.getHR(), "Wrong hr:");
            Assert.AreEqual(time, s.getTime(), "Wrong time:");
        }

        [Test]
        public void validStampRegularTimeNoSUDReadTest()
        {
            string stamp = "15:00:01  90  900";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);
            
            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);

            isRightTimeStamp(testOb, -1, 900, 90, new DateTime(2013,01,01,00,00,01));
        }

        [Test]
        public void validStampSUD10ReadTest()
        {
            string stamp = "15:00:01  90  900 10";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);

            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);

            isRightTimeStamp(testOb, 10, 900, 90, new DateTime(2013, 01, 01, 00, 00, 01));
        }

        [Test]
        public void validStampOddTimeReadTest()
        {
            string stamp = "16:01:00  90  900";
            DateTime d = new DateTime(2013, 01, 01, 15, 59, 59);

            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);

            isRightTimeStamp(testOb, -1, 900, 90, new DateTime(2013, 01, 01, 00, 01, 01));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void validStampPastTimeReadTest()
        {
            string stamp = "15:01:00  90  900";
            DateTime d = new DateTime(2013, 01, 01, 15, 59, 59);

            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);

            isRightTimeStamp(testOb, -1, 900, 90, new DateTime(2013, 01, 01, 00, 01, 01));
        }

        [Test]
        public void validStampWithSUDReadTest()
        {
            string stamp = "15:00:01  90  900 3";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);

            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);

            isRightTimeStamp(testOb, 3, 900, 90, new DateTime(2013, 01, 01, 00, 00, 01));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validStampFaultyTimeReadTest()
        {
            string stamp = "25:61:61  90  900";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);

            ExpTimestamp.ReadExpTimestamp(stamp, d);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void invalidStamp1ReadTest()
        {
            string stamp = "15:0001  90  900 3";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);

            ExpTimestamp.ReadExpTimestamp(stamp, d);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void invalidStamp2ReadTest()
        {
            string stamp = "15:15:00:01  90  900 3";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);

            ExpTimestamp.ReadExpTimestamp(stamp, d);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void invalidStamp3ReadTest()
        {
            string stamp = "15:00:01  90x  900x";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);

            ExpTimestamp.ReadExpTimestamp(stamp, d);
        }


    }
}
