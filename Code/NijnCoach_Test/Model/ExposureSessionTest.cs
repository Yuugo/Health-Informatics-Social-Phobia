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

        private void initEmptySession()
        {
            session = new ExposureSession(new DateTime(2013, 1, 1));

        }

        private void initProperSession()
        {
            DateTime date = new DateTime(2013, 1, 1, 14, 30, 00);
            session = new ExposureSession(date);

            var stamp1 = new ExpTimestamp(date, 90, 900, 9);
            var stamp2 = new ExpTimestamp(date, 90, 900, 9);
            var stamp3 = new ExpTimestamp(date, 90, 900, 9);

            session.addTimeStamp(stamp1);
        }
    }
}
