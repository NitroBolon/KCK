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
    /// Logika interakcji dla klasy dodajTranslacje.xaml
    /// </summary>
    public partial class dodajTranslacje : Page
    {
        List<String> dict1 = new List<string>();
        List<String> dict2 = new List<string>();
        string[] words;
        String line;
        public dodajTranslacje()
        {
            InitializeComponent();
            gif.Visibility = Visibility.Hidden;
            System.IO.StreamReader file = new System.IO.StreamReader("dic.txt");
            while ((line = file.ReadLine()) != null)
            {
                words = line.Split(' ');
                dict1.Add(words[0]);
                dict2.Add(words[1]);
            }
            file.Close();
        }

        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            String wrd = word.Text;
            String trs = transl.Text;
            word.Text = "";
            transl.Text = "";
            wrd = wrd.ToLower();
            trs = trs.ToLower();
            int flag = 0;

            for (int i = 0; i < dict1.Count; i++)
            {
                if ((dict2[i] == wrd && dict1[i]==trs) || (dict1[i] == wrd && dict2[i] == trs))
                {
                    flag = 1;
                }
            }

            if (wrd == "" || trs == "")
            {
                result.Text = "Type words in the brackets";
                gif.Visibility = Visibility.Hidden;
                flag = 2;
            }
            else if ((string.IsNullOrEmpty(wrd)) || (string.IsNullOrEmpty(trs)) || (string.IsNullOrWhiteSpace(wrd)) || (string.IsNullOrWhiteSpace(trs)) || trs.Contains(" ") || wrd.Contains(" "))
            {
                result.Text = "Words cannot contain spaces";
                gif.Visibility = Visibility.Hidden;
                flag = 2;
            }

            if (flag == 0)
            {
                result.Text = "Word added successfully!";
                dict1.Add(wrd);
                dict2.Add(trs);
                gif.Visibility = Visibility.Visible;
                System.IO.StreamWriter file2 = new System.IO.StreamWriter("dic.txt", append: true);
                file2.WriteLine(wrd + " " + trs);
                file2.Close();
            }
            else if(flag==1)
            {
                result.Text = "This combination already exists, you have nothing to do :D";
                gif.Visibility = Visibility.Hidden;
            }
        }
        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();
        }
    }
}
