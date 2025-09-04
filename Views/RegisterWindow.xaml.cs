using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using LAB1.Models;

namespace LAB1.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Page
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            using var db = new Lab1Context();
            if (db.Users.Any(u => u.LoginName == LoginBox.Text))
            {
                MessageBox.Show("Логин уже существует");
                return;
            }
            var user = new User
            {
                LoginName = LoginBox.Text,
                Password = PasswordBox.Password,
                FullName = FullNameBox.Text,
                Phone = string.IsNullOrWhiteSpace(PhoneBox.Text) ? null : PhoneBox.Text,
                RegisteredOn = DateOnly.FromDateTime(DateTime.Now)
            };
            db.Users.Add(user);
            db.SaveChanges();
            MessageBox.Show("Пользователь создан");
            NavigationService?.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
