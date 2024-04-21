using GBBD.Models;
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
using System.Windows.Shapes;

namespace GBBD.Windows
{
    /// <summary>
    /// Логика взаимодействия для OknoVYCopy.xaml
    /// </summary>
    public partial class OknoVYCopy : Window
    {
        public OknoVYCopy(Ydovstvorenie ydovstvorenie)
        {
            InitializeComponent();
            DataContext = ydovstvorenie;
        }

        private void CopyBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new PrintDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                CopyBtn.Visibility = Visibility.Hidden;
                dialog.PrintVisual(GridCopy, "");
            }
        }
    }
}
