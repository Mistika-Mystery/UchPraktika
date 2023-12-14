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
    /// Логика взаимодействия для Jornal.xaml
    /// </summary>
    public partial class Jornal : Page
    {
        public Jornal()
        {
            InitializeComponent();
            JornalDG.ItemsSource=UchPractikEntities1.GetContext().Requests.ToList();
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void LogBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GlavPage());
        }

        private void AdminPanelBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdnimPage());
        }

        private void CreateBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditJornal());
        }
    }
}
