using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salary.Logic;

namespace UnitTestSalary
{
    [TestClass]
    public class UnitTestHelperDate
    {
        [TestMethod]
        public void TestTimestampFromDateTime()
        {
            long expected = 1559553396;
            long actual = HelperDate.TimestampFromDateTime(new DateTime(2019, 6, 3, 9, 16, 36));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRequestDateFromDate()
        {
            string expected = "01+May+2019+00%3A00%3A00+%2B0400";
            string actual = string.Empty;

            actual = HelperDate.RequestDateFromDate(new DateTime(2019, 5, 1));

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }
    }
}
