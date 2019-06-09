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
                try
                {
                    p.CalcBonus(args);
                    p.Help(args);
                    p.Salary(args);
                    p.Config(args);
                    p.ListStaff(args);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + Environment.NewLine +
                                      ex.StackTrace + Environment.NewLine +
                                      ex.Source);
                }
            }
            else
            {
                while (true)
                {
                    string query = Console.ReadLine();
                    if (query.Trim().ToLower() == "exit" ||
                       query.Trim().ToLower() == "close" ||
                       query.Trim().ToLower() == "quit") return;
                    args = query.Split(' ');
                    if (args.Length > 0)
                    {
                        try
                        {
                            p.CalcBonus(args);
                            p.Help(args);
                            p.Salary(args);
                            p.Config(args);
                            p.ListStaff(args);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + Environment.NewLine +
                                                              ex.StackTrace + Environment.NewLine +
                                                              ex.Source);
                        }
                    }
                }
            }
       

        }
    }
}
    