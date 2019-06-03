using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Salary.Model
{
    public class Message
    {
        [JsonIgnore]
        private readonly string formatDate = "ddd, dd MMM yyyy HH:mm:ss K";

        [JsonProperty("message_id", Required = Required.Always)]
        public long MessageId { get; set; }

        [JsonProperty("user_id", Required = Required.Always)]
        public long UserId { get; set; }

        [JsonProperty("staff_id", Required = Required.Always)]
        public long StaffId { get; set; }

        [JsonProperty("content", Required = Required.Always)]
        public string Content { get; set; }

        [JsonProperty("content_html", Required = Required.Always)]
        public string ContentHtml { get; set; }

        [JsonProperty("attachments", Required = Required.Always)]
        public List<object> Attachments { get; set; }

        [JsonProperty("note", Required = Required.Always)]
        public bool Note { get; set; }

        [JsonProperty("sent_via_rule", Required = Required.Always)]
        public bool SentViaRule { get; set; }

        [JsonProperty("created_at", Required = Required.Always)]
        public string CreatedAt { get; set; }

        public DateTime GetCreateAt() => DateTime.ParseExact(CreatedAt, formatDate, CultureInfo.InvariantCulture);
    }
}
