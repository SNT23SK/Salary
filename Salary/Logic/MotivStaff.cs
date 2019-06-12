using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    public class MotivStaff
    {
        public MotivStaff()
        {
            Coefficients = new List<Coeffient>();
        }

        public long StaffId { get; set; }
        
        public List<Coeffient> Coefficients { get; set; }
    }
}
