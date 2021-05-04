using System;
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
using BL;
using BLAPI;
namespace PLGui
{
    /// <summary>
    /// Logique d'interaction pour StationsLine.xaml
    /// </summary>
    public partial class StationsLine : Window
    {
        IBL bl;
        LineStation temp;
        LineStation toPresent;
        bool flag = false;
        Line s;
        public StationsLine(IBL ba)
        {
            InitializeComponent();
            bl = ba;
            myStation.ItemsSource = bl.GetAllLineStation();
        }
        private void Changed(object sender, SelectionChangedEventArgs e)
        {
            //double d = temp.Distance;

        }
        void checkMatsav()
        {
            int sav = myLine.SelectedIndex;
            if(flag&&myLine.SelectedIndex!=-1)
            {
                LineStation check = bl.GetAllLineStation().ToList().Find(item => item.Station.ToString() == StationCodetxtbox.Text);

                temp = bl.findlineForStation(bl.GetAllLineStation().ToList().Find(item => item.ID == check.ID));
                foreach (Line l in temp.myLines)
                {
                    foreach (LineStation sl in l.listStations)
                    {
                        bl.getmyTime(sl);
                    }
                }
                next.Text = temp.myLines[myLine.SelectedIndex].listStations.Find(item => item.Station.ToString() == StationCodetxtbox.Text).NextStation.ToString();
                Time.Text = temp.myLines[myLine.SelectedIndex].listStations.Find(item => item.Station.ToString() == StationCodetxtbox.Text).Temps.ToString();
                Terminus.Text = temp.myLines[myLine.SelectedIndex].LastStation.ToString();
                Distance.Text = temp.myLines[myLine.SelectedIndex].listStations.Find(item => item.Station.ToString() == StationCodetxtbox.Text).Distance.ToString();
            }
        }
        private void LineChanged(object sender, SelectionChangedEventArgs e)
        {
            checkMatsav();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Exit Button
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//Update distance/time button
        {
            if (flag == true && myLine.SelectedIndex != -1)//It means that we have type a station in the txtbox
            {
                int index = temp.myLines[myLine.SelectedIndex].listStations.FindIndex(item => item.Station == temp.Station);

                if (index == temp.myLines[myLine.SelectedIndex].listStations.Count)
                {
                    Updatetimedistance win = new Updatetimedistance(bl, temp.myLines[myLine.SelectedIndex].listStations[index].ID, temp.myLines[myLine.SelectedIndex].listStations[0].ID);
                    win.ShowDialog();
                }
                else
                {
                    Updatetimedistance win = new Updatetimedistance(bl, temp.myLines[myLine.SelectedIndex].listStations[index].ID, temp.myLines[myLine.SelectedIndex].listStations[index + 1].ID);
                    win.ShowDialog();
                }
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Search Button
        {
            LineStation check = bl.GetAllLineStation().ToList().Find(item => item.Station.ToString() == StationCodetxtbox.Text);
            temp = null;
            if(StationCodetxtbox.Text.Length==0)
            {
                MessageBox.Show("Type a station first !");
            }
            else if(check!= null)
            {
                temp = bl.findlineForStation(bl.GetAllLineStation().ToList().Find(item=>item.ID==check.ID));
                myLine.ItemsSource = temp.myLines;
                myLine.SelectedIndex = 0;
                foreach(AdjacentStations si in bl.getAllAdjacentStations())
                {
                    double cc = si.Distance;
                }
                flag = true;
                foreach(Line l in temp.myLines)
                {
                    foreach(LineStation sl in l.listStations)
                    {
                        bl.getmyTime(sl);
                    }
                }

                next.Text = temp.myLines[0].listStations.Find(item => item.Station.ToString() == StationCodetxtbox.Text).NextStation.ToString();
                Time.Text = temp.myLines[0].listStations.Find(item => item.Station.ToString() == StationCodetxtbox.Text).Temps.ToString();
                Terminus.Text = temp.myLines[0].LastStation.ToString();
                Distance.Text = temp.myLines[0].listStations.Find(item => item.Station.ToString() == StationCodetxtbox.Text).Distance.ToString();

            }
            else
            {
                MessageBox.Show("Station not found !");
            }

        }
    }
}
