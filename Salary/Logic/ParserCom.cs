using System;

namespace Salary.Logic
{
    public class ParserCom
    {
        /// <summary>
        /// Консольная команда "list" выводящая список сотрудников
        /// </summary>
        /// <param name="args"></param>
        public void ListStaff(string[] args)
        {
            if (args[0] == "list")
            {
                Console.WriteLine("List staff");
            }
            //throw new NotImplementedException();
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
            // throw new NotImplementedException();
        }
        /// <summary>
        /// Консольная команда "staff" выводящая список сотрудников
        /// </summary>
        /// <param name="args"></param>
        public void Staff(string[] args)
        {
            if (args[0] == "staff")
            {
                Console.WriteLine("List staff");
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
            // throw new NotImplementedException();
        }
        /// <summary>
        /// Консольная команда "help" выводящая список команд
        /// </summary>
        /// <param name="args"></param>
        public void Help(string[] args)
        {
            throw new NotImplementedException();
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
            //throw new NotImplementedException();
        }
    }
}
