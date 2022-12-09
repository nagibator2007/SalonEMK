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
   public class ServiceCategoryesController
    {
        /// <summary>
        /// Вывод категорий
        /// </summary>
        /// <returns></returns>
        public static List<ServicesCategoryes> GetServiceCategoryes()

        {

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}ServiceCategoryes").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<ServicesCategoryes>>(content.Result);
                return answer;

            }

        }
        /// <summary>
        /// Вывод информации о категории
        /// </summary>
        /// <returns></returns>
        public  static ServicesCategoryes GetInfoCategoryes(int idCat)

        {
            return  GetServiceCategoryes().Where(x => x.CategoryId == idCat).FirstOrDefault();

        }
    }
    }


