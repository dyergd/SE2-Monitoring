using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int VisitId { get; set; }
        public bool Purchased { get; set; }
        public DateTime PunchTimestamp { get; set; }

        //public visit visit { get; set; }
        //public List<cart_item> Items { get; set; }
    }
}
