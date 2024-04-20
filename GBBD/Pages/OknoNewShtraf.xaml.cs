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
    /// Логика взаимодействия для OknoNewShtraf.xaml
    /// </summary>
    public partial class OknoNewShtraf : Page
    {
       Shtraf shtraf;
       public OknoNewShtraf(Car car)
        {
            InitializeComponent();
            shtraf = new Shtraf();
            shtraf.Car = car;
            DataContext = shtraf;
        }

        private void GotPhoto_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                shtraf.Photo = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = shtraf;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (shtraf.LicenceNum != null && shtraf.Photo != null && shtraf.Region != null)
            {
                shtraf.StatusId = 1;
                shtraf.CreatedDate = DateTime.Now;
                App.DB.Shtraf.Add(shtraf);
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
