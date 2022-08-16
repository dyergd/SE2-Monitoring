using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj
{
    public class CartItem
    {
        //[Key] specifies that ID is going to be the primary key in the database
        [Key]
        public int Id { get; set; }
        public int CartId { get; set; } //the id of the cart the item is in
        public Cart Cart { get; set; }  //the entire cart the item is in
        public string Item { get; set; } // the item name
        public DateTime Timestamp { get; set; } // the time and date the item was added to the cart
        public int Quantity { get; set; } //the number of a specific item
        public bool Removed { get; set; } //declares if a item has been removed from a cart
        public decimal Cost { get; set; } //the cost of the item

    }
}
