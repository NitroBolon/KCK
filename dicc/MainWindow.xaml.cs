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

namespace dicc
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int x = 0;
        public MainWindow()
        {
            InitializeComponent();
            logo.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "banner.png")));
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void guest(object sender, RoutedEventArgs e)
        {
            Guest o = new Guest();
            o.Show();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void login(object sender, RoutedEventArgs e)
        {
            authMethod.Content = new signIn();
        }

        private void create(object sender, RoutedEventArgs e)
        {
            authMethod.Content = new signUp();
        }

        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();
        }
    }
}
