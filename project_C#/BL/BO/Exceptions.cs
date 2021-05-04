using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    
    [Serializable]
    public class BadBusIdException : Exception
    {
        public int ID;
        public BadBusIdException(string message, Exception innerException) :
            base(message, innerException) => ID = int.Parse(((DO.BadBusIdException)innerException).ID);
        public override string ToString() => base.ToString() + $", bad bus id: {ID}";
    }
    public class BLException : Exception
    {
        public BLException()
        {
        }
        public BLException(string message) : base(message)
        {

        }
    }
    [Serializable]
    public class BadAdjacentStationsIdException : Exception
    {
        public int ID;
        public BadAdjacentStationsIdException(string message, Exception innerException) :
            base(message, innerException) => ID = int.Parse(((DO.BadAdjacentStationsIdException)innerException).ID);
        public override string ToString() => base.ToString() + $", bad adjacent Station id: {ID}";
    }
    public class BadUserIdException : Exception
    {
        public int ID;
        public BadUserIdException(string message, Exception innerException) :
            base(message, innerException) => ID = int.Parse(((DO.BadUserIdException)innerException).ID);
        public override string ToString() => base.ToString() + $", bad user id: {ID}";
    }
    
    public class BadStationIdException : Exception
    {
     public int ID;
     public BadStationIdException(string message, Exception innerException) :
            base(message, innerException) => ID = int.Parse(((DO.BadStationIdException)innerException).ID);
     public override string ToString() => base.ToString() + $", bad station id: {ID}";
    }
    public class BadTripIdException : Exception
    {
        public int ID;
        public BadTripIdException(string message, Exception innerException) :
               base(message, innerException) => ID = int.Parse(((DO.BadTripIdException)innerException).ID);
        public override string ToString() => base.ToString() + $", bad trip id: {ID}";
    }
    public class BadLineTripIdException : Exception
    {
        public int ID;
        public BadLineTripIdException(string message, Exception innerException) :
               base(message, innerException) => ID = int.Parse(((DO.BadLineTripIdException)innerException).ID);
        public override string ToString() => base.ToString() + $", bad line trip id: {ID}";
    }
    public class BadLineStationIdException : Exception
    {
        public int ID;
        public BadLineStationIdException(string message, Exception innerException) :
               base(message, innerException) => ID = int.Parse(((DO.BadLineStationIdException)innerException).ID);
        public override string ToString() => base.ToString() + $", bad line trip id: {ID}";
    }
    public class BadBusOnTripIdException : Exception
    {
        public int ID;
        public BadBusOnTripIdException(string message, Exception innerException) :
               base(message, innerException) => ID = int.Parse(((DO.BadBusOnTripIdException)innerException).ID);
        public override string ToString() => base.ToString() + $", bad line trip id: {ID}";
    }
}
