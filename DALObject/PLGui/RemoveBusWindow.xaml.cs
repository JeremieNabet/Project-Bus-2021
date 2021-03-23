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
    /// Interaction logic for RemoveBusWindow.xaml
    /// </summary>
    public partial class RemoveBusWindow : Window
    {
        Buss mywinprec;
        IBL bl = BLFactory.GetBL();
        public RemoveBusWindow(Buss prec_win)
        {
            InitializeComponent();
            mywinprec = prec_win;
            List<int> mylicenselist = new List<int>();
            foreach (var item in prec_win.listbus.ItemsSource)
            {

                mylicenselist.Add(((Bus)item).LicenseNum);
            }
            busLicenseComboBox.ItemsSource = mylicenselist;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Bus dataObject=new Bus();
            int mylicense = (int)busLicenseComboBox.SelectedItem;
            foreach (var item in bl.getAllBus())
            {
                if (item.LicenseNum == mylicense)
                {
                    dataObject = item;
                    break;
                }
            }
            bl.deleteBus(dataObject);
            mywinprec.refreshAllBus();
            MessageBox.Show("remove successfully!");
            mywinprec.refreshAllBus();
            this.Close();
        }
    }
}
