using CommunicationEntities;
using DbEntities;
using DbWorker;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAppliServer.Controllers
{
    public class OrdersController
    {
        [HttpPost]
        public Response GetFreeOrders ([FromBody] Request request)
        {
                       
            List<Order> orders =DbManager.GetInstance().TableOrders.GetOrders();
            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = JsonConvert.SerializeObject(orders)
            };

        }

        [HttpPost]
        public Response GetFreeOrders2([FromBody] Request request)
        {

            List<Order> orders = DbManager.GetInstance().TableOrders.GetOrders();
            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = JsonConvert.SerializeObject(orders)
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
        public Response GetOrderInfo([FromBody] Request request)
        {
            int idCourier = int.Parse(request.Parameters);
          
            DbManager.GetInstance().TableOrders.GetOrderInfo(idCourier);

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

            DbManager.GetInstance().TableOrders.InsertOrder(lat, lon,coast);

            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = ""
            };

        }
    }
}