using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Trip
    {
        public int id { get; set; }
        public string userName { get; set; }
        public int lineId { get; set; }
        public int inStation { get; set; }
        public TimeSpan inAt { get; set; }
        public int outStation { get; set; }
        public TimeSpan outAt { get; set; }


    }
}
