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
using System.IO;

namespace dicc
{
    /// <summary>
    /// Logika interakcji dla klasy dodajNotatke.xaml
    /// </summary>
    public partial class dodajNotatke : Page
    {
        String user;
        public dodajNotatke(String u)
        {
            InitializeComponent();
            user = u;
        }

        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            String tytul = title.Text;
            String s = cont.Text;
            title.Text = "";
            cont.Text = "";
            if (tytul == "" || s == "")
            {
                result.Text = "Fields cannot be empty";
            }
            else if ((string.IsNullOrEmpty(tytul)) || (string.IsNullOrEmpty(s)) || (string.IsNullOrWhiteSpace(tytul)) || (string.IsNullOrWhiteSpace(s)))
            {
                result.Text = "Fields cannot contain only spaces";
            }
            else 
            {
                if (user != "")
                {

                    if (File.Exists(user + ".txt"))
                    {
                        System.IO.StreamWriter file2 = new System.IO.StreamWriter(user + ".txt", append: true);
                        file2.WriteLine("\n"+tytul+"\n");
                        s = s.Replace("\n", " ");
                        s = s.Replace("\r", " ");
                        s = s.Replace("\t", " ");
                        file2.WriteLine(s);
                        file2.Close();
                        result.Text = "Note added successfully";
                    }
                    else
                    {
                        but.IsEnabled = false;
                        result.Text = "Something went wrong...";
                    }
                }
                else
                {
                    but.IsEnabled = false;
                    result.Text = "Something went wrong...";
                }
            }
        }
    }
}
