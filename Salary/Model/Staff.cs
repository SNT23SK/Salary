using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Model
{
    public class Staff
    {
        private readonly string formatDate = "ddd, dd MMM yyyy HH:mm:ss K";

        [JsonProperty("staff_id", Required = Required.Always)]
        public int StaffId { get; set; }

        [JsonProperty("staff_email", Required = Required.Always)]
        public string StaffEmail { get; set; }

        [JsonProperty("staff_full_name", Required = Required.Always)]
        public string StaffFullName { get; set; }

        [JsonProperty("staff_signature", Required = Required.Always)]
        public string StaffSignature { get; set; }

        [JsonProperty("staff_push_notification", Required = Required.Always)]
        public List<string> StaffPushNotification { get; set; }

        [JsonProperty("thumbnail", Required = Required.Always)]
        public string Thumbnail { get; set; }

        [JsonProperty("active", Required = Required.Always)]
        public bool Active { get; set; }

        [JsonProperty("created_at", Required = Required.Always)]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at", Required = Required.Always)]
        public string UpdatedAt { get; set; }

        [JsonProperty("status", Required = Required.Always)]
        public string Status { get; set; }

        public DateTime GetCreateAt() => DateTime.ParseExact(CreatedAt, formatDate, CultureInfo.InvariantCulture);

        public DateTime GetUpdateAt() => DateTime.ParseExact(UpdatedAt, formatDate, CultureInfo.InvariantCulture);
    }
}