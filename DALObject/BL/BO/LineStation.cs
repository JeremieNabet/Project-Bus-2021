using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineStation:Station
    {
        public int ID { get; set; }
        public int LineId { get; set; }
        public int Station { get; set; }
        public string LineStationIndex { get; set; }
        public TimeSpan Temps { get; set; }
        public double Distance { get; set; }
        public int PrevStation { get; set; }
        public int NextStation { get; set; }
        public List<Line> myLines { get; set; }
        public LineStation()
        {
            myLines = new List<Line>();
        }
        public override string ToString()
        {
            return string.Format("Station code : {0}", Station.ToString());
        }

    }
    
}
