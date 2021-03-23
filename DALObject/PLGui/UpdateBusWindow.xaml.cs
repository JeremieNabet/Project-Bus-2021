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
    /// Interaction logic for UpdateBusWindow.xaml
    /// </summary>
    public partial class UpdateBusWindow : Window
    {
        IBL bl = BLFactory.GetBL();
        Bus bustoupdate;
        Buss mywinprec;

        public UpdateBusWindow(Buss prec_win)
        {
            InitializeComponent();

            //fromDateDatePicker.SelectedDate = System.DateTime.Now;
            //fromDateDatePicker.DisplayDateStart = System.DateTime.Now;
            //fromDateDatePicker.DisplayDate = System.DateTime.Now;
            //fromDateDatePicker.DisplayDateEnd = System.DateTime.Now;

            bustoupdate = new Bus();
            mywinprec = prec_win;
            List<int> mylicenselist = new List<int>();
            foreach(var item in prec_win.listbus.ItemsSource)
            {
                
                mylicenselist.Add(((Bus)item).LicenseNum);
            }
            busLicenseComboBox.ItemsSource = mylicenselist;
            busStatusComboBox.ItemsSource = Enum.GetValues(typeof(BO.Status));
            DataContext = bustoupdate;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            BO.Status mystatus = (BO.Status)busStatusComboBox.SelectedItem;

            bustoupdate.FromDate = (DateTime)fromDateDatePicker.SelectedDate;
            bustoupdate.TotalTrip = Double.Parse(totalTripTextBox.Text);
            bustoupdate.FuelRemain = Double.Parse(fuelRemainTextBox.Text);

            bl.updateBus(bustoupdate);
            MessageBox.Show("updated successfully!");
            mywinprec.refreshAllBus();
            this.Close();

        }

        private void busLicenseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int license = (int)busLicenseComboBox.SelectedItem;
            foreach(var item in bl.getAllBus())
            {
                if(item.LicenseNum==license)
                {
                    bustoupdate = item;
                    break;
                }
            }
            DataContext = bustoupdate;
        }
    }
}
