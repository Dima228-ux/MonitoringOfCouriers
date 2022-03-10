using CommunicationEntities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Client
    {
        private HttpClient _httpClient;

        public Client()
        {
            _httpClient = new HttpClient();
        }

        //public async Task<Response> RetrieveServerResponseAsync(Request request)//44372
        //{
        //    string data = JsonConvert.SerializeObject(request);
        //    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

        //    HttpResponseMessage responseMessage = await _httpClient.PostAsync("http://localhost:15556/", content);

        //    string responseJson = await responseMessage.Content.ReadAsStringAsync();

        //    return JsonConvert.DeserializeObject<Response>(responseJson);
        //}

        public async Task<Response> RetrieveServerResponseAsync(Request request, string urlPart)//44372
        {
            string data = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await _httpClient.PostAsync("https://localhost:44378/api/" + urlPart, content);

            string responseJson = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response>(responseJson);
        }
    }
}
