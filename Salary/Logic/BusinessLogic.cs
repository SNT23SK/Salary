using Salary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    public class BusinessLogic
    {
        #region Variables
        
        private OmnideskAPI.OmnideskAPI api;

        private Configuration config;

        #endregion

        #region Constructors

        public BusinessLogic(Configuration config)
        {
            this.config = config;
            api = new OmnideskAPI.OmnideskAPI(this.config.Address, this.config.Login, this.config.ApiKey);
        }

        #endregion

        public List<MotivStaff> GetMotivStaff(DateTime fromDate, DateTime toDate)
        {
            List<MotivStaff> result = new List<MotivStaff>();

            List<StatStaff> statStaff = api.GetStatisticsAllStaffs(fromDate, toDate);
            statStaff.ForEach(s =>
            {
                MotivStaff employee = new MotivStaff();
                employee.StaffId = s.StaffId;
                config.Motivations.ForEach(m =>
                {
                    long _value = 0;
                    switch (m.Name)
                    {
                        case "averageRating": // Рейтинг сотрудника
                            if (!long.TryParse(s.AverageRating.Replace("%","").Trim(), out _value)) _value = 0;
                            break;
                        case "firstReplySpeed": // Скорость первого ответа
                            _value = s.FirstReplySpeed;
                            break;
                        case "closingSpeed": // Скорость закрытия обращений
                            _value = s.ClosingSpeed;
                            break;
                        case "overTime":

                            // Добавить метод подсчёта сверхурочной работы

                            break; // Сверхурочная работа
                        default:
                            break;
                    }
                    double _coef = 1;
                    m.Rules.ForEach(r =>
                    {
                        switch (r.Actions)
                        {
                            case eRuleActions.Less:
                                break;
                            case eRuleActions.More:
                                break;
                            case eRuleActions.Range:
                                if (_value >= r.LowerBorder && _value <= r.UpperBorder) _coef = 1 + (r.Bonus / 100);
                                break;
                            default:
                                break;
                        }
                        employee.coefficients.Add(m.Name, _coef);
                    });
                });
                result.Add(employee);
            });

            return result;
        }
    }
}
