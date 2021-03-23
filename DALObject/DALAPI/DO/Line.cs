using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALAPI.DO;

namespace DO
{
    public class Line
    {
        public int Id { get; set; }
        public int busLineNumber { get; set; }
        public Area Areas { get; set; }
        public int FirstStation { get; set; }
        public int LastStation { get; set; }

        public override string ToString() => this.ToStringProperty();
    }
}
