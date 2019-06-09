using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    [DataContract]
    public class Rule
    {
        /// <summary>
        /// Верхняя граница правила
        /// </summary>
        [DataMember]
        public int UpperBorder { get; set; }

        /// <summary>
        /// Нижняя граница правила
        /// </summary>
        [DataMember]
        public int LowerBorder { get; set; }

        /// <summary>
        /// Действие по правилу
        /// </summary>
        [DataMember]
        public eRuleActions Actions { get; set; }

        /// <summary>
        /// Ед. изм. границы (проценты/минуты)
        /// </summary>
        [DataMember]
        public eUnitBorder UnitBorder { get; set; }

        /// <summary>
        /// Ед. изм. мотивации (проценты/деньги)
        /// </summary>
        [DataMember]
        public eUnitBonus UnitBonus { get; set; }

        /// <summary>
        /// Величина бонус (проценты/деньги)
        /// </summary>
        [DataMember]
        public int Bonus { get; set; }
    }
}
