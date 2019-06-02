using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                CalcBonus(args);
                Help(args);
                Salary(args);
                Staff(args);
                Config(args);
                ListStaff(args);

            }
            else
            {
                return;
            }

        }
    }
}
    