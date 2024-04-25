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
            App.dateNow = DateTime.Now;
            var dialog = new SaveFileDialog() { Filter = "*.jpeg; | *.jpeg;" };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                var renderBitmap = new RenderTargetBitmap((int)GridCopy.ActualWidth, (int)GridCopy.ActualHeight, 96, 96, PixelFormats.Pbgra32);
                renderBitmap.Render(GridCopy);
                var jpegEncoder = new JpegBitmapEncoder();
                jpegEncoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                using(var fileStream = new FileStream(dialog.FileName, FileMode.Create))
                {
                    jpegEncoder.Save(fileStream);
                }
            }
        }
    }
}
