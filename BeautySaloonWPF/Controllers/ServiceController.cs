using BeautySaloonWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonWPF.Controllers
{
    class ServiceController
    {
        /// <summary>
        /// Вывод  сервисов заданной категории
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        /// 
        public static List<Sevices> GetInfoCategory(int categoryId)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}Services/{categoryId}").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<Sevices>>(content.Result);
                return answer;
            }
        }
    }
}
