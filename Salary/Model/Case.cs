using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Model
{
    public class Case
    {
        [JsonIgnore]
        private readonly string formatDate = "ddd, dd MMM yyyy HH:mm:ss K";

        #region Properties
        
        [JsonProperty("case_id", Required = Required.Always)]
        public long CaseId { get; set; }

        [JsonProperty("case_number", Required = Required.Always)]
        public string CaseNumber { get; set; }

        [JsonProperty("subject", Required = Required.Always)]
        public string Subject { get; set; }

        [JsonProperty("user_id", Required = Required.Always)]
        public long UserId { get; set; }

        [JsonProperty("staff_id", Required = Required.Always)]
        public long StaffId { get; set; }

        [JsonProperty("group_id", Required = Required.Always)]
        public long GroupId { get; set; }

        [JsonProperty("status", Required = Required.Always)]
        public string Status { get; set; }

        [JsonProperty("priority", Required = Required.Always)]
        public string Priority { get; set; }

        [JsonProperty("channel", Required = Required.Always)]
        public string Channel { get; set; }

        [JsonProperty("recipient", Required = Required.Always)]
        public string Recipient { get; set; }

        [JsonProperty("recipient_cc", Required = Required.Always)]
        public string RecipientCc { get; set; }

        [JsonProperty("recipient_bcc", Required = Required.Always)]
        public string RecipientBcc { get; set; }

        [JsonProperty("recipient_arr", Required = Required.Always)]
        public List<string> RecipientArr { get; set; }

        [JsonProperty("recipient_cc_arr", Required = Required.Always)]
        public List<string> RecipientCcArr { get; set; }

        [JsonProperty("recipient_bcc_arr", Required = Required.Always)]
        public List<object> RecipientBccArr { get; set; }

        [JsonProperty("deleted", Required = Required.Always)]
        public bool Deleted { get; set; }

        [JsonProperty("spam", Required = Required.Always)]
        public bool Spam { get; set; }

        [JsonProperty("created_at", Required = Required.Always)]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at", Required = Required.Always)]
        public string UpdatedAt { get; set; }

        [JsonProperty("last_response_at", Required = Required.Always)]
        public string LastResponseAt { get; set; }

        [JsonProperty("parent_case_id", Required = Required.Always)]
        public long ParentCaseId { get; set; }

        [JsonProperty("closing_speed", Required = Required.Always)]
        public string ClosingSpeed { get; set; }

        [JsonProperty("language_id", Required = Required.Always)]
        public long LanguageId { get; set; }

        [JsonProperty("labels", Required = Required.Always)]
        public List<long> Labels { get; set; }

        #endregion

        #region Methods

        public DateTime GetCreateAt() => DateTime.ParseExact(CreatedAt, formatDate, CultureInfo.InvariantCulture);

        public DateTime GetUpdatedAt() => DateTime.ParseExact(UpdatedAt, formatDate, CultureInfo.InvariantCulture);

        public DateTime GetLastResponseAt() => DateTime.ParseExact(LastResponseAt, formatDate, CultureInfo.InvariantCulture);

        #endregion

    }
}