using GBBD.Models;
using GBBD.Windows;
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
using Color = GBBD.Models.Color;

namespace GBBD.Pages
{
    /// <summary>
    /// Логика взаимодействия для OknoNewCar.xaml
    /// </summary>
    public partial class OknoNewCar : Page
    {
        Car car;
        Car carLast;
        User user;
        int rotateRot;
        public OknoNewCar(Car contextCar)
        {
            InitializeComponent();
            if (contextCar.Id != 0)
            {
                carLast = contextCar;
                user = App.DB.User.FirstOrDefault(x => x.Id == contextCar.UserId);
            }
            car = contextCar;
            
            DataContext = car;
            ComboManufacts.ItemsSource = App.DB.Manufact.ToList();
            ComboEngineTypes.ItemsSource = App.DB.EngineType.ToList();
            ComboColors.ItemsSource = App.DB.Color.ToList();
            ComboTypeOfDrives.ItemsSource = App.DB.TypeOfDrive.ToList();
            ComboModels.ItemsSource = App.DB.ModelCar.ToList();
            ComboUsers.ItemsSource = App.DB.User.ToList();
            car.Number = GotNumber();
            DataContext = car;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            if (car.VIN != null && car.MaxSila != null && car.Moch != null 
                && car.MochHorse != null && ComboColors.SelectedIndex != -1 && ComboEngineTypes.SelectedIndex != -1
                && ComboManufacts.SelectedIndex != -1 && ComboTypeOfDrives.SelectedIndex != -1 && car.Year != null
                && car.Weight != null && ComboModels.SelectedIndex != -1 && ComboUsers.SelectedIndex != -1)
            {
                if (App.DB.Car.FirstOrDefault(x => x.VIN == car.VIN) != null && !(car.Id != 0 && car.VIN == carLast.VIN))
                {
                    MessageBox.Show("Данный VIN уже используется!");
                    return;
                }
                car.ModelCar = ComboModels.SelectedItem as ModelCar;
                car.Manufact = ComboManufacts.SelectedItem as Manufact;
                car.Color = ComboColors.SelectedItem as Color;
                car.EngineType = ComboEngineTypes.SelectedItem as EngineType;
                car.TypeOfDrive = ComboTypeOfDrives.SelectedItem as TypeOfDrive;
                car.User = ComboUsers.SelectedItem as User;
                if (car.Id == 0)
                {
                    App.DB.Car.Add(car);
                }
                else
                {
                    CarHistory carHistory = new CarHistory();
                    carHistory.CarId = car.Id;
                    carHistory.User = user;
                    carHistory.Comment = car.Comment;
                    carHistory.Date = DateTime.Now;
                    App.DB.CarHistory.Add(carHistory);
                }
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Заполните все данные!");
            }
        }

        private void PoiskText_TextChanged(object sender, TextChangedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            User user = App.DB.User.ToList().FirstOrDefault(x => x.FullName.ToLower().Contains(PoiskText.Text.ToLower()));
            if (user != null && !string.IsNullOrEmpty(PoiskText.Text))
            {
                ComboUsers.SelectedItem = user;
                TextDate.Text = user.DateBorn.ToString();
                NewUser.Visibility = Visibility.Hidden;
                ComboUsers.ItemsSource = App.DB.User.ToList().Where(x => x.FullName.ToLower().Contains(PoiskText.Text.ToLower())).ToList();
            }
            else
            {
                ComboUsers.SelectedIndex = -1;
                TextDate.Text = "";
                NewUser.Visibility = Visibility.Visible;
            }
        }

        private void GotPhoto_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            var dialog = new OpenFileDialog() { Filter = "*.png; | *.png;" };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                car.Photo = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = car;
            }
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OknoCard(new User()));
        }

        private string GotNumber()
        {
            App.dateNow = DateTime.Now;
            string num;
            while (true)
            {
                num = "";
                Random random = new Random();
                num += (char)random.Next('A', 'Z' + 1);
                num += random.Next(0, 10).ToString();
                num += random.Next(0, 10).ToString();
                num += random.Next(0, 10).ToString();
                num += (char)random.Next('A', 'Z' + 1);
                num += (char)random.Next('A', 'Z' + 1);
                Car car = App.DB.Car.FirstOrDefault(x => x.Number == num);
                if (car == null) break;
            }
            return num;
        }

        private void NewNumber_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            car.Number = GotNumber();
            DataContext = null;
            DataContext = car;
        }

        private void PoiskColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            Color color = App.DB.Color.FirstOrDefault(x => x.Name.ToLower().Contains(PoiskColor.Text.ToLower()));
            if (color != null)
            {
                ComboColors.SelectedItem = color;
            }
        }

        private void GotColor_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            var dialog = new OknoColor();
            var result = dialog.ShowDialog().GetValueOrDefault();
            if (result)
            {
                ComboColors.SelectedItem = App.color;
            }
        }

        private void RotatePhoto_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            if (car.Photo != null)
            {
                rotateRot += 45;
                RotateTransform rotateTransform = new RotateTransform()
                {
                    CenterX = 50,
                    CenterY = 25
                };
                rotateTransform.Angle = rotateRot;
                PhotoCar.RenderTransform = rotateTransform;
            }
        }
    }
}
