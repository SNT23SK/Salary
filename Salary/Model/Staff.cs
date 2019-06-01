using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Model
{
    public class Staff
    {
        public int staff_id { get; set; }
        public string staff_name { get; set; }
        public int cases_with_first_reply { get; set; }
        public int first_reply_speed { get; set; }
        public int total_amount_of_replies { get; set; }
        public int closed_cases { get; set; }
        public int closing_speed { get; set; }
        public int average_rating { get; set; }
    }
}
