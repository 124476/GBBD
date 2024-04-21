using GBBD.Models;
using GBBD.Windows;
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
    /// Логика взаимодействия для OknoVY.xaml
    /// </summary>
    public partial class OknoVY : Page
    {
        User contextUser;
        public OknoVY(User user)
        {
            InitializeComponent();
            contextUser = user;
            Refresh();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OknoNewVY(contextUser, null));
        }

        private void GotVY_Click(object sender, RoutedEventArgs e)
        {
            Ydovstvorenie ydovstvorenie = (sender as Button).DataContext as Ydovstvorenie;
            if (ydovstvorenie != null)
            {
                NavigationService.Navigate(new OknoNewVY(contextUser, ydovstvorenie));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            DataVY.ItemsSource = App.DB.Ydovstvorenie.Where(x => x.UserId == contextUser.Id).ToList();
        }

        private void CopyVy_Click(object sender, RoutedEventArgs e)
        {
            Ydovstvorenie ydovstvorenie = (sender as Button).DataContext as Ydovstvorenie;
            if (ydovstvorenie != null)
            {
                var dialog = new OknoVYCopy(ydovstvorenie);
                dialog.ShowDialog();
            }
        }
    }
}
