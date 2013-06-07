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


        [Test]
        public void validStampRegularTimeNoSUDReadTest()
        {
            string stamp = "15:00:01    90  900";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);
            
            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);

            Assert.AreEqual(90, testOb.getHR());
            Assert.AreEqual(900, testOb.getGSR());
            Assert.AreEqual(-1, testOb.getSUD());
            Assert.AreEqual(new DateTime(2013,01,01,00,00,01), testOb.getTime());
        }

        [Test]
        public void validStampOddTimeReadTest()
        {
            string stamp = "16:01:00    90  900";
            DateTime d = new DateTime(2013, 01, 01, 15, 59, 59);

            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);

            Assert.AreEqual(90, testOb.getHR());
            Assert.AreEqual(900, testOb.getGSR());
            Assert.AreEqual(-1, testOb.getSUD());
            Assert.AreEqual(new DateTime(2013, 01, 01, 00, 01, 01), testOb.getTime());
        }

        [Test]
        public void validStampWithSUDReadTest()
        {
            string stamp = "15:00:01    88  736 3";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);

            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);

            Assert.AreEqual(88, testOb.getHR());
            Assert.AreEqual(736, testOb.getGSR());
            Assert.AreEqual(3, testOb.getSUD());
            Assert.AreEqual(new DateTime(2013, 01, 01, 00, 00, 01), testOb.getTime());
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void validStampFaultyTimeReadTest()
        {
            string stamp = "25:61:61    88  736";
            DateTime d = new DateTime(2013, 01, 01, 15, 00, 00);

            ExpTimestamp testOb = ExpTimestamp.ReadExpTimestamp(stamp, d);
        }
    }
}
