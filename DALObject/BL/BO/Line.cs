using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Line
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int busLineNumber { get; set; }
        public Area Areas { get; set; }
        public int FirstStation { get; set; }
        public int LastStation { get; set; }

        public List<LineStation> listStations { get; set; }
        public Line()
        {
            listStations = new List<LineStation>();
        }
        public override string ToString()
        {
            return string.Format("Line number : {0}", busLineNumber);
        }
    }
}
