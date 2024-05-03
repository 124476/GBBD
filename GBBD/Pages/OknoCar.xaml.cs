using GBBD.Models;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GBBD.Pages
{
    /// <summary>
    /// Логика взаимодействия для OknoCar.xaml
    /// </summary>
    public partial class OknoCar : Page
    {
        public OknoCar()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            App.dateNow = DateTime.Now;
            DataCars.ItemsSource = App.DB.Car.ToList();
        }

        private void GotShtraf_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            Car car = (sender as Button).DataContext as Car;
            if (car != null)
            {
                NavigationService.Navigate(new OknoShtraf(car));
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            NavigationService.Navigate(new OknoNewCar(new Car()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void CarDel_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            Car car = (sender as Button).DataContext as Car;
            if (car != null)
            {
                foreach (var item in App.DB.Shtraf.Where(x => x.Car.Id == car.Id))
                {
                    App.DB.Shtraf.Remove(item);
                }
                App.DB.Car.Remove(car);
                App.DB.SaveChanges();
                Refresh();
            }
        }

        private void SetShtraf_Click(object sender, RoutedEventArgs e)
        {
            Car car = (sender as Button).DataContext as Car;
            User user = App.DB.User.FirstOrDefault(x => x.Id == car.UserId);

            App.dateNow = DateTime.Now;
            var dialog = new SaveFileDialog() { Filter="*.csv; | *.csv;"};
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                FileInfo fileInfo = new FileInfo(dialog.FileName);

                using (StreamWriter sw = fileInfo.CreateText())
                {
                    sw.WriteLine("LicenceNum;Region;CreatedDate");
                    foreach (var oneCar in App.DB.Car.Where(x => x.User.Id == user.Id))
                    {
                        foreach (var shtraf in App.DB.Shtraf.Where(x => x.Car.Id == oneCar.Id).Where(x => x.StatusId == 1))
                        {
                            sw.WriteLine(shtraf.LicenceNum + ";" + shtraf.Region + ";" + shtraf.CreatedDate.Value.ToShortDateString());
                        }
                    }
                    sw.Close();
                }

                App.DB.SaveChanges();
            }
        }

        private void SetUser_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            Car car = (sender as Button).DataContext as Car;
            if (car != null)
            {
                NavigationService.Navigate(new OknoNewCar(car));
            }
        }
    }
}
