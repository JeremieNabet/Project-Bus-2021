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
using BO;
using BLAPI;
namespace PLGui
{
    /// <summary>
    /// Logique d'interaction pour Updatetimedistance.xaml
    /// </summary>
    public partial class Updatetimedistance : Window
    {
        IBL bl;
        LineStation first;
        public Updatetimedistance(IBL ba,int s1,int s2)
        {
            InitializeComponent();
            bl = ba;
            first = bl.GetAllLineStation().ToList().Find(item => item.ID == s1);
            LineStation last = bl.GetAllLineStation().ToList().Find(item => item.ID == s2);
            First.Text = first.name;
            Second.Text = last.name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double test = 0;
            TimeSpan teston = new TimeSpan();
            bool check = double.TryParse(DistancetoCommit.Text, out test);
            bool check2 = TimeSpan.TryParse(Timetocommit.Text, out teston);
            if (check && check2)
            {
                AdjacentStations temp = bl.getAllAdjacentStations().ToList().Find(item => item.Station1 == first.ID);
                int checkk = temp.Id;
                int rrr = temp.Station1;
                int ss = temp.Station2;
                if(temp!=null)
                {
                    temp.Distance = test;
                    temp.Time = teston;
                }
                bl.updateAdjacentStations(temp);
                MessageBox.Show("Commit made successfully !");
                this.Close();
            }
            else
                MessageBox.Show("Error of format !");
        }
    }
}
