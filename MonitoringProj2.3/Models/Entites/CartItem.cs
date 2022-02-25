using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MonitoringProj2._3
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cart Id")]
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public string Item { get; set; }
        public DateTime Timestamp { get; set; }
        public int Quantity { get; set; }
        public bool Removed { get; set; }
        public decimal Cost { get; set; }

    }
}
