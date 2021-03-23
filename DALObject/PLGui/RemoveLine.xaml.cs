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
using BO;
namespace PLGui
{
    /// <summary>
    /// Interaction logic for RemoveLine.xaml
    /// </summary>
    public partial class RemoveLine : Window
    {
        List<BO.Line> lines;
        BO.Line line = new BO.Line();
        IBL bl = BLFactory.GetBL();
        public RemoveLine()
        {
            InitializeComponent();
            lines = bl.getAllLine().ToList();
            this.DataContext = lines;

            idComboBox.ItemsSource = lines;
            idComboBox.DisplayMemberPath = "busLineNumber";
        }
      

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {

            Line toDelete = bl.getAllLine().ToList()[idComboBox.SelectedIndex];
            bl.deleteLine(toDelete);
            foreach (LineStation s in bl.GetAllLineStation())
            {
                if (s.LineId == toDelete.Id)
                    bl.RemoveLineStation(s);
            }
            MessageBox.Show("Line deleted successfully !");
   

            this.Close();
        }

        
    }
}
