using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj
{
    public class VisitResponse
    {
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int ResponseCode { get; set; }
        public string Message { get; set; }
    }
}
