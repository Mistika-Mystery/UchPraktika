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
    /// Логика взаимодействия для InfoLogPage.xaml
    /// </summary>
    public partial class InfoLogPage : Page
    {
       
        public InfoLogPage()
        {
            InitializeComponent();

            var jPoisk = UchPractikEntities1.GetContext().User.ToList();



            if (Flag.idUseri != 0)
            {
                jPoisk = jPoisk.Where(x => x.UserID == Flag.idUseri).ToList();

            }
            DataContext= jPoisk;

            RoleCB.ItemsSource = UchPractikEntities1.GetContext().Role.ToList();
            DepatCB.ItemsSource = UchPractikEntities1.GetContext().Departments.ToList();
            PositCB.ItemsSource = UchPractikEntities1.GetContext().Positions.ToList();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DRDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
