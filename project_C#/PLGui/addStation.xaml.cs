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
    /// Interaction logic for addStation.xaml
    /// </summary>
    public partial class addStation : Window
    {
        public BO.Station mystation;
        public IBL bl;
        public addStation()
        {
            InitializeComponent();
            mystation = new BO.Station();
            bl = BLFactory.GetBL();
        }

      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int test = 0;
            bool check = int.TryParse(codeTextBox.Text, out test);
            bool check2 = int.TryParse(latitudeTextBox.Text, out test);
            bool check3 = int.TryParse(longitudeTextBox.Text, out test);
            if (codeTextBox.Text.Length==0||latitudeTextBox.Text.Length==0||longitudeTextBox.Text.Length==0)
            {
                MessageBox.Show("Missing data !");
            }
            
            else if (check&&check2&&check3)
            {
                mystation.code = int.Parse(this.codeTextBox.Text);

                mystation.latitude = int.Parse(this.latitudeTextBox.Text);
                mystation.longitude = int.Parse(this.longitudeTextBox.Text);
                mystation.handicap = false;
                if (this.handicapCheckBox.IsChecked == true)
                {
                    mystation.handicap = true;
                }
                if (nameTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Precise a name of the station please !");
                }
                else
                {
                    try
                    {
                        mystation.name = this.nameTextBox.Text;
                        bl.addStation(mystation);
                        MessageBox.Show("added successfully");
                        this.Close();
                    }
                    catch (BO.BLException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Only integer value !");
            }
           
        }
    }
}
