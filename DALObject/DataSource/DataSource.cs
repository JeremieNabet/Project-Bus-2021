using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSourceXml;
using DO;

namespace DS
{
    public static class DataSource
    {
       
        public static List<Bus> busList;
        public static List<Station> stationList;
        public static List<User> userList;
        public static List<Trip> tripList;
        public static List<AdjacentStations> adjacentStationsList;
        public static List<Line> lineList;
        public static List<LineTrip> lineTripList;
        public static List<LineStation> lineStationList;
        public static List<BusOnTrip> busOnTripList;

        static DataSource()
        {
            InitAllLists();
        }

        public static void InitAllLists()
        {
            int forID = 0;
            busList = new List<Bus>()
            {
                #region Bus
                new Bus()
                {
                    FuelRemain = 1200, LicenseNum = 12345600, BusStatus = Bus.Status.availableTrip, FromDate = DateTime.Now, TotalTrip = 1200
                },
                new Bus()
                {
                    FuelRemain = 1200, LicenseNum = 12345601, BusStatus = Bus.Status.availableTrip, FromDate = DateTime.Now, TotalTrip = 1200
                },
                new Bus()
                {
                    FuelRemain = 1200, LicenseNum = 12345602, BusStatus = Bus.Status.availableTrip, FromDate = DateTime.Now, TotalTrip = 1200
                },
                new Bus()
                {
                    FuelRemain = 1200, LicenseNum = 12345603, BusStatus = Bus.Status.availableTrip, FromDate = DateTime.Now, TotalTrip = 1200
                },
                new Bus()
                {
                    FuelRemain = 1200, LicenseNum = 12345604, BusStatus = Bus.Status.availableTrip, FromDate = DateTime.Now, TotalTrip = 1200
                },new Bus()
                {
                    FuelRemain = 1200, LicenseNum = 12345605, BusStatus = Bus.Status.availableTrip, FromDate = DateTime.Now, TotalTrip = 1200
                },
                new Bus()
                {
                    FuelRemain = 1200, LicenseNum = 12345606, BusStatus = Bus.Status.availableTrip, FromDate = DateTime.Now, TotalTrip = 1200
                }
#endregion
            };

            stationList = new List<Station>()
            {
                #region Station
                new Station()
                {
                    code = 100, name = "Har Hertzl", longitude= 30, latitude = 35, handicap = true
                   
                },
                
                new Station()
                {
                    code = 101, name = "Yefe Nof", longitude = 29, latitude = 34, handicap = true
                },
                new Station()
                {
                    code = 102, name = "Kikar Denia", longitude = 28, latitude = 33, handicap = false
                },
                new Station()
                {
                    code = 103, name = "Ehalutz", longitude = 27, latitude = 32, handicap = true
                },
                new Station()
                {
                    code = 104, name = "Kiriat Moche", longitude = 26, latitude = 31, handicap = false
                },
                new Station()
                {
                    code = 105, name = "Tahana Merkazit", longitude = 25, latitude = 30, handicap = true
                },
                new Station()
                {
                    code = 106, name = "Hatourim", longitude = 24, latitude = 29, handicap = true
                },
                #endregion

                #region stations Hadriel
               new Station
            {
                code = 100000,
                name = "Central Station Jerusalem",
                longitude = 35,
                latitude = 31,

            },

           new Station
            {
                code = 100010,
                name = "Mamilla",
                longitude = 35,
                latitude = 31,
            },

           new Station
            {
                code = 100020,
                name = "Yafo Center",
                longitude = 35,
                latitude = 31,
            },

            new Station
            {
                code = 100030,
                name = "Kyriat Moshe",
                longitude = 35,
                latitude = 31,
            },

           new Station
            {
                code = 100040,
                name = "Yefe Nof",
                longitude = 35,
                latitude = 31,
            },
           new Station
            {
                code = 100050,
                name = "Mahane Yehouda",
                longitude = 35,
                latitude = 31,
               // },
               //            new Station
               //            {
               //                Code = 100060,
               //                Name = "Hadavidka",
               //                Longitude = 35.21529,
               //                Latitude = 31.78460,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100070,
               //                Name = "Hakotel",
               //                Longitude = 35.23323,
               //                Latitude = 31.77653,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100080,
               //                Name = "Har Hertsel",
               //                Longitude = 35.18161,
               //                Latitude = 31.77094,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100090,
               //                Name = "Cinema City Jerusalem",
               //                Longitude = 35.20363,
               //                Latitude = 31.78312,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100100,
               //                Name = "Malha Mall",
               //                Longitude = 35.18716,
               //                Latitude = 31.75165,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100110,
               //                Name = "Yemin Moshe",
               //                Longitude = 35.22512,
               //                Latitude = 31.77364,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100120,
               //                Name = "Ben Yehuda",
               //                Longitude = 35.21658,
               //                Latitude = 31.78137,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100130,
               //                Name = "King George",
               //                Longitude = 35.21917,
               //                Latitude = 31.77962,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100140,
               //                Name = "Adar Mall",
               //                Longitude = 35.21343,
               //                Latitude = 31.7537,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100150,
               //                Name = "Hillel Street",
               //                Longitude = 35.21862,
               //                Latitude = 31.7802,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100160,
               //                Name = "Shaarei Tsedek Hospital",
               //                Longitude = 35.18527,
               //                Latitude = 31.77332,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100170,
               //                Name = "Hadassa Hospital",
               //                Longitude = 35.24225,
               //                Latitude = 31.79755,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100180,
               //                Name = "Yad Vashem",
               //                Longitude = 35.17532,
               //                Latitude = 31.77422,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100190,
               //                Name = "Museum Israel",
               //                Longitude = 35.20409,
               //                Latitude = 31.77221,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100200,
               //                Name = "Givat Ram University",
               //                Longitude = 35.24082,
               //                Latitude = 31.79464
               //,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100210,
               //                Name = "Har Hatsofim",
               //                Longitude = 35.20955,
               //                Latitude = 31.80311,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100220,
               //                Name = "Mahon Lev",
               //                Longitude = 35.19116,
               //                Latitude = 31.76507,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100230,
               //                Name = "Mahon Tal",
               //                Longitude = 35.1897,
               //                Latitude = 31.7857,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100240,
               //                Name = "Frishman Beach",
               //                Longitude = 34.76678,
               //                Latitude = 32.08036,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100250,
               //                Name = "Banana Beach",
               //                Longitude = 34.76325,
               //                Latitude = 32.07105,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100260,
               //                Name = "Hacarmel Shuk",
               //                Longitude = 34.77084,
               //                Latitude = 32.06891,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100270,
               //                Name = "Tel Aviv Port",
               //                Longitude = 34.77410,
               //                Latitude = 32.09878,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100280,
               //                Name = "Rotshild Avenue",
               //                Longitude = 34.77658,
               //                Latitude = 32.06570,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100290,
               //                Name = "Savidor Center",
               //                Longitude = 34.79813,
               //                Latitude = 32.08366,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100300,
               //                Name = "Gordon Beach",
               //                Longitude = 34.76786,
               //                Latitude = 32.08288,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100310,
               //                Name = "Marina Hertzlia",
               //                Longitude = 34.79625,
               //                Latitude = 32.16312,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100320,
               //                Name = "Bar Ilan University",
               //                Longitude = 34.84319,
               //                Latitude = 32.06880,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100330,
               //                Name = "Massada",
               //                Longitude = 35.36298,
               //                Latitude = 31.31187,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100340,
               //                Name = "Ein Gedi",
               //                Longitude = 35.38731,
               //                Latitude = 31.45330,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100350,
               //                Name = "Meron",
               //                Longitude = 35.44019,
               //                Latitude = 32.99068,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100360,
               //                Name = "Technion",
               //                Longitude = 35.02269,
               //                Latitude = 32.77652,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100370,
               //                Name = "Beer Sheva",
               //                Longitude = 34.79363,
               //                Latitude = 31.24939,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100380,
               //                Name = "Raanana",
               //                Longitude = 34.87645,
               //                Latitude = 32.17986,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100390,
               //                Name = "Eilat",
               //                Longitude = 34.93620,
               //                Latitude = 29.55272,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100400,
               //                Name = "Netivot",
               //                Longitude = 34.57231,
               //                Latitude = 31.41080,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100410,
               //                Name = "Ashdod",
               //                Longitude = 34.65472,
               //                Latitude = 31.81113,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100420,
               //                Name = "Bet Shemesh",
               //                Longitude = 34.98766,
               //                Latitude = 31.75784,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100430,
               //                Name = "Modiin",
               //                Longitude = 35.00263,
               //                Latitude = 31.90883,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100440,
               //                Name = "Ashkelon",
               //                Longitude = 34.56389,
               //                Latitude = 31.65949,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100450,
               //                Name = "Dead Sea",
               //                Longitude = 35.58651,
               //                Latitude = 31.71867,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100460,
               //                Name = "Ikea Rishon Letsion",
               //                Longitude = 34.77143,
               //                Latitude = 31.95148,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100470,
               //                Name = "Natanya",
               //                Longitude = 34.85054,
               //                Latitude = 32.32352,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100480,
               //                Name = "Hadera",
               //                Longitude = 34.88549,
               //                Latitude = 32.47199,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100490,
               //                Name = "Haifa",
               //                Longitude = 34.98863,
               //                Latitude = 32.82506,
               //            });

               //            ListStations new Station
               //            {
               //                Code = 100500,
               //                Name = "Mitspe Ramon",
               //                Longitude = 34.79903,
               //                Latitude = 30.60805,
               //            });

               //        }
               #endregion
           } };
          

            userList = new List<User>()
            {
                #region User
                new User()
                {
                    userName = "a", password = "a", admin = true
                },
                new User()
                {
                    userName = "jeremie", password = "jeremie55", admin = true
                },
                 new User()
                {
                    userName = "Hadriel", password = "Hadriel55", admin = true
                },
                
#endregion User
            };
            tripList = new List<Trip>()
            {
                new Trip()
                {
                   
                }
            };
           
          

            lineList = new List<Line>()
            {

                  new Line
                {
                    busLineNumber=1,
                    Id=++forID,
                    //1
                    
                    Areas = Area.CENTER,

                },
                  new Line
                {
                    Id =++forID, //2
                   
                    Areas = Area.EAST,
                busLineNumber=2,

                },
                new Line
                {
                    Id = 12346002, //3
                   
                    Areas = Area.NORTH,
                    busLineNumber=3,
                   

                },
               
            };

            lineStationList = new List<LineStation>();
            int index = 0;
            for(int a=0;a<stationList.Count;a++)
            {
                lineStationList.Add(new LineStation(stationList[a]));
                lineStationList[a].ID = ++forID;
                int essai = lineStationList[a].Station;

            }
            for (int a=0;a<stationList.Count;a++)
            {
                if (a == stationList.Count - 1)
                    break;
                for(int b=0;b<4;b++,a++)
                {
                    lineStationList[a].LineId = lineList[index].Id;
                }
                a--;
                index++;
            }
            lineStationList[lineStationList.Count -1].LineId = lineList[lineList.Count - 1].Id;

            adjacentStationsList = new List<AdjacentStations>();
            for (int a = 0; a < stationList.Count; a++)
            {
                double checkin = 0;
                if (a == stationList.Count - 1)
                {
                    adjacentStationsList.Add(new AdjacentStations(lineStationList[a], lineStationList[0]));
                    adjacentStationsList[a].Id = ++forID;
                    checkin = adjacentStationsList[a].Distance;
                    break;
                }
                adjacentStationsList.Add(new AdjacentStations(lineStationList[a], lineStationList[a + 1]));
                adjacentStationsList[a].Id = ++forID;
                checkin = adjacentStationsList[a].Distance;
            }
            double check = adjacentStationsList[0].Distance;
            check = adjacentStationsList[3].Distance;

            busOnTripList = new List<BusOnTrip>()
            {
                new BusOnTrip()
                {
                    
                }
            };
      
        }
          
    }
}
