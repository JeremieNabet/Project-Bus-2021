using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALAPI.DO;

namespace DO
{
    public class LineStation:Station
    {
        public int ID { get; set; }
        public int LineId { get; set; }
        public int Station { get; set; }
        public string LineStationIndex { get; set; }
        public int PrevStation { get; set; }
        public int NextStation { get; set; }
        public override string ToString() => this.ToStringProperty();
        public LineStation(Station s)
        {
            latitude = s.latitude;
            longitude = s.longitude;
            name = s.name;
            Station = s.code;
            LineStationIndex = "0";
        }
        public LineStation()
        {

        }
    }
}
