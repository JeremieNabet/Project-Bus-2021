using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DALAPI
{
    public interface IDal
    {
        #region Bus 
        Bus getBus(int licenseNumber); 
        IEnumerable<Bus> getAllBus();
        void createBus(Bus bus);
        void updateBus(Bus bus);
        void deleteBus(Bus bus);
        bool isExistBus(int licenseNumber);
        void InitAllLists();
        #endregion

        #region Users
        User getUser(string username);
        IEnumerable<User> getAllUser();
        void createUser(User user);
        void updateUser(User user);
        void deleteUser(User user);
        bool isExistUser(string username);

        IEnumerable<User> getAllUserBy(Predicate<User> predicate);
         #endregion

        #region Station
        bool isExistStation(int code);
        Station getStation(int code);
        IEnumerable<Station> getAllStation();
        void createStation(Station station);
        void updateStation(Station station);
        void deleteStation(Station station);

   
       
         #endregion

        #region Adjacent stations
        bool isExistAdjacentStations(int Id);
        AdjacentStations getAdjacentStation(int Id);
        IEnumerable<AdjacentStations> getAllAdjacentStations();

        void createAdjacentStations(AdjacentStations adjacentStations);
        void updateAdjacentStations(AdjacentStations adjacentStations);
        void deleteAdjacentStations(AdjacentStations adjacentStations);


        #endregion

        #region Trip
        bool isExistTrip(int id);
        Trip getTrip(int id);
        IEnumerable<Trip> getAllTrip();
        void createTrip(Trip trip);
        void updateTrip(Trip trip);
        void deleteTrip(Trip trip);

       
        IEnumerable<Trip> getAllTripBy(Predicate<Trip> predicate);

        Trip getTripBy(Predicate<Trip> predicate);


       

        #endregion

        #region Line
        bool isExistLine(int id);
        Line getLine(int id);
        IEnumerable<Line> getAllLine();
        void createLine(Line line);
        void updateLine(Line line);
        void deleteLine(Line line);

        IEnumerable<Line> getAllLineBy(Predicate<Line> predicate);

        Line getLineBy(Predicate<Line> predicate);


        #endregion

        #region Line Trip
        bool isExistLineTrip(int id);
        LineTrip getLineTrip(int id);
        IEnumerable<LineTrip> getAllLineTrip();

        void createLineTrip(LineTrip lineTrip);
        void updateLineTrip(LineTrip lineTrip);
        void deleteLineTrip(LineTrip lineTrip);

        LineTrip getLineTripBy(Predicate<LineTrip> predicate);
        IEnumerable<LineTrip> getAllLineTripBy(Predicate<LineTrip> predicate);

        #endregion

        #region Line Station 
        bool isExistLineStation(int lineId);
        LineStation getLineStation(int lineId);
        IEnumerable<LineStation> getAllLineStation();
        void createLineStation(LineStation lineStation);
        void updateLineStation(LineStation linestation);
        void deleteLineStation(LineStation linestation);

        #endregion

        #region Bus on trip
        bool isExistBusOnTrip(int licenseNumber);
        BusOnTrip getBusOnTrip(int licenseNumber);
        IEnumerable<BusOnTrip> getAllBusOnTrip();
        void createBusOnTrip(BusOnTrip busontrip);
        void updateBusOnTrip(BusOnTrip busontrip);
        void deleteBusOnTrip(BusOnTrip busontrip);

        BusOnTrip getBusOnTripBy(Predicate<BusOnTrip> predicate);

        IEnumerable<BusOnTrip> getAllBusOnTripBy(Predicate<BusOnTrip> predicate);

       
        #endregion

       
    }
}
