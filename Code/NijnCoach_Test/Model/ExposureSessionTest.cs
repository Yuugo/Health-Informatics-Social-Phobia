using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NijnCoach;
using System.IO;
using NijnCoach.Exposure_data;
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
            session = new ExposureSession(new DateTime(2013, 1, 1));

            var stamp1 = new Mock<ExpTimeStamp>();
            var stamp2 = new Mock<ExpTimeStamp>();
            var stamp3 = new Mock<ExpTimeStamp>();


        }
    }
}
