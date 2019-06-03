using Newtonsoft.Json;

namespace Salary.Model
{
    public class StatStaff
    {
        [JsonProperty("staff_id", Required = Required.Always)]
        public long StaffId { get; set; }

        [JsonProperty("staff_name", Required = Required.Always)]
        public string StaffName { get; set; }

        [JsonProperty("cases_with_first_reply", Required = Required.Always)]
        public long CasesWithFirstReply { get; set; }

        [JsonProperty("first_reply_speed", Required = Required.Always)]
        public long FirstReplySpeed { get; set; }

        [JsonProperty("total_amount_of_replies", Required = Required.Always)]
        public long TotalAmountOfReplies { get; set; }

        [JsonProperty("closed_cases", Required = Required.Always)]
        public long ClosedCases { get; set; }

        [JsonProperty("closing_speed", Required = Required.Always)]
        public long ClosingSpeed { get; set; }

        [JsonProperty("average_rating", Required = Required.Always)]
        public string AverageRating { get; set; }
    }
}
