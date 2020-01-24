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
using System.Windows.Shapes;

namespace dicc
{
    /// <summary>
    /// Logika interakcji dla klasy Logged.xaml
    /// </summary>
    
    public partial class Logged : Window
    {
        private String login;
        
        public Logged(String user, String nick)
        {
            InitializeComponent();
            logo.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "logo.png")));
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            label.Content = "Welcome to your account " + nick + "! Enjoy your time.";
            login = user;
        }

        private void Button_Click_check(object sender, RoutedEventArgs e)
        {
            subcontent.Content = new translacja();
        }
        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            subcontent.Content = new dodajTranslacje();
        }

        private void Button_Click_delete(object sender, RoutedEventArgs e)
        {
            subcontent.Content = new usunTranslacje();
        }

        private void Button_Click_new(object sender, RoutedEventArgs e)
        {
            subcontent.Content = new dodajNotatke(login);
        }

        private void Button_Click_view(object sender, RoutedEventArgs e)
        {
            subcontent.Content = new zobaczNotatnik(login);
        }

        private void Button_Click_logout(object sender, RoutedEventArgs e)
        {
            MainWindow o = new MainWindow();
            o.Show();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();
        }
    }
}
