using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALAPI.DO;

namespace DO
{
    public class Station
    {
        public int code { get; set; }
        public string name { get; set; }
        public int longitude { get; set; }
        public int latitude { get; set; }
        public bool handicap { get; set; }
        Random r;

        public override string ToString() => this.ToStringProperty();
        public Station()
        {

        }
        public Station(string s)
        {
            r = new Random();
            longitude = r.Next(31, 34);
            latitude = r.Next(31, 34);
            
        }


    }
}
