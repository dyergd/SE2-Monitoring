using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj
{
    public class Visit
    {
        public int Id { get; set; }
        public string ip { get; set; }
        public DateTime Timestamp { get; set; }
        public string Origin { get; set; }
        public string DeviceSource { get; set; }
        //public int CookieId { get; set; }
        //public List<cart> Carts { get; set; }
        //public List<visit_clicks> Clicks { get; set; }
    }
}
