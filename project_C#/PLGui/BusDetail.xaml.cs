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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLGui
{
    /// <summary>
    /// Interaction logic for BusDetail.xaml
    /// </summary>
    public partial class BusDetail : UserControl
    {
        IBL bl;
        public BusDetail()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();

        }

       
    }
}
