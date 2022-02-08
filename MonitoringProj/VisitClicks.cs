using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj
{
    public class VisitClicks
    {
        public int Id { get; set; }
        public int VisitID { get; set; }
        public DateTime ClickTimestamp { get; set; }
        public string CurrentPage { get; set; }
        public string NextPage { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        //public visit Visit { get; set; }
    }
}
