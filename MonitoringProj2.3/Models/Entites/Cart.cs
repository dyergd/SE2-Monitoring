using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj2._3
{
    /// <summary>
    /// The Cart class represents a Cart entity in our database
    /// </summary>
    public class Cart
    {
        [Key]
        public int Id { get; set; } // The Id of the cart
        public DateTime Timestamp { get; set; } //The timestamp value associated with the cart
        public int VisitId { get; set; } //The Visit ID associated with the cart
        public Visit Visit { get; set; } //The visit entity associated with the cart
        public bool Purchased { get; set; }//Whether the cart was purchased or not
        public DateTime Purch_timestamp { get; set; }//The timestamp of the purchase associated with the cart
        public ICollection<CartItem> Items { get; set; }//The Items associated with the cart
    }
}
