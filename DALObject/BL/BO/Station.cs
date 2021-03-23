using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Station
    {
     

        #region get set
        public int code { get ; set ; }
        public string name { get; set; }
        public int longitude { get; set; }
        public int latitude { get; set; }
        public bool handicap { get; set; }
        #endregion
    }
}
