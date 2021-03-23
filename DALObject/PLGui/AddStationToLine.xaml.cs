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
    /// Interaction logic for AddStationToLine.xaml
    /// </summary>
    public partial class AddStationToLine : Window
    {
        List<BO.Line> lines;
        
        List<BO.Station> stations;
        IBL bl;
        BO.LineStation line = new BO.LineStation();
        List<int> indexation;
        public AddStationToLine(IBL ba)
        {
            bl = ba;
            InitializeComponent();
            this.DataContext = line;
            lines = bl.getAllLine().ToList();
            stations = bl.getAllStation().ToList();

            idComboBox.ItemsSource = lines;
            idComboBox.DisplayMemberPath = "busLineNumber";

            nameComboBox.ItemsSource = stations;
            nameComboBox.DisplayMemberPath = "code";

            idComboBox.SelectedIndex = 0;
            nameComboBox.SelectedIndex = 0;


           
        }
        private void nameComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            line.Station = stations[index].code;
        }
        private void idComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            line.LineId = lines[index].Id;
            indexation = new List<int>();
            for (int a = 0; a < bl.getLines()[idComboBox.SelectedIndex].listStations.Count; a++)
                indexation.Add(a);
            IndexCombo.ItemsSource = indexation;

        }
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Station s = bl.getAllStation().ToList()[nameComboBox.SelectedIndex];
            Line l = bl.getLines()[idComboBox.SelectedIndex];
         
            if (l.listStations.Exists(station => station.Station == s.code))
            {
                MessageBox.Show("This station already exists in this line !");

            }
            else
            {
                line = bl.fromStation(stations[nameComboBox.SelectedIndex]);
                line.LineId = l.Id;
                if (IndexCombo.SelectedIndex != -1)
                {
                    AdjacentStations toAd;
                    line.LineStationIndex = (IndexCombo.SelectedIndex).ToString();
                    bl.createLineStation(line);
                    line = bl.GetAllLineStation().ToList().Find(item => item.LineId ==l.Id && item.Station == line.Station);
                    if (int.Parse(line.LineStationIndex) == l.listStations.Count - 1)
                    {
                       toAd = new AdjacentStations(line, l.listStations[l.listStations.Count - 1]);
                    }
                    else
                    {
                       toAd = new AdjacentStations(line, l.listStations[int.Parse(line.LineStationIndex) + 1]);
                    }
                    bl.addAdjacentStations(toAd);
                   
                    MessageBox.Show("Station added successfully !");
                    this.Close();
                }
                else
                    MessageBox.Show("Precise an index please !");
                
              
            }
        }

        
    }
}
