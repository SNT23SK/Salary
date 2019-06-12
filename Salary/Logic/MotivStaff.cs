using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    public class MotivStaff
    {
        public long StaffId { get; set; }
        
        public Dictionary<string, double> coefficients { get; set; }
    }
}
