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

            
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (Flag.role == 1 || Flag.role == 6)
                NavigationService.Navigate(new Jornal());
            else if (Flag.role == 2 ) NavigationService.Navigate(new UserPage());
        }

        
    }
}
