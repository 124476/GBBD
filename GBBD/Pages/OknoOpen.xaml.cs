using GBBD.Models;
using GBBD.Properties;
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
    /// Логика взаимодействия для OknoOpen.xaml
    /// </summary>
    public partial class OknoOpen : Page
    {
        int OpenTest;
        public OknoOpen()
        {
            InitializeComponent();
            OpenTest = 0;
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            if (Settings.Default.DateBlock + TimeSpan.FromMinutes(1) >= DateTime.Now)
            {
                MessageBox.Show("Ограничение по времени!");
                return;
            }
            Inspector inspector = App.DB.Inspector.FirstOrDefault(x => x.Login == Login.Text && x.Password == Password.Text);
            if (inspector != null)
            {
                NavigationService.Navigate(new OknoMain());
            }
            else
            {
                MessageBox.Show("Не верные данные!");
                OpenTest += 1;
                if (OpenTest == 3)
                {
                    Settings.Default.DateBlock = DateTime.Now;
                    Settings.Default.Save();
                    MessageBox.Show("Блокировка времени на минуту!");
                }
            }
        }
    }
}
