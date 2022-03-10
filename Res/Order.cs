using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbEntities2
{
  public  class Order
    {
        public int Id { get; set; }
        public int Lat { get; set; }
        public int Long { get; set; }
        public int Coast { get; set; }
        public bool Status { get; set; }
        public User User { get; set; }
        public int IdCourier { get; set; }
    }
}
