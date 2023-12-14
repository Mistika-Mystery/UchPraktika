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
      

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditJornal((sender as Button).DataContext as Requests));
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            var delReq = JornalDG.SelectedItems.Cast<Requests>().ToList();
            if (delReq.Count != 1) errors.AppendLine("Для удаления выберите только одну запись!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить Заявку?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    UchPractikEntities1.GetContext().Requests.RemoveRange(delReq);
                    UchPractikEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Заявка удалена!");
                    JornalDG.ItemsSource = UchPractikEntities1.GetContext().Requests.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
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
            NavigationService.Navigate(new NewJornal());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                UchPractikEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                JornalDG.ItemsSource = UchPractikEntities1.GetContext().Requests.ToList();
            }
        }

        private void DepartmantCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seach_Filter();
        }

        private void PositionCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seach_Filter();
        }

        private void PoiskTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Seach_Filter();
        }

        private void Seach_Filter()
        {
            var jPoisk = UchPractikEntities1.GetContext().Requests.ToList();


            jPoisk = jPoisk.Where(s => s.User.Name.ToLower().Contains(PoiskTB.Text.ToLower())
                || (s.User.Surname ?? "").ToLower().Contains(PoiskTB.Text.ToLower())
                || (s.Description ?? "").ToLower().Contains(PoiskTB.Text.ToLower())
                || (s.User.FatherName ?? "").ToLower().Contains(PoiskTB.Text.ToLower())).ToList();


            if (DepartmantCB.SelectedIndex != 0)
            {
                jPoisk = jPoisk.Where(x => x.User.Departments == DepartmantCB.SelectedValue).ToList();
            }

            if (PositionCB.SelectedIndex != 0)
            {
                jPoisk = jPoisk.Where(p => p.User.Positions == PositionCB.SelectedValue).ToList();
            }


            switch (SortBox.SelectedIndex)
            {

                case 1:
                    jPoisk = jPoisk.OrderBy(s => s.RequestDate).ToList();
                    break;
                case 2:
                    jPoisk = jPoisk.OrderByDescending(s => s.RequestDate).ToList();

                    break;
            }

                    JornalDG.ItemsSource = jPoisk;
        }

        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seach_Filter();
        }
    }
}
