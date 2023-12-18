using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Логика взаимодействия для AddEditJornal.xaml
    /// </summary>
    public partial class AddEditJornal : Page
    {
        private Requests _req = new Requests();
      
        public AddEditJornal(Requests selecJornal)
        {
            InitializeComponent();
            if (selecJornal != null)
            {
                _req = selecJornal;
            }
            DataContext = _req;
            StatusCB.ItemsSource = UchPractikEntities1.GetContext().Status.ToList();
            if (_req.Img != null) ImgOshib.Source = new ImageSourceConverter().ConvertFrom(_req.Img) as ImageSource;
           
            if (Flag.role == 2) 
            { 
                SaveBTN.Visibility = Visibility.Hidden;
                tbst.Visibility = Visibility.Hidden;
                StatusCB.Visibility = Visibility.Hidden;
            }

        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (Flag.role == 1 || Flag.role ==6)
                NavigationService.Navigate(new Jornal());
            else if (Flag.role == 2) NavigationService.Navigate(new UserPage());
           
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
          
        
            try
            {
                UchPractikEntities1.GetContext().SaveChanges();
        MessageBox.Show("Запись изменена!");
                if (Flag.role == 1 || Flag.role == 6)
                    NavigationService.Navigate(new Jornal());
                else if (Flag.role == 2) NavigationService.Navigate(new UserPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
