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
using System.Windows.Shapes;

namespace PLGui
{
    /// <summary>
    /// Interaction logic for UpdateStationWindow.xaml
    /// </summary>
    public partial class UpdateStationWindow : Window
    {
        Station stationtoupdate;
        Stationn myprecwin;
        IBL bl=BLFactory.GetBL();
        public UpdateStationWindow(Stationn prec_win)
        {
            InitializeComponent();
            myprecwin = prec_win;
            List<int> codes = new List<int>();
            foreach(var item in bl.getAllStation())
            {
                codes.Add(item.code);
            }
            this.stationcodecombobox.ItemsSource = codes;
           // stationtoupdate = mystation;
           // DataContext = stationtoupdate;
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // stationtoupdate.code = int.Parse(this.codeTextBox.Text);
            stationtoupdate.latitude = int.Parse(this.latitudeTextBox.Text);
            stationtoupdate.longitude = int.Parse(this.longitudeTextBox.Text);
            stationtoupdate.handicap = false;
            if (this.handicapCheckBox.IsChecked == true)
            {
                stationtoupdate.handicap = true;
            }
            stationtoupdate.name = this.nameTextBox.Text;
            bl.updateStation(stationtoupdate);
            MessageBox.Show("update successfully");
            myprecwin.refreshAllStations();
            this.Close();
        }

        private void stationcodecombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int code = (int)stationcodecombobox.SelectedItem;
            foreach(var item in bl.getAllStation())
            {
                if(item.code==code)
                {
                    stationtoupdate = item;
                    break;
                }
            }
            DataContext = stationtoupdate;
        }
    }
}
