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
    /// Логика взаимодействия для OknoNewCar.xaml
    /// </summary>
    public partial class OknoNewCar : Page
    {
        Car car;
        public OknoNewCar(User user)
        {
            InitializeComponent();
            car = new Car();
            car.User = user;
            DataContext = car;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            if (car.Number != null)
            {
                App.DB.Car.Add(car);
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Заполните все данные!");
            }
        }
    }
}
