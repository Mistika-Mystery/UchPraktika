﻿using System;
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
    /// Логика взаимодействия для GlavPage.xaml
    /// </summary>
    public partial class GlavPage : Page
    {
        public GlavPage()
        {
            InitializeComponent();
        }

        private void VhodBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userName = UchPractikEntities.GetContext().User.FirstOrDefault(x => x.Login == LoginTB.Text && x.Pass == PassTB.Password);
                if (userName == null)
                {

                   
                    MessageBox.Show("Похоже что вы не зарегистрированы, пожалуйста, обратитесь в тех.отдел для получения учетной вашей записи", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);

                }
              
                else
                {
                    switch (userName.RoleID)
                    {
                        case 2:
                            MessageBox.Show("Приветсвуем Вас, " + userName.Name + "!", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new UserPage());
                            break;

                        case 1:
                            MessageBox.Show("Приветсвуем Вас " + userName.Name + "!", "Вы вошли как соотрудник", MessageBoxButton.OK, MessageBoxImage.Information);

                            this.Content = null;
                            NavigationService.Navigate(new AdnimPage());

                            break;
                        default: MessageBox.Show("Не обнужерен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning); break;

                    }

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Нет данных" + Ex.Message.ToString() + "Критическая ошибка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
