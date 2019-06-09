using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    [DataContract]
    public class Motivation
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ICollection<Rule> Rules { get; set; }
    }
}
