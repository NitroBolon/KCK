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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dicc
{
    /// <summary>
    /// Logika interakcji dla klasy signIn.xaml
    /// </summary>
    public partial class signIn : Page
    {
        public signIn()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            String log = login.Text;
            String pas = password.Password.ToString();
            List<String> users = new List<String>();
            List<String> passwords = new List<String>();
            List<String> nicknames = new List<String>();
            try
            {
                string line;
                string[] words;
                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader("users.txt");
                while ((line = file.ReadLine()) != null)
                {
                    words = line.Split(' ');
                    users.Add(words[0]); 
                    passwords.Add(words[1]);
                    nicknames.Add(words[2]);

                }
                file.Close();
            }
            catch
            {
                MessageBox.Show("Something went wrong...");
            }
            String login1 = "";
            try
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i] == log && passwords[i] == pas)
                    {
                        login1 = log;

                        Logged x = new Logged(login1, nicknames[i]);
                        x.Show();
                        Window parentWindow = Window.GetWindow(this);
                        parentWindow.Close();
                    }
                }
                if (login1 == "")
                {
                    MessageBox.Show("User not found, or wrong login/password", "Dicc - login failure");
                    password.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong...");
            }
            
        }
    }
}
