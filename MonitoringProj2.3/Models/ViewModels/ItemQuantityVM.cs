using System.Runtime.Serialization;

namespace MonitoringProj2._3.Models.ViewModels
{
    [DataContract]
    public class ItemQuantityVM
    {
        [DataMember(Name = "Item")]
        public string Item { get; set; }
        [DataMember(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
