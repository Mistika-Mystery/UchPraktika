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
        List<User> currentTasks = UchPractikEntities1.GetContext().User.ToList();
        public UsersJornal()
        {
            InitializeComponent();
            

            var allDepartm = UchPractikEntities1.GetContext().Departments.ToList();
            allDepartm.Insert(0, new Departments
            {
                DepartmentName = "Все Подразделения"
            });
            DepartmantCB.ItemsSource = allDepartm;

            var allPosition = UchPractikEntities1.GetContext().Positions.ToList();
            allPosition.Insert(0, new Positions
            {
                PositionName = "Все Должности"
            });
            PositionCB.ItemsSource = allPosition;
            Seach_Filter();
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

        private void PoiskTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Seach_Filter();
        }
        private void DepartmantCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seach_Filter();
        }

        private void PositionCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seach_Filter();
        }

        private void Seach_Filter()
        {
            var UserPoisk = UchPractikEntities1.GetContext().User.ToList();

            
            UserPoisk = UserPoisk.Where(s => s.Name.ToLower().Contains(PoiskTB.Text.ToLower())
                || (s.Surname ?? "").ToLower().Contains(PoiskTB.Text.ToLower())
                || (s.FatherName ?? "").ToLower().Contains(PoiskTB.Text.ToLower())).ToList();
            
          
            if (DepartmantCB.SelectedIndex != 0)
            {
                UserPoisk = UserPoisk.Where(x => x.Departments == DepartmantCB.SelectedValue).ToList();
            }
           
            if (PositionCB.SelectedIndex !=0)
            {
                UserPoisk = UserPoisk.Where(p => p.Positions == PositionCB.SelectedValue).ToList();
            }

            UserDG.ItemsSource = UserPoisk;
        }


    }
}
