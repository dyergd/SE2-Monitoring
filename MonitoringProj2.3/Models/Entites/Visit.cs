using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj2._3
{
    /// <summary>
    /// The Visit class represents a Visit entity within our database
    /// </summary>
    public class Visit
    {
        [Key]
        public int Id { get; set; }//The ID of the Visit entity
        public string Ip { get; set; }//The IP address of the visit in question
        public DateTime Timestamp { get; set; }//The timestamp of the visit
        public string DeviceSource { get; set; }//The device source for the visit

    }
}
