using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    
        public class BadBusLicenseNumberException : Exception
        {
            public int LicenseNumber;
            public BadBusLicenseNumberException(int licenseNumber) : base() => LicenseNumber = licenseNumber;
            public BadBusLicenseNumberException(int licenseNumber, string message) :
                base(message) => LicenseNumber = licenseNumber;
            public BadBusLicenseNumberException(int licenseNumber, string message, Exception exception) :
                base(message, exception) => LicenseNumber = licenseNumber;
            public override string ToString() => base.ToString() + $", bad license number bus : {LicenseNumber}";

        }
    public class DLException : Exception
    {
        public DLException()
        {

        }
        public DLException(string message) : base(message)
        {

        }
    }
    public class ObjectNotFoundException : Exception
        {
            public string typpous_object;
            public ObjectNotFoundException(string mytyp) : base() => typpous_object = mytyp;
            public ObjectNotFoundException(string mytyp, string message) :
                base(message) => typpous_object = mytyp;
            public ObjectNotFoundException(string mytyp, string message, Exception exception) :
                base(message, exception) => typpous_object = mytyp;
            public override string ToString() => base.ToString() + $", this object was not found : {typpous_object}";

        }
      
        public class BadBusIdException : Exception
        {
            public string ID;
            public BadBusIdException(string mytyp) : base() => ID = mytyp;
            public BadBusIdException(string mytyp, string message) :
                base(message) => ID = mytyp;
            public BadBusIdException(string mytyp, string message, Exception exception) :
                base(message, exception) => ID = mytyp;

             public override string ToString() => base.ToString() + $", this bus was not found : {ID}";

        }
    public class BadAdjacentStationsIdException : Exception
    {
        public string ID;
        public BadAdjacentStationsIdException(string mytyp) : base() => ID = mytyp;
        public BadAdjacentStationsIdException(string mytyp, string message) :
            base(message) => ID = mytyp;
        public BadAdjacentStationsIdException(string mytyp, string message, Exception exception) :
            base(message, exception) => ID = mytyp;

        public override string ToString() => base.ToString() + $", this adjacent station was not found : {ID}";

    }
    public class BadUserIdException : Exception
    {
        public string ID;
        public BadUserIdException(string mytyp) : base() => ID = mytyp;
        public BadUserIdException(string mytyp, string message) :
            base(message) => ID = mytyp;
        public BadUserIdException(string mytyp, string message, Exception exception) :
            base(message, exception) => ID = mytyp;

        public override string ToString() => base.ToString() + $", this user was not found : {ID}";

    }
    public class BadStationIdException : Exception
    {
        public string ID;
        public BadStationIdException(string mytyp) : base() => ID = mytyp;
        public BadStationIdException(string mytyp, string message) :
            base(message) => ID = mytyp;
        public BadStationIdException(string mytyp, string message, Exception exception) :
            base(message, exception) => ID = mytyp;

        public override string ToString() => base.ToString() + $", this station was not found : {ID}";

    }
    public class BadTripIdException : Exception
    {
        public string ID;
        public BadTripIdException(string mytyp) : base() => ID = mytyp;
        public BadTripIdException(string mytyp, string message) :
            base(message) => ID = mytyp;
        public BadTripIdException(string mytyp, string message, Exception exception) :
            base(message, exception) => ID = mytyp;

        public override string ToString() => base.ToString() + $", this trip was not found : {ID}";

    }
    public class BadLineTripIdException : Exception
    {
        public string ID;
        public BadLineTripIdException(string mytyp) : base() => ID = mytyp;
        public BadLineTripIdException(string mytyp, string message) :
            base(message) => ID = mytyp;
        public BadLineTripIdException(string mytyp, string message, Exception exception) :
            base(message, exception) => ID = mytyp;

        public override string ToString() => base.ToString() + $", this trip was not found : {ID}";

    }
    public class BadLineStationIdException : Exception
    {
        public string ID;
        public BadLineStationIdException(string mytyp) : base() => ID = mytyp;
        public BadLineStationIdException(string mytyp, string message) :
            base(message) => ID = mytyp;
        public BadLineStationIdException(string mytyp, string message, Exception exception) :
            base(message, exception) => ID = mytyp;

        public override string ToString() => base.ToString() + $", this trip was not found : {ID}";

    }
    public class BadBusOnTripIdException : Exception
    {
        public string ID;
        public BadBusOnTripIdException(string mytyp) : base() => ID = mytyp;
        public BadBusOnTripIdException(string mytyp, string message) :
            base(message) => ID = mytyp;
        public BadBusOnTripIdException(string mytyp, string message, Exception exception) :
            base(message, exception) => ID = mytyp;

        public override string ToString() => base.ToString() + $", this trip was not found : {ID}";

    }
    public class XMLFileLoadCreateException : Exception
    {
        public string xmlFilePath;
        public XMLFileLoadCreateException(string xmlPath) : base() { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message) :
            base(message)
        { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message, Exception innerException) :
            base(message, innerException)
        { xmlFilePath = xmlPath; }

        public override string ToString() => base.ToString() + $", fail to load or create xml file: {xmlFilePath}";
    }
}

