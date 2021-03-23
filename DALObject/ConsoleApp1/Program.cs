using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSourceXml;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<LineStation> lineStationList = new List<LineStation>(){};
            lineStationList.Add(new LineStation
            {
                LineId = 1234600,
                Station = 100230,
                LineStationIndex = 7,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 1234600,
                Station = 100240,
                LineStationIndex = 8,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 1234600,
                Station = 100250,
                LineStationIndex = 9,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12346001,
                Station = 100300,
                LineStationIndex = 0,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12346001,
                Station = 100030,
                LineStationIndex = 1,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12346001,
                Station = 100320,
                LineStationIndex = 2,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12346001,
                Station = 100330,
                LineStationIndex = 3,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12346001,
                Station = 100210,
                LineStationIndex = 4,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12346001,
                Station = 100340,
                LineStationIndex = 5,
                PrevStation = 100210,
                NextStation = 100350,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12346001,
                Station = 100350,
                LineStationIndex = 6,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 412346001,
                Station = 100360,
                LineStationIndex = 7,
                PrevStation = 100350,
                NextStation = 100370,
            });

            
            lineStationList.Add(new LineStation
            {
                LineId = 0,
                Station = 010,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 0,
                Station = 011,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 0,
                Station = 012,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 0,
                Station = 013,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 0,
                Station = 014,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 0,
                Station = 015,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 0,
                Station = 016,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 0,
                Station = 017,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 0,
                Station = 018,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 0,
                Station = 019,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 0,
                Station = 020,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });

            // Line 1
            lineStationList.Add(new LineStation
            {
                LineId = 1,
                Station = 110,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 1,
                Station = 111,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 1,
                Station = 112,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 1,
                Station = 113,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 1,
                Station = 114,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 1,
                Station = 115,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 1,
                Station = 116,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 1,
                Station = 117,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 1,
                Station = 118,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });

            
            lineStationList.Add(new LineStation
            {
                LineId = 1,
                Station = 119,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 1,
                Station = 120,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            // Line 2
            lineStationList.Add(new LineStation
            {
                LineId = 2,
                Station = 210,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 2,
                Station = 211,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 2,
                Station = 212,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 2,
                Station = 213,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 2,
                Station = 214,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 2,
                Station = 215,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 2,
                Station = 216,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 2,
                Station = 217,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 2,
                Station = 218,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });


            lineStationList.Add(new LineStation
            {
                LineId = 2,
                Station = 219,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 2,
                Station = 220,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            // Line 3
            lineStationList.Add(new LineStation
            {
                LineId = 3,
                Station = 310,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 3,
                Station = 311,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 3,
                Station = 312,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 3,
                Station = 313,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 3,
                Station = 314,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 3,
                Station = 315,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 3,
                Station = 316,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 3,
                Station = 317,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 3,
                Station = 318,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });


            lineStationList.Add(new LineStation
            {
                LineId = 3,
                Station = 319,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 3,
                Station = 320,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            // Line 4
            lineStationList.Add(new LineStation
            {
                LineId = 4,
                Station = 410,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 4,
                Station = 411,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 4,
                Station = 412,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 4,
                Station = 413,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 4,
                Station = 414,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 4,
                Station = 415,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 4,
                Station = 416,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 4,
                Station = 417,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 4,
                Station = 418,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });


            lineStationList.Add(new LineStation
            {
                LineId = 4,
                Station = 419,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 4,
                Station = 420,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            // Line 5
            lineStationList.Add(new LineStation
            {
                LineId = 5,
                Station = 510,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 5,
                Station = 511,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 5,
                Station = 512,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 5,
                Station = 513,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 5,
                Station = 514,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 5,
                Station = 515,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 5,
                Station = 516,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 5,
                Station = 517,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 5,
                Station = 518,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });


            lineStationList.Add(new LineStation
            {
                LineId = 5,
                Station = 519,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 5,
                Station = 520,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            // Line 6
            lineStationList.Add(new LineStation
            {
                LineId = 6,
                Station = 610,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 6,
                Station = 611,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 6,
                Station = 612,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 6,
                Station = 613,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 6,
                Station = 614,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 6,
                Station = 615,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 6,
                Station = 616,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 6,
                Station = 617,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 6,
                Station = 618,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });


            lineStationList.Add(new LineStation
            {
                LineId = 6,
                Station = 619,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 6,
                Station = 620,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            // Line 7
            lineStationList.Add(new LineStation
            {
                LineId = 7,
                Station = 710,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 7,
                Station = 711,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 7,
                Station = 712,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 7,
                Station = 713,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 7,
                Station = 714,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 7,
                Station = 715,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 7,
                Station = 716,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 7,
                Station = 717,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 7,
                Station = 718,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });


            lineStationList.Add(new LineStation
            {
                LineId = 7,
                Station = 719,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 7,
                Station = 720,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            // Line 8
            lineStationList.Add(new LineStation
            {
                LineId = 8,
                Station = 810,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 8,
                Station = 811,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 8,
                Station = 812,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 8,
                Station = 813,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 8,
                Station = 814,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 8,
                Station = 815,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 8,
                Station = 816,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 8,
                Station = 817,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 8,
                Station = 818,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });


            lineStationList.Add(new LineStation
            {
                LineId = 8,
                Station = 819,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 8,
                Station = 820,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            // Line 9
            lineStationList.Add(new LineStation
            {
                LineId = 9,
                Station = 910,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 9,
                Station = 911,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 9,
                Station = 912,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 9,
                Station = 913,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 9,
                Station = 914,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 9,
                Station = 915,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 9,
                Station = 916,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 9,
                Station = 917,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 9,
                Station = 918,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });


            lineStationList.Add(new LineStation
            {
                LineId = 9,
                Station = 919,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 9,
                Station = 920,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            // Line 10
            lineStationList.Add(new LineStation
            {
                LineId = 10,
                Station = 1010,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 10,
                Station = 1011,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 10,
                Station = 1012,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 10,
                Station = 1013,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 10,
                Station = 1014,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 10,
                Station = 1015,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 10,
                Station = 1016,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 10,
                Station = 1017,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 10,
                Station = 1018,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });


            lineStationList.Add(new LineStation
            {
                LineId = 10,
                Station = 1019,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 10,
                Station = 1020,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            // Line 11
            lineStationList.Add(new LineStation
            {
                LineId = 11,
                Station = 1110,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 11,
                Station = 1111,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 11,
                Station = 1112,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 11,
                Station = 1113,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 11,
                Station = 1114,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 11,
                Station = 1115,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 11,
                Station = 1116,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 11,
                Station = 1117,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 11,
                Station = 1118,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });


            lineStationList.Add(new LineStation
            {
                LineId = 11,
                Station = 1119,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 11,
                Station = 1120,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            // Line 12
            lineStationList.Add(new LineStation
            {
                LineId = 12,
                Station = 1210,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12,
                Station = 1211,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12,
                Station = 1212,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12,
                Station = 1213,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12,
                Station = 1214,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12,
                Station = 1215,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12,
                Station = 1216,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12,
                Station = 1217,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12,
                Station = 1218,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });


            lineStationList.Add(new LineStation
            {
                LineId = 12,
                Station = 1219,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 12,
                Station = 1220,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            // Line 13
            lineStationList.Add(new LineStation
            {
                LineId = 13,
                Station = 1310,
                LineStationIndex = 0,
                PrevStation = 100220,
                NextStation = 100240,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 13,
                Station = 1311,
                LineStationIndex = 1,
                PrevStation = 100230,
                NextStation = 100250,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 13,
                Station = 1312,
                LineStationIndex = 2,
                PrevStation = 100240,
                NextStation = -2,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 13,
                Station = 1313,
                LineStationIndex = 3,
                PrevStation = -1,
                NextStation = 100030,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 13,
                Station = 1314,
                LineStationIndex = 4,
                PrevStation = 100300,
                NextStation = 100320,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 13,
                Station = 1315,
                LineStationIndex = 5,
                PrevStation = 100030,
                NextStation = 100330,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 13,
                Station = 1316,
                LineStationIndex = 6,
                PrevStation = 100320,
                NextStation = 100210,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 13,
                Station = 1317,
                LineStationIndex = 7,
                PrevStation = 100330,
                NextStation = 100340,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 13,
                Station = 1318,
                LineStationIndex = 8,
                PrevStation = 100210,
                NextStation = 100350,
            });


            lineStationList.Add(new LineStation
            {
                LineId = 13,
                Station = 1319,
                LineStationIndex = 9,
                PrevStation = 100340,
                NextStation = 100360,
            });

            lineStationList.Add(new LineStation
            {
                LineId = 13,
                Station = 1320,
                LineStationIndex = 10,
                PrevStation = 100350,
                NextStation = 100370,
            });
            XMLTools.SaveListToXMLSerializer(lineStationList, @"LineStationXml.xml");
        }

    }

 }

