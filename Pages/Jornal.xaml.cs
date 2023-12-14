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
            
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditJornal((sender as Button).DataContext as Requests));
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            var delReq = JornalDG.SelectedItems.Cast<Requests>().ToList();
            if (delReq.Count != 1) errors.AppendLine("Для удаления выберите только одного пользовател)");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить роль?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    UchPractikEntities1.GetContext().Requests.RemoveRange(delReq);
                    UchPractikEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Роль удалена!");
                    JornalDG.ItemsSource = UchPractikEntities1.GetContext().Role.ToList();

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
            NavigationService.Navigate(new AddEditJornal(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                UchPractikEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                JornalDG.ItemsSource = UchPractikEntities1.GetContext().Requests.ToList();
            }
        }
    }
}
