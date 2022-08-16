using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj
{
    public class Visit
    {
        //[Key] specifies that ID is going to be the primary key in the database
        [Key]
        public int Id { get; set; }
        public string Ip { get; set; } //represents user IP
        public DateTime Timestamp { get; set; } //represents the time and date the visit happened
        public string DeviceSource { get; set; } //the type of device the user was using ie. Windows
    }
}
