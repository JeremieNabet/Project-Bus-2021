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
using BO;
namespace PLGui
{
    /// <summary>
    /// Interaction logic for AddLineWin.xaml
    /// </summary>
    public partial class AddLineWin : Window
    {
        List<Station> stations;
        IBL bl = BLFactory.GetBL();
        BO.Line line = new BO.Line();
        LineStation first = new LineStation();
        LineStation last = new LineStation();
        string[] areaList = { "Nord", "South", "West", "Est" };
        public AddLineWin()
        {
            InitializeComponent();
            this.DataContext = line;
            stations = bl.getAllStation().ToList();
            areasComboBox.ItemsSource = areaList.ToList();
            lastStationComboBox.ItemsSource = stations;
            firstStationComboBox.ItemsSource = stations;
            lastStationComboBox.DisplayMemberPath = "name";
            firstStationComboBox.DisplayMemberPath = "name";
            firstStationComboBox.SelectedIndex = 0;
            line.FirstStation = stations[0].code;
            lastStationComboBox.SelectedIndex = 0;
            line.LastStation = stations[0].code;
            areasComboBox.SelectedIndex = 0;
            line.Areas = (Area)0;

        }

        private void firstStationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            first = bl.fromStation(bl.getAllStation().ToList()[firstStationComboBox.SelectedIndex]);
           
        }

        private void lastStationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            last = bl.fromStation(bl.getAllStation().ToList()[lastStationComboBox.SelectedIndex]);

        }

        private void areasComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            line.Areas =(Area) areasComboBox.SelectedIndex;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            line.Id = r.Next(0, 1000);
            first.LineId = line.Id;
            last.LineId = line.Id;
            int test =0;
            bool check = int.TryParse(idTextBox.Text, out test);

            if (first.Station == last.Station)
            {
                MessageBox.Show("The departure must be different from the arrival !");
            }
            else if(check)
            {
                line.busLineNumber = test;
                bl.createLineStation(first);
                bl.createLine(line);

                bl.createLineStation(last);
                
                this.Close();
            }
            else
            {
                MessageBox.Show("Line number must be an integer !");
            }
        }
    }
}
