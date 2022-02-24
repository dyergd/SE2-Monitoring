using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj2._3
{
    public class Visit
    {
        [Key]
        public int Id { get; set; }
        public string Ip { get; set; }
        public DateTime Timestamp { get; set; }
        public string Origin { get; set; }
        public string DeviceSource { get; set; }
        //public int CookieId { get; set; }
        //public List<cart> Carts { get; set; }
        //public List<visit_clicks> Clicks { get; set; }
    }
}
