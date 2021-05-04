using BLAPI;
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
    /// Interaction logic for AddWinBus.xaml
    /// </summary>
    public partial class AddWinBus : Window
    {
        IBL bl = BLFactory.GetBL();
        public BO.Bus mybus;
        public AddWinBus()
        {
            InitializeComponent();
            mybus = new BO.Bus();
            busStatusComboBox.ItemsSource = Enum.GetValues(typeof(BO.Status));
            DataContext = mybus;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (busStatusComboBox.SelectedIndex == -1)
                MessageBox.Show("Select the status !");
            else
            {
                BO.Status mystatus = (BO.Status)busStatusComboBox.SelectedItem;
                int tes;
                double test2;
                double test3;
                bool check = int.TryParse(licenseNumTextBox.Text, out tes);
                bool check22 = double.TryParse(totalTripTextBox.Text, out test2);
                bool check3 = double.TryParse(fuelRemainTextBox.Text, out test3);


                //if (licenseNumTextBox.Text == null ||
                //    fromDateDatePicker.SelectedDate == null
                //    || totalTripTextBox.Text ==null || fuelRemainTextBox.Text == null ||
                //    busStatusComboBox.SelectedItem == null)
                //{
                //    AddButton.IsEnabled = false;
                //}
                //else
                //{
                //    AddButton.IsEnabled = true;
                if (check && check22 && check3&&licenseNumTextBox.Text.Length>0)
                {
                    try
                    {
                        bl.AddBus(mybus);
                        MessageBox.Show("added successfully!");
                        this.Close();
                    }
                    catch (BO.BLException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Error of input !");
            }
        }
    }
    
}
