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
    /// Interaction logic for AddNewUser.xaml
    /// </summary>
    public partial class AddNewUser : Window
    {
        IBL bl;
        User user;
        public AddNewUser(IBL ba)
        {
            InitializeComponent();
            user = new User();
            bl = ba;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user.UserName = Tb_username.Text;
            user.Password = Tb_password.Text;
            user.email = Tb_email.Text;
            user.Admin = true;

            bl.createUser(user);

            this.Close();
        }

    }
}
