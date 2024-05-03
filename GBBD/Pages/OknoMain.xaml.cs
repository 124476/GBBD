using GBBD.Models;
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

namespace GBBD.Pages
{
    /// <summary>
    /// Логика взаимодействия для OknoMain.xaml
    /// </summary>
    public partial class OknoMain : Page
    {
        public OknoMain()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            App.dateNow = DateTime.Now;
            DataUsers.ItemsSource = App.DB.User.ToList();
        }

        private void GotCard_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            User user = (sender as Button).DataContext as User;
            if (user != null)
            {
                NavigationService.Navigate(new OknoCard(user));
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            NavigationService.Navigate(new OknoCard(new User()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void GotVY_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            User user = (sender as Button).DataContext as User;
            if (user != null)
            {
                NavigationService.Navigate(new OknoVY(user));
            }
        }

        private void YDBtn_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            NavigationService.Navigate(new OknoAllYD());
        }

        private void CarsBtn_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            NavigationService.Navigate(new OknoCar());
        }

        private void CarsHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            NavigationService.Navigate(new OknoCarHistoryes());
        }
    }
}
