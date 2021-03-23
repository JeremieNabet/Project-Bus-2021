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

namespace PLGui
{
    /// <summary>
    /// Interaction logic for RemoveLineStation.xaml
    /// </summary>
    public partial class RemoveLineStation : Window
    {
        List<Station> stations;

        IBL bl = BLFactory.GetBL();
        BO.LineStation line = new BO.LineStation();
        public RemoveLineStation()
        {
            InitializeComponent();
            this.DataContext = line;
            stations = bl.getAllStation().ToList();
            idComboBox.ItemsSource = bl.getAllLine();
            nameComboBox.ItemsSource = stations;
            nameComboBox.DisplayMemberPath = "name";
            nameComboBox.SelectedIndex = 0;

            idComboBox.DisplayMemberPath = "busLineNumber";
            idComboBox.SelectedIndex = 0;
        }
        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            line.LineId = stations[index].code;
        }
        private void nameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            line.LineStationIndex = stations[index].code.ToString();
        }
        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            Station s = bl.getAllStation().ToList()[nameComboBox.SelectedIndex];
            Line l = bl.getLines()[idComboBox.SelectedIndex];
            if(!l.listStations.Exists(item=>item.Station==s.code))
            {
                MessageBox.Show("The station selected does not belong to the line !");
            }
            else
            {

                LineStation toDelete = bl.GetAllLineStation().ToList().Find(item => item.Station == s.code && item.LineId == l.Id);
                bl.RemoveLineStation(toDelete);
                MessageBox.Show("Station was removed successfully !");
                this.Close();
            }

            
        }
    }
}
