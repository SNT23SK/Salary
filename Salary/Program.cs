using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salary.Logic;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
             ParserCom p = new ParserCom();
              if (args.Length > 0)
              {
                  p.CalcBonus(args);
                  p.Help(args);
                  p.Salary(args);
                  p.Staff(args);
                  p.Config(args);
                  p.ListStaff(args);


              }
              else
              {
                Console.ReadKey();
                  return;
              }
       

        }
    }
}
    