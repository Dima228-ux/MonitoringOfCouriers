using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DbWorker;
using DbEntities;
using CommunicationEntities;
using Newtonsoft.Json;

namespace WebAppliServer.Controllers
{
    public class UsersController:ApiController
    {
        [HttpPost]
        public Response GetUserByLoginPassword([FromBody] Request request)
        {
            Dictionary<string, string> userParameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(request.Parameters);

            string login = userParameters["login"];
            string password = userParameters["password"];

            User user = DbManager.GetInstance().TableUsers.GetUserByLoginPassword(login, password);

            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = JsonConvert.SerializeObject(user)
            };
        }

        [HttpPost]
        public Response GetFreeOrders([FromBody] Request request)
        {

            List<Order> orders = DbManager.GetInstance().TableOrders.GetOrders();
            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = JsonConvert.SerializeObject(orders)
            };

        }

        [HttpPost]
        public Response UpdateCoordinateCourier([FromBody] Request request)
        {
            Dictionary<string, float> userParameters = JsonConvert.DeserializeObject<Dictionary<string, float>>(request.Parameters);

            int idCourier = (Int32)userParameters["idCourier"];
            float lat = userParameters["lat"];
            float lon = userParameters["lon"];

          bool isUpdate= DbManager.GetInstance().TableUsers.UpdateCoordinateCourier( idCourier, lat, lon);

            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = JsonConvert.SerializeObject(isUpdate)
            };
        }

        [HttpPost]
        public Response GetCoordinatCourier([FromBody] Request request)
        {
            Dictionary<string, int> userParameters = JsonConvert.DeserializeObject<Dictionary<string, int>>(request.Parameters);

            int idCourier = (Int32)userParameters["idCourier"];
            

            float[] coordinats= DbManager.GetInstance().TableUsers.GetCoordinatCourier(idCourier);

            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = JsonConvert.SerializeObject(coordinats)
            };
        }

        [HttpPost]
        public Response UpdateStatusCourier([FromBody] Request request)
        {
            Dictionary<string,int> userParameters = JsonConvert.DeserializeObject<Dictionary<string, int>>(request.Parameters);
            int idCourier = userParameters["idCourier"];

            DbManager.GetInstance().TableUsers.UpdateStatusCourier(idCourier);

            return new Response()
            {
                Status = Response.StatusList.OK
            };
        }

        [HttpPost]
        public Response RegistedNewUser([FromBody] Request request)
        {
            Dictionary<string, string> userParameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(request.Parameters);
            string name = userParameters["name"];
            string login = userParameters["login"];
            string password = userParameters["password"];
            string typeUser = userParameters["type"];
            string surname = userParameters["surname"];

            if (DbManager.GetInstance().TableUsers.CheckLoginUser(login))
            {
                DbManager.GetInstance().TableUsers.RegistedNewUser( login, password,typeUser,name,surname);
            }

            return new Response()
            {
                Status = Response.StatusList.OK
            };
        }

        [HttpPost]
        public Response UpdateStatusOrder([FromBody] Request request)
        {
            Dictionary<string, int> userParameters = JsonConvert.DeserializeObject<Dictionary<string, int>>(request.Parameters);

            int idOrder = userParameters["idOrder"];
            int idCourier = userParameters["idCourier"];

            DbManager.GetInstance().TableOrders.UpdateStatus(idOrder, idCourier);

            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = ""
            };

        }

        [HttpPost]
        public Response InsertOrder([FromBody] Request request)
        {
            Dictionary<string, float> userParameters = JsonConvert.DeserializeObject<Dictionary<string, float>>(request.Parameters);

            float lat = userParameters["lat"];
            float lon = userParameters["long"];
            int coast = (int)userParameters["coast"];

            DbManager.GetInstance().TableOrders.InsertOrder(lat, lon, coast);

            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = ""
            };

        }
    }
}