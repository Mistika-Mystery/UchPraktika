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
            
        }

        private void LogBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GlavPage());
        }

        private void AddRolBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditRole(null));
        }

        private void AdminBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdnimPage());
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            var delRole = RoleDG.SelectedItems.Cast<Role>().ToList();
            if (MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    UchPractikEntities1.GetContext().Role.RemoveRange(delRole);
                    UchPractikEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Пользователь удален!");
                    RoleDG.ItemsSource = UchPractikEntities1.GetContext().Role.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }    
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditRole((sender as Button).DataContext as Role));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility== Visibility.Visible)
            {
                UchPractikEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p=> p.Reload());
                RoleDG.ItemsSource = UchPractikEntities1.GetContext().Role.ToList();
            }
        }
    }
}
