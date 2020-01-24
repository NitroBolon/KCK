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
    /// Logika interakcji dla klasy Guest.xaml
    /// </summary>
    public partial class Guest : Window
    {
        List<String> dict1 = new List<string>();
        List<String> dict2 = new List<string>();
        string[] words;
        public Guest()
        {
            InitializeComponent();
            logo.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "logo.png")));
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("dic.txt");
            while ((line = file.ReadLine()) != null)
            {
                words = line.Split(' ');
                dict1.Add(words[0]);
                dict2.Add(words[1]);
            }
            file.Close();
        }

        private void Button_Click_close(object sender, RoutedEventArgs e)
        {
            MainWindow o = new MainWindow();
            o.Show();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void Button_Click_search(object sender, RoutedEventArgs e)
        {
            String wrd = word.Text;
            word.Text = "";
            wrd = wrd.ToLower();
            List<String> results = new List<string>();

            for(int i=0; i< dict1.Count; i++)
            {
                if (dict1[i] == wrd)
                {
                    results.Add(dict2[i]);
                }
            }
            for (int i = 0; i < dict2.Count; i++)
            {
                if (dict2[i] == wrd)
                {
                    results.Add(dict1[i]);
                }
            }
            if (results.Count > 0)
            {
                result.Text = "You are looking for translation of:\n" + wrd + "\n\nWe have found for you this translation:\n";
                result.Text += results[0];
                if (results.Count > 1)
                {
                    result.Text += "\n\nCheck also:\n";
                    for (int j = 1; j < results.Count; j++)
                    {
                        result.Text += results[j];
                        result.Text += "\n";
                    }
                }
                
            } else
            {
                result.Text = "We have not found anything for you :(";
            }
        }


        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();
        }

        private void word_TextChanged(object sender, TextChangedEventArgs e)
        {
            String wrd = word.Text;
            wrd = wrd.ToLower();
            List<int> res = new List<int>();
            result.Text = "";

            for (int i = 0; i < dict2.Count; i++)
            {
                if ((dict2[i].StartsWith(wrd) || dict2[i]==wrd || dict2[i].Contains(wrd)) && wrd!="" && !res.Contains(i))
                {
                    res.Add(i);
                }
            }
            for (int i = 0; i < dict2.Count; i++)
            {
                if ((dict1[i].StartsWith(wrd) || dict1[i] == wrd || dict2[i].Contains(wrd)) && wrd != "" && !res.Contains(i))
                {
                    res.Add(i);
                }
            }
            if (res.Count > 0)
            {
                result.Text += "You seem to look for:\n";

                for (int j = 0; j < res.Count; j++)
                {
                    if (dict1[res[j]].StartsWith(wrd))
                    {
                        result.Text += dict1[res[j]] + " - " + dict2[res[j]] + "\n";
                    } else
                    {
                        result.Text += dict2[res[j]] + " - " + dict1[res[j]] + "\n";
                    }
                }
            }
            else
            {
                result.Text = "We have not found anything for you :(";
            }
        }
    }
}
