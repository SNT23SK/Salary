using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    public class Rule
    {
        /// <summary>
        /// Верхняя граница правила
        /// </summary>
        public int UpperBorder { get; set; }

        /// <summary>
        /// Нижняя граница правила
        /// </summary>
        public int LowerBorder { get; set; }

        /// <summary>
        /// Действие по правилу
        /// </summary>
        public eRuleActions Actions { get; set; }

        /// <summary>
        /// Ед. изм. границы (проценты/минуты)
        /// </summary>
        public eUnitBorder UnitBorder { get; set; }

        /// <summary>
        /// Ед. изм. мотивации (проценты/деньги)
        /// </summary>
        public eUnitBonus UnitBonus { get; set; }

        /// <summary>
        /// Величина бонус (проценты/деньги)
        /// </summary>
        public int Bonus { get; set; }
    }
}
