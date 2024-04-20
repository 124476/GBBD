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
    /// Логика взаимодействия для OknoShtraf.xaml
    /// </summary>
    public partial class OknoShtraf : Page
    {
        Car contextCar;
        public OknoShtraf(Car car)
        {
            InitializeComponent();
            contextCar = car;
            Refresh();
        }

        private void Refresh()
        {
            DataShrafts.ItemsSource = App.DB.Shtraf.Where(x => x.Car.Id == contextCar.Id).ToList();
        }

        private void ShtrafDel_Click(object sender, RoutedEventArgs e)
        {
            Shtraf shtraf = (sender as Button).DataContext as Shtraf;
            if (shtraf != null)
            {
                App.DB.Shtraf.Remove(shtraf);
                App.DB.SaveChanges();
                Refresh();
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OknoNewShtraf(contextCar));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
