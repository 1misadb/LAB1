using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using LAB1.Models;

namespace LAB1.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        private readonly User _currentUser;
        private readonly Lab1Context _context = new();
        public ObservableCollection<Book> Books { get; set; }

        public MainWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;
            Books = new ObservableCollection<Book>(_context.Books.ToList());
            BooksGrid.ItemsSource = Books;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var window = new BookEditorWindow();
            if (window.ShowDialog() == true)
            {
                _context.Books.Add(window.Book);
                _context.SaveChanges();
                Books.Add(window.Book);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItem is Book book)
            {
                var window = new BookEditorWindow(book);
                if (window.ShowDialog() == true)
                {
                    _context.SaveChanges();
                    BooksGrid.Items.Refresh();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItem is Book book)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                Books.Remove(book);
            }
        }

        private void Issue_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItem is Book book && book.Status == "в наличии")
            {
                book.Status = "выдана";
                book.CurrentReaderId = _currentUser.UserId;
                _context.SaveChanges();
                BooksGrid.Items.Refresh();
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItem is Book book && book.CurrentReaderId == _currentUser.UserId)
            {
                book.Status = "в наличии";
                book.CurrentReaderId = null;
                _context.SaveChanges();
                BooksGrid.Items.Refresh();
            }
        }
    }
}
