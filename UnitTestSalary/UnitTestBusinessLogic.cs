using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salary.Logic;

namespace UnitTestSalary
{
    [TestClass]
    public class UnitTestBusinessLogic
    {
        

        [TestMethod]
        public void TestGetMotivStaff()
        {
            Configuration config = GetConfig();
            BusinessLogic logic = new BusinessLogic(config);
            DateTime fromDate = new DateTime(2019, 5, 1);
            DateTime toDate = new DateTime(2019, 5, 31);

            ShowMotivations(logic.GetMotivStaff(fromDate, toDate), config);
        }

        private Configuration GetConfig()
        {
            return HelperJson.Load<Configuration>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "salary.config"));
        }

        private void ShowMotivations(List<MotivStaff> staff, Configuration config)
        {
            staff.ForEach(s =>
            {
                string coefficients = string.Empty;
                config.Motivations.ForEach(m =>
                {
                    coefficients += s.coefficients[m.Name].ToString();
                });

                Console.WriteLine("id: {0} " +
                                  "coef: {1}",
                                  s.StaffId,
                                  coefficients);
            });
        }
    }
}
