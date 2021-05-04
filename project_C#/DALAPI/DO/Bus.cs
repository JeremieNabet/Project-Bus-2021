using DALAPI.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Bus
    {
        public int LicenseNum { get; set; }
        public DateTime FromDate { get; set; }
        public double TotalTrip { get; set; }
        public double FuelRemain { get; set; }
        public Status BusStatus { get; set; }
        public enum Status
        {
            trip, treatement, refueling, availableTrip
        }

        public override string ToString() => this.ToStringProperty();
    }
}
