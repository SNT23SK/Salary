using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    public class Configuration
    {
        public Configuration()
        {
            Motivations = new List<Motivation>();
        }

        List<Motivation> Motivations { get; set; }

        public void Save(string path)
        {

        }

        public void Load(string path)
        {

        }
    }
}
