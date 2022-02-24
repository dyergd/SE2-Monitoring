using System.Runtime.Serialization;

namespace MonitoringProj2._3.Models.ViewModels
{
    [DataContract]
    public class ItemQuantityVM
    {
        [DataMember]
        public string Item { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
