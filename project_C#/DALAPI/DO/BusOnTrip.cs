using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALAPI.DO;
using System.Threading.Tasks;

namespace DO
{
    public class BusOnTrip
    {
        public int id { get; set; }
        public int licenseNum { get; set; }
        public int lineId { get; set; }
        public TimeSpan plannedTakeOff { get; set; }
        public TimeSpan actualTakeOff { get; set; }
        public int prevStation { get; set; }
        public TimeSpan prevStationAt { get; set; }
        public TimeSpan nextStationAt { get; set; }

        public override string ToString() => this.ToStringProperty();
    }
}
