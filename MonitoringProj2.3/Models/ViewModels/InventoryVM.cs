using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MonitoringProj2._3.Models.ViewModels
{
    /// <summary>
    /// The InventoryVM class represents a viewmodel that allows us to display inventory information
    /// </summary>
    public class InventoryVM
    {
        public int Id { get; set; } //The ID value associated with the inventory
        [Display(Name = "Cart Id")]
        public int CartId { get; set; }//The CartId associated with the inventory
        public Cart Cart { get; set; }//The actual cart entity associated with the inventory
        public string Item { get; set; }//The item associated with the inventory
        public DateTime Timestamp { get; set; }//The timestamp associated with the inventory
        public int Quantity { get; set; }//The quantity of items associated with the inventory
        public bool Removed { get; set; }//Whether or not a specific item was removed from the inventory
        public decimal Cost { get; set; }//The cost of the items in the inventory
        [Display(Name = "Total Cost")]
        public decimal TotalCost { get; set; }//The total cost of all items in the inventory
    }
}
