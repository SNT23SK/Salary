using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    [DataContract]
    public class Configuration
    {
        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string ApiKey { get; set; }

        [DataMember]
        public List<Motivation> Motivations { get; set; }
    }
}
