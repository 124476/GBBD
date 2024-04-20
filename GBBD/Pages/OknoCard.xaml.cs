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
    /// Логика взаимодействия для OknoCard.xaml
    /// </summary>
    public partial class OknoCard : Page
    {
        User contetxUser;
        public OknoCard(User user)
        {
            InitializeComponent();
            contetxUser = user;
            ComboCompanyes.ItemsSource = App.DB.Company.ToList();
            ComboJobs.ItemsSource = App.DB.Job.ToList();
            DataContext = contetxUser;
        }

        private void GotPhoto_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog() { Filter = "*.png;*.jpg; | *.png;*.jpg;" };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contetxUser.Photo = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contetxUser;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (contetxUser.Surname != null && contetxUser.Name != null && contetxUser.MiddleName != null
                && contetxUser.Email != null && contetxUser.Seria != null && contetxUser.AddLife != null
                && contetxUser.Address != null && ComboCompanyes.SelectedIndex != -1 && ComboJobs.SelectedIndex != -1
                && contetxUser.PostCode != null && contetxUser.Phone != null && contetxUser.Number != null)
            {
                if (!contetxUser.Email.Contains("@"))
                {
                    MessageBox.Show("Неправильная почта!");
                    return;
                }

                if (contetxUser.Id == 0)
                {
                    App.DB.User.Add(contetxUser);
                }
                contetxUser.Job = ComboJobs.SelectedItem as Job;
                contetxUser.Company = ComboCompanyes.SelectedItem as Company;
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
            else {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
