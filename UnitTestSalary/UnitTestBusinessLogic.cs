using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salary.Logic;
using Salary.OmnideskAPI;

namespace UnitTestSalary
{
    [TestClass]
    public class UnitTestBusinessLogic
    {
        #region Variables

        Configuration config;

        OmnideskAPI api;

        BusinessLogic logic;

        #endregion

        [TestMethod]
        public void TestGetMotivStaff()
        {
            Init();
            DateTime fromDate = new DateTime(2019, 5, 1);
            DateTime toDate = new DateTime(2019, 5, 31);

            ShowMotivations(logic.GetMotivStaff(api.GetStatisticsAllStaffs(fromDate, toDate), config.Motivations));
        }

        #region Methods

        /// <summary>
        /// Инициализация окружения
        /// </summary>
        private void Init()
        {
            config = GetConfig();
            api = new OmnideskAPI(config);
            logic = new BusinessLogic();
        }

        /// <summary>
        /// Загрузка настроек из файла конфигурации
        /// </summary>
        /// <returns></returns>
        private Configuration GetConfig()
        {
            return HelperJson.Load<Configuration>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "salary.config"));
        }

        /// <summary>
        /// Вывод в консоль коэффициентов мотивации для каждого сотрудника
        /// </summary>
        /// <param name="staff"></param>
        private void ShowMotivations(List<MotivStaff> staff)
        {
            staff.ForEach(s =>
            {
                string coef = string.Empty;
                s.Coefficients.ForEach(c =>
                {
                    coef += string.Format("\n\t {0} = {1} ", c.Name, c.Value);
                });
                Console.WriteLine(string.Format("staffId {0}: {1}", s.StaffId, coef));
            });
        }

        #endregion

    }
}
