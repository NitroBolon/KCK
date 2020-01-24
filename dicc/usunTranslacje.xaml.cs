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
    /// Logika interakcji dla klasy usunTranslacje.xaml
    /// </summary>
    public partial class usunTranslacje : Page
    {
        List<String> dict1 = new List<string>();
        List<String> dict2 = new List<string>();
        string[] words;
        String line;
        public usunTranslacje()
        {
            InitializeComponent();
            System.IO.StreamReader file = new System.IO.StreamReader("dic.txt");
            while ((line = file.ReadLine()) != null)
            {
                words = line.Split(' ');
                dict1.Add(words[0]);
                dict2.Add(words[1]);
            }
            file.Close();
        }

        private void Button_Click_delete(object sender, RoutedEventArgs e)
        {
            String w1 = word.Text;
            String w2 = trans.Text;
            word.Text = "";
            trans.Text = "";
            int del = -1;
            for(int i=0; i<dict1.Count; i++)
            {
                if((dict1[i]==w1 && dict2[i]==w2) || (dict2[i] == w1 && dict1[i] == w2))
                {
                    del = i;
                }
            }

            if (del >= 0)
            {
                dict1.RemoveAt(del);
                dict2.RemoveAt(del);
                result.Text = "Word deleted successfully.";
                
                System.IO.StreamWriter file2 = new System.IO.StreamWriter("dic.txt");
                if (dict1.Count > 0)
                {
                    for (int i = 0; i < dict1.Count; i++)
                    {
                        file2.WriteLine(dict1[i] + " " + dict2[i]);
                    }
                }
                file2.Close();
            } else result.Text = "There is no such a combination";

        }
    }
}
