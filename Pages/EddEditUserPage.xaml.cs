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
        Regex name = new Regex(@"^[А-ЯЁ][А-ЯЁа-яё\s\-]{2,50}$");
        Regex cifr = new Regex(@"^\d{7}$|^\d{10}$");
        Regex email = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        Regex logg = new Regex(@"^[a-zA-Zа-яА-Я0-9]{1,50}$");
        MatchCollection match;
        public EddEditUserPage(User selectUser)
        {
            InitializeComponent();
            if (selectUser != null)
            {
                _user = selectUser;
            }
            DataContext = _user;
            RoleCB.ItemsSource = UchPractikEntities1.GetContext().Role.ToList();
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
            match = name.Matches(NameTB.Text);
            if (match.Count == 0) errors.AppendLine("Имя должно содержать только русские быквы! Первая буква должна быть Заглавной! Минимум 2 символа, максимум 50");
            match = name.Matches(SurnameTB.Text);
            if (match.Count == 0) errors.AppendLine("Фамилия должно содержать только русские быквы! Первая буква должна быть Заглавной! Минимум 2 символа, максимум 50");
            match = name.Matches(FathNameTB.Text);
            if (match.Count == 0) errors.AppendLine("Отчество должно содержать только русские быквы! Первая буква должна быть Заглавной! Минимум 2 символа, максимум 50");
            match = cifr.Matches(TelTB.Text);
            if (match.Count == 0) errors.AppendLine("Телефон может содержать только цифры! Количество цифв должно быть либо 7, либо 10!");
            match = logg.Matches(LoginTB.Text);
            if (match.Count == 0) errors.AppendLine("Логин может состоять толлько из букв и цифр! Минимум 1 символ, максимум 50");
            match = email.Matches(EmailTB.Text);
            if (match.Count == 0) errors.AppendLine("Почта должна содержать только латинские буквы! Знак @, и доменный адрес! Максимум 50 символов");
            match = logg.Matches(PassTB.Text);
            if (match.Count == 0) errors.AppendLine("Пароль может состоять толлько из букв и цифр! Минимум 1 символ, максимум 50");
            if (_user.DR == DateTime.Today || _user.DR > DateTime.Today || _user.DR == null || _user.DR < DRDP.DisplayDateStart)
            {
                errors.AppendLine("Неправильно введена дата рождения");

            }
            if (DRDP.SelectedDate > DateTime.Now.AddYears(-18) || DRDP.SelectedDate < DateTime.Now.AddYears(-99))
            {
                errors.AppendLine("Регистрироваться могут только люди страше 18 лет и младше 99");
            }

            if (errors.Length > 0)
            {
                    MessageBox.Show(errors.ToString());
                    return;
            }

            if (_user.UserID== 0)
            {
                
                var Email = UchPractikEntities1.GetContext().User.FirstOrDefault(x => x.Email == _user.Email.ToString());
                if (Email != null)
                {
                    errors.AppendLine("Этот email уже заригистрирован");
                }
                var Tel = UchPractikEntities1.GetContext().User.FirstOrDefault(x => x.Tel == _user.Tel.ToString());
                if (Tel != null)
                {
                    errors.AppendLine("Этот телефон уже заригистрирован");
                }
                var Log = UchPractikEntities1.GetContext().User.FirstOrDefault(x => x.Login == _user.Login.ToString());
                if (Log != null)
                {
                    errors.AppendLine("Такой логин уже существует, выберите другой");
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                UchPractikEntities1.GetContext().User.Add(_user);
            }
            try
            {
                UchPractikEntities1.GetContext().SaveChanges();
                MessageBox.Show("Пользователь успешно сохранен!");
                NavigationService.Navigate(new UsersJornal());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DRDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            DatePicker datePicker = (DatePicker)sender;

            if (datePicker.SelectedDate == DateTime.MinValue)
            {
                datePicker.SelectedDate = DateTime.Now;
            }

            
        }
    }
}
