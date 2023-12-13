using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
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
    /// Логика взаимодействия для AddEditRole.xaml
    /// </summary>
    public partial class AddEditRole : Page
    {
        private Role _role = new Role();
        Regex nazvania = new Regex(@"^[А-ЯЁ][а-яё\s]*$");
        MatchCollection match;
        public AddEditRole(Role selectRole)
        {
            InitializeComponent();
            if (selectRole != null)
            {
                _role = selectRole;
            }
            DataContext = _role;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoleJornal());
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors= new StringBuilder();
            if (string.IsNullOrWhiteSpace(_role.RoleName))errors.AppendLine("Укажите название роли!");
            match=nazvania.Matches(NameTB.Text);
            if (match.Count == 0) errors.AppendLine("Название должно содержать только русские быквы! Первая буква должна быть Заглавной!");
            var Roll = UchPractikEntities1.GetContext().Role.FirstOrDefault(x => x.RoleName == _role.RoleName.ToString());
            if (Roll != null)
            {
                errors.AppendLine("Такая роль уже существует, выберите другую");
            }


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_role.RileID==0)
            {
                UchPractikEntities1.GetContext().Role.Add(_role);
            }
            try
            {
                UchPractikEntities1.GetContext().SaveChanges();
                MessageBox.Show("Роль успешно сохранена!");
                NavigationService.Navigate(new RoleJornal());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
