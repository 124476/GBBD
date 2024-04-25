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
    /// Логика взаимодействия для OknoAllYD.xaml
    /// </summary>
    public partial class OknoAllYD : Page
    {
        public OknoAllYD()
        {
            InitializeComponent();
            Refresh();
        }

        private void DateEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            App.dateNow = DateTime.Now;
            DateTime? DateStar;
            DateTime? DateEn;
            if (DateStart.SelectedDate == null)
            {
                DateStart.SelectedDate = DateTime.Now.AddYears(-10);
            }
            DateStar = DateStart.SelectedDate;

            if (DateEnd.SelectedDate == null)
            {
                DateEnd.SelectedDate = DateTime.Now;
            }
            DateEn = DateEnd.SelectedDate;

            DataVY.ItemsSource = App.DB.Ydovstvorenie.Where(x => x.StatusId == 1 && DateStar <= x.LicenceDate && x.LicenceDate <= DateEn).ToList();
        }

        private void DateStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {
            App.dateNow = DateTime.Now;
            DateTime? DateStar;
            DateTime? DateEn;
            if (DateStart.SelectedDate == null)
            {
                DateStart.SelectedDate = DateTime.Now.AddYears(-10);
            }
            DateStar = DateStart.SelectedDate;

            if (DateEnd.SelectedDate == null)
            {
                DateEnd.SelectedDate = DateTime.Now;
            }
            DateEn = DateEnd.SelectedDate;

            var dialog = new SaveFileDialog() { Filter = "*.csv; | *.csv;" };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                var file = File.Create(dialog.FileName);
                file.Close();

                string text = "LicenceDate; ExpireDate;Categories;LicenceSeries;LicenceNumber";
                foreach (var item in App.DB.Ydovstvorenie.Where(x => x.StatusId == 1 && DateStar <= x.LicenceDate && x.LicenceDate <= DateEn).ToList())
                {
                    text += "\n" + item.LicenceDate.ToString() + ";" + item.ExpireDate.ToString() + ";" + item.Categories.ToString() + ";" + item.LicenceSeries.ToString() + ";" + item.LicenceNumber.ToString();
                }
                File.WriteAllText(dialog.FileName, text);
            }
        }
    }
}
