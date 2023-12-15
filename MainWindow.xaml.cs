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
using UchPraktika.Pages;

namespace UchPraktika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FramMain.Navigate(new GlavPage());
            //FramMain.Navigate(new UsersJornal());
            //FramMain.Navigate(new NewJornal());
            if (Flag.idUseri == 0)
            {
                InfoTB.Visibility = Visibility.Hidden;
            }
            else if (Flag.idUseri != 0)
            {
                InfoTB.Visibility = Visibility.Visible;
                PosicInfoTB.Text = Flag.NameFL;
            }
        }

        

        private void FramMain_ContentRendered(object sender, EventArgs e)
        {
         
        }
    }
}
