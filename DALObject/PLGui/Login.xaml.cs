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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BO;


namespace PLGui
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public IBL bl;
        public Login(IBL ba)
        {
            InitializeComponent();
            bl = ba;
            
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string myusername = identifier.Text;
            string mypassword = password.Password;
            bool access=bl.login(myusername, mypassword);
            if(access)
            {
                //affciher le menu 
                mycontent.Content = new Menu(bl);
            }
            else
            {
                MessageBox.Show("identifiant or password error");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewUser addNewUser = new AddNewUser(bl);
            addNewUser.ShowDialog();
        }

        private void resetPassword_Click(object sender, RoutedEventArgs e)
        {
            User a = new User();
            a.UserName = identifier.Text;
            if (identifier.Text.Length == 0)
                    MessageBox.Show("Type your username please");
            else if (bl.getAllUser().ToList().Exists(item => item.UserName == a.UserName))
                {
                   try
                    {
                        bl.resetpwd(a);
                        
                        MessageBox.Show("Your password is now in your mail message");
                    }
                    catch (BLException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("You're not from us !");
            
        }
    }
}
