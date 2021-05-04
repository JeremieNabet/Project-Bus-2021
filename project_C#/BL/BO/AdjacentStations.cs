using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class AdjacentStations
    {
        public int Id { get; set; }
        public int Station1 { get; set; }
        public int Station2 { get; set; }
        public double Distance { get; set; }
        public TimeSpan Time { get; set; }

        public override string ToString()
        {
            return string.Format("Id={0}, Station1={1}, Station2={2}, Distance={3}, Time={4}]", Id, Station1, Station2, Distance, Time);
        }
        public AdjacentStations()
        {

        }
        public AdjacentStations(LineStation s1,LineStation s2)
        {
            Station1 = s1.ID;
            Station2 = s2.ID;
            Random r = new Random();
            Distance = r.Next(100, 600);

            if (Distance > 300)
            {

                Time = new TimeSpan(0, r.Next(3, 6), r.Next(0, 60));
            }
            else
                Time = new TimeSpan(0, r.Next(0, 3), r.Next(0, 60));
        }
    }
}
