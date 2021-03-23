using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BO;
using BLAPI;
using System.Collections.Generic;

namespace PLGui
{
    /// <summary>
    /// Logique d'interaction pour Buss.xaml
    /// </summary>
    public partial class Buss : UserControl
    {
        IBL bl;
        
        public Buss(IBL ba)
        {
            InitializeComponent();
            bl = ba;
            listbus.ItemsSource = bl.getAllBus();
            
        }

        
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyBusContent.Content = new Menu(bl);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           new AddWinBus().ShowDialog();
            refreshAllBus();

        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            new RemoveBusWindow(this).ShowDialog();
            refreshAllBus();

        }
        public void refreshAllBus()
        {
            listbus.ItemsSource = bl.getAllBus();
        }

        private void listbus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bus mybus = (Bus)listbus.SelectedItem;
            new DispBus(mybus).ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new UpdateBusWindow(this).ShowDialog();
        }
    }
}
