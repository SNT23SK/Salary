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
        /// <param name="date"></param>
        /// <returns></returns>
        public static long TimestampFromDateTime(DateTime date)
        {
            long unixTimestamp = date.Ticks - new DateTime(1970, 1, 1).Ticks;
            unixTimestamp /= TimeSpan.TicksPerSecond;
            return unixTimestamp;
        }

        public static string RequestDateFromDate(DateTime date)
        {
            return date.ToString("dd MMM yyyy HHp3Ammp3Ass pzz00", CultureInfo.InvariantCulture)
                       .Replace('p', '%')
                       .Replace("+", "2B")
                       .Replace(' ', '+');
        }
    }
}
