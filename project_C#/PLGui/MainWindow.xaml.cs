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
namespace PLGui
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = BLFactory.GetBL();
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void Button_Nioul_Click(object sender, RoutedEventArgs e)
        {
            this.mycontent.Content = new Login(bl);
            //this.mycontent.Content =  new Menu(bl);
        }

        private void Button_Traveler_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This option is not available");
        }
    }
}
