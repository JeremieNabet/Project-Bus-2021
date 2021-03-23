using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using DS;
using DALAPI;
using DataSourceXml;


namespace DalObject
{
    public sealed class DalObject : IDal
    {
        #region singelton
        static readonly DalObject instance = new DalObject();
        static DalObject()// static ctor to ensure instance init is done just before first usage
        {
        }
        DalObject() // default => private
        {
        } 
        public static DalObject Instance { get => instance; }// The public Instance property to use
        #endregion

        #region Bus

        public DO.Bus getBus(int licenseNumber)
        {

            var stock = DataSource.busList.Exists(x => (x.LicenseNum == licenseNumber));
            DO.Bus item = DataSource.busList.FirstOrDefault(x => (x.LicenseNum == licenseNumber));
            if (stock)
            {
                DO.Bus guibouy_bus = new DO.Bus()
                {
                    LicenseNum = item.LicenseNum,
                    BusStatus = item.BusStatus,
                    FromDate = item.FromDate,
                    FuelRemain = item.FuelRemain,
                    TotalTrip = item.TotalTrip
                };

                return guibouy_bus;
            }
            else { throw new Exception("None of bus was found"); }

        }
        public IEnumerable<DO.Bus> getAllBus()
        {
            List<Bus> toReturn = new List<Bus>();
            foreach (Bus b in DataSource.busList)
                toReturn.Add(b);
            return toReturn;
        }
        public void createBus(DO.Bus bus)
        {
            var stock = DataSource.busList.Exists(x => (x.LicenseNum == bus.LicenseNum));

            if (stock == false)
            {
                DataSource.busList.Add(bus);
            
            }
            else { throw new DLException("This bus already exist"); }
        }

        public void updateBus(DO.Bus bus)
        {
            var stock = DataSource.busList.Exists(x => (x.LicenseNum == bus.LicenseNum));
            DO.Bus item = DataSource.busList.FirstOrDefault(x => (x.LicenseNum == bus.LicenseNum));
            if (stock)
            {
                item.LicenseNum = bus.LicenseNum; 
                item.BusStatus = bus.BusStatus;
                item.FromDate = bus.FromDate;
                item.FuelRemain = bus.FuelRemain;
                item.TotalTrip = bus.TotalTrip;

                //xml.updateBus(bus);
            }
            else { throw new Exception("None bus wasnt found so cannot update it"); }
        }

        public void deleteBus(DO.Bus bus) 
        {
            var stock = DataSource.busList.Exists(x => (x.LicenseNum == bus.LicenseNum)); // is exist
            if (stock)
            {
                foreach (var item in DataSource.busList)
                {
                    if (item.LicenseNum == bus.LicenseNum)
                    {
                        DataSource.busList.Remove(item);
                        //xml.deleteBus(bus);

                        break;
                    }
                }


            }
            else { throw new Exception("This bus dosnt exists, cannot delete it"); }
            
        }

        public bool isExistBus(int licenseNumber)
        {
            return DataSource.busList.Exists(x => (x.LicenseNum == licenseNumber));
        }


        #endregion Bus 

        #region User
        public DO.User getUser(string username)
        {
            var stock = DataSource.userList.Exists(x => (x.userName == username));
            DO.User item = DataSource.userList.FirstOrDefault(x => (x.userName == username));
            if (stock)
            {
                DO.User guibouy_user = new DO.User()
                {
                    userName = item.userName,
                    password = item.password,
                    admin = item.admin

                };

                return guibouy_user;
            }
            else { throw new Exception("None of user was found"); }
        }
        public IEnumerable<DO.User> getAllUser()
        {
            var users = from User in DataSource.userList
                        select User.Clone<DO.User>();


            return users;
        }
        public void createUser(DO.User user)
        {
            var stock = DataSource.userList.Exists(x => (x.userName == user.userName));

            if (stock == false)
            {
                user.admin = true;
                DataSource.userList.Add(user);
               
            }
            else { throw new Exception("This user already exist"); }
        }
        public void updateUser(DO.User user)
        {
            var stock = DataSource.userList.Exists(x => (x.userName == user.userName));
            DO.User item = DataSource.userList.FirstOrDefault(x => (x.userName == user.userName));
            if (stock)
            {
                item.userName = user.userName;
                item.password = user.password;
                item.admin = user.admin;
               
            }
            else { throw new Exception("None user wasnt found so cannot update it"); }
        }
        public void deleteUser(DO.User user)
        {
            var stock = DataSource.userList.Exists(x => (x.userName == user.userName));
            if (stock)
            {
                DataSource.userList.Remove(user);
              

            }
            else { throw new Exception("This user dosnt exists, cannot delete it"); }
        }
        public bool isExistUser(string username)
        {
            return DataSource.userList.Exists(x => (x.userName == username));
        }
        
        #endregion User

        #region Station
        public bool isExistStation(int code)
        {
            return DataSource.stationList.Exists(x => (x.code== code));
        }
        public DO.Station getStation(int code)
        {
            var stock = DataSource.stationList.Exists(x => (x.code == code));
            DO.Station item = DataSource.stationList.FirstOrDefault(x => (x.code == code));
            if (stock)
            {
                DO.Station guibouy_station = new Station()
                {
                    code = item.code,
                    name = item.name,
                    handicap = item.handicap,
                    latitude = item.latitude,
                    longitude = item.longitude


                };

                return guibouy_station;
            }
            else { throw new Exception("None of station was found"); }
        }
        public IEnumerable<Station> getAllStation()
        {
            var station = from Station in DataSource.stationList
                          select Station.Clone();
            return station;
        }
        public void createStation(Station station)
        {
            var stock = DataSource.stationList.Exists(x => (x.code == station.code));

            if (stock == false)
            {
                
                DataSource.stationList.Add(station);
                //xml.createStation(station);
            }
            else { throw new DLException("This station is already exist"); }
        }
        public void updateStation(Station station)
        {
            var stock = DataSource.stationList.Exists(x => (x.code == station.code));
            Station item = DataSource.stationList.FirstOrDefault(x => (x.code == station.code));
            if (stock)
            {
                item.code = station.code;
                item.handicap = station.handicap;
                item.latitude = station.latitude;
                item.longitude = station.longitude;
                item.name = station.name;

                //xml.updateStation(station);
            }
            else { throw new DLException("None user wasnt found so cannot update it"); }
        }
        public void deleteStation(Station station)
        {
            var stock = DataSource.stationList.Exists(x => (x.code == station.code));
            if (stock)
            {
                DataSource.stationList.RemoveAll(item => item.code == station.code);
                DataSource.lineStationList.RemoveAll(item => item.Station == station.code);
            }
            else { throw new DLException("This station dosnt exists, cannot delete it"); }
        }
        
        #endregion Station

        #region Adjacent Stations
        public bool isExistAdjacentStations(int id)
        {
            return DataSource.adjacentStationsList.Exists(x => (x.Id == id));
        }
        public AdjacentStations getAdjacentStation(int Id)
        {
            var stock = DataSource.adjacentStationsList.Exists(x => x.Id == Id); // Id rajouter 
            AdjacentStations item = DataSource.adjacentStationsList.FirstOrDefault(x => x.Id == Id);
            if (stock)
            {
                AdjacentStations guibouy_adjacentStations = new AdjacentStations()
                {
                    Distance = item.Distance,
                    Station1 = item.Station1,
                    Station2 = item.Station2,
                    Time = item.Time

                };

                return guibouy_adjacentStations;
            }
            else { throw new DLException("None of Adjacent Stations was found"); }
        }
        public IEnumerable<AdjacentStations> getAllAdjacentStations()
        {
           
            return DataSource.adjacentStationsList;
        }
        public void createAdjacentStations(AdjacentStations adjacentStations)
        {
            bool stock = DataSource.adjacentStationsList.Exists(x => x.Id==adjacentStations.Id); // a revoir
            Random r = new Random();
            adjacentStations.Id = r.Next(0, 10000);
            if (stock == false)
            {
                DataSource.adjacentStationsList.Add(adjacentStations);
             
            }
            else { throw new DLException("This adjacent stations is already exist"); }
        }
        public void updateAdjacentStations(AdjacentStations adjacentStations)
        {
            bool stock = DataSource.adjacentStationsList.Exists(x => (x.Station1 == adjacentStations.Station1));
            if (stock)
            {
                int index = DataSource.adjacentStationsList.FindIndex(item => item.Id == adjacentStations.Id);
                DataSource.adjacentStationsList[index].Time = adjacentStations.Time;
                DataSource.adjacentStationsList[index].Distance = adjacentStations.Distance;

                //xml.updateAdjacentStations(item);
            }
            else { throw new Exception("None adjacent stations wasnt found so cannot update it"); }
        }
        public void deleteAdjacentStations(AdjacentStations adjacentStations)
        {
            var stock = DataSource.adjacentStationsList.Exists(x => (x.Station1 == adjacentStations.Station1) && (x.Station2 == adjacentStations.Station2));
            if (stock)
            {
                DataSource.adjacentStationsList.Remove(adjacentStations);
                //xml.deleteAdjacentStations(adjacentStations);

            }
            else { throw new Exception("This adjacent stations dosnt exists, cannot delete it"); }
        }
        
        #endregion

        #region Trip
        public bool isExistTrip(int Id)
        {
            return DataSource.tripList.Exists(x => (x.id == Id));
        }
        public Trip getTrip(int Id)
        {
            var stock = DataSource.tripList.Exists(x => (x.id == Id));
            Trip item = DataSource.tripList.FirstOrDefault(x => (x.id == Id));
            if (stock)
            {
                Trip guibouy_trip = new Trip()
                {
                    id = item.id,
                    inAt = item.inAt,
                    inStation = item.inStation,
                    lineId = item.lineId,
                    outAt = item.outAt,
                    outStation = item.outStation,
                    userName = item.userName
                };

                return guibouy_trip;
            }
            else { throw new Exception("None of trip was found"); }
        }
        public IEnumerable<Trip> getAllTrip()
        {
            var trip = from Trip in DataSource.tripList
                       select Trip.Clone();
            return trip;

        }
        public void createTrip(Trip trip)
        {
            var stock = DataSource.tripList.Exists(x => (x.id == trip.id)); // a revoir

            if (stock == false)
            {
                DataSource.tripList.Add(trip); 
                //xml.createTrip(trip);
            }
            else { throw new Exception("This trip is already exist"); }
        }
        public void updateTrip(Trip trip)
        {
            var stock = DataSource.tripList.Exists(x => (x.id == trip.id));
            Trip item = DataSource.tripList.FirstOrDefault(x => (x.id == trip.id));
            if (stock)
            {
                item.id = trip.id;
                item.inAt = trip.inAt;
                item.inStation = trip.inStation;
                item.lineId = trip.lineId;
                item.outAt = trip.outAt;
                item.outStation = trip.outStation;
                item.userName = trip.userName;

                //xml.updateTrip(trip);
            }
            else { throw new Exception("None trip wasnt found so cannot update it"); }
        }
        public void deleteTrip(Trip trip)
        {
            var stock = DataSource.tripList.Exists(x => (x.id == trip.id));
            if (stock)
            {
                DataSource.tripList.Remove(trip);
                //xml.deleteTrip(trip);
            }
            else { throw new Exception("This trip dosnt exists, cannot delete it"); }
        }
        
        #endregion

        #region Line
        public bool isExistLine(int Id)
        {
            return DataSource.lineList.Exists(x => (x.Id == Id));
        }
        public Line getLine(int Id)
        {
            var stock = DataSource.lineList.Exists(x => (x.Id == Id));
            Line item = DataSource.lineList.FirstOrDefault(x => (x.Id == Id));
            if (stock)
            {
                Line guibouy_Line = new Line()
                {
                    Id = item.Id,
                    Areas = item.Areas,
                    busLineNumber = item.busLineNumber,
                    FirstStation = item.FirstStation,
                    LastStation = item.LastStation

                };

                return guibouy_Line;
            }
            else { throw new Exception("None of line was found"); }
        }
        public IEnumerable<Line> getAllLine()
        {
            var line = from Line in DataSource.lineList
                       select Line.Clone();
            return line;

        }
        public void createLine(Line line)
        {
            var stock = DataSource.lineList.Exists(x => (x.Id == line.Id));
            int check = line.Id;

            if (stock == false)
            {
                DataSource.lineList.Add(line);
               
            }
            else { throw new Exception("This line is already exist"); }
        }
        public void updateLine(Line line)
        {
            var stock = DataSource.lineList.Exists(x => (x.Id == line.Id));
            Line item = DataSource.lineList.FirstOrDefault(x => (x.Id == line.Id));
            if (stock)
            {
                item.Id = line.Id;
                item.Areas = line.Areas;
                item.busLineNumber = line.busLineNumber;
                item.FirstStation = line.FirstStation;
                item.LastStation = line.LastStation;

                //xml.updateLine(line);
            }
            else { throw new Exception("None line wasn't found so cannot update it"); }
        }
        public void deleteLine(Line line)
        {
             
            bool stock = DataSource.lineList.Exists(x => (x.Id == line.Id));
            if (stock)
            {
                DataSource.lineList.RemoveAll(item => item.Id == line.Id);
                //xml.deleteLine(line);
            }
            else { throw new Exception("This line doesn't exists, cannot delete it"); }
        }
        
        #endregion

        #region Line Trip
        public bool isExistLineTrip(int Id)
        {
            return DataSource.lineTripList.Exists(x => (x.Id == Id));
        }
        public LineTrip getLineTrip(int Id)
        {
            var stock = DataSource.lineTripList.Exists(x => (x.Id == Id));
            LineTrip item = DataSource.lineTripList.FirstOrDefault(x => (x.Id == Id));
            if (stock)
            {
                LineTrip guibouy_lineTrip = new LineTrip()
                {
                    Id = item.Id,
                    FinishAt = item.FinishAt,
                    Frequency = item.Frequency,
                    LineId = item.LineId,
                    StartAt = item.StartAt


                };

                return guibouy_lineTrip;
            }
            else { throw new Exception("None of line was found"); }
        }
        public IEnumerable<LineTrip> getAllLineTrip()
        {
            var lineTrip = from LineTrip in DataSource.lineTripList
                           select LineTrip.Clone();
            return lineTrip;

        }
        public void createLineTrip(LineTrip lineTrip)
        {
            var stock = DataSource.lineTripList.Exists(x => (x.Id == lineTrip.Id)); // a revoir

            if (stock == false)
            {
                DataSource.lineTripList.Add(lineTrip);
                //xml.createLineTrip(lineTrip);
            }
            else { throw new Exception("This line trip is already exist"); }
        }
        public void updateLineTrip(LineTrip lineTrip)
        {
            var stock = DataSource.lineTripList.Exists(x => (x.Id == lineTrip.Id));
            LineTrip item = DataSource.lineTripList.FirstOrDefault(x => (x.Id == lineTrip.Id));
            if (stock)
            {
                item.Id = lineTrip.Id;
                item.FinishAt = lineTrip.FinishAt;
                item.Frequency = lineTrip.Frequency;
                item.LineId = lineTrip.LineId;
                item.StartAt = lineTrip.StartAt;

                //xml.updateLineTrip(lineTrip);
            }
            else { throw new Exception("None line trip wasnt found so cannot update it"); }
        }
        public void deleteLineTrip(LineTrip lineTrip)
        {
            var stock = DataSource.lineTripList.Exists(x => (x.Id == lineTrip.Id));
            if (stock)
            {
                DataSource.lineTripList.Remove(lineTrip);

                //xml.deleteLineTrip(lineTrip);
            }
            else { throw new Exception("This line trip dosnt exists, cannot delete it"); }
        }
        

        #endregion

        #region Line Station
        public bool isExistLineStation(int LineId)
        {
            return DataSource.lineStationList.Exists(x => (x.LineId == LineId));
        }
        public LineStation getLineStation(int Id)
        {
            var stock = DataSource.lineStationList.Exists(x => (x.LineId == Id));
            LineStation item = DataSource.lineStationList.FirstOrDefault(x => (x.LineId == Id));
            if (stock)
            {
                LineStation guibouy_lineStation = new LineStation()
                {
                    ID=item.ID,
                    LineId = item.LineId,
                    LineStationIndex = item.LineStationIndex,
                    NextStation = item.NextStation,
                    PrevStation = item.PrevStation,
                    Station = item.Station
                };

                return guibouy_lineStation;
            }
            else { throw new Exception("None of line station was found"); }
        }
        public IEnumerable<LineStation> getAllLineStation()
        {
            var lineStation = from LineStation in DataSource.lineStationList
                              select LineStation.Clone();
            return lineStation;

        }
        Random r = new Random();

        public void createLineStation(LineStation lineStation)
        {
                lineStation.ID = r.Next(0, 10000);
                DataSource.lineStationList.Add(lineStation);
               
        }
        public void updateLineStation(LineStation lineStation)
        {
            var stock = DataSource.lineStationList.Exists(x => (x.ID == lineStation.ID));
            LineStation item = DataSource.lineStationList.FirstOrDefault(x => (x.ID == lineStation.ID));
            if (stock)
            {
                item.LineId = lineStation.LineId;
                item.LineStationIndex = lineStation.LineStationIndex;
                item.NextStation = lineStation.NextStation;
                item.PrevStation = lineStation.PrevStation;
                item.Station = lineStation.Station;

                //xml.updateLineStation(lineStation);
            }
            else { throw new DLException("None line station wasnt found so cannot update it"); }
        }
        public void deleteLineStation(LineStation lineStation)
        {
            var stock = DataSource.lineStationList.Exists(x => (x.ID == lineStation.ID));
            if (stock)
            {
                DataSource.lineStationList.RemoveAll(item => item.ID == lineStation.ID);
                //xml.updateLineStation(lineStation);
            }
            else { throw new DLException("This line station doesnt exists, cannot delete it"); }
        }
       
        #endregion

        #region Bus on trip
        public bool isExistBusOnTrip(int Id)
        {
            return DataSource.busOnTripList.Exists(x => (x.id == Id));
        }
        public BusOnTrip getBusOnTrip(int Id)
        {
            var stock = DataSource.busOnTripList.Exists(x => (x.id == Id));
            BusOnTrip item = DataSource.busOnTripList.FirstOrDefault(x => (x.id == Id));
            if (stock)
            {
                BusOnTrip guibouy_busOnTrip = new BusOnTrip()
                {
                    lineId = item.lineId,
                    prevStation = item.prevStation,
                    id = item.id,
                    actualTakeOff = item.actualTakeOff,
                    licenseNum = item.licenseNum,
                    nextStationAt = item.nextStationAt,
                    plannedTakeOff = item.plannedTakeOff,
                    prevStationAt = item.prevStationAt

                };

                return guibouy_busOnTrip;
            }
            else { throw new Exception("None of bus on trip was found"); }
        }
        public IEnumerable<BusOnTrip> getAllBusOnTrip()
        {
            var busOnTrip = from BusOnTrip in DataSource.busOnTripList
                            select BusOnTrip.Clone();
            return busOnTrip;
        }
        public void createBusOnTrip(BusOnTrip busOnTrip)
        {
            var stock = DataSource.busOnTripList.Exists(x => (x.id == busOnTrip.id));

            if (stock == false)
            {
                DataSource.busOnTripList.Add(busOnTrip);
                //xml.createBusOnTrip(busOnTrip);
            }
            else { throw new Exception("This bus on trip is already exist"); }
        }
        public void updateBusOnTrip(BusOnTrip busOnTrip)
        {
            var stock = DataSource.busOnTripList.Exists(x => (x.id == busOnTrip.id));
            BusOnTrip item = DataSource.busOnTripList.FirstOrDefault(x => (x.id == busOnTrip.id));
            if (stock)
            {
                item.lineId = busOnTrip.lineId;
                item.prevStationAt = busOnTrip.prevStationAt;
                item.prevStation = busOnTrip.prevStation;
                item.plannedTakeOff = busOnTrip.plannedTakeOff;
                item.nextStationAt = busOnTrip.nextStationAt;
                item.licenseNum = busOnTrip.licenseNum;
                item.id = busOnTrip.id;
                item.actualTakeOff = busOnTrip.actualTakeOff;

                //xml.updateBusOnTrip(busOnTrip);
            }
            else { throw new Exception("None bus on trip wasnt found so cannot update it"); }
        }
        public void deleteBusOnTrip(BusOnTrip busOnTrip)
        {
            var stock = DataSource.busOnTripList.Exists(x => (x.id == busOnTrip.id));
            if (stock)
            {
                DataSource.busOnTripList.Remove(busOnTrip);
                //xml.deleteBusOnTrip(busOnTrip);
            }
            else { throw new Exception("This bus on trip dosnt exists, cannot delete it"); }
        }
        

        #endregion

    

       


        public IEnumerable<User> getAllUserBy(Predicate<User> predicate)
        {
            throw new NotImplementedException();
        }

       

       



  

        






        public IEnumerable<Trip> getAllTripBy(Predicate<Trip> predicate)
        {
            throw new NotImplementedException();
        }

        public Trip getTripBy(Predicate<Trip> predicate)
        {
            throw new NotImplementedException();
        }

        




        public IEnumerable<Line> getAllLineBy(Predicate<Line> predicate)
        {
            throw new NotImplementedException();
        }

        public Line getLineBy(Predicate<Line> predicate)
        {
            throw new NotImplementedException();
        }

       




        public LineTrip getLineTripBy(Predicate<LineTrip> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineTrip> getAllLineTripBy(Predicate<LineTrip> predicate)
        {
            throw new NotImplementedException();
        }

       




        public LineStation getLineStationBy(Predicate<LineStation> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> getAllLineStationBy(Predicate<LineStation> predicate)
        {
            throw new NotImplementedException();
        }

       





        public BusOnTrip getBusOnTripBy(Predicate<BusOnTrip> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusOnTrip> getAllBusOnTripBy(Predicate<BusOnTrip> predicate)
        {
            throw new NotImplementedException();
        }

        public void InitAllLists()
        {
            throw new NotImplementedException();
        }
    }
}

