using DALAPI.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class AdjacentStations
    {
        Random r = new Random();      
        public int Id { get; set; }
        public int Station1 { get; set; }
        public int Station2 { get; set; }
        public double Distance { get; set; }
        public TimeSpan Time { get; set; }

        public override string ToString()
        {
            return string.Format("Distance :{0}, Time :{1}", Distance, Time.ToString());
        }
        public AdjacentStations(LineStation s,LineStation l)
        {
            Station1 = s.ID;
            Station2 = l.ID;

           
            Distance = r.Next(100, 600);

            if (Distance > 300)
            {

                Time = new TimeSpan(0, r.Next(3, 6), r.Next(0, 60));
            }
            else
                Time = new TimeSpan(0, r.Next(0, 3), r.Next(0, 60));
        }
        public AdjacentStations()
        {

        }
       
    }
}
