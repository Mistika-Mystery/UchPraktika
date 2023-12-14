using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UchPraktika.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewJornal.xaml
    /// </summary>
    public partial class NewJornal : Page
    {
        private Requests _req = new Requests();
        private byte[] data = null;
        public NewJornal()
        {
            InitializeComponent();
            DataContext = _req;
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Jornal());
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_req.Description))
                errors.AppendLine("Опишите проблему! Или позвоните по номеру: 666-999 !");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
         
            _req.RequestDate = DateTime.Now;
            _req.StatusID = 1;
            _req.UserID = Flag.idUseri;
            
            _req.Img = data;

            UchPractikEntities1.GetContext().Requests.Add(_req);

            try
            {
                UchPractikEntities1.GetContext().SaveChanges();
                MessageBox.Show("Заявка успешно создана!");
                NavigationService.Navigate(new Jornal());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void SelectImageBTN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Multiselect = false;
            fileOpen.Filter = "Image | *.png; *.jpg; *.jpeg";
            if (fileOpen.ShowDialog() == true)
            {
                data = System.IO.File.ReadAllBytes(fileOpen.FileName);
               
                ImageSerice.Source = new ImageSourceConverter().ConvertFrom(data) as ImageSource;
            }
        }
    }
}
