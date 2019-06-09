using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salary;
using Salary.Logic;

namespace UnitTestSalary
{
    [TestClass]
    public class UnitTestConfiguration
    {
        string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "salary.config");

        [TestMethod]
        public void TestSaveConfiguration()
        {
            HeplerJson.Save<Configuration>(pathFile, GreateConfiguration());
            Console.WriteLine(pathFile);
        }

        [TestMethod]
        public void TestLoadConfiguration()
        {
            Configuration expected = GreateConfiguration();
            Configuration actual = HeplerJson.Load<Configuration>(pathFile);

            Assert.AreEqual(actual.Motivations[0].Rules[0].Actions, expected.Motivations[0].Rules[0].Actions);
        }

        private Configuration GreateConfiguration()
        {
            Configuration con = new Configuration();

            con.Address = "https://b2bfamily.omnidesk.ru";
            con.Login = "nkazakov@b2bfamily.com";
            con.ApiKey = "049ba38380d92596e9fad30b5";

            con.Motivations = new List<Motivation>()
            {
                new Motivation
                {
                    Name = "averageRating",
                    Rules = new List<Rule>()
                    {
                        new Rule
                        {
                            UpperBorder = 85,
                            LowerBorder = 80,
                            UnitBorder = eUnitBorder.Percent,
                            Actions = eRuleActions.Range,
                            Bonus = 10,
                            UnitBonus = eUnitBonus.Percent
                        },
                        new Rule
                        {
                            UpperBorder = 90,
                            LowerBorder = 86,
                            UnitBorder = eUnitBorder.Percent,
                            Actions = eRuleActions.Range,
                            Bonus = 15,
                            UnitBonus = eUnitBonus.Percent
                        },
                        new Rule
                        {
                            UpperBorder = 95,
                            LowerBorder = 91,
                            UnitBorder = eUnitBorder.Percent,
                            Actions = eRuleActions.Range,
                            Bonus = 20,
                            UnitBonus = eUnitBonus.Percent
                        },
                        new Rule
                        {
                            UpperBorder =100,
                            LowerBorder = 96,
                            UnitBorder = eUnitBorder.Percent,
                            Actions = eRuleActions.Range,
                            Bonus = 25,
                            UnitBonus = eUnitBonus.Percent
                        }
                    }
                },
                new Motivation
                {
                    Name = "firstReplySpeed",
                    Rules = new List<Rule>()
                    {
                        new Rule()
                        {
                            UpperBorder = 150,
                            LowerBorder = 120,
                            UnitBorder = eUnitBorder.Minute,
                            Actions = eRuleActions.Range,
                            Bonus = 8,
                            UnitBonus = eUnitBonus.Percent
                        },
                        new Rule()
                        {
                            UpperBorder = 119,
                            LowerBorder = 80,
                            UnitBorder = eUnitBorder.Minute,
                            Actions = eRuleActions.Range,
                            Bonus = 10,
                            UnitBonus = eUnitBonus.Percent
                        },
                        new Rule()
                        {
                            UpperBorder = 79,
                            LowerBorder = 40,
                            UnitBorder = eUnitBorder.Minute,
                            Actions = eRuleActions.Range,
                            Bonus = 15,
                            UnitBonus = eUnitBonus.Percent
                        },
                        new Rule()
                        {
                            UpperBorder = 39,
                            LowerBorder = 20,
                            UnitBorder = eUnitBorder.Percent,
                            Actions = eRuleActions.Range,
                            Bonus = 20,
                            UnitBonus = eUnitBonus.Percent
                        }
                    }
                },
                new Motivation()
                {
                    Name = "closingSpeed",
                    Rules = new List<Rule>()
                    {
                        new Rule()
                        {
                            UpperBorder = 660,
                            LowerBorder = 540,
                            UnitBorder = eUnitBorder.Minute,
                            Actions = eRuleActions.Range,
                            Bonus = 8,
                            UnitBonus = eUnitBonus.Percent
                        },
                        new Rule()
                        {
                            UpperBorder = 539,
                            LowerBorder = 480,
                            UnitBorder = eUnitBorder.Minute,
                            Actions = eRuleActions.Range,
                            Bonus = 10,
                            UnitBonus = eUnitBonus.Percent
                        },
                        new Rule()
                        {
                            UpperBorder = 478,
                            LowerBorder = 420,
                            UnitBorder = eUnitBorder.Minute,
                            Actions = eRuleActions.Range,
                            Bonus = 15,
                            UnitBonus = eUnitBonus.Percent
                        },
                        new Rule()
                        {
                            UpperBorder = 419,
                            LowerBorder = 390,
                            UnitBorder = eUnitBorder.Minute,
                            Actions = eRuleActions.Range,
                            Bonus = 20,
                            UnitBonus = eUnitBonus.Percent
                        },
                        new Rule()
                        {
                            UpperBorder = 389,
                            LowerBorder = 0,
                            UnitBorder = eUnitBorder.Minute,
                            Actions = eRuleActions.Range,
                            Bonus = 25,
                            UnitBonus = eUnitBonus.Percent
                        }
                    }
                },
                new Motivation()
                {
                    Name = "OverTime",
                    Rules = new List<Rule>()
                    {
                        new Rule()
                        {
                            UpperBorder = 50,
                            LowerBorder = 30,
                            UnitBorder = eUnitBorder.Percent,
                            Actions = eRuleActions.Range,
                            Bonus = 10,
                            UnitBonus = eUnitBonus.Percent
                        },
                        new Rule()
                        {
                            UpperBorder = 100,
                            LowerBorder =51,
                            UnitBorder = eUnitBorder.Percent,
                            Actions = eRuleActions.Range,
                            Bonus = 25,
                            UnitBonus = eUnitBonus.Percent
                        }
                    }
                }
            };

            con.Holidays = new List<DateTime>()
            {
                new DateTime(2019,1,1),
                new DateTime(2019,1,2),
                new DateTime(2019,1,3),
                new DateTime(2019,1,4),
                new DateTime(2019,1,5),
                new DateTime(2019,1,6),
                new DateTime(2019,1,7),
                new DateTime(2019,1,8),
                new DateTime(2019,2,23),
                new DateTime(2019,3,8),
                new DateTime(2019,5,1),
                new DateTime(2019,5,9),
                new DateTime(2019,6,12),
                new DateTime(2019,11,4)
            };

            return con;
        }
    }
}
