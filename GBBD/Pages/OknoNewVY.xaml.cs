using GBBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
    /// Логика взаимодействия для OknoNewVY.xaml
    /// </summary>
    public partial class OknoNewVY : Page
    {
        Ydovstvorenie ydovstvorenie;
        User contextUser;
        public OknoNewVY(User user, Ydovstvorenie ydovstvoreni)
        {
            InitializeComponent();
            ComboStatus.ItemsSource = App.DB.VYStatus.ToList();
            if (ydovstvoreni == null)
            {
                ydovstvorenie = new Ydovstvorenie();
                StackComment.Visibility = Visibility.Hidden;
                HistoryBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                LicenceDate.IsEnabled = false;
                ExpireDate.IsEnabled = false;
                Categories.IsEnabled = false;
                LicenceNumber.IsEnabled = false;
                LicenceSeries.IsEnabled = false;
            }
            contextUser = user;
            ydovstvorenie = ydovstvoreni;
            DataContext = ydovstvorenie;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ydovstvorenie.LicenceNumber != null && ydovstvorenie.LicenceSeries != null 
                && ExpireDate.SelectedDate != null && LicenceDate.SelectedDate != null
                && ydovstvorenie.Categories != null)
            {
                ydovstvorenie.User = contextUser;
                if (ydovstvorenie.Id == 0)
                {
                    Ydovstvorenie ydovstvorenieLast = App.DB.Ydovstvorenie.FirstOrDefault(x => x.StatusId == 1 && x.UserId == contextUser.Id);
                    ydovstvorenieLast.StatusId = 3;
                    App.DB.Ydovstvorenie.Add(ydovstvorenie);
                }
                else
                {
                    HistoryStatus historyStatus = new HistoryStatus();
                    historyStatus.Ydovstvorenie = ydovstvorenie;
                    historyStatus.DateEnd = DateTime.Now;
                    historyStatus.Comment = Comment.Text;
                    historyStatus.StatusId = ydovstvorenie.StatusId;
                    HistoryStatus historyStatusLast = App.DB.HistoryStatus.FirstOrDefault(x => x.YdId == ydovstvorenie.Id);
                    if (historyStatusLast != null)
                    {
                        historyStatus.DateStart = historyStatusLast.DateEnd;
                    }
                    else
                    {
                        historyStatus.DateStart = ydovstvorenie.LicenceDate;
                    }
                    App.DB.HistoryStatus.Add(historyStatus);
                }
                ydovstvorenie.VYStatus = ComboStatus.SelectedItem as VYStatus;
                App.DB.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OknoHistory(ydovstvorenie));
        }
    }
}
