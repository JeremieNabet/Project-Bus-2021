using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAPI
{
    public interface IBL
    {
        bool login(string myusername, string mypassword);


        #region Bus
        BO.Bus busDoBoAdapter(DO.Bus busDo);
        BO.Bus getBus(BO.Bus bus);
        IEnumerable<BO.Bus> getAllBus();
        void updateBus(BO.Bus bus);
        void deleteBus(BO.Bus bus);
        bool isExistBus(int licenseNumber);
        void AddBus(BO.Bus bus);

        void StartSimulator(TimeSpan startTime, int Rate, Action<TimeSpan> updateTime);
        void StopSimulator();

        //IEnumerable getAllLine();

        //void createLine(BO.Line line);

        #endregion

        #region Adjacent stations
        BO.AdjacentStations adjacentStationsDoBoAdapter(DO.AdjacentStations adjacentStationsDo);
        BO.AdjacentStations getAdjacentStations(BO.AdjacentStations adjacentStations);
        IEnumerable<BO.AdjacentStations> getAllAdjacentStations();
        IEnumerable<BO.LineStation> getAllLineStation();
        void updateAdjacentStations(BO.AdjacentStations adjacentStations);
        bool isExistAdjacentStations(int id);
        void addAdjacentStations(BO.AdjacentStations adjacentStations);
        //BO.AdjacentStations getAdjacentStationsBy(Predicate<BO.AdjacentStations> predicate);
        //IEnumerable<BO.AdjacentStations> getAllAdjacentStationsBy(Predicate<BO.AdjacentStations> predicate);
       
        

        #endregion

        #region Users
        BO.User userDoBoAdapter(DO.User userDO);
        BO.User getUser(BO.User User);
        IEnumerable<BO.User> getAllUser();
        void updateUser(BO.User User);
        void deleteUser(BO.User User);
        bool isExistUser(string userName);
        void createUser(BO.User User);
        void resetpwd(BO.User a);



        #endregion

        #region Station
        BO.Station stationDoBoAdapter(DO.Station stationDo);
        BO.Station getStation(BO.Station station);
        IEnumerable<BO.Station> getAllStation();
        void updateStation(BO.Station station);
        void deleteStation(BO.Station station);
        bool isExistStation(int Id);
        void addStation(BO.Station station);
 
        
        
        
        #endregion

        #region Trip
        BO.Trip tripDoBoAdapter(DO.Trip tripDo);
        BO.Trip getTrip(BO.Trip trip);
        IEnumerable<BO.Trip> getAllTrip();
        void updateTrip(BO.Trip trip);
        void deleteTrip(BO.Trip trip);
        bool isExistTrip(int Id);
        void createTrip(BO.Trip trip);
        BO.Trip getTripBy(Predicate<BO.Trip> predicate);
        IEnumerable<BO.Trip> getAllTripBy(Predicate<BO.Trip> predicate);



        #endregion

        #region Line
        BO.Line lineDoBoAdapter(DO.Line lineDo);
        BO.Line getLine(BO.Line Line);
        void setIndexinLine(BO.Line l);
        IEnumerable<BO.Line> getAllLine();
        List<BO.Line> getLines();
        void updateLine(BO.Line Line);
        void deleteLine(BO.Line Line);
        bool isExistLine(int Id);
        void  createLine(BO.Line Line);
        BO.Line getLineBy(Predicate<BO.Line> predicate);
        IEnumerable<BO.Line> getAllLineBy(Predicate<BO.Line> predicate);



        #endregion


        #region Line Trip
        BO.LineTrip LineTripDoBoAdapter(DO.LineTrip lineTripDO);
        BO.LineTrip GetLineTrip(BO.LineTrip lineTrip);
        IEnumerable<BO.LineTrip> GetAllLineTrip();
        void UpdateLineTrip(BO.LineTrip lineTrip);
        void RemoveLineTrip(BO.LineTrip lineTrip);
        bool IsExistLineTrip(int Id);
        void createLineTrip(BO.LineTrip lineTrip);

        BO.LineTrip getLineTripBy(Predicate<BO.LineTrip> predicate);

        IEnumerable<BO.LineTrip> getAllLineTripBy(Predicate<BO.LineTrip> predicate);

        
        
         
        #endregion

        #region Line Station 
        BO.LineStation LineStationDoBoAdapter(DO.LineStation lineStationDO);
        BO.LineStation GetLineStation(BO.LineStation lineStation);
        IEnumerable<BO.LineStation> GetAllLineStation();
        void UpdateLineStation(BO.LineStation lineStation);
        void RemoveLineStation(BO.LineStation lineStation);
        bool IsExistLineStation(int Id);
        BO.LineStation fromStation(BO.Station i);
        void createLineStation(BO.LineStation lineStation);
        BO.LineStation findlineForStation(BO.LineStation i);
        void getmyTime(BO.LineStation s);


       
        
        
        #endregion

        #region Bus on trip
        BO.BusOnTrip BusOnTripDoBoAdapter(DO.BusOnTrip busOnTripDO);
        BO.BusOnTrip GetBusOnTrip(BO.BusOnTrip busOnTrip);
        IEnumerable<BO.BusOnTrip> GetAllBusOnTrip();
        void UpdateBusOnTrip(BO.BusOnTrip busOnTrip);
        void RemoveBusOnTrip(BO.BusOnTrip busOnTrip);
        bool IsExistBusOnTrip(int Id);
        void createBusOnTrip(BO.BusOnTrip busOnTrip);

        BO.BusOnTrip getBusOnTripBy(Predicate<BO.BusOnTrip> predicate);

        IEnumerable<BO.BusOnTrip> getAllBusOnTripBy(Predicate<BO.BusOnTrip> predicate);

        
         
        #endregion
    }
}
