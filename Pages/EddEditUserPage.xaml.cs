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
        Regex cifr = new Regex(@"^[0-9-]+$");
        MatchCollection match;
        public EddEditUserPage(User selectUser)
        {
            InitializeComponent();
            if (selectUser != null)
            {
                _user = selectUser;
            }
            DataContext = _user;
            RoleCB.ItemsSource=UchPractikEntities1.GetContext().Role.ToList();
            DepatCB.ItemsSource = UchPractikEntities1.GetContext().Departments.ToList();
            PositCB.ItemsSource = UchPractikEntities1.GetContext().Positions.ToList();
        } 

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersJornal());
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_user.Login))
                errors.AppendLine("Введите Логин");
            if (string.IsNullOrWhiteSpace(_user.Pass))
                errors.AppendLine("Введите Пароль");
            if (string.IsNullOrWhiteSpace(_user.Tel))
                errors.AppendLine("Введите Телефон");
            if (string.IsNullOrWhiteSpace(_user.Email))
                errors.AppendLine("Введите e-mail");
            if (string.IsNullOrWhiteSpace(_user.Name))
                errors.AppendLine("Введите Имя");
            if (string.IsNullOrWhiteSpace(_user.Surname))
                errors.AppendLine("Введите Фамилию");
            if (string.IsNullOrWhiteSpace(_user.FatherName))
                errors.AppendLine("Введите Отчество");
            if (_user.Role == null) errors.AppendLine("Выберите роль");
            if (_user.Departments == null) errors.AppendLine("Выберите подразделение");
            if (_user.Positions == null) errors.AppendLine("Выберите должность");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

        }
    }
}
