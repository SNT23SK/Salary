﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    public class ParserCom
    {

        public void ListStaff(string[] args)
        {
            if (args[0]=="list")
            {
                Console.WriteLine("List staff");
            }
            //throw new NotImplementedException();
        }

        public void Config(string[] args)
        {
            throw new NotImplementedException();
        }

        public void Staff(string[] args)
        {
            if (args[0] == "staff")
            {
                Console.WriteLine("List staff");
            }
        }

        public void Salary(string[] args)
        {
            throw new NotImplementedException();
        }

        public void Help(string[] args)
        {
            throw new NotImplementedException();
        }

        public void CalcBonus(string[] args)
        {
            if (args[0] == "bonus")
            {
                if (args.Length == 3)
                {
                    DateTime dDate1;DateTime dDate2;
                    if (DateTime.TryParse(args[1], out dDate1) && DateTime.TryParse(args[2], out dDate2))
                    { 
                        String.Format("{0:dd.MM.yy}", dDate2);
                        // Здесь должна быть функция расчета
                    }
                    else
                    {
                        throw new Exception("Invalid Format date");
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
