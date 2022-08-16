using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj
{
    public class Cart
    {
        //[Key] specifies that ID is going to be the primary key in the database
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; } //the time and date that the cart was created 
        public int VisitId { get; set; } //the visit id of the visit
        public Visit Visit { get; set; } //a visit object associated with the cart
        public bool Purchased { get; set; } //declares if the cart was purchased or not
        public DateTime Purch_timestamp { get; set; } // the time and date the cart was purchased
        public ICollection<CartItem> Items { get; set; } //a collection of the items in the cart
    }
}
