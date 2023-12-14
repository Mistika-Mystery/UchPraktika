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

        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Jornal());
           
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
          
        
            try
            {
                UchPractikEntities1.GetContext().SaveChanges();
        MessageBox.Show("Запись изменена!");
                NavigationService.Navigate(new Jornal());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
