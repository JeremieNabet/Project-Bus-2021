using BLAPI;
using BO;
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
using System.Windows.Navigation;
using BL.BO;
namespace PLGui
{
    /// <summary>
    /// Logique d'interaction pour Linee.xaml
    /// </summary>
    public partial class Linee : UserControl
    {
        SimulatorClock simulatorClock;
        IBL bl;
        public Linee(IBL ba,SimulatorClock s)
        {
            InitializeComponent();
            bl = ba;
            listLine.ItemsSource = bl.getAllLine();
            simulatorClock = s;
        }

        private void listLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listLine.SelectedIndex != -1)
            {
                stations_it_list.ItemsSource = bl.getLines()[listLine.SelectedIndex].listStations;
            }
        }

        private void ADDLINE(object sender, RoutedEventArgs e)
        {
            AddLineWin x = new AddLineWin();
            x.ShowDialog();

            refreshAll();

        }
        public void refreshAll()
        {
            listLine.ItemsSource = bl.getAllLine();
            stations_it_list.ItemsSource = bl.getAllLineStation();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RemoveLine remove = new RemoveLine();
            remove.ShowDialog();
            refreshAll();
            stations_it_list.ItemsSource = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddStationToLine addStation = new AddStationToLine(bl);
            addStation.ShowDialog();
            stations_it_list.ItemsSource = null;
            refreshAll();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RemoveLineStation removeLineStation = new RemoveLineStation();
            removeLineStation.ShowDialog();
            stations_it_list.ItemsSource = null;
            refreshAll();
 

        }
        private void SeeStationsLines(object sender,RoutedEventArgs e)
        {

            StationsLine win = new StationsLine(bl);
            win.ShowDialog();
            refreshAll();
        }

        private void stations_it_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (simulatorClock.Time.Seconds == -1)
                MessageBox.Show("Please activate the simulation !");
            else if(stations_it_list.SelectedIndex!=-1)
            {
                Simulation win = new Simulation(bl.getLines()[listLine.SelectedIndex].listStations[stations_it_list.SelectedIndex], bl, simulatorClock);
                win.ShowDialog();
            }
        }
    }
}
