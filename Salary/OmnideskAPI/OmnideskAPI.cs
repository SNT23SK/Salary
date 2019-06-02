using Newtonsoft.Json.Linq;
using Salary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Salary.OmnideskAPI
{
    public class OmnideskAPI
    {
        #region Vaiables        

        private Uri _baseAddress;

        private string _username = string.Empty;

        private string _apikey = string.Empty;

        #endregion

        #region Constructors        

        public OmnideskAPI(string address, string username, string apikey)
        {
            _baseAddress = new Uri(address);
            _username = username;
            _apikey = apikey;
        }

        #endregion

        public List<Staff> GetAllStaffs()
        {
            JObject answer = null;
            List<Staff> staffs = new List<Staff>();
            Task.Run(async () => answer = await GetAllStaffsAsync()).GetAwaiter().GetResult();

            int totalCount = answer["total_count"].ToObject<int>();

            for (int i = 0; i < totalCount; i++)
            {
                JObject subAnswer = answer[i.ToString()]["staff"] as JObject;
                Staff staff = subAnswer.ToObject<Staff>();
                staffs.Add(staff);
            }            

            return staffs;
        }

        #region Properties



        #endregion

        #region Async Requests

        private async Task<JObject> GetAllStaffsAsync()
        {
            string url = "/api/staff.json";            
            JObject json = null;

            using (var client = new HttpClient() { BaseAddress = _baseAddress })
            {
                var byteArray = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _username, _apikey));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var result = await client.GetAsync(url);
                var bytes = await result.Content.ReadAsByteArrayAsync();
                Encoding encoding = Encoding.GetEncoding("utf-8");
                string data = encoding.GetString(bytes, 0, bytes.Length);
                json = JObject.Parse(data);
                result.EnsureSuccessStatusCode();
            }

            return json;
        }

        #endregion
    }
}