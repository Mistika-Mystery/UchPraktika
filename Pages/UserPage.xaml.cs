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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            var allStatus = UchPractikEntities1.GetContext().Status.ToList();
            allStatus.Insert(0, new Status
            {
                NameStatus = "Любой Статус"
            });
            StatusCB.ItemsSource = allStatus;


        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                UchPractikEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

                var jPoisk = UchPractikEntities1.GetContext().Requests.ToList();
                jPoisk = jPoisk.Where(x => x.UserID == Flag.idUseri).ToList();
                JornalDG.ItemsSource = jPoisk;
            }
        }

        private void CreateBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewJornal());
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditJornal((sender as Button).DataContext as Requests));
        }

        private void LogBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GlavPage());
        }

        private void PoiskTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Seach_Filter();
        }
         
              
        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seach_Filter();
        }

        private void StatusCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Seach_Filter();
        }

        private void Seach_Filter()
        {
            var jPoisk = UchPractikEntities1.GetContext().Requests.ToList();

            

            jPoisk = jPoisk.Where(s => (s.Description ?? "").ToLower().Contains(PoiskTB.Text.ToLower())).ToList();

            if (Flag.idUseri !=0 )
            {
                jPoisk = jPoisk.Where(x => x.UserID == Flag.idUseri).ToList();
            }


            if (StatusCB.SelectedIndex != 0)
            {
                jPoisk = jPoisk.Where(x => x.Status == StatusCB.SelectedValue).ToList();
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
    }
}
