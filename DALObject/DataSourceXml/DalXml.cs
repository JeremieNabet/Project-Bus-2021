using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DALAPI.DO;
using DALAPI;

using DO;

namespace DataSourceXml
{
    
    internal class DalXml : IDal
    {
        #region singleton
        static readonly DalXml instance = new DalXml();
        DalXml() {}// static ctor to ensure instance init is done just before first usage
        static DalXml()
        {
            instance.InitAllLists();
        }
        public static DalXml Instance
        {
            get => instance;

        }// The public Instance property to use
   
        #endregion

        public static string busPath = @"BusXml.xml";

        public static string adjacentStationsPath = @"AdjacentStationsXml.xml";

        public static string busOnTripPath = @"BusOnTripXml.xml";

        public static string linePath = @"LineXml.xml";

        public static string lineStationPath = @"LineStationXml.xml";

        public static string lineTripPath = @"LineTripXml.xml";

        public static string stationPath = @"StationXml.xml";

        public static string tripPath = @"TripXml.xml";

        public static string userPath = @"UserXml.xml";


        public void InitAllLists()
        { 
        
        }
           
        #region Bus
        public Bus getBus(int licenseNumber)

        {
            XElement xElement = XMLTools.LoadListFromXMLElement(busPath);
            XElement tempElement = (from p in xElement.Elements()
                                    where int.Parse(p.Element("LicenseNum").Value) == licenseNumber
                                    select p).FirstOrDefault();
            if (tempElement == null)
                throw new Exception("Duplicate bus ID");

            return new Bus()
            {
                LicenseNum = Int32.Parse(tempElement.Element("LicenseNum").Value),
                FromDate = DateTime.Parse(tempElement.Element("FromDate").Value),
                FuelRemain = Int32.Parse(tempElement.Element("FuelRemain").Value),
                TotalTrip = Int32.Parse(tempElement.Element("TotalTrip").Value)
                //BusStatus = (Bus.Status)Int32.Parse(tempElement.Element("busstatus").Value)
            };

        }
        public IEnumerable<Bus> getAllBus()
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(busPath);
            //DataSourceXml.Load_Bus();
            IEnumerable<Bus> list = new List<Bus>();
            list = from p in xElement.Elements()
                   select new Bus()
                   {
                       LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                       //FromDate = DateTime.Parse(p.Element("FromDate").Value),
                       FuelRemain = Int32.Parse(p.Element("FuelRemain").Value),
                       TotalTrip = Int32.Parse(p.Element("TotalTrip").Value),
                       //BusStatus = (Bus.Status)Int32.Parse(p.Element("BusStatus").Value)

                   };


            return list;
        }
        public void createBus(Bus bus)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(busPath);

            XElement element = (from per in xElement.Elements()
                                where int.Parse(per.Element("LicenseNum").Value) == bus.LicenseNum
                                select per).FirstOrDefault();
            if (element != null)
                throw new Exception("Duplicate license number");

            XElement p = new XElement("bus",
                new XElement("LicenseNum", bus.LicenseNum.ToString()),
                new XElement("FuelRemain", bus.FuelRemain.ToString()),
                new XElement("FromDate", bus.FromDate.ToUniversalTime().Ticks.ToString()),
                new XElement("TotalTrip", bus.TotalTrip.ToString())
                //new XElement("busstatus", bus.BusStatus.ToString())

                );
            xElement.Add(p);
            XMLTools.SaveListToXMLElement(xElement, busPath);
            //DataSourceXml.Bus.Add(p);
            //DataSourceXml.Bus.Save(DataSourceXml.busPath);
        }
        public void updateBus(Bus bus)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(busPath);


            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("LicenseNum").Value) == bus.LicenseNum
                                   select per).FirstOrDefault();
            if (tmpelement == null)
                throw new ObjectNotFoundException("Bus");

            tmpelement.Element("LicenseNum").Value = bus.LicenseNum.ToString();
            tmpelement.Element("FuelRemain").Value = bus.FuelRemain.ToString();
            tmpelement.Element("FromDate").Value = bus.FromDate.ToUniversalTime().Ticks.ToString();
            tmpelement.Element("TotalTrip").Value = bus.TotalTrip.ToString();
            //tmpelement.Element("busstatus").Value = bus.BusStatus.ToString();

            XMLTools.SaveListToXMLElement(xElement, busPath);
            
        }
        public void deleteBus(Bus bus)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(busPath);

            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("LicenseNum").Value) == bus.LicenseNum
                                   select per).FirstOrDefault();
            if (tmpelement == null)
                throw new Exception("this bus does not exist, cannot remove it");

            tmpelement.Remove();
            XMLTools.SaveListToXMLElement(xElement, busPath);
           
        }
        public IEnumerable<Bus> getAllBusBy(Predicate<Bus> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(busPath);
               
                return from p in xElement.Elements()
                       let y = new Bus()
                       {
                           LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                           FromDate = DateTime.Parse(p.Element("FromDate").Value),
                           FuelRemain = Int32.Parse(p.Element("FuelRemain").Value),
                           TotalTrip = Int32.Parse(p.Element("TotalTrip").Value),
                           //BusStatus = (Bus.Status)Int32.Parse(p.Element("busstatus").Value)
                       }
                       where predicate(y)
                       select y;
            }

            return getAllBus();

        }
        public bool isExistBus(int licenseNumber)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(busPath);
            XElement element = (from p in xElement.Elements()
                                where int.Parse(p.Element("LicenseNum").Value) == licenseNumber
                                select p).FirstOrDefault();
            return element != null;
        }

        public Bus getBusBy(Predicate<Bus> predicate)
        {
            if (predicate != null)
            {

                //DataSourceXml.Load_Bus();
                XElement xElement = XMLTools.LoadListFromXMLElement(busPath);

                IEnumerable<Bus> help = from p in xElement.Elements()
                                        let y = new Bus()
                                        {
                                            LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                                            FromDate = DateTime.Parse(p.Element("FromDate").Value),
                                            FuelRemain = Int32.Parse(p.Element("FuelRemain").Value),
                                            TotalTrip = Int32.Parse(p.Element("TotalTrip").Value)
                                            //BusStatus = (Bus.Status)Int32.Parse(p.Element("busstatus").Value)
                                        }
                                        where predicate(y)
                                        select y;
                return help.FirstOrDefault();
            }
            else
                throw new Exception("The bus was not found");



        }
        #endregion

        #region Users
        public User getUser(string username)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(userPath);
            XElement tempElement = (from p in xElement.Elements()
                                    where p.Element("userName").Value == username
                                    select p).FirstOrDefault();
            if (tempElement == null)
                throw new Exception("Duplicate User ID");

            return new User()
            {
                userName = tempElement.Element("userName").Value,
                password = tempElement.Element("password").Value,
                admin = Boolean.Parse(tempElement.Element("admin").Value),
                email = tempElement.Element("email").Value
            };
        }
        public IEnumerable<User> getAllUser()
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(userPath);

            IEnumerable<User> list = new List<User>();
            list = from p in xElement.Elements()
                   select new User()
                   {
                       userName = p.Element("userName").Value,
                       password = p.Element("password").Value,
                       admin = Boolean.Parse(p.Element("admin").Value), // convert a string to boolean
                       email = p.Element("email").Value
                   };

            return list;
        }
        public void createUser(User user)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(userPath);

            XElement element = (from per in xElement.Elements()
                                where per.Element("userName").Value == user.userName // convert to int because it is string
                                select per).FirstOrDefault();

            if (element != null)
                throw new Exception("Duplicate user Username");

            XElement p = new XElement("User",
                new XElement("userName", user.userName),
                new XElement("password", user.password),
                new XElement("admin", user.admin.ToString()),
                new XElement("email", user.email)

                );
            xElement.Add(p);
            XMLTools.SaveListToXMLElement(xElement, userPath);

        }
        public void updateUser(User user)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(userPath);

            XElement tmpelement = (from per in xElement.Elements()
                                   where per.Element("userName").Value == user.userName
                                   select per).FirstOrDefault();
            if (tmpelement == null)
                throw new ObjectNotFoundException("User");

            tmpelement.Element("userName").Value = user.userName;
            tmpelement.Element("password").Value = user.password;
            tmpelement.Element("admin").Value = user.admin.ToString();
            tmpelement.Element("email").Value = user.email;

            XMLTools.SaveListToXMLElement(xElement, userPath);

        }
        public void deleteUser(User user)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(userPath);

            XElement tmpelement = (from per in xElement.Elements()
                                   where per.Element("userName").Value == user.userName
                                   select per).FirstOrDefault();

            if (tmpelement == null)
                throw new Exception("this user does not exist, cannot remove it");

            tmpelement.Remove();
            XMLTools.SaveListToXMLElement(xElement, userPath);
        }
        public bool isExistUser(string username)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(userPath);
            XElement element = (from p in xElement.Elements()
                                where p.Element("userName").Value == username
                                select p).FirstOrDefault();
            return element != null;
        }
        public IEnumerable<User> getAllUserBy(Predicate<User> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(userPath);
                return from p in xElement.Elements()
                       let y = new User()
                       {
                           userName = p.Element("userName").Value,
                           password = p.Element("password").Value,
                           admin = Boolean.Parse(p.Element("admin").Value),
                           email = p.Element("email").Value
                       }
                       where predicate(y)
                       select y;
            }

            return getAllUser();

        }

        public User getUserBy(Predicate<User> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(userPath);
                IEnumerable<User> help = from p in xElement.Elements()
                                         let y = new User()
                                         {
                                             userName = p.Element("userName").Value,
                                             password = p.Element("password").Value,
                                             admin = Boolean.Parse(p.Element("admin").Value),
                                             email = p.Element("email").Value
                                         }
                                         where predicate(y)
                                         select y;

                return help.FirstOrDefault();
            }
            else
                throw new Exception("The user was not found");

        }
        #endregion

        #region Station
        public bool isExistStation(int code)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(stationPath);
            XElement element = (from p in xElement.Elements()
                                where int.Parse(p.Element("code").Value) == code
                                select p).FirstOrDefault();
            return element != null;
        }
        public Station getStation(int code)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(stationPath);
            XElement tempElement = (from p in xElement.Elements()
                                    where int.Parse(p.Element("code").Value) == code
                                    select p).FirstOrDefault();

            if (tempElement == null)
                throw new Exception("Duplicate Station Stations ID");

            return new Station()
            {
                code = Int32.Parse(tempElement.Element("code").Value),
                handicap = Boolean.Parse(tempElement.Element("handicapaccess").Value),
                latitude = Int32.Parse(tempElement.Element("latitude").Value),
                longitude = Int32.Parse(tempElement.Element("lontitude").Value),
                name = tempElement.Element("name").Value
            };
        }
        public IEnumerable<Station> getAllStation()
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(stationPath);
            //DataSourceXml.Load_Station();
            IEnumerable<Station> list = new List<Station>();
            list = (from p in xElement.Elements()
                    select new Station()
                    {
                        code = Int32.Parse(p.Element("code").Value),
                        handicap = Boolean.Parse(p.Element("handicap").Value),
                        latitude = Int32.Parse(p.Element("latitude").Value),
                        longitude = Int32.Parse(p.Element("longitude").Value),
                        name = p.Element("name").Value

                    }).ToList();

            return list;
        }
        public void createStation(DO.Station station)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(stationPath);
            XElement element = (from per in xElement.Elements()
                                where int.Parse(per.Element("code").Value) == station.code // convert to int because it is string
                                select per).FirstOrDefault();
            //if (element == null)
            //    throw new Exception("Duplicate station code");

            XElement p = new XElement("Station",
                new XElement("code", station.code.ToString()),
                new XElement("name", station.name),
                new XElement("latitude", station.latitude.ToString()),
                new XElement("longitude", station.longitude.ToString()),
                new XElement("handicap", station.handicap.ToString())

                );
            xElement.Add(p);
            XMLTools.SaveListToXMLElement(xElement, stationPath);
            //DataSourceXml.Station.Add(p);
            //DataSourceXml.Station.Save(DataSourceXml.stationPath);
        }
        public void updateStation(Station station)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(stationPath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("code").Value) == station.code
                                   select per).FirstOrDefault();

            if (tmpelement == null)
                throw new ObjectNotFoundException("Station");

            tmpelement.Element("code").Value = station.code.ToString();
            tmpelement.Element("name").Value = station.name;
            tmpelement.Element("latitude").Value = station.latitude.ToString();
            tmpelement.Element("longitude").Value = station.longitude.ToString();
            tmpelement.Element("handicap").Value = station.handicap.ToString();

            XMLTools.SaveListToXMLElement(tmpelement, stationPath);
            //DataSourceXml.Station.Save(DataSourceXml.stationPath);
        }
        public void deleteStation(Station station)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(stationPath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("code").Value) == station.code
                                   select per).FirstOrDefault();

            if (tmpelement == null)
                throw new Exception("this Station does not exist, cannot remove it");

            tmpelement.Remove();
            XMLTools.SaveListToXMLElement(xElement, stationPath);
            //DataSourceXml.Station.Save(DataSourceXml.stationPath);
        }
        public Station getStationBy(Predicate<Station> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(stationPath);
                //DataSourceXml.Load_Station();
                IEnumerable<Station> help = from p in xElement.Elements()
                                            let y = new Station()
                                            {
                                                code = Int32.Parse(p.Element("code").Value),
                                                handicap = Boolean.Parse(p.Element("handicap").Value),
                                                latitude = Int32.Parse(p.Element("latitude").Value),
                                                longitude = Int32.Parse(p.Element("longitude").Value),
                                                name = p.Element("name").Value
                                            }
                                            where predicate(y)
                                            select y;

                return help.FirstOrDefault();
            }
            else
                throw new Exception("The station was not found");

        }

        public IEnumerable<Station> getAllStationBy(Predicate<Station> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(stationPath);
                //DataSourceXml.Load_Station();
                return from p in xElement.Elements()
                       let y = new Station()
                       {
                           code = Int32.Parse(p.Element("code").Value),
                           handicap = Boolean.Parse(p.Element("handicap").Value),
                           latitude = Int32.Parse(p.Element("latitude").Value),
                           longitude = Int32.Parse(p.Element("longitude").Value),
                           name = p.Element("name").Value
                       }
                       where predicate(y)
                       select y;
            }

            return getAllStation();
        }

        #endregion

        #region Adjacent stations
        public bool isExistAdjacentStations(int Id)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(adjacentStationsPath);
            XElement element = (from p in xElement.Elements()
                                where int.Parse(p.Element("Id").Value) == Id
                                select p).FirstOrDefault();
            return element != null;
        }
        public AdjacentStations getAdjacentStation(int Id)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(adjacentStationsPath);
            XElement tempElement = (from p in xElement.Elements()
                                    where int.Parse(p.Element("Id").Value) == Id
                                    select p).FirstOrDefault();
            if (tempElement == null)
                throw new Exception("Duplicate Adjacent Stations ID");

            return new AdjacentStations()
            {
                Id = Int32.Parse(tempElement.Element("Id").Value),
                Distance = Int32.Parse(tempElement.Element("Distance").Value),
                Station1 = Int32.Parse(tempElement.Element("Station1").Value),
                Station2 = Int32.Parse(tempElement.Element("Station2").Value),
                Time = TimeSpan.Parse(tempElement.Element("Time").Value)
            };
        }
        public IEnumerable<AdjacentStations> getAllAdjacentStations()
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(adjacentStationsPath);
            IEnumerable<AdjacentStations> list = new List<AdjacentStations>();
            list = (from tempElement in xElement.Elements()
                    select new AdjacentStations()
                    {
                        Id = Int32.Parse(tempElement.Element("Id").Value),
                        Station1 = Int32.Parse(tempElement.Element("Station1").Value),
                        Station2 = Int32.Parse(tempElement.Element("Station2").Value),
                        Distance = Double.Parse(tempElement.Element("Distance").Value),
                      
                    }
                   ).ToList();

            return list;
        }
        public void createAdjacentStations(AdjacentStations adjacentStations)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(adjacentStationsPath);
            XElement element = (from per in xElement.Elements()
                                where int.Parse(per.Element("Id").Value) == adjacentStations.Id
                                select per).FirstOrDefault();
            //if (element != null)
            //    throw new Exception("Duplicate Adjacent Station ID");

            Random r = new Random();
            adjacentStations.Id = r.Next(0, 10000);

            XElement p = new XElement("AdjacentStations",
                new XElement("Id", adjacentStations.Id.ToString()),
                new XElement("Station1", adjacentStations.Station1.ToString()),
                new XElement("Station2", adjacentStations.Station2.ToString()),
                new XElement("Time", adjacentStations.Time.ToString()),
                new XElement("Distance", adjacentStations.Distance.ToString())

                );
            xElement.Add(p);
            XMLTools.SaveListToXMLElement(xElement, adjacentStationsPath);
        }
        public void updateAdjacentStations(AdjacentStations adjacentStations)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(adjacentStationsPath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("Id").Value) == adjacentStations.Id
                                   select per).FirstOrDefault();
            if (tmpelement == null)
                throw new ObjectNotFoundException("Adjacent Station");

            tmpelement.Element("Id").Value = adjacentStations.Id.ToString();
            tmpelement.Element("Station1").Value = adjacentStations.Station1.ToString();
            tmpelement.Element("Time").Value = adjacentStations.Time.Ticks.ToString(); // time span cannot use universalTime() funct
            tmpelement.Element("Station2").Value = adjacentStations.Station2.ToString();
            tmpelement.Element("Distance").Value = adjacentStations.Distance.ToString();

            XMLTools.SaveListToXMLElement(tmpelement, adjacentStationsPath);
        }
        public void deleteAdjacentStations(AdjacentStations adjacentStations)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(adjacentStationsPath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("Id").Value) == adjacentStations.Id
                                   select per).FirstOrDefault();
            if (tmpelement == null)
                throw new Exception("this Adjacent Stations does not exist, cannot remove it");

            tmpelement.Remove();
            XMLTools.SaveListToXMLElement(xElement, adjacentStationsPath);
        }
        public IEnumerable<AdjacentStations> getAllAdjacentStationsBy(Predicate<AdjacentStations> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(adjacentStationsPath);
                return from p in xElement.Elements()
                       let y = new AdjacentStations()
                       {

                           Id = Int32.Parse(p.Element("Id").Value),
                           Distance = Int32.Parse(p.Element("Distance").Value),
                           Station1 = Int32.Parse(p.Element("Station1").Value),
                           Station2 = Int32.Parse(p.Element("Station2").Value),
                           Time = TimeSpan.Parse(p.Element("Time").Value)
                       }
                       where predicate(y)
                       select y;
            }

            return getAllAdjacentStations();
        }

        public AdjacentStations getAdjacentStationsBy(Predicate<AdjacentStations> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(adjacentStationsPath);
                IEnumerable<AdjacentStations> help = from p in xElement.Elements()
                                                     let y = new AdjacentStations()
                                                     {
                                                         Id = Int32.Parse(p.Element("Id").Value),
                                                         Distance = Int32.Parse(p.Element("Distance").Value),
                                                         Station1 = Int32.Parse(p.Element("Station1").Value),
                                                         Station2 = Int32.Parse(p.Element("Station2").Value),
                                                         Time = TimeSpan.Parse(p.Element("Time").Value)
                                                     }
                                                     where predicate(y)
                                                     select y;

                return help.FirstOrDefault();
            }
            else
                throw new Exception("The Adjacent Stations was not found");
        }

        #endregion

        #region Trip
        public bool isExistTrip(int id)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(tripPath);
            XElement element = (from p in xElement.Elements()
                                where int.Parse(p.Element("id").Value) == id
                                select p).FirstOrDefault();
            return element != null;
        }
        public Trip getTrip(int id)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(tripPath);
            XElement tempElement = (from p in xElement.Elements()
                                    where int.Parse(p.Element("id").Value) == id
                                    select p).FirstOrDefault();
            if (tempElement == null)
                throw new Exception("Duplicate Trip ID");

            return new Trip()
            {
                id = Int32.Parse(tempElement.Element("id").Value),
                inStation = Int32.Parse(tempElement.Element("inStation").Value),
                userName = tempElement.Element("userName").Value,
                lineId = Int32.Parse(tempElement.Element("lineId").Value),
                inAt = TimeSpan.Parse(tempElement.Element("inAt").Value), // time span convert
                outStation = Int32.Parse(tempElement.Element("outStation").Value),
                outAt = TimeSpan.Parse(tempElement.Element("outAt").Value),
            };
        }
        public IEnumerable<Trip> getAllTrip()
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(tripPath);
            //DataSourceXml.Load_Trip();
            IEnumerable<Trip> list = new List<Trip>();
            list = (from p in xElement.Elements()
                    select new Trip()
                    {
                        id = Int32.Parse(p.Element("id").Value),
                        inStation = Int32.Parse(p.Element("inStation").Value),
                        userName = p.Element("userName").Value,
                        lineId = Int32.Parse(p.Element("lineId").Value),
                        inAt = TimeSpan.Parse(p.Element("inAt").Value), // time span convert
                        outStation = Int32.Parse(p.Element("outStation").Value),
                        outAt = TimeSpan.Parse(p.Element("outAt").Value),

                    }
                   ).ToList();
            return list;
        }
        public void createTrip(Trip trip)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(tripPath);
            XElement element = (from per in xElement.Elements()
                                where int.Parse(per.Element("id").Value) == trip.id
                                select per).FirstOrDefault();
            if (element == null)
                throw new Exception("Duplicate trip id");

            XElement p = new XElement("Trip",
                new XElement("id", trip.id.ToString()),
                new XElement("inStation", trip.inStation.ToString()),
                new XElement("userName", trip.userName),
                new XElement("lineId", trip.lineId.ToString()),
                new XElement("inAt", trip.inAt.ToString()),
                new XElement("outStation", trip.outStation.ToString()),
                new XElement("outAt", trip.outAt.ToString())

                );
            xElement.Add(p);
            XMLTools.SaveListToXMLElement(xElement, tripPath);
            //DataSourceXml.Trip.Add(p);
            //DataSourceXml.Trip.Save(DataSourceXml.tripPath);
        }
        public void updateTrip(Trip trip)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(tripPath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("id").Value) == trip.id
                                   select per).FirstOrDefault();
            if (tmpelement == null)
                throw new ObjectNotFoundException("Trip");

            tmpelement.Element("id").Value = trip.id.ToString();
            tmpelement.Element("inStation").Value = trip.inStation.ToString();
            tmpelement.Element("userName").Value = trip.userName.ToString();
            tmpelement.Element("lineId").Value = trip.lineId.ToString();
            tmpelement.Element("inAt").Value = trip.inAt.ToString();
            tmpelement.Element("outStation").Value = trip.outStation.ToString();
            tmpelement.Element("outAt").Value = trip.outAt.ToString();


            XMLTools.SaveListToXMLElement(tmpelement, tripPath);
            //DataSourceXml.Trip.Save(DataSourceXml.tripPath);
        }
        public void deleteTrip(Trip trip)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(tripPath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("id").Value) == trip.id

                                   select per).FirstOrDefault();
            if (tmpelement == null)
                throw new Exception("this trip does not exist, cannot remove it");


            tmpelement.Remove();
            XMLTools.SaveListToXMLElement(xElement, tripPath);
            //DataSourceXml.Trip.Save(DataSourceXml.tripPath);
        }
        public IEnumerable<Trip> getAllTripBy(Predicate<Trip> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(tripPath);
                //DataSourceXml.Load_Trip();
                return from p in xElement.Elements()
                       let y = new Trip()
                       {
                           id = Int32.Parse(p.Element("id").Value),
                           inStation = Int32.Parse(p.Element("inStation").Value),
                           userName = p.Element("userName").Value,
                           lineId = Int32.Parse(p.Element("lineId").Value),
                           inAt = TimeSpan.Parse(p.Element("inAt").Value), // time span convert
                           outStation = Int32.Parse(p.Element("outStation").Value),
                           outAt = TimeSpan.Parse(p.Element("outAt").Value),
                       }
                       where predicate(y)
                       select y;
            }

            return getAllTrip();
        }



        public Trip getTripBy(Predicate<Trip> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(tripPath);
                //DataSourceXml.Load_Trip();
                IEnumerable<Trip> help = from p in xElement.Elements()
                                         let y = new Trip()
                                         {
                                             id = Int32.Parse(p.Element("id").Value),
                                             inStation = Int32.Parse(p.Element("inStation").Value),
                                             userName = p.Element("userName").Value,
                                             lineId = Int32.Parse(p.Element("lineId").Value),
                                             inAt = TimeSpan.Parse(p.Element("inAt").Value), // time span convert
                                             outStation = Int32.Parse(p.Element("outStation").Value),
                                             outAt = TimeSpan.Parse(p.Element("outAt").Value),
                                         }
                                         where predicate(y)
                                         select y;

                return help.FirstOrDefault();
            }
            else
                throw new Exception("The Trip was not found");
        }
        #endregion

        #region Line
        public bool isExistLine(int id)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(linePath);
            XElement element = (from p in xElement.Elements()
                                where int.Parse(p.Element("Id").Value) == id
                                select p).FirstOrDefault();
            return element != null;
        }
        public Line getLine(int id)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(linePath);
            XElement tempElement = (from p in xElement.Elements()
                                    where int.Parse(p.Element("Id").Value) == id
                                    select p).FirstOrDefault();
            if (tempElement == null)
                throw new Exception("Duplicate Line ID");

            return new Line()
            {

                Id = Int32.Parse(tempElement.Element("Id").Value),
                busLineNumber = Int32.Parse(tempElement.Element("busLineNumber").Value),
                FirstStation = Int32.Parse(tempElement.Element("FirstStation").Value),
                LastStation = Int32.Parse(tempElement.Element("LastStation").Value),
                Areas = (Area)Int32.Parse(tempElement.Element("Areas").Value)

            };
        }
        public IEnumerable<Line> getAllLine()
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(linePath);
            //DataSourceXml.Load_Line();
            IEnumerable<Line> list = new List<Line>();
          
            list = (from p in xElement.Elements()
                    select new Line()
                    {
                        Id = Int32.Parse(p.Element("Id").Value),
                        busLineNumber = Int32.Parse(p.Element("busLineNumber").Value),
                         //= p.Element("Areas").Value, //a voir rapidemment parce que beug
                        FirstStation = Int32.Parse(p.Element("FirstStation").Value),
                        LastStation = Int32.Parse(p.Element("LastStation").Value),
                        //a voir rapidemment parce que beug
                        
                    }
                   ).ToList();
            return list;
        }
        public void createLine(Line line)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(linePath);

            XElement element = (from per in xElement.Elements()
                                where int.Parse(per.Element("Id").Value) == line.Id
                                select per).FirstOrDefault();
            if (element != null)
            {
                throw new Exception(" already exist");
            }

            XElement p = new XElement("Line",
                new XElement("Id", line.Id.ToString()),
                new XElement("busLineNumber", line.busLineNumber.ToString()),
                new XElement("Areas", ((Int32)(line.Areas)).ToString()),
                new XElement("FirstStation", line.FirstStation.ToString()),
                new XElement("LastStation", line.LastStation.ToString())

                );

            xElement.Add(p);
            XMLTools.SaveListToXMLElement(xElement, linePath);
            
        }
        public void updateLine(Line line)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(linePath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("Id").Value) == line.Id
                                   select per).FirstOrDefault();
            if (tmpelement == null)
                throw new ObjectNotFoundException("Line");

            tmpelement.Element("Id").Value = line.Id.ToString();
            tmpelement.Element("LastStation").Value = line.LastStation.ToString();
            tmpelement.Element("busLineNumber").Value = line.busLineNumber.ToString();
            tmpelement.Element("Areas").Value = line.Areas.ToString();
            tmpelement.Element("FirstStation").Value = line.FirstStation.ToString();

            XMLTools.SaveListToXMLElement(tmpelement, linePath);
            //DataSourceXml.Line.Save(DataSourceXml.linePath);
        }
        public void deleteLine(Line line)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(linePath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("Id").Value) == line.Id

                                   select per).FirstOrDefault();
            if (tmpelement == null)
                throw new Exception("this line does not exist, cannot remove it");


            tmpelement.Remove();
            XMLTools.SaveListToXMLElement(xElement, linePath);

            
        }


        public IEnumerable<Line> getAllLineBy(Predicate<Line> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(linePath);
                //DataSourceXml.Load_Line();
                return from p in xElement.Elements()
                       let y = new Line()
                       {
                           Id = Int32.Parse(p.Element("Id").Value),
                           busLineNumber = Int32.Parse(p.Element("busLineNumber").Value),
                           FirstStation = Int32.Parse(p.Element("FirstStation").Value),
                           LastStation = Int32.Parse(p.Element("LastStation").Value),
                           Areas = (Area)Int32.Parse(p.Element("Areas").Value)
                       }
                       where predicate(y)
                       select y;
            }

            return getAllLine();
        }

        public Line getLineBy(Predicate<Line> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(linePath);
                //DataSourceXml.Load_Line();
                IEnumerable<Line> help = from p in xElement.Elements()
                                         let y = new Line()
                                         {
                                             Id = Int32.Parse(p.Element("Id").Value),
                                             busLineNumber = Int32.Parse(p.Element("busLineNumber").Value),
                                             FirstStation = Int32.Parse(p.Element("FirstStation").Value),
                                             LastStation = Int32.Parse(p.Element("LastStation").Value),
                                             //Areas = (Area)Int32.Parse(p.Element("Areas").Value)
                                         }
                                         where predicate(y)
                                         select y;

                return help.FirstOrDefault();
            }
            else
                throw new Exception("The Line was not found");
        }

        #endregion

        #region Line Trip
        public bool isExistLineTrip(int id)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(lineTripPath);
            XElement element = (from p in xElement.Elements()
                                where int.Parse(p.Element("Id").Value) == id
                                select p).FirstOrDefault();
            return element != null;
        }
        public LineTrip getLineTrip(int id)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(lineTripPath);
            XElement tempElement = (from p in xElement.Elements()
                                    where int.Parse(p.Element("Id").Value) == id
                                    select p).FirstOrDefault();
            if (tempElement == null)
                throw new Exception("Duplicate bus ID");

            return new LineTrip()
            {
                Id = Int32.Parse(tempElement.Element("Id").Value),
                LineId = Int32.Parse(tempElement.Element("LineId").Value),
                StartAt = TimeSpan.Parse(tempElement.Element("StartAt").Value),
                Frequency = TimeSpan.Parse(tempElement.Element("Frequency").Value),
                FinishAt = TimeSpan.Parse(tempElement.Element("FinishAt").Value)
            };
        }
        public IEnumerable<LineTrip> getAllLineTrip()
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(lineTripPath);
            //DataSourceXml.Load_LineTrip();

            IEnumerable<LineTrip> list = new List<LineTrip>();
            list = (from p in xElement.Elements()
                    select new LineTrip()
                    {
                        Id = Int32.Parse(p.Element("Id").Value),
                        LineId = Int32.Parse(p.Element("LineId").Value),
                        StartAt = TimeSpan.Parse(p.Element("StartAt").Value),
                        Frequency = TimeSpan.Parse(p.Element("Frequency").Value),
                        FinishAt = TimeSpan.Parse(p.Element("FinishAt").Value)

                    }
                   ).ToList();
            return list;
        }
        public void createLineTrip(LineTrip lineTrip)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(lineTripPath);
            XElement element = (from per in xElement.Elements()
                                where int.Parse(per.Element("Id").Value) == lineTrip.Id
                                select per).FirstOrDefault();
            if (element == null)
                throw new Exception("Duplicate Line trip ");

            XElement p = new XElement("LineTrip",
                new XElement("Id", lineTrip.Id.ToString()),
                new XElement("LineId", lineTrip.LineId.ToString()),
                new XElement("StartAt", lineTrip.StartAt.ToString()),
                new XElement("Frequency", lineTrip.Frequency.ToString()),
                new XElement("FinishAt", lineTrip.FinishAt.ToString())

                );

            xElement.Add(p);
            XMLTools.SaveListToXMLElement(xElement, lineTripPath);
            //DataSourceXml.LineTrip.Add(p);
            //DataSourceXml.LineTrip.Save(DataSourceXml.lineTripPath);
        }
        public void updateLineTrip(LineTrip lineTrip)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(lineTripPath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("Id").Value) == lineTrip.Id
                                   select per).FirstOrDefault();
            if (tmpelement == null)
                throw new ObjectNotFoundException("Line Trip");

            tmpelement.Element("Id").Value = lineTrip.Id.ToString();
            tmpelement.Element("LineId").Value = lineTrip.LineId.ToString();
            tmpelement.Element("StartAt").Value = lineTrip.StartAt.ToString();
            tmpelement.Element("Frequency").Value = lineTrip.Frequency.ToString();
            tmpelement.Element("FinishAt").Value = lineTrip.FinishAt.ToString();


            XMLTools.SaveListToXMLElement(tmpelement, lineTripPath);
            //DataSourceXml.LineTrip.Save(DataSourceXml.lineTripPath);

        }
        public void deleteLineTrip(LineTrip lineTrip)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(lineTripPath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("Id").Value) == lineTrip.Id
                                   select per).FirstOrDefault();

            if (tmpelement == null)
                throw new Exception("this Line Trip does not exist, cannot remove it");

            tmpelement.Remove();
            XMLTools.SaveListToXMLElement(xElement, lineTripPath);
            //DataSourceXml.LineTrip.Save(DataSourceXml.lineTripPath);
        }
        public LineTrip getLineTripBy(Predicate<LineTrip> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(lineTripPath);
                //DataSourceXml.Load_LineTrip();
                IEnumerable<LineTrip> help = from p in xElement.Elements()
                                             let y = new LineTrip()
                                             {
                                                 Id = Int32.Parse(p.Element("Id").Value),
                                                 LineId = Int32.Parse(p.Element("LineId").Value),
                                                 StartAt = TimeSpan.Parse(p.Element("StartAt").Value),
                                                 Frequency = TimeSpan.Parse(p.Element("Frequency").Value),
                                                 FinishAt = TimeSpan.Parse(p.Element("FinishAt").Value)
                                             }
                                             where predicate(y)
                                             select y;

                return help.FirstOrDefault();
            }
            else
                throw new Exception("The Line Trip was not found");
        }


        public IEnumerable<LineTrip> getAllLineTripBy(Predicate<LineTrip> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(lineTripPath);
                return from p in xElement.Elements()
                       let y = new LineTrip()
                       {
                           Id = Int32.Parse(p.Element("Id").Value),
                           LineId = Int32.Parse(p.Element("LineId").Value),
                           StartAt = TimeSpan.Parse(p.Element("StartAt").Value),
                           Frequency = TimeSpan.Parse(p.Element("Frequency").Value),
                           FinishAt = TimeSpan.Parse(p.Element("FinishAt").Value)
                       }
                       where predicate(y)
                       select y;
            }

            return getAllLineTrip();
        }
        #endregion

        #region Line Station 
        public bool isExistLineStation(int lineId)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(lineStationPath);
            XElement element = (from p in xElement.Elements()
                                where int.Parse(p.Element("LineId").Value) == lineId
                                select p).FirstOrDefault();
            return element != null;
        }
        public LineStation getLineStation(int lineId)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(lineStationPath);
            XElement tempElement = (from p in xElement.Elements()
                                    where int.Parse(p.Element("LineId").Value) == lineId
                                    select p).FirstOrDefault();
            if (tempElement == null)
                throw new Exception("Duplicate Line Station ID");

            return new LineStation()
            {
                LineStationIndex = (tempElement.Element("LineStationIndex").Value),
                LineId = Int32.Parse(tempElement.Element("LineId").Value),
                NextStation = Int32.Parse(tempElement.Element("NextStation").Value),
                PrevStation = Int32.Parse(tempElement.Element("PrevStation").Value),
                Station = Int32.Parse(tempElement.Element("Station").Value)
            };
        }
        public IEnumerable<LineStation> getAllLineStation()
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(lineStationPath);
            IEnumerable<LineStation> list = new List<LineStation>();
            list = (from p in xElement.Elements()
                    select new LineStation()
                    {

                        LineStationIndex = (p.Element("LineStationIndex").Value),
                        LineId = Int32.Parse(p.Element("LineId").Value),
                        Station = Int32.Parse(p.Element("Station").Value),
                        PrevStation = Int32.Parse(p.Element("PrevStation").Value),
                        NextStation = Int32.Parse(p.Element("NextStation").Value),
                        
                    }
                   ).ToList();
            return list;
        }
        public void createLineStation(LineStation lineStation)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(lineStationPath);

            XElement element = (from per in xElement.Elements()
                                where int.Parse(per.Element("LineId").Value) == lineStation.LineId
                                select per).FirstOrDefault();

            Random r = new Random();
            lineStation.ID = r.Next(0, 1000);
            XElement p = new XElement("LineStation",
                new XElement("LineId", lineStation.LineId.ToString()),
                new XElement("Station", lineStation.Station.ToString()),
                new XElement("LineStationIndex", lineStation.LineStationIndex),
                new XElement("PrevStation", lineStation.PrevStation.ToString()),
                new XElement("NextStation", lineStation.NextStation.ToString()),
                new XElement("ID", lineStation.ID.ToString())

                );
            xElement.Add(p);
            XMLTools.SaveListToXMLElement(xElement, lineStationPath);

        }
        public void updateLineStation(LineStation linestation)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(lineStationPath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("LineId").Value) == linestation.LineId
                                   select per).FirstOrDefault();
            if (tmpelement == null)
                throw new ObjectNotFoundException("Line Station");

            tmpelement.Element("LineId").Value = linestation.LineId.ToString();
            tmpelement.Element("Station").Value = linestation.Station.ToString();
            tmpelement.Element("LineStationIndex").Value = linestation.LineStationIndex.ToString();
            tmpelement.Element("PrevStation").Value = linestation.PrevStation.ToString();
            tmpelement.Element("NextStation").Value = linestation.NextStation.ToString();

            XMLTools.SaveListToXMLElement(tmpelement, lineStationPath);
            
        }
        public void deleteLineStation(LineStation linestation)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(lineStationPath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where
   int.Parse(per.Element("LineId").Value) == linestation.LineId
   
                                   select per).FirstOrDefault();

            if (tmpelement == null)
                throw new Exception("this LineStation does not exist, cannot remove it");

            tmpelement.Remove();
            XMLTools.SaveListToXMLElement(xElement, lineStationPath);
           
        }
        public LineStation getLineStationBy(Predicate<LineStation> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(lineStationPath);
                IEnumerable<LineStation> help = from p in xElement.Elements()
                                                let y = new LineStation()
                                                {
                                                    LineStationIndex = (p.Element("LineStationIndex").Value),
                                                    LineId = Int32.Parse(p.Element("LineId").Value),
                                                    NextStation = Int32.Parse(p.Element("NextStation").Value),
                                                    PrevStation = Int32.Parse(p.Element("PrevStation").Value),
                                                    Station = Int32.Parse(p.Element("Station").Value)
                                                }
                                                where predicate(y)
                                                select y;

                return help.FirstOrDefault();
            }
            else
                throw new Exception("The Line Station was not found");
        }

        public IEnumerable<LineStation> getAllLineStationBy(Predicate<LineStation> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(lineStationPath);
                //DataSourceXml.Load_LineStation();
                return from p in xElement.Elements()
                       let y = new LineStation()
                       {
                           LineStationIndex = (p.Element("LineStationIndex").Value),
                           LineId = Int32.Parse(p.Element("LineId").Value),
                           NextStation = Int32.Parse(p.Element("NextStation").Value),
                           PrevStation = Int32.Parse(p.Element("PrevStation").Value),
                           Station = Int32.Parse(p.Element("Station").Value)
                       }
                       where predicate(y)
                       select y;
            }

            return getAllLineStation();
        }
        #endregion

        #region Bus on trip
        public bool isExistBusOnTrip(int id)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(busOnTripPath);
            XElement element = (from p in xElement.Elements()
                                where int.Parse(p.Element("id").Value) == id
                                select p).FirstOrDefault();
            return element != null;
        }
        public BusOnTrip getBusOnTrip(int id)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(busOnTripPath);
            XElement tempElement = (from p in xElement.Elements()
                                    where int.Parse(p.Element("id").Value) == id
                                    select p).FirstOrDefault();
            if (tempElement == null)
                throw new Exception("Duplicate Bus On Trip ID");

            return new BusOnTrip()
            {
                id = Int32.Parse(tempElement.Element("id").Value),
                licenseNum = Int32.Parse(tempElement.Element("licenseNum").Value),
                lineId = Int32.Parse(tempElement.Element("lineId").Value),
                plannedTakeOff = TimeSpan.Parse(tempElement.Element("plannedTakeOff").Value),
                actualTakeOff = TimeSpan.Parse(tempElement.Element("actualTakeOff").Value),
                prevStation = Int32.Parse(tempElement.Element("prevStation").Value),
                prevStationAt = TimeSpan.Parse(tempElement.Element("prevStationAt").Value),
                nextStationAt = TimeSpan.Parse(tempElement.Element("nextStationAt").Value)
            };

        }
        public IEnumerable<BusOnTrip> getAllBusOnTrip()
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(busOnTripPath);

            //DataSourceXml.Load_BusOnTrip();
            IEnumerable<BusOnTrip> list = new List<BusOnTrip>();
            list = (from p in xElement.Elements()
                    select new BusOnTrip()
                    {
                        id = Int32.Parse(p.Element("id").Value),
                        licenseNum = Int32.Parse(p.Element("licenseNum").Value),
                        lineId = Int32.Parse(p.Element("lineId").Value),
                        plannedTakeOff = TimeSpan.Parse(p.Element("plannedTakeOff").Value),
                        actualTakeOff = TimeSpan.Parse(p.Element("actualTakeOff").Value),
                        prevStation = Int32.Parse(p.Element("prevStation").Value),
                        prevStationAt = TimeSpan.Parse(p.Element("prevStationAt").Value),
                        nextStationAt = TimeSpan.Parse(p.Element("nextStationAt").Value)

                    }
                   ).ToList();
            return list;


        }
        public void createBusOnTrip(BusOnTrip busOnTrip)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(busOnTripPath);

            XElement tempElement = (from a in xElement.Elements()
                                    where int.Parse(a.Element("id").Value) == busOnTrip.id
                                    select a).FirstOrDefault();

            XElement p = new XElement("BusOnTrip",
                new XElement("licenseNum", busOnTrip.licenseNum.ToString()),
                new XElement("lineId", busOnTrip.lineId.ToString()),
                new XElement("nextStationAt", busOnTrip.nextStationAt.ToString()),
                new XElement("plannedTakeOff", busOnTrip.plannedTakeOff.ToString()),
                new XElement("prevStationAt", busOnTrip.prevStationAt.ToString()),
                new XElement("prevStation", busOnTrip.prevStation.ToString()),
                new XElement("actualTakeOff", busOnTrip.actualTakeOff.ToString()),
                new XElement("id", busOnTrip.id.ToString())

                 );
            xElement.Add(p);
            XMLTools.SaveListToXMLElement(xElement, busOnTripPath);

            //DataSourceXml.BusOnTrip.Add(p);
            //DataSourceXml.BusOnTrip.Save(DataSourceXml.busOnTripPath);
        }
        public void updateBusOnTrip(BusOnTrip busOnTrip)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(busOnTripPath);

            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("id").Value) == busOnTrip.id
                                   select per).FirstOrDefault();
            if (tmpelement == null)
                throw new ObjectNotFoundException("Bus On Trip");

            tmpelement.Element("licenseNum").Value = busOnTrip.licenseNum.ToString();
            tmpelement.Element("lineId").Value = busOnTrip.lineId.ToString();
            tmpelement.Element("nextStationAt").Value = busOnTrip.nextStationAt.ToString();
            tmpelement.Element("plannedTakeOff").Value = busOnTrip.plannedTakeOff.ToString();
            tmpelement.Element("prevStation").Value = busOnTrip.prevStation.ToString();
            tmpelement.Element("prevStationAt").Value = busOnTrip.prevStationAt.ToString();
            //tmpelement.Element("id").Value = busOnTrip.id.ToString();
            XMLTools.SaveListToXMLElement(tmpelement, busOnTripPath);
            //DataSourceXml.BusOnTrip.Save(DataSourceXml.busOnTripPath);
        }
        public void deleteBusOnTrip(BusOnTrip busOnTrip)
        {
            XElement xElement = XMLTools.LoadListFromXMLElement(busOnTripPath);
            XElement tmpelement = (from per in xElement.Elements()
                                   where int.Parse(per.Element("id").Value) == busOnTrip.id
                                   select per).FirstOrDefault();

            if (tmpelement == null)
                throw new Exception("this Bus On Trip does not exist, cannot remove it");

            tmpelement.Remove();
            XMLTools.SaveListToXMLElement(xElement, busOnTripPath);
            //DataSourceXml.BusOnTrip.Save(DataSourceXml.busOnTripPath);
        }
        public BusOnTrip getBusOnTripBy(Predicate<BusOnTrip> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(busOnTripPath);

                //DataSourceXml.Load_BusOnTrip();
                IEnumerable<BusOnTrip> help = from p in xElement.Elements()
                                              let y = new BusOnTrip()
                                              {
                                                  id = Int32.Parse(p.Element("id").Value),
                                                  licenseNum = Int32.Parse(p.Element("licenseNum").Value),
                                                  lineId = Int32.Parse(p.Element("lineId").Value),
                                                  plannedTakeOff = TimeSpan.Parse(p.Element("plannedTakeOff").Value),
                                                  actualTakeOff = TimeSpan.Parse(p.Element("actualTakeOff").Value),
                                                  prevStation = Int32.Parse(p.Element("prevStation").Value),
                                                  prevStationAt = TimeSpan.Parse(p.Element("prevStationAt").Value),
                                                  nextStationAt = TimeSpan.Parse(p.Element("nextStationAt").Value)
                                              }
                                              where predicate(y)
                                              select y;

                return help.FirstOrDefault();
            }
            else
                throw new Exception("The Bus On Trip was not found");
        }

        public IEnumerable<BusOnTrip> getAllBusOnTripBy(Predicate<BusOnTrip> predicate)
        {
            if (predicate != null)
            {
                XElement xElement = XMLTools.LoadListFromXMLElement(busOnTripPath);

                //DataSourceXml.Load_BusOnTrip();
                return from p in xElement.Elements()
                       let y = new BusOnTrip()
                       {
                           id = Int32.Parse(p.Element("id").Value),
                           licenseNum = Int32.Parse(p.Element("licenseNum").Value),
                           lineId = Int32.Parse(p.Element("lineId").Value),
                           plannedTakeOff = TimeSpan.Parse(p.Element("plannedTakeOff").Value),
                           actualTakeOff = TimeSpan.Parse(p.Element("actualTakeOff").Value),
                           prevStation = Int32.Parse(p.Element("prevStation").Value),
                           prevStationAt = TimeSpan.Parse(p.Element("prevStationAt").Value),
                           nextStationAt = TimeSpan.Parse(p.Element("nextStationAt").Value)
                       }
                       where predicate(y)
                       select y;
            }

            return getAllBusOnTrip();

        }
        #endregion

    }
}
