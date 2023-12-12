using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EddEditUserPage.xaml
    /// </summary>
    public partial class EddEditUserPage : Page
    {
        private User _user = new User();
        Regex name = new Regex(@"^[А-ЯЁ][А-ЯЁа-яё\s-]*$");
        MatchCollection match;
        public EddEditUserPage(User selectUser)
        {
            InitializeComponent();
            if (selectUser != null)
            {
                _user = selectUser;
            }
            DataContext = _user;
        } 

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersJornal());
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
