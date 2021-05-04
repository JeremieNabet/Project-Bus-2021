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
using System.Windows.Shapes;

namespace PLGui
{
    /// <summary>
    /// Logique d'interaction pour Stationn.xaml
    /// </summary>
    public partial class Stationn : UserControl
    {
        IBL bl;
        public Stationn(IBL ba)
        {
            InitializeComponent();
            bl = ba;
            listStation.ItemsSource = bl.getAllStation();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new addStation().ShowDialog();
            refreshAllStations();
        }
        public void refreshAllStations()
        {
            listStation.ItemsSource = bl.getAllStation();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new UpdateStationWindow(this).ShowDialog();
            refreshAllStations();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new RemoveStationWin(this).ShowDialog();
            refreshAllStations();
        }

        private void listStation_SelectionChanged(object sender, MouseButtonEventArgs e)
        {
            Station mystation = (Station)listStation.SelectedItem;
            DispStation win = new DispStation(mystation);
            win.ShowDialog();
            refreshAllStations();
        }
    }
}
