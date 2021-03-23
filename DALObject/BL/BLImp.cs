using BLAPI;
using BO;
using DALAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using BL.BO;
using System.Threading;
using System.Net.Mail;

namespace BL
{
    public class BLImp : IBL //internal
    {
        IDal dl = DalFactory.GetDL();
        #region Bus
        public Bus busDoBoAdapter(DO.Bus busDo)
        {
            Bus busBo = new Bus();
            DeepCopyUtilities.BusDoToBo(busBo,busDo);
            return busBo;
        }


        public Bus getBus(Bus bus)
        {
            DO.Bus busDo;
            try
            {
                busDo = dl.getBus(bus.LicenseNum);
            }
            catch (DO.BadBusIdException ex)
            {
                throw new BadBusIdException("Bus id does not exist or he is not a Bus", ex);
            }
            return busDoBoAdapter(busDo);
        }


        public IEnumerable<Bus> getAllBus()
        {

            var help= from item in dl.getAllBus()
                   select busDoBoAdapter(item);
            return help;
        }
       
       
        public void updateBus(Bus bus)
        {
           
            DO.Bus busDo = new DO.Bus();
            bus.CopyPropertiesTo(busDo);
            try
            {
                dl.updateBus(busDo);
            }
            catch (DO.BadBusIdException ex)
            {
                throw new BadBusIdException("Bus ID is illegal", ex);
            }

        }

        public void deleteBus(Bus bus)
        {

            DO.Bus busDo = new DO.Bus();
            bus.CopyPropertiesTo(busDo);
            try
            {
                dl.deleteBus(busDo);
            }
            catch (DO.BadBusIdException ex)
            {
                throw new BadBusIdException("bus ID and License Number is Not exist", ex);
            }

        }

        public bool isExistBus(int licenseNumber)
        {
            return dl.isExistBus(licenseNumber);
        }
        public void AddBus(Bus bus)
        {
            DO.Bus busDo = new DO.Bus();
            bus.CopyPropertiesTo(busDo);
            try
            {
                dl.createBus(busDo);
            }
            catch (DO.DLException ex)
            {
                throw new BLException(ex.Message);
            }
        }

      

     

        #endregion

        #region Adjacent stations

        public AdjacentStations adjacentStationsDoBoAdapter(DO.AdjacentStations adjacentStationsDo)
        {
            AdjacentStations AdjacentStationsBO = new AdjacentStations();

            adjacentStationsDo.CopyPropertiesTo(AdjacentStationsBO);

            return AdjacentStationsBO;
        }
        public AdjacentStations getAdjacentStations(AdjacentStations adjacentStations)
        {
            DO.AdjacentStations adjacentStationsDo;
            try
            {
                adjacentStationsDo = dl.getAdjacentStation(adjacentStations.Id);
            }
            catch (DO.DLException ex)
            {
                throw new BLException(ex.Message);
            }
            return adjacentStationsDoBoAdapter(adjacentStationsDo);
        }
        AdjacentStations convertASDoToB(DO.AdjacentStations s)
        {
            AdjacentStations newOne = new AdjacentStations();
            newOne.Id = s.Id;
            newOne.Station1 = s.Station1;
            newOne.Station2 = s.Station2;
            newOne.Time = s.Time;
            newOne.Distance = s.Distance;
            return newOne;

        }
        public IEnumerable<AdjacentStations> getAllAdjacentStations()
        {
            List<AdjacentStations> toReturn = new List<AdjacentStations>();
         
            dl.getAllAdjacentStations().ToList().ForEach(item => toReturn.Add(convertASDoToB(item)));
            return toReturn;
        }
        public void updateAdjacentStations(AdjacentStations adjacentStations)
        {
            DO.AdjacentStations adjacentStationsDO = new DO.AdjacentStations();
            adjacentStations.CopyPropertiesTo(adjacentStationsDO);
            try
            {
                dl.updateAdjacentStations(adjacentStationsDO);
            }
            catch (DO.DLException ex)
            {
                throw new BLException("cant update Adjacent station was not found");
            }
        }
      
        public bool isExistAdjacentStations(int id)
        {
            return dl.isExistAdjacentStations(id);
        }
   
     
       
        
         

        #endregion

        #region Users
        public User userDoBoAdapter(DO.User UserDO)
        {
            User UserBO = new User();

            DeepCopyUtilities.UserDOtoBO(UserBO, UserDO);
           
            return UserBO;
        }
        public User getUser(User User)
        {
            DO.User UserDo;
            try
            {
                UserDo = dl.getUser(User.UserName);
            }
            catch (DO.BadUserIdException ex)
            {
                throw new BadUserIdException("username does not exist or he is not a username", ex);
            }
            return userDoBoAdapter(UserDo);
        }
        
        public  IEnumerable<User> getAllUser()
        {
             var help=from item in  dl.getAllUser()
                   select userDoBoAdapter(item);
            return help;
        }
        public void updateUser(User User)
        {
            DO.User UserDo = new DO.User();
            User.CopyPropertiesTo(UserDo);
            try
            {
                dl.updateUser(UserDo);
            }
            catch (DO.BadUserIdException ex)
            {
                throw new BadUserIdException("this user was not found", ex);
            }
        }
        public void deleteUser(User User)
        {
            DO.User UserDo = new DO.User();
            User.CopyPropertiesTo(UserDo);
            try
            {
                dl.deleteUser(UserDo);
            }
            catch (DO.BadUserIdException ex)
            {
                throw new BadUserIdException("this user was not found", ex);
            }
        }
        public bool isExistUser(string userName)
        {
            return dl.isExistUser(userName);
        }
        public void createUser(User User)
        {
            DO.User UserDo = new DO.User();
            User.CopyPropertiesTo(UserDo);
            try
            {
                dl.createUser(UserDo);
            }
            catch (DO.BadUserIdException ex)
            {
                throw new BadUserIdException("this user is already exist", ex);
            }
        }

        public void resetpwd(User j)
        {
            DO.User a = new DO.User();
            j.CopyPropertiesTo(a);

            DO.User b = dl.getAllUser().ToList().Find(user => user.userName == a.userName);
            string pass = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string newpwd = "";
            Random r = new Random();
            for (int i = 0; i < 8; i++)
                newpwd += pass[r.Next(0, 52)];
            b.password = newpwd;
            try
            {
                using (MailMessage mymessage = new MailMessage())
                {
                    mymessage.From = new MailAddress("jeremomo27@gmail.com", "From MoovitProject");

                    mymessage.To.Add(b.email);
                    mymessage.Subject = "Reinitializing your password";
                    mymessage.Body = string.Format("Hi {0} here's your new password :<b> {1} </b> ,it let you access again to our system , try it !", a.userName, b.password);
                    mymessage.IsBodyHtml = true;
                    using (SmtpClient smpt = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smpt.Credentials = new System.Net.NetworkCredential("jeremomo27@gmail.com", "*ECtmi7E7/,7ui2V6Wk");
                        smpt.EnableSsl = true;

                        smpt.Send(mymessage);

                    }
                    dl.deleteUser(a);
                    dl.createUser(b);
                }
            }
            catch (Exception)
            {
                b.password = "0000";
                dl.deleteUser(a);
                dl.createUser(b);

                throw new BLException("Your mail is not valid we can't send you a new password so by default it's 0000 now !");
            }
        }









        #endregion
        public void StartSimulator(TimeSpan startTime, int Rate, Action<TimeSpan> updateTime)
        {
            SimulatorClock.Instance.Cancel = false;

            SimulatorClock simulatorClock = SimulatorClock.Instance;
            simulatorClock.Rate = Rate;
            simulatorClock.stopWatch.Restart();
            simulatorClock.ClockObserver += updateTime;
            while (simulatorClock.Cancel != true)//Until we didnt click on stop simlation the time in our simulatorClock still working on adding the timeElapsed
            {
                simulatorClock.Time = startTime + new TimeSpan(simulatorClock.stopWatch.ElapsedTicks * simulatorClock.Rate);
                if (simulatorClock.Time.Hours == 23 && simulatorClock.Time.Minutes == 59 && simulatorClock.Time.Seconds == 59)
                    simulatorClock.Time = new TimeSpan(0, 0, 0);
                Thread.Sleep(100);
            }
        }
        public void StopSimulator()
        {
            SimulatorClock.Instance.Cancel = true;
            SimulatorClock.Instance.Time = new TimeSpan(0, 0, -1);
        }

        #region Station
        public Station stationDoBoAdapter(DO.Station stationDo)
        {
            Station stationBO = new Station();

            stationDo.CopyPropertiesTo(stationBO);

            return stationBO;
        }
        public Station getStation(Station station)
        {
            DO.Station stationDO;
            try
            {
                stationDO = dl.getStation(station.code);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BadStationIdException("station does not exist or he is not a station", ex);
            }
            return stationDoBoAdapter(stationDO);
        }
        public IEnumerable<Station> getAllStation()
        {
            return from item in dl.getAllStation()
                   select stationDoBoAdapter(item);
        }
        public void updateStation(Station station)
        {
            DO.Station stationDO = new DO.Station();
            station.CopyPropertiesTo(stationDO);
            try
            {
                dl.updateStation(stationDO);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BadStationIdException("this station was not found", ex);
            }
        }
        public void deleteStation(Station station)
        {
            DO.Station stationDO = new DO.Station();
            station.CopyPropertiesTo(stationDO);
           
            try
            {
                dl.deleteStation(stationDO);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BadStationIdException("this station was not found", ex);
            }
        }
        public bool isExistStation(int Id)
        {
            return dl.isExistStation(Id);
        }
        public void addStation(Station station)
        {
            DO.Station stationDO = new DO.Station();
            station.CopyPropertiesTo(stationDO);
            try
            {
                dl.createStation(stationDO);
            }
            catch (DO.DLException ex)
            {
                throw new BLException(ex.Message);
            }
        }

    

    

       
       
         
        #endregion

        #region Trip
        public Trip tripDoBoAdapter(DO.Trip tripDo)
        {
            Trip tripBo = new Trip();

            tripDo.CopyPropertiesTo(tripBo);

            return tripBo;
        }
        public Trip getTrip(Trip trip)
        {
            DO.Trip tripDo;
            try
            {
                tripDo = dl.getTrip(trip.id);
            }
            catch (DO.BadTripIdException ex)
            {
                throw new BadTripIdException("trip Id is illegal or is not exist", ex);
            }
            return tripDoBoAdapter(tripDo);
        }
        public IEnumerable<Trip> getAllTrip()
        {
            return from item in dl.getAllTrip()
                   select tripDoBoAdapter(item);
        }
        public void updateTrip(Trip trip)
        {
            DO.Trip tripDo = new DO.Trip();
            trip.CopyPropertiesTo(tripDo);
            try
            {
                dl.updateTrip(tripDo);
            }
            catch (DO.BadTripIdException ex)
            {
                throw new BadTripIdException("trip Id is illegal", ex);
            }
        }
        public void deleteTrip(Trip trip)
        {
            DO.Trip tripDo = new DO.Trip();
            trip.CopyPropertiesTo(tripDo);
            try
            {
                dl.deleteTrip(tripDo);
            }
            catch (DO.BadTripIdException ex)
            {
                throw new BadTripIdException("this trip is not exist", ex);
            }
        }
        public bool isExistTrip(int Id)
        {
            return dl.isExistTrip(Id);
        }
        public void createTrip(Trip trip)
        {
            DO.Trip tripDo = new DO.Trip();
            trip.CopyPropertiesTo(tripDo);
            try
            {
                dl.createTrip(tripDo);
            }
            catch (DO.BadTripIdException ex)
            {
                throw new BadTripIdException("this trip is already exist", ex);
            }
        }

        public Trip getTripBy(Predicate<Trip> predicate)
        {
            Predicate<DO.Trip> help = (Predicate<DO.Trip>)predicate;
            try
            {
                Trip myTrip = new Trip();
                dl.getTripBy(help).CopyPropertiesTo(myTrip);
                return myTrip;
            }
            catch (DO.BadTripIdException ex)
            {
                throw new BadTripIdException("cant get trip by predicate", ex);
            }
        }

        public  IEnumerable<Trip> getAllTripBy(Predicate<Trip> predicate)
        {

            Predicate<DO.Trip> help = (Predicate<DO.Trip>)predicate;
            try
            {
                List<Trip> helpTrip = new List<Trip>();
                foreach (var trip in dl.getAllTripBy(help))
                {
                    Trip myTrip = new Trip();
                    trip.CopyPropertiesTo(myTrip);
                    helpTrip.Add(myTrip);
                }
                return helpTrip;
            }
            catch (DO.BadTripIdException ex)
            {
                throw new BadTripIdException("cant get all trip by predicate", ex);
            }
        }





        #endregion

        #region Line
        public Line lineDoBoAdapter(DO.Line lineDo)
        {
            Line lineBo = new Line();

            lineDo.CopyPropertiesTo(lineBo);

            return lineBo;
        }
        public Line getLine(Line s)
        {
            Line fin = getLines().Find(item => item.Id == s.Id);
            if (fin == null)
            {
                throw new BLException("Line not found !");
            }
            else
                return fin;
        }
        public List<Line> getLines()//It search all the lines saved and add it all the stationLine which passing through 
        {
            List<Line> t = new List<Line>();
            dl.getAllLine().ToList().ForEach(line => t.Add(lineDoBoAdapter(line)));//here we just have the line
            foreach (Line l in t.ToList())
            {
                foreach (LineStation s in GetAllLineStation())
                {
                    int check = s.ID;
                    if (s.LineId == l.Id)//It means that this stations is passed by the line l
                    {
                        if (s.LineStationIndex != null)//We check if there's an index to pay attentio for
                        {
                            if(s.LineStationIndex == "")
                            {
                                int stock = 0;
                                s.LineStationIndex = stock.ToString();
                            }
                            l.listStations.Insert(int.Parse(s.LineStationIndex), s);
                        }
                        else
                        {
                            l.listStations.Add(s);
                        }
                    }
                }
                if (l.listStations.Count() >= 2)//If the line contains - than 2 stations it's not "a line"
                {

                    setIndexinLine(l);
                    l.listStations[l.listStations.Count - 1].Distance = 0;

                    l.listStations[l.listStations.Count - 1].Temps = new TimeSpan(0, 0, 0);
                }
                //else
                //{
                   
                //    RemoveLineStation(l.listStations[0]);
                //    deleteLine(l);
                //    t.Remove(l);
                //}
              //because there's no next stop at the terminus

            }


            return t;
        }
        public void setIndexinLine(Line l)//It set all the needed value in a line (distance,time,first station,last station..) 
        {

            for (int a = 0; a < l.listStations.Count(); a++)
            {

                if (a == 0)
                {
                    l.listStations[a].PrevStation = 0;

                }
                else
                {
                    l.listStations[a].PrevStation = l.listStations[a - 1].Station;
                }
                l.listStations[a].LineStationIndex = a.ToString();

                if (a == l.listStations.Count() - 1)
                    l.listStations[a].NextStation = l.listStations[0].Station;
                else
                    l.listStations[a].NextStation = l.listStations[a + 1].Station;
            }
            l.listStations[l.listStations.Count - 1].Distance = 0;

            l.listStations[l.listStations.Count - 1].Temps = new TimeSpan(0, 0, 0);
            if (l.listStations.Count != 0)
            {
                l.FirstStation = l.listStations[0].Station;
                l.LastStation = l.listStations[l.listStations.Count - 1].Station;
            }
            else
            {
                l.FirstStation = 0;
                l.LastStation = 0;
            }

        }
        public IEnumerable<Line> getAllLine()
        {
            IEnumerable<Line> list= from item in dl.getAllLine() select lineDoBoAdapter(item);
            foreach(Line l in list.ToList())
            {
                Line temp = getLines().Find(item => item.Id == l.Id && item.listStations.Count < 2);
                if (temp!=null)
                {
                    deleteLine(temp);
                    list.ToList().RemoveAll(item => item.Id == temp.Id);
                }
            }
            return list;
        }
        public void updateLine(Line Line)
        {
            DO.Line LineDo = new DO.Line();
            Line.CopyPropertiesTo(LineDo);
            try
            {
                dl.updateLine(LineDo);
            }
            catch (DO.BadTripIdException ex)
            {
                throw new BadTripIdException("Line Id is illegal", ex);
            }
        }
        public void deleteLine(Line Line)
        {
            DO.Line LineDo = new DO.Line();
            Line.CopyPropertiesTo(LineDo);
            int check = LineDo.Id;
            try
            {
                dl.deleteLine(LineDo);
            }
            catch (DO.BadTripIdException ex)
            {
                throw new BadTripIdException("this line is not exist", ex);
            }
        }
        public bool isExistLine(int Id)
        {
            return dl.isExistLine(Id);
        }
        public void createLine(Line Line)
        {
            DO.Line LineDo = new DO.Line();
            Line.CopyPropertiesTo(LineDo);
            try
            {
                dl.createLine(LineDo);
                //for(int i =0; i < Line.lineStations.Count; i++)
                //{

                //}
            }
            catch (DO.DLException ex)
            {
                throw new BLException( ex.Message);
            }
        }

        public Line getLineBy(Predicate<Line> predicate)
        {
            Predicate<DO.Line> help = (Predicate<DO.Line>)predicate;
            try
            {
                Line myLine = new Line();
                dl.getLineBy(help).CopyPropertiesTo(myLine);
                return myLine;
            }
            catch (DO.BadTripIdException ex)
            {
                throw new BadTripIdException("cant get Line by predicate", ex);
            }
        }

        public IEnumerable<Line> getAllLineBy(Predicate<Line> predicate)
        {

            Predicate<DO.Line> help = (Predicate<DO.Line>)predicate;
            try
            {
                List<Line> helpLine = new List<Line>();
                foreach (var Line in dl.getAllLineBy(help))
                {
                    Line myLine = new Line();
                    Line.CopyPropertiesTo(myLine);
                    helpLine.Add(myLine);
                }
                return helpLine;
            }
            catch (DO.BadTripIdException ex)
            {
                throw new BadTripIdException("cant get all line by predicate", ex);
            }
        }






        #endregion

        #region Line Trip
        public LineTrip LineTripDoBoAdapter(DO.LineTrip lineTripDO)
        {
            LineTrip lineTripBO = new LineTrip();

            lineTripDO.CopyPropertiesTo(lineTripBO);

            return lineTripBO;
        }
        public LineTrip GetLineTrip(LineTrip lineTrip)
        {
            DO.LineTrip lineTripDo;
            try
            {
                lineTripDo = dl.getLineTrip(lineTrip.Id);
            }
            catch (DO.BadLineTripIdException ex)
            {
                throw new BadLineTripIdException("this Line Trip is not exist or not found", ex);
            }
            return LineTripDoBoAdapter(lineTripDo);
        }
        public IEnumerable<LineTrip> GetAllLineTrip()
        {
            return from item in dl.getAllLineTrip()
                   select LineTripDoBoAdapter(item);
        }
        public void UpdateLineTrip(LineTrip lineTrip)
        {
            DO.LineTrip lineTripDo = new DO.LineTrip();
            lineTrip.CopyPropertiesTo(lineTripDo);
            try
            {
                dl.updateLineTrip(lineTripDo);
            }
            catch (DO.BadLineTripIdException ex)
            {
                throw new BadLineTripIdException("this Line Trip is not exist or not found", ex);
            }
        }
        public void RemoveLineTrip(LineTrip lineTrip)
        {
            DO.LineTrip lineTripDo = new DO.LineTrip();
            lineTrip.CopyPropertiesTo(lineTripDo);
            try
            {
                dl.deleteLineTrip(lineTripDo);
            }
            catch (DO.BadLineTripIdException ex)
            {
                throw new BadLineTripIdException("this Line Trip is not exist or not found", ex);
            }
        }
        public bool IsExistLineTrip(int Id)
        {
            return dl.isExistLineTrip(Id);
        }
        public void createLineTrip(LineTrip lineTrip)
        {
            DO.LineTrip lineTripDo = new DO.LineTrip();
            lineTrip.CopyPropertiesTo(lineTripDo);
            try
            {
                dl.createLineTrip(lineTripDo);
            }
            catch (DO.BadLineTripIdException ex)
            {
                throw new BadLineTripIdException("this Line Trip is already exist", ex);
            }
        }

        public LineTrip getLineTripBy(Predicate<LineTrip> predicate)
        {
            Predicate<DO.LineTrip> help = (Predicate<DO.LineTrip>)predicate;
            try
            {
                LineTrip myLineTrip = new LineTrip();
                dl.getLineTripBy(help).CopyPropertiesTo(myLineTrip);
                return myLineTrip;
            }
            catch (DO.BadLineTripIdException ex)
            {
                throw new BadLineTripIdException("cant get line trip by predicate, maybe the predicate is wrong?", ex);
            }
        }

        public IEnumerable<LineTrip> getAllLineTripBy(Predicate<LineTrip> predicate)
        {

            Predicate<DO.LineTrip> help = (Predicate<DO.LineTrip>)predicate;
            try
            {
                List<LineTrip> helpLineTrip = new List<LineTrip>();
                foreach (var lineTrip in dl.getAllLineTripBy(help))
                {
                    LineTrip myLineTrip = new LineTrip();
                    lineTrip.CopyPropertiesTo(myLineTrip);
                    helpLineTrip.Add(myLineTrip);
                }
                return helpLineTrip;
            }
            catch (DO.BadTripIdException ex)
            {
                throw new BadTripIdException("cant get all trip by predicate", ex);
            }
        }

       
        
         
        #endregion

        #region Line Station 
        public LineStation LineStationDoBoAdapter(DO.LineStation lineStationDO)
        {
            LineStation lineStationBO = new LineStation()
            {
                LineId = lineStationDO.LineId,
                NextStation = lineStationDO.NextStation,
                LineStationIndex = lineStationDO.LineStationIndex,
                PrevStation = lineStationDO.PrevStation,
                Station = lineStationDO.Station,
                ID=lineStationDO.ID,
                name=lineStationDO.name,
                code=lineStationDO.code
               
            };

            

            return lineStationBO;
        }
        public LineStation fromStation(Station from)
        {
            LineStation to = new LineStation();
            to.code = from.code;
            to.Station = from.code;
            to.longitude = from.longitude;
            to.latitude = from.latitude;
            to.name = from.name;
            return to;
        }
        public DO.LineStation LineStationBoDoAdapter(LineStation lineStationDO)
        {
            DO.LineStation lineStationBO = new DO.LineStation()
            {
                LineId = lineStationDO.LineId,
                NextStation = lineStationDO.NextStation,
                LineStationIndex = lineStationDO.LineStationIndex,
                PrevStation = lineStationDO.PrevStation,
                Station = lineStationDO.Station,
                ID=lineStationDO.ID,
                code=lineStationDO.code,
                name=lineStationDO.name
            };



            return lineStationBO;
        }
        public LineStation GetLineStation(LineStation lineStation)
        {
            List<DO.LineStation> stationList = dl.getAllLineStation().ToList();
            if(stationList.Exists(item=>item.ID==lineStation.ID))
            {
                return LineStationDoBoAdapter(stationList.Find(item => item.ID == lineStation.ID));
            }
            else
            {
                throw new BLException("Station not found !");
            }
        }
        public IEnumerable<LineStation> GetAllLineStation()
        {
            List<LineStation> list = new List<LineStation>();

            dl.getAllLineStation().ToList().ForEach(station => list.Add(LineStationDoBoAdapter(station)));
            list.ForEach(station => getmyTime(station));//Linq request to get the time and distance from the data 

            return list.ToList();

        }
       public void getmyTime(LineStation s)
        {
            int index = getAllAdjacentStations().ToList().FindIndex(station => station.Station1 == s.ID);
            double checking = getAllAdjacentStations().ToList()[0].Distance;
            checking = getAllAdjacentStations().ToList()[1].Distance;
            if (index != -1)
            {
                s.Distance = getAllAdjacentStations().ToList()[index].Distance;

                s.Temps = getAllAdjacentStations().ToList()[index].Time;
            }
        }
        public LineStation findlineForStation(LineStation i)//This function will give all the line passing through a specific station
        {
            List<LineStation> ss = GetAllLineStation().Where(station => station.Station == i.Station).ToList();
            LineStation s = i;
            foreach (LineStation l in ss)
            {
                s.myLines.Add(getLines().ToList().Find(line => line.Id == l.LineId));
            }

            return s;
        }
        public void UpdateLineStation(LineStation lineStation)
        {
            DO.LineStation lineStationDO = new DO.LineStation();
            lineStation.CopyPropertiesTo(lineStationDO);
            try
            {
                dl.updateLineStation(lineStationDO);
            }
            catch (DO.BadLineStationIdException ex)
            {
                throw new BadLineStationIdException("line station ID is illegal", ex);
            }
        }
        public void RemoveLineStation(LineStation lineStation)
        {
            DO.LineStation s = new DO.LineStation();
            lineStation.CopyPropertiesTo(s);
            int check = s.ID;
            dl.deleteLineStation(s);
          
        }
        public bool IsExistLineStation(int Id)
        {
            return dl.isExistLineStation(Id);
        }
        public void createLineStation(LineStation l)
        {
            DO.LineStation s = new DO.LineStation();
            l.CopyPropertiesTo(s);
            try
            {
                dl.createLineStation(s);
            }
            catch(DO.DLException ex)
            {
                throw new BLException(ex.Message);
            }
        }

        
    
       

      
        
         
        #endregion

        #region Bus on trip
        public BusOnTrip BusOnTripDoBoAdapter(DO.BusOnTrip busOnTripDO)
        {

            BusOnTrip busOnTripBO = new BusOnTrip();

            busOnTripDO.CopyPropertiesTo(busOnTripBO);

            return busOnTripBO;
        }
        public BusOnTrip GetBusOnTrip(BusOnTrip busOnTrip)
        {
            DO.BusOnTrip busOnTripDO;
            try
            {
                busOnTripDO = dl.getBusOnTrip(busOnTrip.licenseBusNum);
            }
            catch (DO.BadBusOnTripIdException ex)
            {
                throw new BadBusOnTripIdException("Bus on trip does not exist or he is not a Bus", ex);
            }
            return BusOnTripDoBoAdapter(busOnTripDO);
        }
        public IEnumerable<BusOnTrip> GetAllBusOnTrip()
        {
            return from item in dl.getAllBusOnTrip()
                   select BusOnTripDoBoAdapter(item);
        }
        public void UpdateBusOnTrip(BusOnTrip busOnTrip)
        {
            DO.BusOnTrip busOnTripDO = new DO.BusOnTrip();
            busOnTrip.CopyPropertiesTo(busOnTripDO);
            try
            {
                dl.updateBusOnTrip(busOnTripDO);
            }
            catch (DO.BadBusOnTripIdException ex)
            {
                throw new BadBusOnTripIdException("Bus on trip is illegal", ex);
            }
        }
        public void RemoveBusOnTrip(BusOnTrip busOnTrip)
        {
            DO.BusOnTrip busOnTripDO = new DO.BusOnTrip();
            busOnTrip.CopyPropertiesTo(busOnTripDO);
            try
            {
                dl.deleteBusOnTrip(busOnTripDO);
            }
            catch (DO.BadBusOnTripIdException ex)
            {
                throw new BadBusOnTripIdException("this bus on trip is not exist", ex);
            }
        }
        public bool IsExistBusOnTrip(int Id)
        {
            return dl.isExistBusOnTrip(Id);
        }
        public void createBusOnTrip(Bus busOnTrip)
        {
            DO.BusOnTrip busOnTripDO = new DO.BusOnTrip();
            busOnTrip.CopyPropertiesTo(busOnTripDO);

            try
            {
                dl.createBusOnTrip(busOnTripDO);
            }
            catch (DO.BadBusOnTripIdException ex)
            {
                throw new BadBusOnTripIdException("Bus on Trip is already exist", ex);
            }
        }

       public BusOnTrip getBusOnTripBy(Predicate<BusOnTrip> predicate)
        {
            Predicate<DO.BusOnTrip> help = (Predicate<DO.BusOnTrip>)predicate;
            try
            {
                BusOnTrip myBusOnTrip = new BusOnTrip();
                dl.getBusOnTripBy(help).CopyPropertiesTo(myBusOnTrip);
                return myBusOnTrip;
            }
            catch (DO.BadBusOnTripIdException ex)
            {
                throw new BadBusOnTripIdException("get bus on trip by predicate is wrong, maybe the " +
                    "predicate is not correct?", ex);
            }
        }

       public IEnumerable<BusOnTrip> getAllBusOnTripBy(Predicate<BusOnTrip> predicate)
        {
            Predicate<DO.BusOnTrip> help = (Predicate<DO.BusOnTrip>)predicate;
            try
            {
                List<BusOnTrip> helpBusOnTrip = new List<BusOnTrip>();
                foreach (var busOnTrip in dl.getAllBusOnTripBy(help))
                {
                    BusOnTrip myBusOnTrip = new BusOnTrip();
                    busOnTrip.CopyPropertiesTo(myBusOnTrip);
                    helpBusOnTrip.Add(myBusOnTrip);
                }
                return helpBusOnTrip;
            }
            catch (DO.BadBusOnTripIdException ex)
            {
                throw new BadBusOnTripIdException("cant have get all bus on trip by predicate, maybe" +
                    "the predicate is wrong?", ex);
            }
        }

     

        

       

        bool  IBL.login(string myusername, string mypassword)
        {
            IEnumerable<User> users= getAllUser();
            foreach(var item in users)
            {
                if (item.Password == mypassword && item.UserName == myusername)
                    return true;
            }
            return false;
        }

      
        void IBL.createBusOnTrip(BusOnTrip busOnTrip)
        {
            throw new NotImplementedException();
        }

        //public System.Collections.IEnumerable getAllLine()
        //{
        //    var help = from item in dl.getAllLine()
        //               select lineDoBoAdapter(item);
        //    return help;
        //}

        public IEnumerable<LineStation> getAllLineStation()
        {
            var help = from item in dl.getAllLineStation()
                       select lineStationDoBoAdapter(item);
            return help;
        }

        public LineStation lineStationDoBoAdapter(DO.LineStation busDo)
        {
            LineStation busBo = new LineStation();
            DeepCopyUtilities.LineStationDoToBo(busBo, busDo);
            busBo.Station = busDo.Station;
            return busBo;
        }

        public void addAdjacentStations(AdjacentStations s)
        {
            DO.AdjacentStations to = new DO.AdjacentStations();
            s.CopyPropertiesTo(to);
            to.Station1 = s.Station1;
            to.Station2 = s.Station2;
            to.Time = s.Time;
            to.Distance = s.Distance;
            dl.createAdjacentStations(to);
        }
        //public void createLine(Line line)
        //{
        //    DO.Line LineDo = new DO.Line();
        //    line.CopyPropertiesTo(LineDo);
        //    try
        //    {
        //        dl.createLine(LineDo);
        //    }
        //    catch (DO.BadUserIdException ex)
        //    {
        //        throw new BadUserIdException("this line is already exist", ex);
        //    }
        //}

        #endregion
    }
}
