using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
namespace BL.BO
{
    public class LineTiming : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public int BusLineNumber { get; set; }
        public int Freq { get; set; }

        private TimeSpan timeBeforeArrival;
        public TimeSpan TimeBeforeArrival
        {
            get { return timeBeforeArrival; }
            set
            {
                timeBeforeArrival = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("TimeBeforeArrival"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

 
        public string lastStation { get; set; }
        public LineTiming() { }
        public LineTiming(Line l)
        {
            BusLineNumber = l.busLineNumber;
      
            lastStation = l.listStations[l.listStations.Count - 1].Station.ToString();
        }
        public IEnumerable<LineTiming> getmyTimings(LineStation i, TimeSpan currentH)
        {
            Random r;
            List<LineTiming> mylist = new List<LineTiming>();
            
            i.myLines.ForEach(item => mylist.Add(new LineTiming(item)));
            for (int a = 1; a < mylist.Count+1; a++)
            {
                if (a >=3)
                {
                    mylist[a-1].timeBeforeArrival = new TimeSpan(0, currentH.Minutes%a*10-10, 60 - currentH.Seconds);

                }
                else
                {
                    mylist[a-1].timeBeforeArrival = new TimeSpan(0, currentH.Minutes%a*10, 60 - currentH.Seconds);
                }
            }

            
            return from timing in mylist orderby timing.timeBeforeArrival.Minutes ascending select timing;
        }

    }
}
