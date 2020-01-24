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
    /// Logika interakcji dla klasy zobaczNotatnik.xaml
    /// </summary>
    public partial class zobaczNotatnik : Page
    {
        String user;
        int flag = 0;
        public zobaczNotatnik(String u)
        {
            InitializeComponent();
            user = u;
            String line  = "";

            if (user != "")
            {

                if (File.Exists(user + ".txt"))
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(user + ".txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        cont.Text += line;
                        cont.Text += "\n";
                    }
                    file.Close();
                }
                else
                {
                    cont.Text = "Something went wrong...";
                }
            }
            else
            {
                cont.Text = "Something went wrong...";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (flag == 0)
            {
                but.Content = "Save";
                //odblokowanie
                cont.IsReadOnly = false;
                flag = 1;
            } else
            {
                but.Content = "Edit";
                //zapis
                cont.IsReadOnly = true;
                System.IO.StreamWriter file = new System.IO.StreamWriter(user + ".txt");
                List<String> lines = new List<string>();

                int lineCount = cont.LineCount;

                for (int line = 0; line < lineCount; line++)
                    lines.Add(cont.GetLineText(line));

                for (int i = 0; i < lines.Count; i++)
                    if(!(string.IsNullOrEmpty(lines[i])) && !(string.IsNullOrWhiteSpace(lines[i])))
                        file.WriteLine(lines[i]);

                flag = 0;
                file.Close();
            }
        }
    }
}
