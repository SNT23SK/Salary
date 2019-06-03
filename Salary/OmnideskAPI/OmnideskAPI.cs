using Newtonsoft.Json.Linq;
using Salary.Logic;
using Salary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Salary.OmnideskAPI
{
    public class OmnideskAPI
    {
        #region Vaiables        

        /// <summary>
        /// Адрес сервиса с API
        /// </summary>
        private Uri _baseAddress;

        /// <summary>
        /// Логин для API
        /// </summary>
        private string _username = string.Empty;

        /// <summary>
        /// Ключ для подключения к API
        /// </summary>
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

        public List<Case> GetCasesRange(int staffsId, DateTime fromDate, DateTime toDate)
        {
            JObject answer = null;
            List<Case> cases = new List<Case>();
            Task.Run(async () => answer = await GetCasesForRangeAsycn(staffsId, fromDate, toDate)).GetAwaiter().GetResult();

            if (answer.ContainsKey("total_count"))
            {
                int totalCount = answer["total_count"].ToObject<int>();
                List<int> repeat = GetRepeat(totalCount);

                for (int j = 0; j < repeat.Count; j++)
                {
                    if (repeat.Count > 1 && j > 0 && j < repeat.Count)
                    {
                        Task.Run(async () => answer = await GetCasesForRangeAsycn(staffsId, fromDate, toDate, 1 + j, repeat[j])).GetAwaiter().GetResult();
                    }
                    for (int i = 0; i < repeat[j]; i++)
                    {
                        JObject subAnswer = answer[i.ToString()]["case"] as JObject;
                        if (subAnswer != null)
                        {
                            Case _case = subAnswer.ToObject<Case>();
                            cases.Add(_case);
                        }
                    }
                }
            }

            return cases;
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
                client.DefaultRequestHeaders.Authorization = GetAuthHeader();
                var result = await client.GetAsync(url);
                var bytes = await result.Content.ReadAsByteArrayAsync();
                json = BytesToJson(bytes);
                result.EnsureSuccessStatusCode();
            }

            return json;
        }

        private async Task<JObject> GetCasesForRangeAsycn(int staffId, DateTime fromDate, DateTime toDate, int page=1, int limit=100)
        {
            string url = string.Format("/api/cases.json?" +
                                       "page={0}&" +
                                       "limit={1}&" +
                                       "staff_id={2}&" +
                                       "from_updated_time={3}&" +
                                       "to_updated_time={4}",
                                       page,
                                       limit,
                                       staffId,
                                       HelperDate.TimestampFromDateTime(fromDate),
                                       HelperDate.TimestampFromDateTime(toDate));
            JObject json = null;

            using (var client = new HttpClient() { BaseAddress = _baseAddress })
            {
                client.DefaultRequestHeaders.Authorization = GetAuthHeader();
                var result = await client.GetAsync(url);
                var bytes = await result.Content.ReadAsByteArrayAsync();
                json = BytesToJson(bytes);
                result.EnsureSuccessStatusCode();
            }

            return json;
        }        

        #endregion

        #region Methods

        /// <summary>
        /// Формирует строку базовой аутентификации в API Omnidesk
        /// </summary>
        /// <returns>параметр header аутентификации</returns>
        private AuthenticationHeaderValue GetAuthHeader()
        {
            var byteArray = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _username, _apikey));
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        /// <summary>
        /// Конвертирует ответ в байтах в ответ json текст
        /// с кодировкой utf - 8
        /// </summary>
        /// <param name="bytes">ответ в байтах</param>
        /// <returns>json ответ</returns>
        private JObject BytesToJson(byte[] bytes)
        {
            Encoding encoding = Encoding.GetEncoding("utf-8");
            string data = encoding.GetString(bytes, 0, bytes.Length);
            return JObject.Parse(data);
        }        

        /// <summary>
        /// Возвращает список с количеством записей на каждый запрос 
        /// (ограничение omnidesk в ответе не более 100 записей)
        /// </summary>
        /// <param name="totalCount">количество записей в ответе на запрос</param>
        /// <returns>Массив записей на страницах</returns>
        private List<int> GetRepeat(int totalCount)
        {
            List<int> repeat = new List<int>();

            if (totalCount > 100)
            {
                int remainderPage = totalCount % 100;
                int totalPages = ((totalCount - remainderPage) / 100) + (remainderPage > 0 ? 1 : 0);
                for (int i = 0; i < totalPages; i++)
                {
                    if (i == totalPages - 1)
                    {
                        repeat.Add(remainderPage);
                    }
                    else
                    {
                        repeat.Add(100);
                    }
                }
            }
            else
            {
                repeat.Add(totalCount);
            }

            return repeat;
        }

        #endregion
    }
}