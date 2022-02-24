using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj2._3
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int VisitId { get; set; }
        public Visit Visit { get; set; }
        public bool Purchased { get; set; }
        public DateTime PunchTimestamp { get; set; }
        public ICollection<CartItem> Items { get; set; }
    }
}
