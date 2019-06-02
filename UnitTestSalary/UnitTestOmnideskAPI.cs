using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salary.Model;
using Salary.OmnideskAPI;

namespace UnitTestSalary
{
    [TestClass]
    public class UnitTestOmnideskAPI
    {
        private readonly OmnideskAPI api = new OmnideskAPI("https://b2bfamily.omnidesk.ru", "nkazakov@b2bfamily.com", "049ba38380d92596e9fad30b5");

        [TestMethod]
        public void TestGetAllStaffs()
        {
            #region Arrange

            List<Staff> staffs = new List<Staff>();

            #endregion

            #region Action

            staffs = api.GetAllStaffs();

            #endregion

            #region Asset

            // интеграционной тест, пока смотреть вывод

            #endregion

            #region Output

            staffs.ForEach(s =>
            {
                Console.WriteLine("{0} {1} {2} {3} ({4})", s.StaffId, s.StaffFullName, s.Active, s.Status, s.CreatedAt);
            });

            #endregion
        }
    }
}
