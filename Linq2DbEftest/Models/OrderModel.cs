using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linq2DbEftest.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public int ClientId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
