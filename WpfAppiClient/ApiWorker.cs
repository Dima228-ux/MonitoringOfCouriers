using ClassLibrary;
using CommunicationEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppiClient
{
    public class ApiWorker
    {
        private static ApiWorker _instance;
        private string _apiKey;
        private Client _client;

        private ApiWorker()
        {
            _client = new Client();
            _apiKey = "FSB-9c2ee4c6-b7df-49bf-bf2d-3381df692a3c";
        }

        public static ApiWorker GetInstance()
        {
            if (_instance == null)
                _instance = new ApiWorker();
            return _instance;
        }

        public Task<Response> GetUserByLoginPassword(string login, string password)
        {
            Dictionary<string, string> userParameters = new Dictionary<string, string>();
            userParameters["login"] = login;
            userParameters["password"] = password;

            Request request = new Request
            {
                Parameters = JsonConvert.SerializeObject(userParameters),
                ApiKey = _apiKey
            };
            return _client.RetrieveServerResponseAsync(request, "Users/GetUserByLoginPassword");
        }

        public Task<Response> UpdateCoordinateCourier(int idCourier, float lat, float lon)
        {
            Dictionary<string, float> userParameters = new Dictionary<string, float>();
            userParameters["idCourier"] = idCourier;
            userParameters["lat"] = lat;
            userParameters["lon"] = lon;

            Request request = new Request
            {
                Parameters = JsonConvert.SerializeObject(userParameters),
                ApiKey = _apiKey
            };
            return _client.RetrieveServerResponseAsync(request, "Users/UpdateCoordinateCourier");
        }

        public Task<Response> GetCoordinatCourier(int idCourier)
        {
            Dictionary<string, int> userParameters = new Dictionary<string, int>();
            userParameters["idCourier"] = idCourier;

            Request request = new Request
            {
                Parameters = JsonConvert.SerializeObject(userParameters),
                ApiKey = _apiKey
            };
            return _client.RetrieveServerResponseAsync(request, "Users/GetCoordinatCourier");
        }

        public Task<Response> UpdateStatusCourier(int idCourier)
        {
            Dictionary<string, int> userParameters = new Dictionary<string, int>();
            userParameters["idCourier"] = idCourier;

            Request request = new Request
            {
                Parameters = JsonConvert.SerializeObject(userParameters),
                ApiKey = _apiKey
            };
            return _client.RetrieveServerResponseAsync(request, "Users/UpdateStatusCourier");
        }

        public Task<Response> RegistedNewUser(string name, string login, string password, string typeUser, string surname)
        {
            Dictionary<string, string> userParameters = new Dictionary<string, string>();
            userParameters["name"] = name;
            userParameters["login"] = login;
            userParameters["password"] = password;
            userParameters["type"] = typeUser;
            userParameters["surname"] = surname;

            Request request = new Request
            {
                Parameters = JsonConvert.SerializeObject(userParameters),
                ApiKey = _apiKey
            };
            return _client.RetrieveServerResponseAsync(request, "Users/RegistedNewUser");
        }

        public Task<Response> GetFreeOrders(bool status)
        {
            //Dictionary<string, bool> userParameters = new Dictionary<string, bool>();
            //userParameters["status"] = status;
            Request request = new Request
            {
                Parameters = JsonConvert.SerializeObject(null),
                ApiKey = _apiKey
            };
            return _client.RetrieveServerResponseAsync(request, "Users/GetFreeOrders");
        }

        public Task<Response> UpdateStatusOrder(int idCourier, int idOrder)
        {
            Dictionary<string, int> userParameters = new Dictionary<string, int>();
            userParameters["idCourier"] = idCourier;
            userParameters["idOrder"] = idOrder;

            Request request = new Request
            {
                Parameters = JsonConvert.SerializeObject(userParameters),
                ApiKey = _apiKey
            };
            return _client.RetrieveServerResponseAsync(request, "Users/UpdateStatusOrder");
        }

        public Task<Response> GetOrderInfo(int idCourier)
        {
            Dictionary<string, int> userParameters = new Dictionary<string, int>();
            userParameters["idCourier"] = idCourier;

            Request request = new Request
            {
                Parameters = JsonConvert.SerializeObject(userParameters),
                ApiKey = _apiKey
            };
            return _client.RetrieveServerResponseAsync(request, "Orders/GetOrderInfo");
        }

        public Task<Response> InsertOrder(float lat, float lon, int coast)
        {
            Dictionary<string, float> userParameters = new Dictionary<string, float>();

            userParameters["lat"] = lat;
            userParameters["long"] = lon;
            userParameters["coast"] = coast;

            Request request = new Request
            {
                Parameters = JsonConvert.SerializeObject(userParameters),
                ApiKey = _apiKey
            };
            return _client.RetrieveServerResponseAsync(request, "Users/InsertOrder");
        }

    }
}
