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
using BLAPI;
using BL.BO;
namespace PLGui
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        IBL bl;
        SimulatorClock simultorClock;
        public Menu(IBL ba)
        {
            simultorClock = SimulatorClock.Instance;
            
            InitializeComponent();
            myGrid.DataContext = simultorClock;
            bl = ba;
            this.mycontent.Content = new Buss(bl);
        }

        private void Button_Line_Click(object sender, RoutedEventArgs e)
        {
            this.mycontent.Content = new Linee(bl,simultorClock);
        }

        private void Button_Station_Click(object sender, RoutedEventArgs e)
        {
            this.mycontent.Content = new Stationn(bl);
        }

        private void Button_Bus_Click(object sender, RoutedEventArgs e)
        {
            this.mycontent.Content = new Buss(bl);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            generalcontent.Content = new Login(bl);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SimuParameter win = new SimuParameter(bl);
            win.ShowDialog();
            myHours.Visibility = Visibility.Visible;
            

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            bl.StopSimulator();
            myHours.Visibility = Visibility.Hidden;
        }
    }
}
