﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BO;
using BL.BO;
using BLAPI;
using System.Windows.Threading;

namespace PLGui
{
    /// <summary>
    /// Logique d'interaction pour Simulation.xaml
    /// </summary>
    public partial class Simulation : Window
    {
        IBL instance;

        public SimulatorClock simulatorClock;
        DispatcherTimer TimerLeft;


        LineTiming s;
        LineStation temp;
        /// <summary>
        /// Here we starting with a check of the current hours to know if the line is on service or not
        /// </summary>
        public Simulation(LineStation station, IBL b, SimulatorClock sC)
        {
            InitializeComponent();
            s = new LineTiming();
            simulatorClock = sC;
            instance = b;
            temp = station;
          
            temp.myLines.Clear();
            instance.findlineForStation(temp);
            Uri myl = new Uri("https://drive.google.com/uc?export=download&id=1hXhXr4kTw4hQkomZZGF9XGe96UOy55-H", UriKind.RelativeOrAbsolute);
            var image = new BitmapImage(myl);
            myBus.Source = image;
            myl = new Uri("https://drive.google.com/uc?export=download&id=1cTQC49etPREUPvbq1azgo4vEfHQuUR_s", UriKind.RelativeOrAbsolute);
            image = new BitmapImage(myl);
            myTimer.Source = image;
            foreach(Line l in instance.getLines())
            {

            }
            IEnumerable<LineTiming> myTiming = s.getmyTimings(temp,simulatorClock.Time);
            Info.DataContext = myTiming;
            //myTiming.ToList().ForEach(item => ServiceEnded(item));

            myTiming.ToList().ForEach(item => MakeTimer(item, simulatorClock.Rate));
        }
        /// <summary>
        /// The main function to update the time every seconds but according to the rate in order to know how much seconds we have to substract
        /// </summary>
        private void MakeTimer(LineTiming clas, int rate)
        {
            TimerLeft = new DispatcherTimer();
            TimerLeft.Start();
            TimerLeft.Interval = new TimeSpan(0, 0, 1);
            TimerLeft.Tick += (s, args) =>
            {
                check(clas, rate);
                //clas.MyTime = clas.MyTime.Subtract(TimeSpan.FromSeconds(1));
                if (clas.TimeBeforeArrival.Seconds == 0)
                {
                    if (clas.TimeBeforeArrival.Minutes > 0)
                    {
                        clas.TimeBeforeArrival = clas.TimeBeforeArrival.Subtract(TimeSpan.FromMinutes(1));
                        clas.TimeBeforeArrival = clas.TimeBeforeArrival.Add(TimeSpan.FromSeconds(59));
                    }
                    else if (clas.TimeBeforeArrival.Minutes == 0 && clas.TimeBeforeArrival.Hours > 0)
                    {
                        clas.TimeBeforeArrival = clas.TimeBeforeArrival.Subtract(TimeSpan.FromHours(1));
                        clas.TimeBeforeArrival = clas.TimeBeforeArrival.Add(TimeSpan.FromMinutes(59));
                        clas.TimeBeforeArrival = clas.TimeBeforeArrival.Add(TimeSpan.FromSeconds(59));

                    }

                    else
                        clas.TimeBeforeArrival = new TimeSpan(0, clas.Freq, 0);
                }
                else
                {

                    clas.TimeBeforeArrival = clas.TimeBeforeArrival.Subtract(TimeSpan.FromSeconds(rate));


                }


            };
        }
        void check(LineTiming s,int rate)
        {
            if(s.TimeBeforeArrival.Hours==0&&s.TimeBeforeArrival.Minutes==0)
            {
                if(s.TimeBeforeArrival.Seconds-rate<=0)
                {
                    s.TimeBeforeArrival = new TimeSpan(0, 10, 0);
                }
            }
        }

        /// <summary>
        /// This function calculate the time we need to the next start of service ( this function will be used only if the current time is not in the line's service)
        /// </summary>
        //void ServiceEnded(LineTiming line)//This function handle the case that the line is not in  service
        //{
        //    int id = instance.getAllAllLine().ToList().Find(item => item.busLineNumber == line.BusLineNumber).ID;
        //    TimeSpan debut = instance.getmySchedules().ToList().Find(item => item.IdBus == id).Start;
        //    TimeSpan fin = instance.getmySchedules().ToList().Find(item => item.IdBus == id).End;
        //    int h1 = simulatorClock.Time.Hours;
        //    int h2 = debut.Hours;
        //    if (simulatorClock.Time.Hours >= fin.Hours || simulatorClock.Time.Hours < debut.Hours)
        //    {
        //        if (h2 - h1 > 0)//After midnight,ex : h2=06:00:00 , h1=01:00:00
        //        {
        //            line.TimeBeforeArrival = new TimeSpan(h2 - h1 - 1, 60 - simulatorClock.Time.Minutes, 60 - simulatorClock.Time.Seconds);

        //        }
        //        else if (h2 - h1 < 0)//Before midnight,ex  :h2=06:00:00 ,h1=23:00:00
        //        {

        //            line.TimeBeforeArrival = new TimeSpan(23 + h2 - h1, 60 - simulatorClock.Time.Minutes, 60 - simulatorClock.Time.Seconds);



        //        }
        //        else
        //        {

        //            line.TimeBeforeArrival = new TimeSpan(debut.Hours, 60 - simulatorClock.Time.Minutes, 60 - simulatorClock.Time.Seconds);
        //        }
        //    }



        //}
        /// <summary>
        /// It check if the line is already arrived ,if yes so the time restart to the frequencies of the line
        /// </summary>
        //private void Check(LineTiming objet, int rate)//This function check if the bus is arrive to the station then we add to the station frequencies time of the Line
        //{
        //    var temp = (Line)instance.getAllAllLine().ToList().Find(line => line.busLineNumber == objet.BusLineNumber);
        //    int id = temp.Id;
        //    TimeSpan realCheck = objet.TimeBeforeArrival;
        //    realCheck = realCheck.Subtract(TimeSpan.FromSeconds(rate));
        //    TimeSpan beginAt = instance.getAllAdjacentStations().ToList().Find(item => item. == id).Start;
        //    if (realCheck.Seconds <= 0 && realCheck.Hours == 0 && realCheck.Minutes == 0)
        //    {
        //        objet.TimeBeforeArrival = new TimeSpan(0, objet.Freq, 0);
        //    }

        //}



    }
}
