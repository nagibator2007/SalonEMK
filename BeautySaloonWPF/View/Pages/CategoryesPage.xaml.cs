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
    /// Логика взаимодействия для Categoryes.xaml
    /// </summary>
    public partial class CategoryesPage : Page
    {
        int idCategory;
        public CategoryesPage()
        {
            InitializeComponent();
            ServiceListView.ItemsSource = ServiceCategoryesController.GetServiceCategoryes();
        }

     

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid activeCategory = sender as Grid;
            ServicesCategoryes activeData = activeCategory.DataContext as ServicesCategoryes;
            idCategory = activeData.CategoryId;
            this.NavigationService.Navigate(new ServicePage(idCategory));
        }
    }
}
