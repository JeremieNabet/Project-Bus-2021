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
    /// Interaction logic for RemoveStationWin.xaml
    /// </summary>
    public partial class RemoveStationWin : Window
    {
        Stationn myprecwin;
        IBL bl = BLFactory.GetBL();
        public RemoveStationWin(Stationn prec_win)
        {
            InitializeComponent();
            myprecwin = prec_win;
            List<int> codes = new List<int>();
            foreach(var item in bl.getAllStation())
            {
                codes.Add(item.code);
            }
            codeComboBox.ItemsSource=codes;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Station dataObject=new Station();
            int code = (int)codeComboBox.SelectedItem;
            foreach (var item in bl.getAllStation())
            {
                if (item.code == code)
                {
                    dataObject = item;
                    break;
                }
            }
            bl.deleteStation(dataObject);
            myprecwin.refreshAllStations();
            MessageBox.Show("remove successfully!");
            this.Close();
        }
    }
}
