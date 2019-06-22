using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salary.OmnideskAPI;

namespace Salary.Logic
{
    public class ParserCom
    {
        OmnideskAPI.OmnideskAPI api = new OmnideskAPI.OmnideskAPI("https://b2bfamily.omnidesk.ru", "nkazakov@b2bfamily.com", "049ba38380d92596e9fad30b5");

        /// <summary>
        /// Консольная команда "list" выводящая список сотрудников
        /// </summary>
        /// <param name="args"></param>
        public void ListStaff(string[] args)
        {
            if (args[0]=="staff")
            {
                api.GetAllStaffs().Where(s => s.Active == true).ToList().ForEach(c =>
                {
                    Console.WriteLine("employee id:{0} {1} {2}", c.StaffId, c.StaffFullName, c.StaffEmail);
                });
            }
        }
        /// <summary>
        /// Консольная команда "config" 
        /// </summary>
        /// <param name="args"></param>
        public void Config(string[] args)
        {
            if (args[0] == "config")
            {
                Console.WriteLine("config");
            }
        }        

        /// <summary>
        /// Консольная команда "salary" выводящая мотивационную часть зп
        /// </summary>
        /// <param name="args"></param>
        public void Salary(string[] args)
        {
            if (args[0] == "salary")
            {
                Console.WriteLine("salary");
            }
                    }
        /// <summary>
        /// Консольная команда "help" выводящая список команд
        /// </summary>
        /// <param name="args"></param>
        public void Help(string[] args)
        {
            if (args.Length == 1)
            {
                string command = args[0].Trim().ToLower();
                if (command == "help" || command == "")
                {
                    Console.WriteLine("======================== !!! Help !!! ====================" + Environment.NewLine +
                                      "List commands:" + Environment.NewLine +
                                      "\tbonus <from date> <to date> - output list everyone employees with bonus to salary for date range" + Environment.NewLine +
                                      "\t\texample: bonus 01.05.19 31.05.19" + Environment.NewLine +
                                      "\tstaff - output list staff" + Environment.NewLine +
                                      "\tsalary <mail> <from date> <to date> - output bonus for current employee" + Environment.NewLine +
                                      "\t\texample: sharikov@mail.ru 01.05.19 31.05.19" + Environment.NewLine +
                                      "");
                }
            }
        }
        /// <summary>
        /// Консольная команда "bonus" выводящая
        /// список сотрудников c мотивационной частью зп
        /// </summary>
        /// <param name="args"></param>
        public void CalcBonus(string[] args)
        {
            if (args[0] == "bonus")
            {
                if (args.Length == 3)
                {
                    DateTime dDate1; DateTime dDate2;
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
        }
    }
}
