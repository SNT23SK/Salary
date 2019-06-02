using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    public class Parser
    {

        private void ListStaff(string[] args)
        {
            throw new NotImplementedException();
        }

        private void Config(string[] args)
        {
            throw new NotImplementedException();
        }

        private void Staff(string[] args)
        {
            throw new NotImplementedException();
        }

        private void Salary(string[] args)
        {
            throw new NotImplementedException();
        }

        private void Help(string[] args)
        {
            throw new NotImplementedException();
        }

        private void CalcBonus(string[] args)
        {
            if (args[0] == "bonus")
            {
                if (args.Length == 2)
                {
                    DateTime dDate1;
                    if (DateTime.TryParse(args[1], out dDate1))
                    {
                        String.Format("{0:d.MM.yy}", dDate1);
                    }
                    else
                    {
                        throw new Exception("Invalid Format");
                    }
                    DateTime dDate2;
                    if (DateTime.TryParse(args[2], out dDate2))
                    {
                        String.Format("{0:d.MM.yy}", dDate2);
                    }
                    else
                    {
                        throw new Exception("Invalid Format");
                    }

                }
                else
                {
                    Console.WriteLine("Incorrect Input");
                }

            }

            else return;

            //throw new NotImplementedException();
        }




    }
}
