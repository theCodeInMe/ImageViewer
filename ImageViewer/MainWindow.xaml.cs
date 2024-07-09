using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageViewer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] names = Enum.GetNames(typeof(Stretch));
            stretchMode.ItemsSource = names;
            stretchMode.SelectedIndex = 0;
        }

        private void openImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog auswahl = new OpenFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures),
                Filter = "Bilddateien |*.bmp;*.png;*.jpg"
            };

            if (auswahl.ShowDialog(this)==true)
            {
               Uri uri = new Uri(auswahl.FileName);
               BitmapImage image = new BitmapImage(uri);
               Bildanzeige.Source = image;
                
            };
        }

        private void selectStretchmode(object sender, SelectionChangedEventArgs e)
        {
            string value = (string)stretchMode.SelectedValue;
            Stretch stretchValue = (Stretch)Enum.Parse(typeof(Stretch), value);
            Bildanzeige.Stretch = stretchValue;
        }
    }
}
