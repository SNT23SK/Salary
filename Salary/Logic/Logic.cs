using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salary.Logic;
using Salary.Model;
using Salary.OmnideskAPI;

namespace Salary.Logic
{
   public class Logic
    {
        OmnideskAPI.OmnideskAPI api;

        Configuration config;

        public Logic(Configuration configuration)
        {
            config = configuration;
            api = new OmnideskAPI.OmnideskAPI(config.Address, config.Login, config.ApiKey);
        }

        public void MotivationAverageRating(DateTime dDate1, DateTime dDate2)
        {
            // Сделать валидации дат
            //(dDate1, dDate2)

            List<StatStaff> staffs = api.GetStatisticsAllStaffs(dDate1, dDate2);
            staffs.ForEach(s =>
            {
                config.Motivations = new List<Motivation>()
               {
                   new Motivation
                   {
                       Name="AverageRating",
                       Rules = new List<Rule>
                       {

                       }
                   }
               };
               //s.AverageRating
                
            });
               
        }
    }
}
