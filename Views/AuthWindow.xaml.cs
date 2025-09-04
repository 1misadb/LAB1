using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using LAB1.Models;

namespace LAB1.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Page
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            using var db = new Lab1Context();
            var user = db.Users.FirstOrDefault(u => u.LoginName == LoginBox.Text && u.Password == PasswordBox.Password);
            if (user != null)
            {
                NavigationService?.Navigate(new MainWindow(user));
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RegisterWindow());
        }
    }
}
