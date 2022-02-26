using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MonitoringProj2._3.Models.ViewModels
{
    public class InventoryVM
    {
        public int Id { get; set; }
        [Display(Name = "Cart Id")]
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public string Item { get; set; }
        public DateTime Timestamp { get; set; }
        public int Quantity { get; set; }
        public bool Removed { get; set; }
        public decimal Cost { get; set; }
        [Display(Name = "Total Cost")]
        public decimal TotalCost { get; set; }
    }
}
