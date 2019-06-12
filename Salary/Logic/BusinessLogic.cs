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
        
        #endregion

        #region Constructors

        public BusinessLogic() { }

        #endregion

        public List<MotivStaff> GetMotivStaff(List<StatStaff> statStaff, List<Motivation> motivations)
        {
            if (statStaff is null) throw new ArgumentException("statStaff is null");
            if (statStaff.Count == 0) throw new ArgumentException("statStaff amount is zero");
            if (motivations is null) throw new ArgumentException("motivations is null");
            if (motivations.Count == 0) throw new ArgumentException("motivations amount is zero");

            List<MotivStaff> result = new List<MotivStaff>();

            statStaff.ForEach(s =>
            {
                MotivStaff employee = new MotivStaff();
                employee.StaffId = s.StaffId;
                motivations.ForEach(m =>
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
                        case "overTime": // Сверхурочная работа

                            // Добавить метод подсчёта сверхурочной работы

                            break; 
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
                                if (_value >= r.LowerBorder && _value <= r.UpperBorder)
                                {
                                    _coef = 1 + (((double)r.Bonus) / 100);
                                }
                                break;
                            default:
                                break;
                        }

                        Coeffient coef = employee.Coefficients.Find(c => c.Name == m.Name);

                        if (coef == null)
                        {
                            coef = new Coeffient()
                            {
                                Name = m.Name,
                                Value = _coef
                            };
                            employee.Coefficients.Add(coef);
                        }
                        else
                        {
                            coef.Value = _coef;
                        }
                    });
                });
                result.Add(employee);
            });

            return result;
        }
    }
}
