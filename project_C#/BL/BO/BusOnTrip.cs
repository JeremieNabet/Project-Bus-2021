using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BusOnTrip
    {
        public int licenseBusNum { get; set; }
        public int lineId { get; set; }
        public TimeSpan plannedTakeOff { get; set; }
        public TimeSpan actualTakeOff { get; set; }
        public int prevStation { get; set; }
        public TimeSpan prevStationAt { get; set; }
        public TimeSpan nextStationAt { get; set; }

        //List<StationBO> list;
    }
}
