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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
       
        public ServicePage(int idCategory)
        {
            InitializeComponent();
            ServiceListInfo.ItemsSource = ServiceController.GetInfoCategory(idCategory);
            Title_TextBlock.Text= ServiceCategoryesController.GetInfoCategoryes(idCategory).CategoryTitle;
        }

        private void GridMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SignServices.Visibility = Visibility.Visible;
        }

        private void RecordButtonClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(EnterDate_TextBox.Text)&&!String.IsNullOrEmpty(EnterTime_TextBox.Text))
            {
                SignServices.Visibility = Visibility.Collapsed;
                MessageBox.Show("Господи помилуй, тебя записали !!!");

            }
            else
            {
                MessageBox.Show("Боже упаси, введи данные!!!");
            }
        }

        private void RecordCloseClick(object sender, RoutedEventArgs e)
        {
            SignServices.Visibility = Visibility.Collapsed;
        }
    }
}
