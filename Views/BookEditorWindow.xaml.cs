using System;
using System.Windows;
using System.Windows.Controls;
using LAB1.Models;

namespace LAB1.Views
{
    public partial class BookEditorWindow : Window
    {
        public Book Book { get; private set; }

        public BookEditorWindow()
        {
            InitializeComponent();
            Book = new Book { ReleaseDate = DateOnly.FromDateTime(DateTime.Today), Status = "в наличии" };
        }

        public BookEditorWindow(Book book)
        {
            InitializeComponent();
            Book = book;
            ArticleBox.Text = Book.Article;
            TitleBox.Text = Book.Title;
            GenreBox.Text = Book.Genre;
            DescriptionBox.Text = Book.Description;
            ReleaseDatePicker.SelectedDate = Book.ReleaseDate.ToDateTime(TimeOnly.MinValue);
            StatusBox.Text = Book.Status;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Book.Article = ArticleBox.Text;
            Book.Title = TitleBox.Text;
            Book.Genre = GenreBox.Text;
            Book.Description = DescriptionBox.Text;
            if (ReleaseDatePicker.SelectedDate.HasValue)
                Book.ReleaseDate = DateOnly.FromDateTime(ReleaseDatePicker.SelectedDate.Value);
            Book.Status = (StatusBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "в наличии";
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
