using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MonitoringProj2._3
{
    /// <summary>
    /// The CartItem class represents an item inside a cart in our data
    /// </summary>
    public class CartItem
    {
        [Key]
        public int Id { get; set; } //The ID of the cart item
        [Display(Name = "Cart Id")]
        public int CartId { get; set; }//The ID of the associated Cart
        public Cart Cart { get; set; }//The actual Cart entity
        public string Item { get; set; }//The Item entity
        public DateTime Timestamp { get; set; }//The associated timestamp
        public int Quantity { get; set; }//The quantity of the item in the cart
        public bool Removed { get; set; }//Whether or not the cart item was removed
        public decimal Cost { get; set; }//The cost of the cart item

    }
}
