using BeautySaloonWPF.Controllers;
using BeautySaloonWPF.Models;
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
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Users newUser = new Users
            {
                IdRole = 2,
                UserName =NameTextBox.Text, 
                UserLastName = LastNameTextBox.Text,
                UserOtherName = OtherNamaTextBox.Text,
                UserPassword = PasswordPasswordBox.Password,
                UserLogin = LoginTextBox.Text
                
            };
            string corectSymbols = "qwertyuiopasdfghjklzxcvbnm1234567890-_.";
            if (!LoginTextBox.Text.All(x=>corectSymbols.Contains(x)))
            {
                MessageBox.Show("логин соддержит не те символы...");
            }
            else
            {
                if (LoginTextBox.Text == String.Empty)
                {
                    MessageBox.Show("Логин напиши.");
                }
                else
                {
                    if (LoginTextBox.Text.EndsWith("."))
                    {
                        MessageBox.Show("Логин не может заканчиваться 'точкой'");
                    }
                    else
                    {
                        if (PasswordPasswordBox.Password != RepeatPasswordPasswordBox.Password)
                        {
                            MessageBox.Show("Чего ***?");
                        }
                        else
                        {
                            if (WriteCapthaTextBox.Text != CreateCapthaTextBlock.Text)
                            {
                                MessageBox.Show("Ты робот?");
                            }
                            else
                            {
                                if (PasswordPasswordBox.Password == RepeatPasswordPasswordBox.Password)
                                {
                                    MessageBox.Show("Поздравляю.");
                                    UsersController.AddUser(newUser);
                                    this.NavigationService.Navigate(new SignInPage());
                                }
                            }
                        }
                    }
                }
                
            }
           
        }

        private void CaptchaButtonClick(object sender, RoutedEventArgs e)
        {
            CreateCaptcha();
        }
        private void CreateCaptcha()
        {
            string allowchar = string.Empty;
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += " a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            string[] ar = allowchar.Split(a);
            string pwd = string.Empty;
            string temp = string.Empty;
            System.Random r = new System.Random();
            
            for(int i = 0; i < 6; i++)
            {
                temp = ar[r.Next(0, ar.Length)];
                pwd += temp;
            }
            CreateCapthaTextBlock.Text = pwd;
        }
    }
}
