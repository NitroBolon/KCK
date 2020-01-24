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
    /// Logika interakcji dla klasy signUp.xaml
    /// </summary>
    public partial class signUp : Page
    {
        public signUp()
        {
            InitializeComponent();
        }

        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            String nazwa = nick.Text;
            String log = login.Text;
            String haslo = password.Password.ToString();
            String Phaslo = Cpassword.Password.ToString();
            List<String> lista = new List<string>();
            String line;
            String[] words;
            int flag = 0;

            System.IO.StreamReader file3 = new System.IO.StreamReader("users.txt");
            while ((line = file3.ReadLine()) != null)
            {
                words = line.Split(' ');
                lista.Add(words[0]);
            }
            file3.Close();

            if (nazwa == "" || log == "" || haslo == "" || Phaslo == "")
            {
                MessageBox.Show("Fields cannot be empty", "Dicc - new account create failure");
                password.Clear();
                Cpassword.Clear();
                flag = 1;
            }
            else if ((string.IsNullOrEmpty(nazwa)) || (string.IsNullOrEmpty(log)) || (string.IsNullOrWhiteSpace(haslo)) || (string.IsNullOrWhiteSpace(Phaslo)) || (string.IsNullOrEmpty(haslo)) || (string.IsNullOrEmpty(Phaslo)) || (string.IsNullOrWhiteSpace(nazwa)) || (string.IsNullOrWhiteSpace(log)) || nazwa.Contains(" ") || log.Contains(" ") || haslo.Contains(" ") || Phaslo.Contains(" "))
            {
                MessageBox.Show("Fields cannot contain spaces", "Dicc - new account create failure");
                password.Clear();
                Cpassword.Clear();
                login.Clear();
                nick.Clear();
                flag = 1;
            }
            else if(haslo != Phaslo)
            {
                MessageBox.Show("Password and its confirmation are different", "Dicc - new account create failure");
                password.Clear();
                Cpassword.Clear();
                flag = 2;
            }
            for(int i=0; i<lista.Count; i++)
            {
                if (lista[i] == log)
                {
                    MessageBox.Show("Login already exists in system", "Dicc - new account create failure");
                    password.Clear();
                    Cpassword.Clear();
                    flag = 3;
                }
            }

            if (flag == 0)
            {
                System.IO.StreamWriter file2 = new System.IO.StreamWriter("users.txt", append: true);
                nazwa = nazwa.Replace("\n", ""); nazwa = nazwa.Replace("\r", ""); nazwa = nazwa.Replace("\t", "");
                log = log.Replace("\r", "");     log = log.Replace("\n", "");     log = log.Replace("\t", "");
                haslo = haslo.Replace("\t", ""); haslo = haslo.Replace("\r", ""); haslo = haslo.Replace("\n", "");
                file2.WriteLine(log+" " +haslo+" "+nazwa);
                file2.Close();
                System.IO.StreamWriter file = new System.IO.StreamWriter(log+".txt");
                file.Close();

                Logged x = new Logged(log, nazwa);
                x.Show();
                Window parentWindow = Window.GetWindow(this);
                parentWindow.Close();
            }
                
        }
    }
}
