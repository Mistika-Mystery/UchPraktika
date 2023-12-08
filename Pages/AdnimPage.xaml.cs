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
    /// Логика взаимодействия для AdnimPage.xaml
    /// </summary>
    public partial class AdnimPage : Page
    {
        public AdnimPage()
        {
            InitializeComponent();
        }

        private void RequestBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Jornal());
        }

        private void UserBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersJornal());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoleJornal());
        }
    }
}
