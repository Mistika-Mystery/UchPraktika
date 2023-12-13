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
    /// Логика взаимодействия для UsersJornal.xaml
    /// </summary>
    public partial class UsersJornal : Page
    {
        public UsersJornal()
        {
            InitializeComponent();
            
        }



        private void LogBTN_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GlavPage());
        }

        private void AdminPanelBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdnimPage());
        }

        private void CreateBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EddEditUserPage(null));
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EddEditUserPage((sender as Button).DataContext as User));
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            var delUser = UserDG.SelectedItems.Cast<User>().ToList();
         
            if (MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    UchPractikEntities1.GetContext().User.RemoveRange(delUser);
                    UchPractikEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Пользователь удален!");
                    UserDG.ItemsSource = UchPractikEntities1.GetContext().User.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                UchPractikEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                UserDG.ItemsSource = UchPractikEntities1.GetContext().User.ToList();
            }
        }
    }
}
