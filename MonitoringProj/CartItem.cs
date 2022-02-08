using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public string Item { get; set; }
        public DateTime Timestamp { get; set; }
        public int Quantity { get; set; }
        public bool Removed { get; set; }
        public decimal Cost { get; set; }

    }
}
