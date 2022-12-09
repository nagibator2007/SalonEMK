using BeautySaloonWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonWPF.Controllers
{
    public class UsersController
    {
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>
        /// Объек Users
        /// </returns>
        public static Users GetUsers(string login,string password)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}Users/{login}/{password}").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<Users>>(content.Result);
                return answer[0];
                
            }
        }
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>
        /// true/false
        /// </returns>
        public static bool Auth(string login, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}Users/{login}/{password}").Result;
                return response.IsSuccessStatusCode;

            }
        }

        /// <summary>
        /// Регестрация POST
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool AddUser(Users user)
        {
            string jsonStr = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonStr);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync($"{Manager.RootUrl}Users", byteContent).Result;
                return response.IsSuccessStatusCode;
            }
        }

    }
}
