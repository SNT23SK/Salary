using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    public static class HelperDate
    {
        /// <summary>
        /// Конвертирует DateTime в Timestamp
        /// </summary>
        /// <param name="date">Дата и время тип DateTime</param>
        /// <returns>Дата и время тип Timestamp (UNIX)</returns>
        public static long TimestampFromDateTime(DateTime date)
        {
            long unixTimestamp = date.Ticks - new DateTime(1970, 1, 1).Ticks;
            unixTimestamp /= TimeSpan.TicksPerSecond;
            return unixTimestamp;
        }

        /// <summary>
        /// Конвертирует DateTime в строку дату-запрос
        /// </summary>
        /// <param name="date">Дата и время тип DateTime</param>
        /// <returns>Дата и время в формате части запроса</returns>
        /// <example>01+May+2019+00%3A00%3A00+%2B0400</example>
        public static string RequestDateFromDate(DateTime date)
        {
            return date.ToString("dd MMM yyyy HHp3Ammp3Ass pzz00", CultureInfo.InvariantCulture)
                       .Replace('p', '%')
                       .Replace("+", "2B")
                       .Replace(' ', '+');
        }
    }
}
