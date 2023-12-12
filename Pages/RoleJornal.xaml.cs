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

namespace UchPraktika.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoleJornal.xaml
    /// </summary>
    public partial class RoleJornal : Page
    {
        public RoleJornal()
        {
            InitializeComponent();
            RoleDG.ItemsSource=UchPractikEntities1.GetContext().Role.ToList();
        }

        private void LogBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GlavPage());
        }

        private void AddRolBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditRole());
        }

        private void AdminBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdnimPage());
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
