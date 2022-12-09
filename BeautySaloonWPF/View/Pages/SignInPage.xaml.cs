using BeautySaloonWPF.Controllers;
using BeautySaloonWPF.View.Windows;
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

namespace BeautySaloonWPF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();

        }

        private void SignInbutton_Click(object sender, RoutedEventArgs e)
        {
            //if (UsersController.Auth(LoginTextBox.Text, PasswordPasswordBox.Password))
            //{
            //    CategoryesWindows categoryesWindows = new CategoryesWindows();
            //    categoryesWindows.ShowDialog();
            //}
            if (UsersController.Auth(LoginTextBox.Text, PasswordPasswordBox.Password))
            {
                this.NavigationService.Navigate(new CategoryesPage());
            }
            else
            {
                this.NavigationService.Navigate(new SignUpPage());
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SignUpPage());
        }
    }
}
