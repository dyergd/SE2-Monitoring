using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonitoringProj2._3.Models.ViewModels
{
    /// <summary>
    /// ItemAverageVM represents a viewmodel that allows us to display different price statistics about an item
    /// </summary>
    public class ItemAverageVM
    {
        public string Item { get; set; }//The Item we are displaying information for
        public decimal Average { get; set; }//The average price of the item
        [Display(Name = "High Price")]
        public decimal HighPrice { get; set; }//The highest price of the item
        [Display(Name = "Low Price")]
        public decimal LowPrice { get; set; }//The lowest price of the item
        public List<decimal> CostList { get; set; } = new List<decimal>();//A list of costs 
        [Display(Name ="Day most likely to be sold")]
        public DayOfWeek DayOfWeek { get; set; }//The day the item is most likely to be sold
        [Display(Name = "Month most likely to be sold")]
        public int Month { get; set; }//The month the item is most likely to be sold
        public List<DateTime> DateTimeList { get; set; } = new List<DateTime>();//A date time list representing date times
        public List<int> TotalSoldList { get; set; } = new List<int>();//The total amount sold list of the Item
        [Display(Name = "Total Sold")]
        public int TotalSold { get; set; }//The total sold amount of the item
        [Display(Name = "Total Removed From Cart")]
        public int Removed { get; set; }//Whether the item was removed or not

    }
}
