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
    class ExposureSessionTest
    {
        protected ExposureSession session;

        [TestFixtureSetUp]
        public virtual void setUp()
        {
        }

        private ExposureSession initEmptySession()
        {
            return new ExposureSession(new DateTime(2013, 1, 1));
        }

        private ExposureSession initProperSession()
        {
            DateTime date = new DateTime(2013, 1, 1, 14, 30, 00);
            session = new ExposureSession(date);

            ExpTimestamp stamp1 = new ExpTimestamp(date, 90, 900, 1);
            ExpTimestamp stamp2 = new ExpTimestamp(date, 90, 900, 2);
            ExpTimestamp stamp3 = new ExpTimestamp(date, 90, 900, 3);

            session.addTimeStamp(stamp1);
            session.addTimeStamp(stamp2);
            session.addTimeStamp(stamp3);
            
            return session;
        }

        private ExposureSession initSessionWithNull()
        {
            DateTime date = new DateTime(2013, 1, 1, 14, 30, 00);
            session = new ExposureSession(date);

            ExpTimestamp stamp1 = new ExpTimestamp(date, 90, 900, 1);
            ExpTimestamp stamp2 = new ExpTimestamp(date, 90, 900, 2);
            ExpTimestamp stamp3 = new ExpTimestamp(date, 90, 900, 3);

            session.addTimeStamp(stamp1);
            session.addTimeStamp(stamp2);
            session.addTimeStamp(null);
            session.addTimeStamp(stamp3);

            return session;
        }

        [Test]
        public void nextTimeStampProperTest()
        {
            ExposureSession ses = initProperSession();

            ExpTimestamp t = ses.nextTimeStamp();
            Assert.AreEqual(1, t.getSUD(), "Wrong ExpTimeStamp: ");
            t = ses.nextTimeStamp();
            Assert.AreEqual(2, t.getSUD(), "Wrong ExpTimeStamp: "); 
            t = ses.nextTimeStamp();
            Assert.AreEqual(3, t.getSUD(), "Wrong ExpTimeStamp: ");
            t = ses.nextTimeStamp();
            Assert.AreEqual(null, t, "Wrong ExpTimeStamp: ");
        }

        [Test]
        public void nextTimeStampWithNullTest()
        {
            ExposureSession ses = initSessionWithNull();

            ExpTimestamp t = ses.nextTimeStamp();
            Assert.AreEqual(1, t.getSUD(), "Wrong ExpTimeStamp: ");
            t = ses.nextTimeStamp();
            Assert.AreEqual(2, t.getSUD(), "Wrong ExpTimeStamp: ");
            t = ses.nextTimeStamp();
            Assert.AreEqual(3, t.getSUD(), "Wrong ExpTimeStamp: ");
            t = ses.nextTimeStamp();
            Assert.AreEqual(null, t, "Wrong ExpTimeStamp: ");
        }

        [Test]
        public void nextTimeStampEmptyTest()
        {
            ExposureSession ses = initEmptySession();

            ExpTimestamp t = ses.nextTimeStamp();
            Assert.AreEqual(null, t, "Wrong ExpTimeStamp: ");
        }

    }
}
